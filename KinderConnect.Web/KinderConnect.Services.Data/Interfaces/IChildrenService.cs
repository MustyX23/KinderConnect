using KinderConnect.Web.ViewModels.Classroom;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface IChildrenService
    {
        Task JoinChildToClassroomAsync(JoinClassroomFormModel model, string parentGuardianId);
        //Task<IEnumerable<ChildDto>> GetAllChildrenAsync();
        //Task<ChildDto> GetChildByIdAsync(string childId);
        //Task CreateChildAsync(ChildDto childDto);
        //Task UpdateChildAsync(string childId, ChildDto childDto);
        //Task DeleteChildAsync(string childId);
    }
}
