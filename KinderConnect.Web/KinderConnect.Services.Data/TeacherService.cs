using KinderConnect.Data;
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

        public async Task<IEnumerable<TeachersForViewModel>> GetTeachersForViewAsync()
        {
            var teachersForView = await dbContext.Teachers
                .Select(t => new TeachersForViewModel
                {
                    FirstName = t.TeacherUser.FirstName,
                    LastName = t.TeacherUser.LastName,
                    ImageUrl = t.ImageUrl
                })
                .ToArrayAsync();

            return teachersForView;
        }
    }
}
