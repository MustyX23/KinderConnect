using KinderConnect.Data;
using KinderConnect.Data.Models;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Activity;
using KinderConnect.Web.ViewModels.Attendance;
using KinderConnect.Web.ViewModels.Child;
using Microsoft.EntityFrameworkCore;
using static KinderConnect.Common.EntityValidationConstants;

namespace KinderConnect.Services.Data
{
    public class AttendanceService : IAttendanceService
    {
        private readonly KinderConnectDbContext dbContext;

        public AttendanceService(KinderConnectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AttendanceRecordFormModel>> GetAllAttendancesByTeacherAndClassroomIdAsync(string teacherId, string classroomId)
        {
            var childrenViewModel = await dbContext
                .Children
                .Where(c => c.ClassroomId.ToString() == classroomId && c.IsActive)
                .Select(
                c => new ChildForAttendanceViewModel()
                {
                    Id = c.Id.ToString(),
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    IsPresent = c.IsPresent,
                })
                .ToListAsync();

            var allAttendances = await dbContext
                .AttendanceRecords
                .Where(a => a.IsActive)
                .Select(a => new AttendanceRecordFormModel()
                {
                    Id = a.Id.ToString(),
                    ClassroomId = classroomId,
                    ActivityId = a.ActivityId,
                    Actvity = a.Activity.Name,
                    TeacherId = a.TeacherId.ToString(),
                    Start = a.Start.ToString("dd/MM/yyyy HH:mm"),
                    End = a.End.ToString("dd/MM/yyyy HH:mm"),
                    Comment = a.Comment,
                    Children = childrenViewModel
                })
                .ToArrayAsync();

            return allAttendances;
        }

        public async Task<AttendanceRecordFormModel> GetAttendanceRecordFormModelByClassroomIdAsync(string classroomId)
        {
            var activitiesViewModel = await
                dbContext
                .Activities
                .Where(a => a.IsActive)
                .Select(a => new ActivityViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                })
                .ToListAsync();

            var childrenViewModel = await dbContext
                .Children
                .Where(c => c.ClassroomId.ToString() == classroomId && c.IsActive)
                .Select(
                c => new ChildForAttendanceViewModel()
                {
                    Id = c.Id.ToString(),
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    FullName = c.FirstName + " " + c.LastName, 
                    IsPresent = c.IsPresent,
                })
                .ToListAsync();

            var formModel = new AttendanceRecordFormModel()
            {
                Activities = activitiesViewModel,
                ClassroomId = classroomId,
                Children = childrenViewModel
            };

            return formModel;
        }
    }
}
