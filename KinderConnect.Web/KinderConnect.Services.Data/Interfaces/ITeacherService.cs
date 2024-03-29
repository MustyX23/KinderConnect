using KinderConnect.Web.ViewModels.Teacher;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeachersForViewModel>> GetTeachersForViewAsync();
    }
}
