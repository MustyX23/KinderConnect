﻿using KinderConnect.Web.ViewModels.Classroom;
using KinderConnect.Web.ViewModels.Teacher;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherDetailsViewModel> GetDetailsByIdAsync(string id);
        Task<IEnumerable<MyClassroomViewModel>> GetMyClassroomsByTeacherIdAsync(string teacherId);
        Task<string> GetTeacherIdByUserIdAsync(string userId);
        Task<IEnumerable<AllTeacherViewModel>> GetTeachersForViewAsync();

        Task<bool> IsTeacherByUserIdAsync(string userId);
        //Task<TeacherDto> GetTeacherByIdAsync(string teacherId);
        //Task CreateTeacherAsync(TeacherDto teacherDto);
        //Task EditTeacherByIdAsync(string teacherId, TeacherDto teacherDto);
        //Task SoftDeleteTeacherByAsync(string teacherId);
    }
}
