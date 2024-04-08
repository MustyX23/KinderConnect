﻿using KinderConnect.Data.Models;
using KinderConnect.Web.ViewModels.Child;
using KinderConnect.Web.ViewModels.Classroom;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface IChildrenService
    {
        Task JoinChildToClassroomAsync(JoinClassroomFormModel model, string parentGuardianId);
        Task<bool> IsChildAlreadyInAClassroomAsync(JoinClassroomFormModel model, string parentGuardianId);
        Task <ChildClassroomJoinViewModel> GetChildByParentIdAsync(string parentGuardianId);
        Task<Child?> GetChildByIdAsync(string childId);
        Task<IEnumerable<MyChildrenIndexViewModel>> GetChildrenByParentIdAsync(string parentGuardianId);
        Task<ChildDetailsViewModel> GetChildForDetailsByIdAsync(string childId);
        Task<EditChildFormModel> GetChildForEditByIdAsync(string id);
        Task EditChildByIdAsync(string id, EditChildFormModel formModel);
        Task LeaveClassroomByChildIdAsync(string id);
        //Task<IEnumerable<ChildDto>> GetAllChildrenAsync();
        //Task<ChildDto> GetChildByIdAsync(string childId);
        //Task CreateChildAsync(ChildDto childDto);
        //Task UpdateChildAsync(string childId, ChildDto childDto);
        //Task DeleteChildAsync(string childId);
    }
}
