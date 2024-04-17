using KinderConnect.Data;
using KinderConnect.Data.Models;
using KinderConnect.Services.Data;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Classroom;
using KinderConnect.Web.ViewModels.Classroom.Enums;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace KinderConnect.Services.Tests.ClassroomServiceTests
{
    [TestFixture]
    public class ClassroomRetrevalTests
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

            _dbContext.Classrooms.Add(new Classroom { IsActive = true, Name = "Test Classroom 1", Information = "Info 1", CreatedOn = DateTime.Now, ImageUrl = "https://example.com/image1.jpg" });
            _dbContext.Classrooms.Add(new Classroom { IsActive = true, Name = "Test Classroom 2", Information = "Info 2", CreatedOn = DateTime.Now, ImageUrl = "https://example.com/image2.jpg" });
            _dbContext.SaveChanges();
        }

        [Test]
        public async Task AllAsync_ShouldFilterResults_WhenSearchStringIsSet()
        {
            // Arrange
            var queryModel = new AllClassroomsQueryModel { SearchString = "Test Classroom 1" };

            // Act
            var result = await _classroomService.AllAsync(queryModel);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.TotalClasses);
            Assert.AreEqual("Test Classroom 1", result.Classes.First().Name);
        }
        [Test]
        public async Task AllAsync_ShouldReturnCorrectModel_WhenSearchStringIsSet()
        {
            // Arrange
            var queryModel = new AllClassroomsQueryModel { SearchString = "Test Classroom 1" };

            // Act
            var result = await _classroomService.AllAsync(queryModel);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.TotalClasses);
            Assert.AreEqual("Test Classroom 1", result.Classes.First().Name);
        }

        [Test]
        public async Task AllAsync_ShouldSortByNewest_WhenClassroomSortingIsNewest()
        {
            // Arrange
            var queryModel = new AllClassroomsQueryModel { ClassroomSorting = ClassroomSorting.Newest };

            // Act
            var result = await _classroomService.AllAsync(queryModel);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.TotalClasses);
            Assert.AreEqual("Test Classroom 2", result.Classes.First().Name);
        }

        [Test]
        public async Task AllAsync_ShouldSortByOldest_WhenClassroomSortingIsOldest()
        {
            // Arrange
            var queryModel = new AllClassroomsQueryModel { ClassroomSorting = ClassroomSorting.Oldest };

            // Act
            var result = await _classroomService.AllAsync(queryModel);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.TotalClasses);
            Assert.AreEqual("Test Classroom 1", result.Classes.First().Name);
        }

        [Test]
        public async Task AllAsync_ShouldReturnPagedResults_WhenCurrentPageAndClassesPerPageAreSet()
        {
            // Arrange
            var queryModel = new AllClassroomsQueryModel { CurrentPage = 1, ClassesPerPage = 1 };

            // Act
            var result = await _classroomService.AllAsync(queryModel);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.Classes.Count());
        }
        [Test]
        public async Task GetAllClassroomsAsync_ShouldReturnAllClassrooms()
        {
            // Act
            var result = await _classroomService.GetAllClassroomsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count());
        }
        [Test]
        public async Task GetLeaveClassroomViewModelByChildIdAsync_ShouldReturnCorrectViewModel()
        {
            // Arrange
            var parentGuardian = new ApplicationUser {Id = Guid.Parse("60016eff-694a-4efa-a0eb-68702f0a1132"), FirstName="Jon'sFather", LastName="Snow", Email="jonsfather@gmail.com", Gender ="male", DateOfBirth =DateTime.Parse("17.04.1998 00:00") };
            var classroom = new Classroom { IsActive = true, Name = "Test Classroom", Information = "Info", CreatedOn = DateTime.Now, ImageUrl = "https://example.com/image.jpg", TotalSeats = 30 };
            _dbContext.Classrooms.Add(classroom);
            await _dbContext.SaveChangesAsync();

            var child = new Child { IsActive = true, FirstName = "John",LastName="Snow",Gender="male", ParentGuardianContact="12345678999", DateOfBirth=DateTime.Parse("17/04/2020 00:00"),Age = 5, ImageUrl= "https://example.com/image.jpg", ParentGuardianId=Guid.Parse("60016eff-694a-4efa-a0eb-68702f0a1132"), ClassroomId = classroom.Id };
            _dbContext.Children.Add(child);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _classroomService.GetLeaveClassroomViewModelByChildIdAsync(child.Id.ToString());

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(child.Id.ToString(), result.Id);
            Assert.AreEqual(child.FirstName, result.ChildFirstName);
            Assert.AreEqual(classroom.Name, result.Name);
            Assert.AreEqual(classroom.ImageUrl, result.ImageUrl);
        }

        [Test]
        public async Task GetJoinClassroomViewModelAsync_ShouldReturnCorrectViewModel()
        {
            // Arrange
            var classroom = new Classroom { IsActive = true, Name = "Test Classroom", Information = "Info", CreatedOn = DateTime.Now, ImageUrl = "https://example.com/image.jpg", TotalSeats = 30 };
            _dbContext.Classrooms.Add(classroom);
            await _dbContext.SaveChangesAsync();

            var child = new Child { IsActive = true, FirstName = "John", LastName = "Doe", DateOfBirth = DateTime.Now, Allergies = "None", ParentGuardianContact = "1234567890", Gender = "Male", ImageUrl = "https://example.com/child_image.jpg", MedicalInformation = "None" };
            _dbContext.Children.Add(child);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _classroomService.GetJoinClassroomViewModelAsync(classroom.Id.ToString(), child.Id.ToString());

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(classroom.Name, result.Classroom.ClassroomName);
            Assert.AreEqual(child.FirstName, result.Child.FirstName);
        }

        [Test]
        public async Task GetJoinClassroomByChildViewModelByIdAsync_ShouldReturnCorrectViewModel()
        {
            // Arrange
            var classroom = new Classroom { IsActive = true, Name = "Test Classroom", Information = "Info", CreatedOn = DateTime.Now, ImageUrl = "https://example.com/image.jpg", TotalSeats = 30 };
            _dbContext.Classrooms.Add(classroom);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _classroomService.GetJoinClassroomByChildViewModelByIdAsync(classroom.Id.ToString());

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(classroom.Id.ToString(), result.Id);
            Assert.AreEqual(classroom.Name, result.Name);
            Assert.AreEqual(classroom.ImageUrl, result.ImageUrl);
        }

        [Test]
        public async Task GetJoinClassroomFormModelByIdAsync_ShouldReturnCorrectFormModel()
        {
            // Arrange
            var classroom = new Classroom { IsActive = true, Name = "Test Classroom", Information = "Info", CreatedOn = DateTime.Now, ImageUrl = "https://example.com/image.jpg", TotalSeats = 30 };
            _dbContext.Classrooms.Add(classroom);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _classroomService.GetJoinClassroomFormModelByIdAsync(classroom.Id.ToString());

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(classroom.Id.ToString(), result.ClassroomId);
            Assert.AreEqual(classroom.Name, result.ClassroomName);
            Assert.AreEqual(classroom.ImageUrl, result.ClassroomImageUrl);
        }
        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
        }
    }
}
