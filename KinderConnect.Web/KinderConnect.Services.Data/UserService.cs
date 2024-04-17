using KinderConnect.Data;
using KinderConnect.Data.Models;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;

namespace KinderConnect.Services.Data
{
    public class UserService : IUserService
    {
        private readonly KinderConnectDbContext dbContext;

        public UserService(KinderConnectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.IsActive && u.Id.ToString() == userId);
            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            List<UserViewModel> allUsers = await this.dbContext
                .Users
                .Where(u => u.IsActive)
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    FullName = u.FirstName + " " + u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    IsTeacher = this.dbContext.Teachers.Any(t => t.TeacherUserId == u.Id),
                })
                .ToListAsync();

            return allUsers;
        }

        public async Task<UserViewModel> GetUserViewModelByIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.IsActive && u.Id.ToString() == userId);


            var viewModel = new UserViewModel()
            {
                Id= userId,
                Email = user.Email,
                FullName= user.FirstName + " " + user.LastName,
                PhoneNumber= user.PhoneNumber,
            };

            return viewModel;

        }
    }
}
