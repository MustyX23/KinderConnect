using KinderConnect.Web.ViewModels.Teacher;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<AllTeacherViewModel>> GetTeachersForViewAsync();
        //Task<TeacherDto> GetTeacherByIdAsync(string teacherId);
        //Task CreateTeacherAsync(TeacherDto teacherDto);
        //Task EditTeacherByIdAsync(string teacherId, TeacherDto teacherDto);
        //Task SoftDeleteTeacherByAsync(string teacherId);
    }
}
