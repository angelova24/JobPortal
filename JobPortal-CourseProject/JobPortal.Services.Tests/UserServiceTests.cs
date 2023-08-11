namespace JobPortal.Services.Tests
{
    using JobPortal.Data;
    using JobPortal.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Sevices.Data;

    public class UserServiceTests
    {
        private DbContextOptions<JobPortalDbContext> dbOptions;
        private JobPortalDbContext dbContext;
        private UserService userService;

        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<JobPortalDbContext>()
                .UseInMemoryDatabase("JobPortalInMemory" + Guid.NewGuid())
                .Options;

            dbContext = new JobPortalDbContext(dbOptions);
            
            dbContext.Database.EnsureCreated();
            userService = new UserService(dbContext);
        }
        
        [Test]
        public async Task ApplyForJobAsyncShouldCreateApplication()
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
        
            await userService.ApplyForJobAsync(user.Id.ToString(), job.Id.ToString(), "Some/Path");

            var result =
                await dbContext.UserJobs.FirstOrDefaultAsync(uj => uj.JobId == job.Id && uj.CandidateId == user.Id);
            
            Assert.That(result, Is.Not.Null);
        }
        
        [Test]
        public async Task GetFullNameByEmailAsyncShouldReturnFullName()
        {
            var user = await dbContext.Users.FirstAsync();

            var result = await userService.GetFullNameByEmailAsync(user.Email);

            Assert.That(result, Is.EqualTo(user.FirstName + " " + user.LastName));
        }
        
        [Test]
        public async Task GetAllAsyncShouldReturnUsers()
        {
            var result = await userService.GetAllAsync();

            Assert.That(result, Is.Not.Null);
        }
    }
}