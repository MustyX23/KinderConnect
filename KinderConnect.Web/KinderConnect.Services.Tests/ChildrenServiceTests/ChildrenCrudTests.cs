using KinderConnect.Data;
using KinderConnect.Data.Models;
using KinderConnect.Services.Data;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Child;
using KinderConnect.Web.ViewModels.Classroom;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace KinderConnect.Services.Tests.ChildrenServiceTests
{
    [TestFixture]
    public class ChildrenCrudTests
    {
        private DbContextOptions<KinderConnectDbContext> options;
        private KinderConnectDbContext dbContext;
        private IChildService childService;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<KinderConnectDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            dbContext = new KinderConnectDbContext(options);
            childService = new ChildService(dbContext);

            // Seed data
            dbContext.Children.AddRange(new[]
            {
                new Child { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), FirstName = "John", LastName = "Doe", Gender = "Male", DateOfBirth = DateTime.Parse("2019-01-01"), Age = 3, ImageUrl = "image1.jpg", IsActive = true, ParentGuardianId = Guid.Parse("22222222-2222-2222-2222-222222222222"),ParentGuardianContact="1234567899" },
                new Child { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), FirstName = "Jane", LastName = "Doe", Gender = "Female", DateOfBirth = DateTime.Parse("2018-01-01"), Age = 4, ImageUrl = "image2.jpg", IsActive = true, ParentGuardianId = Guid.Parse("22222222-2222-2222-2222-222222222222"),ParentGuardianContact="1234567899" }
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
        public async Task EditChildByIdAsync_ShouldEditChild()
        {
            // Arrange
            var formModel = new EditChildFormModel
            {
                FirstName = "UpdatedJohn",
                LastName = "UpdatedDoe",
                Gender = "Male",
                DateOfBirth = "2019-01-01",
                Allergies = "Allergy Info",
                MedicalInformation = "Medical Info",
                ImageUrl = "updatedImage.jpg"
            };

            // Act
            await childService.EditChildByIdAsync("11111111-1111-1111-1111-111111111111", formModel);

            // Assert
            var updatedChild = await dbContext.Children.FindAsync(Guid.Parse("11111111-1111-1111-1111-111111111111"));
            Assert.AreEqual("UpdatedJohn", updatedChild.FirstName);
            Assert.AreEqual("UpdatedDoe", updatedChild.LastName);
            Assert.AreEqual("Male", updatedChild.Gender);
            Assert.AreEqual("Allergy Info", updatedChild.Allergies);
            Assert.AreEqual("Medical Info", updatedChild.MedicalInformation);
            Assert.AreEqual("updatedImage.jpg", updatedChild.ImageUrl);
        }

        [Test]
        public async Task JoinChildToClassroomAsync_ShouldAddChildToClassroom()
        {
            // Arrange
            var model = new JoinClassroomFormModel
            {
                FirstName = "Child",
                LastName = "New",
                DateOfBirth = DateTime.Parse("2020-01-01"),
                Allergies = "Allergy Info",
                MedicalInformation = "Medical Info",
                ClassroomId = "33333333-3333-3333-3333-333333333333",
                ImageUrl = "newImage.jpg",
                Gender = "Female",
                ParentGuardianContact = "+1234567890"
            };
            var parentGuardianId = "22222222-2222-2222-2222-222222222222";

            // Act
            await childService.JoinChildToClassroomAsync(model, parentGuardianId);

            // Assert
            var addedChild = await dbContext.Children.FirstAsync(c => c.FirstName == model.FirstName && c.LastName == model.LastName);
            Assert.IsNotNull(addedChild);
            Assert.AreEqual(Guid.Parse("33333333-3333-3333-3333-333333333333"), addedChild.ClassroomId);
        }

        [Test]
        public async Task JoinChildToClassroomByIdAsync_ShouldJoinChildToClassroom()
        {
            // Arrange
            var classroomId = "33333333-3333-3333-3333-333333333333";
            var childId = "11111111-1111-1111-1111-111111111111";
            var parentGuardianId = "22222222-2222-2222-2222-222222222222";

            // Act
            await childService.JoinChildToClassroomByIdAsync(classroomId, childId, parentGuardianId);

            // Assert
            var joinedChild = await dbContext.Children.FindAsync(Guid.Parse(childId));
            Assert.IsNotNull(joinedChild);
            Assert.AreEqual(Guid.Parse(classroomId), joinedChild.ClassroomId);
        }

        [Test]
        public async Task LeaveClassroomByChildIdAsync_ShouldRemoveChildFromClassroom()
        {
            // Arrange
            var childId = "11111111-1111-1111-1111-111111111111";

            // Act
            await childService.LeaveClassroomByChildIdAsync(childId);

            // Assert
            var leftChild = await dbContext.Children.FindAsync(Guid.Parse(childId));
            Assert.IsNotNull(leftChild);
            Assert.IsNull(leftChild.ClassroomId);
        }
    }
}
