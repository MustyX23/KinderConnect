using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Attendance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinderConnect.Web.Controllers
{
    [Authorize]
    public class AttendanceController : Controller
    {
        private IAttendanceService attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }
        public async Task<IActionResult> AttendanceRecords(string teacherId, string classroomId)
        {
            IEnumerable<AttendanceRecordFormModel> attendanceRecords
                = await attendanceService.GetAllAttendancesByTeacherAndClassroomIdAsync(teacherId, classroomId);

            return View(attendanceRecords);
        }
        public async Task<IActionResult> Create(string classroomId)
        {
            var viewModel
                = await attendanceService
                .GetAttendanceRecordFormModelByClassroomIdAsync(classroomId);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AttendanceRecordFormModel model)
        {
            return Ok();
        }
    }
}
