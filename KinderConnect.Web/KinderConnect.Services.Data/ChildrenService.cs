using KinderConnect.Data;
using KinderConnect.Data.Models;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Child;
using KinderConnect.Web.ViewModels.Classroom;
using Microsoft.EntityFrameworkCore;

namespace KinderConnect.Services.Data
{
    public class ChildrenService : IChildrenService
    {
        private readonly KinderConnectDbContext dbContext;

        public ChildrenService(KinderConnectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ChildClassroomJoinViewModel> GetChildByParentIdAsync(string parentguardianId)
        {
            var child = await dbContext
                .Children
                .Where(c => c.IsActive)
                .Select(c => new ChildClassroomJoinViewModel
                {
                    Id = c.Id.ToString(),
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    ParentGuardianId = c.ParentGuardianId.ToString()
                })
                .FirstAsync(c => c.ParentGuardianId == parentguardianId);

            return child;
        }

        public async Task<ChildDetailsViewModel> GetChildForDetailsByIdAsync(string childId)
        {
            var classroom = await dbContext
                .Classrooms
                .Where(c => c.IsActive && c.Children.Any(c => c.Id.ToString() == childId))
                .Select(c => new DetailsClassroomViewModel()
                {
                    Id= c.Id.ToString(),
                    Name = c.Name,
                })
                .FirstAsync();

            var child = await dbContext
                .Children
                .Where(c => c.IsActive)
                .Select(c => new ChildDetailsViewModel
                {
                    Id = c.Id.ToString(),
                    Age = c.Age,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    DateOfBirth = c.DateOfBirth.ToString("f"),
                    Allergies = c.Allergies,
                    Gender = c.Gender,
                    ImageUrl = c.ImageUrl,
                    IsActive = c.IsActive,
                    MedicalInformation = c.MedicalInformation,
                    ParentGuardianContact = c.ParentGuardianContact,
                    Classroom = classroom,
                })
                .FirstOrDefaultAsync(c => c.Id == childId);

            return child;
        }

        public async Task<IEnumerable<MyChildrenIndexViewModel>> GetChildrenByParentIdAsync(string parentguardianId)
        {
            var children = await dbContext
                .Children
                .Where(c => c.IsActive && c.ParentGuardianId.ToString() == parentguardianId)
                .Select(c => new MyChildrenIndexViewModel
                {
                    Id= c.Id.ToString(),
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    ImageUrl = c.ImageUrl,
                })
                .ToArrayAsync();

            return children;
        }

        public async Task<bool> IsChildAlreadyInAClassroomAsync(JoinClassroomFormModel model, string parentGuardianId)
        {
            bool result = await dbContext.Children
                .AnyAsync(c => c.FirstName == model.FirstName
                    && c.LastName == model.LastName
                    && c.DateOfBirth == model.DateOfBirth
                    && c.ParentGuardianId.ToString() == parentGuardianId
                    && c.ClassroomId.ToString() == model.ClassroomId);

            return result;
        }

        

        public async Task JoinChildToClassroomAsync(JoinClassroomFormModel model, string parentGuardianId)
        {
            Child child = new Child()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Age = DateTime.Now.Year - model.DateOfBirth.Year,
                Allergies = model.Allergies,
                MedicalInformation = model.MedicalInformation,
                ClassroomId = Guid.Parse(model.ClassroomId),
                ImageUrl = model.ImageUrl,
                Gender = model.Gender,
                IsActive = true,
                ParentGuardianId = Guid.Parse(parentGuardianId),
                ParentGuardianContact = model.ParentGuardianContact,                
            };

            await dbContext.Children.AddAsync(child);
            await dbContext.SaveChangesAsync();
        }
    }
}
