using KinderConnect.Data;
using KinderConnect.Data.Models;
using KinderConnect.Services.Data;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Classroom;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace KinderConnect.Services.Tests.ClassroomServiceTests
{
    [TestFixture]
    public class ClassroomCrudTests
    {
        private KinderConnectDbContext _dbContext;
        private IClassroomService _classroomService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<KinderConnectDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _dbContext = new KinderConnectDbContext(options);
            _classroomService = new ClassroomService(_dbContext);
        }

        [Test]
        public async Task CreateAsync_ShouldAddNewClassroom()
        {
            // Arrange
            var model = new CreateClassroomFormModel
            {
                Name = "Test Classroom",
                Information = "Info",
                ImageUrl = "https://example.com/image.jpg",
                MinimumAge = 5,
                MaximumAge = 10,
                TotalSeats = 30,
                TutionFee = 1000
            };

            // Act
            await _classroomService.CreateAsync(model);

            // Assert
            Assert.AreEqual(1, _dbContext.Classrooms.Count());
            var classroom = _dbContext.Classrooms.First();
            Assert.AreEqual(model.Name, classroom.Name);
            Assert.AreEqual(model.Information, classroom.Information);
            Assert.AreEqual(model.ImageUrl, classroom.ImageUrl);
            Assert.AreEqual(model.MinimumAge, classroom.MinimumAge);
            Assert.AreEqual(model.MaximumAge, classroom.MaximumAge);
            Assert.AreEqual(model.TotalSeats, classroom.TotalSeats);
            Assert.AreEqual(model.TutionFee, classroom.TutionFee);
        }
        [Test]
        public async Task IncreaseTotalSeatsByIdAsync_ShouldIncreaseTotalSeats()
        {
            // Arrange
            var classroom = new Classroom { IsActive = true, Name = "Test Classroom", Information = "Info", CreatedOn = DateTime.Now, ImageUrl = "https://example.com/image.jpg", TotalSeats = 30 };
            _dbContext.Classrooms.Add(classroom);
            await _dbContext.SaveChangesAsync();

            // Act
            await _classroomService.IncreaseTotalSeatsByIdAsync(classroom.Id.ToString());

            // Assert
            var updatedClassroom = await _dbContext.Classrooms.FindAsync(classroom.Id);
            Assert.AreEqual(31, updatedClassroom.TotalSeats);
        }

        [Test]
        public async Task DecreaseTotalSeatsByIdAsync_ShouldDecreaseTotalSeats()
        {
            // Arrange
            var classroom = new Classroom { IsActive = true, Name = "Test Classroom", Information = "Info", CreatedOn = DateTime.Now, ImageUrl = "https://example.com/image.jpg", TotalSeats = 30 };
            _dbContext.Classrooms.Add(classroom);
            await _dbContext.SaveChangesAsync();

            // Act
            await _classroomService.DecreaseTotalSeatsByIdAsync(classroom.Id.ToString());

            // Assert
            var updatedClassroom = await _dbContext.Classrooms.FindAsync(classroom.Id);
            Assert.AreEqual(29, updatedClassroom.TotalSeats);
        }

        [Test]
        public async Task EditAsync_ShouldUpdateClassroom()
        {
            // Arrange
            var classroom = new Classroom { IsActive = true, Name = "Test Classroom", Information = "Info", CreatedOn = DateTime.Now, ImageUrl = "https://example.com/image.jpg", TotalSeats = 30 };
            _dbContext.Classrooms.Add(classroom);
            await _dbContext.SaveChangesAsync();

            var formModel = new EditClassroomFormModel { Name = "Updated Classroom", Information = "Updated Info", ImageUrl = "https://example.com/updated_image.jpg", MinimumAge = 6, MaximumAge = 12, TutionFee = 2000 };

            // Act
            await _classroomService.EditAsync(classroom.Id.ToString(), formModel);

            // Assert
            var updatedClassroom = await _dbContext.Classrooms.FindAsync(classroom.Id);
            Assert.AreEqual(formModel.Name, updatedClassroom.Name);
            Assert.AreEqual(formModel.Information, updatedClassroom.Information);
            Assert.AreEqual(formModel.ImageUrl, updatedClassroom.ImageUrl);
            Assert.AreEqual(formModel.MinimumAge, updatedClassroom.MinimumAge);
            Assert.AreEqual(formModel.MaximumAge, updatedClassroom.MaximumAge);
            Assert.AreEqual(formModel.TutionFee, updatedClassroom.TutionFee);
        }

        [Test]
        public async Task SoftRemoveClassroomByIdAsync_ShouldSetIsActiveToFalse()
        {
            // Arrange
            var classroom = new Classroom { IsActive = true, Name = "Test Classroom", Information = "Info", CreatedOn = DateTime.Now, ImageUrl = "https://example.com/image.jpg", TotalSeats = 30 };
            _dbContext.Classrooms.Add(classroom);
            await _dbContext.SaveChangesAsync();

            // Act
            await _classroomService.SoftRemoveClassroomByIdAsync(classroom.Id.ToString());

            // Assert
            var updatedClassroom = await _dbContext.Classrooms.FindAsync(classroom.Id);
            Assert.IsFalse(updatedClassroom.IsActive);
        }
        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
        }
    }
}
