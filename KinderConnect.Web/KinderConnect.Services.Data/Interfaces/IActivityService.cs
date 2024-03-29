using KinderConnect.Web.ViewModels.Activity;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface IActivityService
    {
        Task<IEnumerable<AllActivitiesViewModel>> GetAllActivitiesAsync();
    }
}
