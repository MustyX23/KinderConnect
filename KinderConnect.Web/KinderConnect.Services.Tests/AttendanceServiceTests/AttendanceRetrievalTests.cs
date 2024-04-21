using KinderConnect.Data;
using KinderConnect.Data.Models;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Services.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinderConnect.Services.Tests.AttendanceServiceTests
{
    public class AttendanceRetrievalTests
    {
        private KinderConnectDbContext dbContext;
        private AttendanceService attendanceService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<KinderConnectDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            dbContext = new KinderConnectDbContext(options);
            attendanceService = new AttendanceService(dbContext);
        }        

        [Test]
        public async Task GetClassroomIdByAttendancyIdAsync_ShouldReturnClassroomId()
        {
            // Arrange
            var classroom = new Classroom { IsActive = true, Name = "Test Classroom", Information = "Info", CreatedOn = DateTime.Now, ImageUrl = "https://example.com/image.jpg", TotalSeats = 30 };
            var attendanceRecord = new AttendanceRecord { IsActive = true, ClassroomId = classroom.Id, Start = DateTime.Now, End = DateTime.Now, Comment = "Test Comment" };
            dbContext.Classrooms.Add(classroom);
            dbContext.AttendanceRecords.Add(attendanceRecord);
            await dbContext.SaveChangesAsync();

            // Act
            var result = await attendanceService.GetClassroomIdByAttendancyIdAsync(attendanceRecord.Id.ToString());

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(classroom.Id.ToString(), result);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
