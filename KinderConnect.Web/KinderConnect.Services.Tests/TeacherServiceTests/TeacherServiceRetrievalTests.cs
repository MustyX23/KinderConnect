using KinderConnect.Data.Models;
using KinderConnect.Data;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Services.Data;
using KinderConnect.Web.ViewModels.Teacher.Enums;
using KinderConnect.Web.Views.Teacher;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace KinderConnect.Services.Tests.TeacherServiceTests
{
    [TestFixture]
    public class TeacherServiceRetrievalTests
    {
        private DbContextOptions<KinderConnectDbContext> options;
        private KinderConnectDbContext dbContext;
        private ITeacherService teacherService;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<KinderConnectDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            dbContext = new KinderConnectDbContext(options);
            teacherService = new TeacherService(dbContext);

            // Seed data
            dbContext.Teachers.AddRange(new[]
            {
                new Teacher { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), TeacherUserId = Guid.Parse("11111111-1111-1111-1111-111111111111"), ImageUrl = "image1.jpg", QualificationId = 1, Summary="Test Summary 1" },
                new Teacher { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), TeacherUserId = Guid.Parse("22222222-2222-2222-2222-222222222222"), ImageUrl = "image2.jpg", QualificationId = 2, Summary="Test Summary 2" }
            });

            dbContext.Users.AddRange(new[]
            {
                new ApplicationUser { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), FirstName = "John", LastName = "Doe", DateOfBirth = DateTime.Parse("1990-01-01"), IsActive = true, PhoneNumber = "1234567890", Email = "john.doe@example.com", Gender = "male" },
                new ApplicationUser { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), FirstName = "Jane", LastName = "Doe", DateOfBirth = DateTime.Parse("1991-01-01"), IsActive = true, PhoneNumber = "0987654321", Email = "jane.doe@example.com", Gender = "female" }
            });

            dbContext.Qualifications.AddRange(new[]
            {
                new Qualification { Id = 1, Name = "B.Sc", Description = "Test Description" },
                new Qualification { Id = 2, Name = "M.Sc", Description = "Test Description" }
            });

            dbContext.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Test]
        public async Task AllAsync_ShouldReturnAllTeachers()
        {
            // Arrange
            var queryModel = new AllTeachersQueryModel
            {
                CurrentPage = 1,
                TeachersPerPage = 10
            };

            // Act
            var result = await teacherService.AllAsync(queryModel);

            // Assert
            Assert.AreEqual(2, result.TotalTeachers);
            Assert.AreEqual(2, result.Teachers.Count());
        }

        [Test]
        public async Task AllAsync_ShouldReturnTeachersFilteredBySearchString()
        {
            // Arrange
            var queryModel = new AllTeachersQueryModel
            {
                CurrentPage = 1,
                TeachersPerPage = 10,
                SearchString = "john"
            };

            // Act
            var result = await teacherService.AllAsync(queryModel);

            // Assert
            Assert.AreEqual(1, result.TotalTeachers);
            Assert.AreEqual("John", result.Teachers.First().FirstName);
        }

        [Test]
        public async Task AllAsync_ShouldReturnTeachersSortedByFirstNameAZ()
        {
            // Arrange
            var queryModel = new AllTeachersQueryModel
            {
                CurrentPage = 1,
                TeachersPerPage = 10,
                TeacherSorting = TeacherSorting.ByFirstNameAZ
            };

            // Act
            var result = await teacherService.AllAsync(queryModel);

            // Assert
            Assert.AreEqual("Jane", result.Teachers.First().FirstName);
            Assert.AreEqual("John", result.Teachers.Last().FirstName);
        }

        [Test]
        public async Task AllAsync_ShouldReturnTeachersSortedByFirstNameZA()
        {
            // Arrange
            var queryModel = new AllTeachersQueryModel
            {
                CurrentPage = 1,
                TeachersPerPage = 10,
                TeacherSorting = TeacherSorting.ByFirstNameZA
            };

            // Act
            var result = await teacherService.AllAsync(queryModel);

            // Assert
            Assert.AreEqual("John", result.Teachers.First().FirstName);
            Assert.AreEqual("Jane", result.Teachers.Last().FirstName);
        }
        [Test]
        public async Task AllAsync_ShouldReturnTeachersSortedByLastNameAZ()
        {
            // Arrange
            var queryModel = new AllTeachersQueryModel
            {
                CurrentPage = 1,
                TeachersPerPage = 10,
                TeacherSorting = TeacherSorting.ByLastNameAZ
            };

            // Act
            var result = await teacherService.AllAsync(queryModel);

            // Assert
            Assert.AreEqual("Doe", result.Teachers.First().LastName);
            Assert.AreEqual("Doe", result.Teachers.Last().LastName);
        }

        [Test]
        public async Task AllAsync_ShouldReturnTeachersSortedByLastNameZA()
        {
            // Arrange
            var queryModel = new AllTeachersQueryModel
            {
                CurrentPage = 1,
                TeachersPerPage = 10,
                TeacherSorting = TeacherSorting.ByLastNameZA
            };

            // Act
            var result = await teacherService.AllAsync(queryModel);

            // Assert
            Assert.AreEqual("Doe", result.Teachers.First().LastName);
            Assert.AreEqual("Doe", result.Teachers.Last().LastName);
        }

        [Test]
        public async Task AllAsync_ShouldReturnCorrectPageOfTeachers()
        {
            // Arrange
            var queryModel = new AllTeachersQueryModel
            {
                CurrentPage = 2,
                TeachersPerPage = 1
            };

            // Act
            var result = await teacherService.AllAsync(queryModel);

            // Assert
            Assert.AreEqual(2, result.TotalTeachers);
            Assert.AreEqual(1, result.Teachers.Count());
            Assert.AreEqual("John", result.Teachers.First().FirstName);
        }

        [Test]
        public async Task AllAsync_ShouldReturnEmptyListForInvalidPage()
        {
            // Arrange
            var queryModel = new AllTeachersQueryModel
            {
                CurrentPage = 3,
                TeachersPerPage = 2
            };

            // Act
            var result = await teacherService.AllAsync(queryModel);

            // Assert
            Assert.AreEqual(2, result.TotalTeachers);
            Assert.AreEqual(0, result.Teachers.Count());
        }

        [Test]
        public async Task AllAsync_ShouldReturnTeachersWithQualification()
        {
            // Arrange
            var queryModel = new AllTeachersQueryModel
            {
                CurrentPage = 1,
                TeachersPerPage = 10
            };

            // Act
            var result = await teacherService.AllAsync(queryModel);

            // Assert
            Assert.AreEqual("M.Sc", result.Teachers.First().Qualification);
            Assert.AreEqual("B.Sc", result.Teachers.Last().Qualification);
        }
    }
}
