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

        public async Task<IEnumerable<AllTeacherViewModel>> GetTeachersForViewAsync()
        {
            var teachersForView = await dbContext.Teachers
                .Select(t => new AllTeacherViewModel
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
