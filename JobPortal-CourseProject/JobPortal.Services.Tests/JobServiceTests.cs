namespace JobPortal.Services.Tests
{
    using JobPortal.Data;
    using JobPortal.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Sevices.Data;
    using Web.ViewModels.Job;

    public class JobServiceTests
    {
        private DbContextOptions<JobPortalDbContext> dbOptions;
        private JobPortalDbContext dbContext;
        private JobService jobService;

        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<JobPortalDbContext>()
                .UseInMemoryDatabase("JobPortalInMemory" + Guid.NewGuid())
                .Options;

            dbContext = new JobPortalDbContext(dbOptions);
            
            dbContext.Database.EnsureCreated();
            jobService = new JobService(dbContext);
        }
        
        [Test]
        public async Task CreateAndReturnIdAsyncShouldCreateJobAndReturnId()
        {
            const string employerId = "aa294071-5c7d-4f4c-8451-42fac506957c";
            var model = new JobAddFormModel
            {
               Title = "Some Title",
               Description = "Lorem ipsum dolor sit amet, consetetur sadipscing",
               Requirements = "Lorem ipsum dolor sit amet, consetetur sadipscing ",
               Salary = 2000,
               CategoryId = 2
            };

            var result = await jobService.CreateAndReturnIdAsync(employerId, model);
            
            Assert.That(result, Is.Not.Null);
        }
        
        [Test]
        public async Task JobExistsByIdAsyncShouldReturnTrueWhenExists()
        {
            var existingJob = await dbContext.Jobs.FirstOrDefaultAsync();
        
            var result = await jobService.ExistsByIdAsync(existingJob?.Id.ToString()!);
        
            Assert.That(result, Is.True);
        }
        
        [Test]
        public async Task JobExistsByIdAsyncShouldReturnFalseWhenNotExists()
        {
            const string notExistingJobId = "74e320b2-3a2d-4407-a56e-7de3bc781f64";
        
            var result = await jobService.ExistsByIdAsync(notExistingJobId);
        
            Assert.That(result, Is.False);
        }
        
        [Test]
        public async Task GetJobForEditByIdAsyncShouldReturnJobInfo()
        {
            var existingJob = await dbContext.Jobs.FirstOrDefaultAsync();

            var result = await jobService.GetJobForEditByIdAsync(existingJob?.Id.ToString()!);
            
            Assert.Multiple(() =>
            {
                Assert.That(result.Title, Is.EqualTo(existingJob?.Title));
                Assert.That(result.Description, Is.EqualTo(existingJob?.Description));
                Assert.That(result.Requirements, Is.EqualTo(existingJob?.Requirements));
                Assert.That(result.Salary, Is.EqualTo(existingJob?.Salary));
                Assert.That(result.CategoryId, Is.EqualTo(existingJob?.CategoryId));
            });
        }
        
        [Test]
        public async Task EditJobByIdAsyncShouldSetNewValues()
        {
            var existingJob = await dbContext.Jobs.FirstOrDefaultAsync();

            var model = new JobAddFormModel
            {
                Title = "Some Title",
                Description = "Lorem ipsum dolor sit amet, consetetur sadipscing",
                Requirements = "Lorem ipsum dolor sit amet, consetetur sadipscing ",
                Salary = 2000,
                CategoryId = 2
            };
            
            await jobService.EditJobById(existingJob?.Id.ToString()!, model);
            
            Assert.Multiple(() =>
            {
                Assert.That(existingJob?.Title, Is.EqualTo(model.Title));
                Assert.That(existingJob?.Description, Is.EqualTo(model.Description));
                Assert.That(existingJob?.Requirements, Is.EqualTo(model.Requirements));
                Assert.That(existingJob?.Salary, Is.EqualTo(model.Salary));
                Assert.That(existingJob?.CategoryId, Is.EqualTo(model.CategoryId));
            });
        }

        [Test]
        public async Task DeleteJobByIdAsyncShouldSetDeletedOnValue()
        {
            var existingJob = await dbContext.Jobs.FirstOrDefaultAsync();

            await jobService.DeleteJobByIdAsync(existingJob?.Id.ToString()!);
            
            Assert.That(existingJob?.DeletedOn, Is.Not.Null);
        }
        
        [Test]
        public async Task ApplicationExistsAsyncShouldReturnTrueWhenExists()
        {
            var user = new ApplicationUser
            {
                Id = Guid.Parse("9fd4a332-1e0e-4e07-8011-d32c19d8c3e0"),
                Email = "someUser@test.com",
                UserName = "someUser@test.com",
                NormalizedUserName = "someUser@test.com",
                NormalizedEmail = "someUser@test.com",
                SecurityStamp = "714393af-a207-4356-aac2-c75b13315a96",
                FirstName = "Test",
                LastName = "User"
            };
            
            await dbContext.Users.AddAsync(user);
            var job = await dbContext.Jobs.FirstAsync();
            
            var model = new UserJobs
            {
                CandidateId = user.Id,
                JobId = job.Id,
                FilePath = "Some/Path"
            };
            job.Candidates.Add(model);
            await dbContext.SaveChangesAsync();
            
            var result = await jobService.ApplicationExistsAsync(job.Id.ToString(), user.Id.ToString());

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ApplicationExistsAsyncShouldReturnFalseWhenNotExists()
        {
            var jobId = Guid.NewGuid().ToString();
            var candidateId = Guid.NewGuid().ToString();
            
            var result = await jobService.ApplicationExistsAsync(jobId, candidateId);

            Assert.That(result, Is.False);
        }
        
        [Test]
        public async Task GetCvPathAsyncShouldReturnPath()
        {
            var user = new ApplicationUser
            {
                Id = Guid.Parse("9fd4a332-1e0e-4e07-8011-d32c19d8c3e0"),
                Email = "someUser@test.com",
                UserName = "someUser@test.com",
                NormalizedUserName = "someUser@test.com",
                NormalizedEmail = "someUser@test.com",
                SecurityStamp = "714393af-a207-4356-aac2-c75b13315a96",
                FirstName = "Test",
                LastName = "User"
            };
            
            await dbContext.Users.AddAsync(user);
            var job = await dbContext.Jobs.FirstAsync();
            
            var model = new UserJobs
            {
                CandidateId = user.Id,
                JobId = job.Id,
                FilePath = "Some/Path"
            };
            job.Candidates.Add(model);
            await dbContext.SaveChangesAsync();
            
            var result = await jobService.GetCvPathAsync(job.Id.ToString(), user.Id.ToString());

            Assert.That(result, Is.EqualTo(model.FilePath));
        }
        
        [Test]
        public async Task GetAllJobsAsyncShouldReturnJobs()
        {
            var result = await jobService.GetAllJobsAsync(new JobsQueryModel());

            Assert.That(result, Is.Not.Null);
        }
        
        [Test]
        public async Task GetJobDetailsByIdAsyncShouldReturnJob()
        {
            var job = await dbContext.Jobs.FirstAsync();
            
            var result = await jobService.GetJobDetailsByIdAsync(job.Id.ToString());

            Assert.That(result, Is.Not.Null);
        }
    }
}