using KinderConnect.Web.ViewModels.Attendance;

namespace KinderConnect.Services.Data.Interfaces
{
    public interface IAttendanceService
    {
        //Task<IEnumerable<AttendanceRecordDto>> GetAllAttendanceRecordsAsync();
        //Task<AttendanceRecordDto> GetAttendanceRecordByIdAsync(string id);
        //Task RecordAttendanceAsync(AttendanceRecordDto attendanceRecordDto);
        //Task UpdateAttendanceAsync(string id, AttendanceRecordDto attendanceRecordDto);
        //Task DeleteAttendanceAsync(string id);
        Task<IEnumerable<AttendanceRecordFormModel>> GetAllAttendancesByTeacherAndClassroomIdAsync(string teacherId, string classroomId);
        Task<AttendanceRecordFormModel> GetAttendanceRecordFormModelByClassroomIdAsync(string classroomId);
        Task CreateAttendanceRecordAsync(AttendanceRecordFormModel model, string teacherId);
        Task EditPresenceAsync(string attendanceId, string childId);
        Task<string> GetClassroomIdByAttendancyIdAsync(string attendanceId);
    }
}
