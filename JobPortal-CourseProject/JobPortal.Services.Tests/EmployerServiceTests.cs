namespace JobPortal.Services.Tests
{
    using JobPortal.Data;
    using Microsoft.EntityFrameworkCore;
    using Sevices.Data;
    using Web.ViewModels.Employer;

    public class EmployerServiceTests
    {
        private DbContextOptions<JobPortalDbContext> dbOptions;
        private JobPortalDbContext dbContext;
        private EmployerService employerService;

        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<JobPortalDbContext>()
                .UseInMemoryDatabase("JobPortalInMemory" + Guid.NewGuid())
                .Options;

            dbContext = new JobPortalDbContext(dbOptions);
            
            dbContext.Database.EnsureCreated();
            employerService = new EmployerService(dbContext);
        }
        
        [Test]
        public async Task CreateAsyncShouldCreateEmployer()
        {
            const string userId = "b190aaff-30ce-484b-be69-01403d97cb8c";
            var model = new BecomeEmployerFormModel
            {
                CompanyName = "Company Name",
                CompanyAddress = "Sofia",
                PhoneNumber = "0888888888"
            };

            await employerService.CreateAsync(userId, model);
            {
                var employer = dbContext.Employers.SingleOrDefault(e => e.UserId.ToString() == userId);
                Assert.That(employer, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(employer?.CompanyName, Is.EqualTo("Company Name"));
                    Assert.That(employer?.CompanyAddress, Is.EqualTo("Sofia"));
                    Assert.That(employer?.PhoneNumber, Is.EqualTo("0888888888"));
                });
            }
        }

        [Test]
        public async Task EmployerExistsByPhoneNumberAsyncShouldReturnTrueWhenExists()
        {
            const string existingEmployerPhoneNumber = "+359888888888";
        
            var result = await employerService.EmployerExistsByPhoneNumberAsync(existingEmployerPhoneNumber);
        
            Assert.That(result, Is.True);
        }
        
        [Test]
        public async Task EmployerExistsByPhoneNumberAsyncShouldReturnFalseWhenNotExists()
        {
            const string notExistingEmployerPhoneNumber = "8888888888";
        
            var result = await employerService.EmployerExistsByPhoneNumberAsync(notExistingEmployerPhoneNumber);
        
            Assert.That(result, Is.False);
        }
        
        [Test]
        public async Task EmployerExistsByUserIdAsyncShouldReturnTrueWhenExists()
        {
            const string existingEmployerUserId = "262a41ba-3ef1-4fe8-94b2-7f3b2fa6f855";

            var result = await employerService.EmployerExistsByUserIdAsync(existingEmployerUserId);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task EmployerExistsByUserIdAsyncShouldReturnFalseWhenNotExists()
        {
            const string notExistingEmployerUserId = "9f4c4410-c6b4-4a20-9ff3-c15f3caf9ea8";

            var result = await employerService.EmployerExistsByUserIdAsync(notExistingEmployerUserId);

            Assert.That(result, Is.False);
        }
        
        [Test]
        public async Task GetEmployerIdByUserIdAsyncShouldReturnEmployerId()
        {
            const string existingEmployerUserId = "262a41ba-3ef1-4fe8-94b2-7f3b2fa6f855";

            var employerId = await employerService.GetEmployerIdByUserIdAsync(existingEmployerUserId);

            Assert.That(employerId, Is.Not.Null);
            Assert.That(employerId, Is.EqualTo("aa294071-5c7d-4f4c-8451-42fac506957c"));
        }
        
        [Test]
        public async Task IsAuthorOfJobByUserIdAsyncShouldReturnTrueWhenIsAuthor()
        {
            const string existingEmployerUserId = "262a41ba-3ef1-4fe8-94b2-7f3b2fa6f855";
            var job = dbContext.Jobs.FirstOrDefault(j => j.Employer.UserId.ToString() == existingEmployerUserId);

            var result = await employerService.IsAuthorOfJobByUserIdAsync(existingEmployerUserId, job?.Id.ToString()!);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsAuthorOfJobByUserIdAsyncShouldReturnFalseWhenIsNotAuthor()
        {
            const string existingEmployerUserId = "262a41ba-3ef1-4fe8-94b2-7f3b2fa6f855";
            const string notExistingJobId = "218a34f4-70e2-4a8b-88dd-c467b39b49ad";
            
            var result = await employerService.IsAuthorOfJobByUserIdAsync(existingEmployerUserId, notExistingJobId);

            Assert.That(result, Is.False);
        }
    }
}