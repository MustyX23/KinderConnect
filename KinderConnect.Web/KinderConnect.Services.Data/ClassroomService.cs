using KinderConnect.Data;
using KinderConnect.Data.Models;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Child;
using KinderConnect.Web.ViewModels.Classroom;
using KinderConnect.Web.ViewModels.Classroom.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace KinderConnect.Services.Data
{
    public class ClassroomService : IClassroomService
    {
        private readonly KinderConnectDbContext dbContext;

        public ClassroomService(KinderConnectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllClassroomsQueryModel> AllAsync(AllClassroomsQueryModel queryModel)
        {
            IQueryable<Classroom> classroomsQuery = dbContext
                .Classrooms
                .Where(c => c.IsActive)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                classroomsQuery = classroomsQuery
                    .Where(c => EF.Functions.Like(c.Name, wildCard)
                    || EF.Functions.Like(c.Information, wildCard));
            }

            classroomsQuery = queryModel.ClassroomSorting switch
            {
                ClassroomSorting.Newest => classroomsQuery
                .OrderByDescending(c => c.CreatedOn),

                ClassroomSorting.Oldest => classroomsQuery
                .OrderBy(c => c.CreatedOn),

                ClassroomSorting.ElderAge => classroomsQuery
                .OrderByDescending(c => c.MaximumAge),

                ClassroomSorting.YoungerAge => classroomsQuery
                .OrderBy(c => c.MaximumAge),

                _ => classroomsQuery.OrderByDescending(c => c.Id),
            };

            IEnumerable<AllClassroomViewModel> allClassrooms = await classroomsQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.ClassesPerPage)
                .Take(queryModel.ClassesPerPage)
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
                    SeatsAvailable = c.Children.Count < c.TotalSeats
                })
                .ToArrayAsync();

            int totalClasses = classroomsQuery.Count();

            queryModel.TotalClasses = totalClasses;
            queryModel.Classes = allClassrooms;

            return queryModel;
        }

        public async Task CreateAsync(CreateClassroomFormModel model)
        {
            Classroom classroom = new Classroom() 
            {
                Name = model.Name,
                Information = model.Information,
                ImageUrl = model.ImageUrl,
                MinimumAge = model.MinimumAge,
                MaximumAge = model.MaximumAge,
                TotalSeats = model.TotalSeats,
                TutionFee = model.TutionFee,
            };

            dbContext.Classrooms.Add(classroom);
            await dbContext.SaveChangesAsync();
        }

        public async Task DecreaseTotalSeatsByIdAsync(string classroomId)
        {
            var classroom = await dbContext
                .Classrooms
                .FirstOrDefaultAsync(c => c.IsActive && c.Id.ToString() == classroomId);

            classroom.TotalSeats -= 1;

            await dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(string classroomId, EditClassroomFormModel formModel)
        {
            var classroom = await dbContext
                .Classrooms
                .FirstOrDefaultAsync(c => c.IsActive && c.Id.ToString() == classroomId);

            classroom.Name = formModel.Name;
            classroom.Information = formModel.Information;
            classroom.TutionFee = formModel.TutionFee;
            classroom.ImageUrl = formModel.ImageUrl;
            classroom.MinimumAge = formModel.MinimumAge;
            classroom.MaximumAge = formModel.MaximumAge;

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllClassroomViewModel>> GetAllClassroomsAsync()
        {
            var allClassrooms = await dbContext
                .Classrooms
                .Where(c => c.IsActive)
                .Include(c => c.Children)
                .ToListAsync();

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

        public async Task<EditClassroomFormModel> GetClassroomForEditByIdAsync(string classroomId)
        {
            var classroom = await dbContext
                .Classrooms
                .FirstOrDefaultAsync(c => c.IsActive && c.Id.ToString() == classroomId);

            if (classroom != null)
            {
                EditClassroomFormModel classroomViewModel = new EditClassroomFormModel
                {
                    Id = classroomId,
                    Name = classroom.Name,
                    Information = classroom.Information,
                    ImageUrl = classroom.ImageUrl,
                    MinimumAge = classroom.MinimumAge,
                    MaximumAge = classroom.MaximumAge,
                    TotalSeats = classroom.TotalSeats,
                    TutionFee = classroom.TutionFee,                    
                };

                return classroomViewModel;
            }

            return null;
        }

        public async Task<ClassroomViewModel> GetClassroomViewModelByIdAsync(string classroomId)
        {
            var viewModel = await dbContext
                .Classrooms
                .Where(c => c.IsActive && c.Id.ToString() == classroomId)
                .Select(c => new ClassroomViewModel()
                {
                    ClassroomName = c.Name,
                    ClassroomImageUrl = c.ImageUrl,
                    ClassroomMaximumAge = c.MaximumAge,
                    ClassroomMinimumAge = c.MinimumAge,
                })
                .FirstOrDefaultAsync();

            return viewModel;
        }

        public async Task<JoinClassroomByChildViewModel> GetJoinClassroomByChildViewModelByIdAsync(string id)
        {
            var viewModel = await dbContext
                .Classrooms
                .Where(c => c.IsActive && c.Id.ToString() == id)
                .Select(c => new JoinClassroomByChildViewModel
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    ImageUrl = c.ImageUrl,
                })
                .FirstOrDefaultAsync();

            return viewModel;
        }

        public async Task<JoinClassroomFormModel> GetJoinClassroomFormModelByIdAsync(string classroomId)
        {
            var classroomFormModel = await dbContext.Classrooms
                .Where(c => c.IsActive && c.Id.ToString() == classroomId)
                .Select(c => new JoinClassroomFormModel()
                {
                    ClassroomImageUrl = c.ImageUrl,
                    ClassroomId = c.Id.ToString(),
                    ClassroomName = c.Name,
                    ClassroomMaximumAge = c.MaximumAge,
                    ClassroomMinimumAge = c.MinimumAge,
                })
                .FirstOrDefaultAsync();

            return classroomFormModel;
                
        }

        public async Task<JoinClassroomViewModel> GetJoinClassroomViewModelAsync(string classroomId, string childId)
        {
            var classroom = await
                dbContext
                .Classrooms
                .FirstOrDefaultAsync(c => c.IsActive && c.Id.ToString() == classroomId);

            var child = await
                dbContext
                .Children
                .FirstOrDefaultAsync(c => c.IsActive && c.Id.ToString() == childId);

            var viewModel = new JoinClassroomViewModel() 
            {
                Classroom = await dbContext
                    .Classrooms
                    .Select (c => new ClassroomViewModel()
                    {
                        ClassroomName = classroom.Name,
                        ClassroomImageUrl = classroom.ImageUrl,
                        ClassroomMinimumAge = classroom.MinimumAge,
                        ClassroomMaximumAge = classroom.MaximumAge
                    })
                    .FirstAsync(),
                Child = await dbContext
                    .Children
                    .Select(c => new ChildViewModel()
                    {
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        DateOfBirth = c.DateOfBirth.ToString("yyyy/MM/dd HH:mm"),
                        Allergies = c.Allergies,
                        ParentGuardianContact = c.ParentGuardianContact,
                        Gender = c.Gender,
                        ImageURL = c.ImageUrl,
                        MedicalInformation = c.MedicalInformation
                    })
                    .FirstAsync(),
            };

            return viewModel;
        }

        public async Task<LeaveClassroomViewModel> GetLeaveClassroomViewModelByChildIdAsync(string childId)
        {
            string childsFirstName = await dbContext
                .Children
                .Where(c => c.IsActive && c.Id.ToString() == childId)
                .Select(c => c.FirstName)
                .FirstAsync();

            Guid? classroomId = await dbContext
                .Children
                .Where(c => c.IsActive && c.Id.ToString() == childId)
                .Select(c => c.ClassroomId)
                .FirstAsync();

            var viewModel = await dbContext
                .Classrooms
                .Where(c => c.IsActive && c.Id == classroomId)                
                .Select (c => new LeaveClassroomViewModel()
                {
                    Id = childId,
                    ClassroomId = c.Id.ToString(),
                    ChildFirstName = childsFirstName,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl,
                })
                .FirstAsync();

            return viewModel;
        }

        public async Task IncreaseTotalSeatsByIdAsync(string classroomId)
        {
            var classroom = await dbContext
                .Classrooms
                .FirstOrDefaultAsync(c => c.IsActive && c.Id.ToString() == classroomId);

            classroom.TotalSeats += 1;

            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsClassroomSeatsAvailableAsync(string classroomId)
        {
            int currentSeats = await dbContext.Children
             .CountAsync(c => c.ClassroomId.ToString() == classroomId);

            var classroom = await dbContext.Classrooms.FindAsync(Guid.Parse(classroomId));

            return currentSeats < classroom!.TotalSeats;
        }

        public async Task SoftRemoveClassroomByIdAsync(string id)
        {
            var classroom = await dbContext
                .Classrooms
                .FirstOrDefaultAsync(c => c.IsActive && c.Id.ToString() == id);

            if (classroom != null)
            {
                classroom.IsActive = false;

                await dbContext.SaveChangesAsync();
            }            
        }
    }
}
