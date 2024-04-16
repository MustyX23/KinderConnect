using KinderConnect.Data;
using KinderConnect.Data.Models;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Teacher;
using KinderConnect.Web.ViewModels.Teacher.Enums;
using KinderConnect.Web.Views.Teacher;
using Microsoft.EntityFrameworkCore;

namespace KinderConnect.Services.Data
{
    public class TeacherService : ITeacherService
    {
        private readonly KinderConnectDbContext dbContext;

        public TeacherService(KinderConnectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllTeachersQueryModel> AllAsync(AllTeachersQueryModel queryModel)
        {
            IQueryable<Teacher> teachersQuery = dbContext
                .Teachers
                .Include(tU => tU.TeacherUser)
                .Where(t => t.TeacherUser.IsActive)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                teachersQuery = teachersQuery
                    .Where(t => EF.Functions.Like(t.TeacherUser.FirstName, wildCard)
                    || EF.Functions.Like(t.TeacherUser.LastName, wildCard));
            }

            teachersQuery = queryModel.TeacherSorting switch
            {
                TeacherSorting.ByFirstNameAZ => teachersQuery
                .OrderBy(t => t.TeacherUser.FirstName),

                TeacherSorting.ByFirstNameZA => teachersQuery
                .OrderByDescending(t => t.TeacherUser.FirstName),

                TeacherSorting.ByLastNameAZ => teachersQuery
                .OrderBy(t => t.TeacherUser.LastName),

                TeacherSorting.ByLastNameZA => teachersQuery
                .OrderByDescending(t => t.TeacherUser.LastName),

                _ => teachersQuery.OrderByDescending(t => t.Id),
            };

            IEnumerable<AllTeachersViewModel> allTeachers = await teachersQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.TeachersPerPage)
                .Take(queryModel.TeachersPerPage)
                .Select(t => new AllTeachersViewModel()
                {
                    Id = t.Id.ToString(), //TeacherId
                    FirstName = t.TeacherUser.FirstName,
                    LastName = t.TeacherUser.LastName,
                    DateOfBirth = t.TeacherUser.DateOfBirth.ToString("yyyy/MM/dd"),
                    IsActive = t.TeacherUser.IsActive,
                    PhoneNumber = t.TeacherUser.PhoneNumber,
                    Email = t.TeacherUser.Email,
                    ImageUrl = t.ImageUrl,
                    Qualification = t.Qualification.Name,
                })
                .ToArrayAsync();

            int totalTeachers = teachersQuery.Count();

            queryModel.TotalTeachers = totalTeachers;
            queryModel.Teachers = allTeachers;

            return queryModel;
        }

        public async Task<TeacherDetailsViewModel> GetDetailsByIdAsync(string id)
        {
            Teacher teacher = await dbContext.Teachers
                .Where(t => t.TeacherUser.IsActive)
                .Include(t => t.TeacherUser)
                .FirstAsync(t => t.Id.ToString() == id);

            return new TeacherDetailsViewModel()
            {
                Id = teacher.Id.ToString(),
                FirstName = teacher.TeacherUser.FirstName,
                LastName = teacher.TeacherUser.LastName,
                ImageUrl = teacher.ImageUrl,
                Summary = teacher.Summary
            };
        }

        public async Task<IEnumerable<MyClassroomViewModel>> GetMyClassroomsByTeacherIdAsync(string teacherId)
        {
            var myClassrooms = await
                dbContext
                .ClassroomsTeachers
                .Where(ct => ct.TeacherId.ToString() == teacherId)
                .Select(ct => new MyClassroomViewModel 
                {
                    TeacherId = ct.Teacher.Id.ToString(),
                    TeacherFirstName = ct.Teacher.TeacherUser.FirstName,
                    ClassroomId = ct.ClassroomId.ToString(),
                    ClassroomImageUrl = ct.Classroom.ImageUrl,
                    ClassroomName = ct.Classroom.Name,
                })
                .ToArrayAsync();

            return myClassrooms;
        }

        public async Task<string> GetTeacherIdByUserIdAsync(string userId)
        {
            string? teacherId = await dbContext
                .Teachers
                .Where(t => t.TeacherUserId.ToString() == userId)
                .Select(t => t.Id.ToString())
                .FirstOrDefaultAsync();

            return teacherId;
        }

        public async Task<IEnumerable<AllTeacherViewModel>> GetTeachersForViewAsync()
        {
            var teachersForView = await dbContext.Teachers
                .Select(t => new AllTeacherViewModel
                {
                    Id = t.Id.ToString(),
                    FirstName = t.TeacherUser.FirstName,
                    LastName = t.TeacherUser.LastName,
                    ImageUrl = t.ImageUrl
                })
                .ToArrayAsync();

            return teachersForView;
        }

        public async Task<bool> IsTeacherByUserIdAsync(string userId)
        {
            bool isTeacher = await dbContext
                .Teachers
                .AnyAsync(t => t.TeacherUser.Id.ToString() == userId);

            return isTeacher;
        }

        public async Task<bool> IsTeacherLeaderOfClassroomByIdAndClassroomIdAsync(string teacherId, string classroomId)
        {
            var classroom = await dbContext.Classrooms
                .Include(c => c.ClassroomsTeachers)
                .FirstOrDefaultAsync(c => c.Id.ToString() == classroomId);

            // Check if the teacher is a leader of the classroom
            bool isLeader = classroom.ClassroomsTeachers.Any(ct => ct.TeacherId.ToString() == teacherId.ToLower());

            return isLeader;
        }

    }
}
