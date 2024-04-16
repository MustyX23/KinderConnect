using KinderConnect.Web.ViewModels.User;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> GetFullNameByEmailAsync(string email);

        Task<string> GetFullNameByIdAsync(string userId);

        Task<IEnumerable<UserViewModel>> AllAsync();
    }
}
