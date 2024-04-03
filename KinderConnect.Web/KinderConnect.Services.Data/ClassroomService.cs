using KinderConnect.Data;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Classroom;
using Microsoft.EntityFrameworkCore;

namespace KinderConnect.Services.Data
{
    public class ClassroomService : IClassroomService
    {
        private readonly KinderConnectDbContext dbContext;

        public ClassroomService(KinderConnectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<AllClassroomViewModel>> GetAllClassroomsAsync()
        {
            var allClassroomsForView = await dbContext.Classrooms
                .Select(c => new AllClassroomViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Information = c.Information,
                    MinimumAge = c.MinimumAge,
                    MaximumAge = c.MaximumAge,
                    TotalSeats = c.TotalSeats,
                    TutionFee = c.TutionFee.ToString(),
                    ImageUrl = c.ImageUrl,
                })
                .ToArrayAsync();

            return allClassroomsForView;
        }

        public async Task<JoinClassroomFormModel> GetJoinClassroomFormModelByIdAsync(string classroomId)
        {
            var classroomFormModel = await dbContext.Classrooms
                .Select(c => new JoinClassroomFormModel()
                {
                    ClassroomImageUrl = c.ImageUrl,
                    ClassroomId = c.Id.ToString(),
                    ClassroomName = c.Name,
                    ClassroomMaximumAge = c.MaximumAge,
                    ClassroomMinimumAge = c.MinimumAge,
                })
                .FirstAsync(c => c.ClassroomId == classroomId);

            return classroomFormModel;
                
        }
    }
}
