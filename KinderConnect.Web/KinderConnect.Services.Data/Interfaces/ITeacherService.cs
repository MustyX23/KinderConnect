using KinderConnect.Data.Models;
using KinderConnect.Web.ViewModels.Classroom;
using KinderConnect.Web.ViewModels.Teacher;
using KinderConnect.Web.Views.Teacher;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface ITeacherService
    {
        Task<AllTeachersQueryModel> AllAsync(AllTeachersQueryModel queryModel);
        Task<Teacher> GetTeacherByIdAsync(Guid teacherId);
        Task<TeacherDetailsViewModel> GetDetailsByIdAsync(string id);
        Task<IEnumerable<MyClassroomViewModel>> GetMyClassroomsByTeacherIdAsync(string teacherId);
        Task<string> GetTeacherIdByUserIdAsync(string userId);
        Task<IEnumerable<AllTeacherViewModel>> GetTeachersForViewAsync();
        Task<bool> IsTeacherByUserIdAsync(string userId);
        Task<bool> IsTeacherLeaderOfClassroomByIdAndClassroomIdAsync(string teacherId, string classroomId);
        Task UpgradeToTeacherByUserIdAsync(string userId, CreateTeacherFormModel formModel);
        //Task<TeacherDto> GetTeacherByIdAsync(string teacherId);
        //Task CreateTeacherAsync(TeacherDto teacherDto);
        //Task EditTeacherByIdAsync(string teacherId, TeacherDto teacherDto);
        //Task SoftDeleteTeacherByAsync(string teacherId);
    }
}
