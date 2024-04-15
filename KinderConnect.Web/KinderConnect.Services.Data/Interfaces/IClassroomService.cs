using KinderConnect.Data.Models;
using KinderConnect.Web.ViewModels.Classroom;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface IClassroomService
    {
        Task<IEnumerable<AllClassroomViewModel>> GetAllClassroomsAsync();
        Task<AllClassroomsQueryModel> AllAsync(AllClassroomsQueryModel queryModel);
        Task<JoinClassroomFormModel> GetJoinClassroomFormModelByIdAsync(string classroomId);
        Task<LeaveClassroomViewModel> GetLeaveClassroomViewModelByChildIdAsync(string childId);
        Task<JoinClassroomByChildViewModel> GetJoinClassroomByChildViewModelByIdAsync(string id);
        Task<bool> IsClassroomSeatsAvailableAsync(string classroomId);
        Task<JoinClassroomViewModel> GetJoinClassroomViewModelAsync(string classroomId, string childId);
        Task<ClassroomViewModel> GetClassroomViewModelByIdAsync(string classroomId);
        Task IncreaseTotalSeatsByIdAsync(string classroomId);
        Task DecreaseTotalSeatsByIdAsync(string classroomId);
        //Task<ClassroomDto> GetClassroomByIdAsync(string clasroomId);
        //Task CreateClassroomAsync(ClassroomDto classroomDto);
        //Task UpdateClassroomAsync(string clasroomId, ClassroomDto classroomDto);
        //Task DeleteClassroomAsync(string clasroomId);
    }
}
