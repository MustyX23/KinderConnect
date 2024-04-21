using KinderConnect.Data;
using KinderConnect.Data.Models;
using KinderConnect.Services.Data;
using KinderConnect.Web.ViewModels.Activity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace KinderConnect.Services.Tests.ActivityServiceTests
{
    [TestFixture]
    public class ActivityTests
    {
        private KinderConnectDbContext _dbContext;
        private ActivityService _activityService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<KinderConnectDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _dbContext = new KinderConnectDbContext(options);
            _activityService = new ActivityService(_dbContext);
        }

        [Test]
        public async Task CreateAsync_ShouldAddNewActivity()
        {
            // Arrange
            var model = new ActivityFormModel { Name = "Test Activity", Description = "Test Description" };

            // Act
            await _activityService.CreateAsync(model);

            // Assert
            Assert.AreEqual(1, _dbContext.Activities.Count());
            var activity = _dbContext.Activities.First();
            Assert.AreEqual(model.Name, activity.Name);
            Assert.AreEqual(model.Description, activity.Description);
        }

        [Test]
        public async Task EditByIdAsync_ShouldUpdateActivity()
        {
            // Arrange
            var activity = new Activity { IsActive = true, Name = "Test Activity", Description = "Test Description" };
            _dbContext.Activities.Add(activity);
            await _dbContext.SaveChangesAsync();

            var model = new ActivityFormModel { Name = "Updated Activity", Description = "Updated Description" };

            // Act
            await _activityService.EditByIdAsync(activity.Id, model);

            // Assert
            var updatedActivity = await _dbContext.Activities.FindAsync(activity.Id);
            Assert.AreEqual(model.Name, updatedActivity.Name);
            Assert.AreEqual(model.Description, updatedActivity.Description);
        }

        [Test]
        public async Task GetActivityForEditByIdAsync_ShouldReturnCorrectFormModel()
        {
            // Arrange
            var activity = new Activity { IsActive = true, Name = "Test Activity", Description = "Test Description" };
            _dbContext.Activities.Add(activity);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _activityService.GetActivityForEditByIdAsync(activity.Id);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(activity.Name, result.Name);
            Assert.AreEqual(activity.Description, result.Description);
        }

        [Test]
        public async Task GetAllActivitiesAsync_ShouldReturnAllActivities()
        {
            // Arrange
            var activity1 = new Activity { IsActive = true, Name = "Test Activity 1", Description = "Test Description 1" };
            var activity2 = new Activity { IsActive = true, Name = "Test Activity 2", Description = "Test Description 2" };
            _dbContext.Activities.AddRange(activity1, activity2);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _activityService.GetAllActivitiesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetThreeActivitiesAsync_ShouldReturnThreeActivities()
        {
            // Arrange
            var activity1 = new Activity { IsActive = true, Name = "Test Activity 1", Description = "Test Description 1" };
            var activity2 = new Activity { IsActive = true, Name = "Test Activity 2", Description = "Test Description 2" };
            var activity3 = new Activity { IsActive = true, Name = "Test Activity 3", Description = "Test Description 3" };
            var activity4 = new Activity { IsActive = true, Name = "Test Activity 4", Description = "Test Description 4" };
            _dbContext.Activities.AddRange(activity1, activity2, activity3, activity4);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _activityService.GetThreeActivitiesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public async Task SoftRemoveByIdAsync_ShouldSetIsActiveToFalse()
        {
            // Arrange
            var activity = new Activity { IsActive = true, Name = "Test Activity", Description = "Test Description" };
            _dbContext.Activities.Add(activity);
            await _dbContext.SaveChangesAsync();

            // Act
            await _activityService.SoftRemoveByIdAsync(activity.Id);

            // Assert
            var updatedActivity = await _dbContext.Activities.FindAsync(activity.Id);
            Assert.IsFalse(updatedActivity.IsActive);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
        }
    }
}
