using KinderConnect.Data;
using KinderConnect.Data.Models;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Teacher;
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
    }
}
