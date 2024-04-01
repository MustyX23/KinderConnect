using KinderConnect.Web.ViewModels.Classroom;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface IClassroomService
    {
        Task<IEnumerable<AllClassroomViewModel>> GetAllClassroomsAsync();
        //Task<ClassroomDto> GetClassroomByIdAsync(string clasroomId);
        //Task CreateClassroomAsync(ClassroomDto classroomDto);
        //Task UpdateClassroomAsync(string clasroomId, ClassroomDto classroomDto);
        //Task DeleteClassroomAsync(string clasroomId);
    }
}
