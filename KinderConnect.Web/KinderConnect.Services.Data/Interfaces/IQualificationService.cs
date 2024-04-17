using KinderConnect.Web.ViewModels.Qualification;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface IQualificationService
    {
        Task<IEnumerable<QualificationViewModel>> GetAllQualificationsViewModels();
    }
}
