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
            var allClassrooms = await dbContext.Classrooms.ToListAsync(); 

            var allClassroomsForView = new List<AllClassroomViewModel>();

            foreach (var classroom in allClassrooms)
            {               
                var seatsAvailable = await IsClassroomSeatsAvailableAsync(classroom.Id.ToString());

                allClassroomsForView.Add(new AllClassroomViewModel
                {
                    Id = classroom.Id.ToString(),
                    Name = classroom.Name,
                    Information = classroom.Information,
                    MinimumAge = classroom.MinimumAge,
                    MaximumAge = classroom.MaximumAge,
                    TotalSeats = classroom.TotalSeats,
                    TutionFee = classroom.TutionFee.ToString(),
                    ImageUrl = classroom.ImageUrl,
                    SeatsAvailable = seatsAvailable
                });
            }

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
        public async Task<bool> IsClassroomSeatsAvailableAsync(string classroomId)
        {
            int currentSeats = await dbContext.Children
             .CountAsync(c => c.ClassroomId.ToString() == classroomId);

            var classroom = await dbContext.Classrooms.FindAsync(Guid.Parse(classroomId));

            return currentSeats < classroom!.TotalSeats;
        }
    }
}
