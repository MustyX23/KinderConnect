using KinderConnect.Web.ViewModels.Activity;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface IActivityService
    {
        Task CreateAsync(ActivityFormModel model);
        Task EditByIdAsync(int id, ActivityFormModel model);
        Task<ActivityFormModel> GetActivityForEditByIdAsync(int id);
        Task<IEnumerable<AllActivitiesViewModel>> GetAllActivitiesAsync();

        Task SoftRemoveByIdAsync(int id);
        //Task<ActivityDto> GetActivityByIdAsync(string activityId);
        //Task CreateActivityAsync(ActivityDto activityDto);
        //Task UpdateActivityAsync(string activityId, ActivityDto activityDto);
        //Task DeleteActivityAsync(string activityId);
    }
}
