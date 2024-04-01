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
    }
}
