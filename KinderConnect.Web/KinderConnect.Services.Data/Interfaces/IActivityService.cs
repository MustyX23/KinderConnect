using KinderConnect.Web.ViewModels.Activity;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface IActivityService
    {
        Task<IEnumerable<AllActivitiesViewModel>> GetAllActivitiesAsync();
        //Task<ActivityDto> GetActivityByIdAsync(string activityId);
        //Task CreateActivityAsync(ActivityDto activityDto);
        //Task UpdateActivityAsync(string activityId, ActivityDto activityDto);
        //Task DeleteActivityAsync(string activityId);
    }
}
