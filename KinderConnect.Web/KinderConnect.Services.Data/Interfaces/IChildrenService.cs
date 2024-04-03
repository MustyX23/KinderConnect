using KinderConnect.Web.ViewModels.Child;
using KinderConnect.Web.ViewModels.Classroom;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface IChildrenService
    {
        Task JoinChildToClassroomAsync(JoinClassroomFormModel model, string parentGuardianId);
        Task<bool> IsChildAlreadyInAClassroomAsync(JoinClassroomFormModel model, string parentGuardianId);
        Task <ChildClassroomJoinViewModel> GetChildByParentIdAsync(string parentGuardianId);
        Task<IEnumerable<ChildClassroomJoinViewModel>> GetChildrenByParentIdAsync(string parentGuardianId);       
        //Task<IEnumerable<ChildDto>> GetAllChildrenAsync();
        //Task<ChildDto> GetChildByIdAsync(string childId);
        //Task CreateChildAsync(ChildDto childDto);
        //Task UpdateChildAsync(string childId, ChildDto childDto);
        //Task DeleteChildAsync(string childId);
    }
}
