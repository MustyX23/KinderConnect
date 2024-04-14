using KinderConnect.Data;
using KinderConnect.Data.Models;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Activity;
using KinderConnect.Web.ViewModels.Attendance;
using KinderConnect.Web.ViewModels.Child;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace KinderConnect.Services.Data
{
    public class AttendanceService : IAttendanceService
    {
        private readonly KinderConnectDbContext dbContext;

        public AttendanceService(KinderConnectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAttendanceRecordAsync(AttendanceRecordFormModel model, string teacherId)
        {
            var children = await dbContext
                .Children
                .Where(c => c.ClassroomId.ToString() == model.ClassroomId && c.IsActive)
                .ToListAsync();

            var childrenViewModel 
                = children.Select(c => new ChildForAttendanceViewModel()
            {
                Id = c.Id.ToString(),
                FirstName = c.FirstName,
                LastName = c.LastName,
                FullName = c.FirstName + " " + c.LastName,
                IsPresent = true
            })
            .ToList();

            model.Children = childrenViewModel;

            var attendanceRecord = new AttendanceRecord
            {
                ClassroomId = Guid.Parse(model.ClassroomId),
                TeacherId = Guid.Parse(teacherId),
                Start = DateTime.Parse(model.Start),
                End = DateTime.Parse(model.End),
                ActivityId = model.ActivityId,
            };

            dbContext.AttendanceRecords.Add(attendanceRecord);

            foreach (var child in model.Children)
            {
                var attendanceChild = new AttendanceChild
                {
                    AttendanceRecordId = attendanceRecord.Id,
                    ChildId = Guid.Parse(child.Id),
                    IsPresent = child.IsPresent,
                    Comment = child.Comment
                };

                dbContext.AttendanceChildren.Add(attendanceChild);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task EditPresenceAsync(string attendanceId, string childId)
        {
            var attendance = await dbContext
                .AttendanceChildren
                .FirstOrDefaultAsync(ac =>
                ac.AttendanceRecordId.ToString() == attendanceId
                && ac.ChildId.ToString() == childId
                && ac.AttendanceRecord.IsActive);

            if (attendance != null)
            {
                attendance.IsPresent = !attendance.IsPresent;
                await dbContext.SaveChangesAsync();
            }            
        }

        public async Task<IEnumerable<AttendanceRecordFormModel>> GetAllAttendancesByTeacherAndClassroomIdAsync(string teacherId, string classroomId)
        {
            var allAttendances = await dbContext
                .AttendanceRecords
                .Where(a => a.IsActive && a.ClassroomId.ToString() == classroomId)
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
                    Children = a.AttendanceChildren
                    .Select(ac => new ChildForAttendanceViewModel()
                    {
                        Id = ac.ChildId.ToString(),
                        FirstName = ac.Child.FirstName,
                        LastName = ac.Child.LastName,
                        FullName = ac.Child.FirstName + " " + ac.Child.LastName,
                        Comment = ac.Comment,
                        IsPresent = ac.IsPresent
                    })
                    .ToList()
                })
                .ToArrayAsync();

            return allAttendances;
        }

        public async Task<AttendanceRecordFormModel> GetAttendanceRecordFormModelByClassroomIdAsync(string classroomId)
        {
            var activitiesViewModel = await dbContext
                .Activities
                .Where(a => a.IsActive)
                .Select(a => new ActivityViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                })
                .ToListAsync();

            var children = await dbContext
                .Children
                .Where(c => c.ClassroomId.ToString() == classroomId && c.IsActive)
                .ToListAsync();

            var childrenWithAttendance = children
                .Select(c => new ChildForAttendanceViewModel()
                {
                    Id = c.Id.ToString(),
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    FullName = c.FirstName + " " + c.LastName,
                })
                .ToList();

            var formModel = new AttendanceRecordFormModel()
            {
                Activities = activitiesViewModel,
                ClassroomId = classroomId,
                Children = childrenWithAttendance
            };

            return formModel;
        }

        public async Task<string> GetClassroomIdByAttendancyIdAsync(string attendancyId)
        {
            string? classroomId = await dbContext
                .AttendanceRecords
                .Where(a => a.Id.ToString() == attendancyId)
                .Select(a => a.ClassroomId.ToString())
                .FirstOrDefaultAsync();


            return classroomId;
        }
    }
}
