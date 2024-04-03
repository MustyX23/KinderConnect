using KinderConnect.Data;
using KinderConnect.Data.Models;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Child;
using KinderConnect.Web.ViewModels.Classroom;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections;

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
        public async Task<IEnumerable<ChildClassroomJoinViewModel>> GetChildrenByParentIdAsync(string parentguardianId)
        {
            var children = await dbContext
                .Children
                .Where(c => c.IsActive && c.ParentGuardianId.ToString() == parentguardianId)
                .Select(c => new ChildClassroomJoinViewModel
                {
                    Id = c.Id.ToString(),
                    FirstName = c.FirstName,
                    LastName = c.LastName
                })
                .ToArrayAsync();

            return children;
        }

        public async Task<bool> IsChildAlreadyInAClassroomAsync(string parentGuardianId, string classroomId)
        {
            IEnumerable<ChildClassroomJoinViewModel> children =
                await GetChildrenByParentIdAsync(parentGuardianId);

            // Iterate over each child and check if they are associated with the specified classroom
            foreach (var child in children)
            {
                if (await dbContext.Children
                    .Where(c => c.Id.ToString() == child.Id && c.IsActive && c.ParentGuardianId.ToString() == parentGuardianId && c.ClassroomId.ToString() == classroomId)
                    .AnyAsync())
                {
                    return true;
                }
            }

            return false;
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
