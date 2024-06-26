﻿using KinderConnect.Services.Data;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.Infrastructure.Extensions;
using KinderConnect.Web.ViewModels.Attendance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static KinderConnect.Common.NotificationMessagesConstants;

namespace KinderConnect.Web.Controllers
{
    [Authorize]
    public class AttendanceController : Controller
    {
        private IAttendanceService attendanceService;
        private ITeacherService teacherService;

        public AttendanceController(
            IAttendanceService attendanceService,
            ITeacherService teacherService)
        {
            this.attendanceService = attendanceService;
            this.teacherService = teacherService;

        }
        public async Task<IActionResult> AttendanceRecords(string teacherId, string classroomId)
        {
            string userId = User.GetUserId();

            bool isTeacher = await teacherService.IsTeacherByUserIdAsync(userId);

            var teacher = await teacherService.GetTeacherByIdAsync(Guid.Parse(teacherId));

            if (teacher == null)
            {
                return BadRequest();
            }
            if (teacher.TeacherUser.Id != Guid.Parse(userId))
            {
                return Unauthorized();
            }
            if (teacherId != null && classroomId != null)
            {
                bool isTeacherLeader = await teacherService.IsTeacherLeaderOfClassroomByIdAndClassroomIdAsync(teacherId, classroomId);

                if (!isTeacherLeader)
                {
                    ModelState.AddModelError(string.Empty, "You don't have permission to access this page.");
                    TempData[ErrorMessage] = $"You don't have permission to access this page.";
                    return RedirectToAction("Index", "Home");
                }
            }           
            if (!isTeacher)
            {
                ModelState.AddModelError(string.Empty, "You don't have permission to access this page.");
                TempData[ErrorMessage] = $"You don't have permission to access this page.";
                return RedirectToAction("Index", "Home");
            }
            if (userId == null)
            {
                ModelState.AddModelError(string.Empty, "You don't have permission to access this page.");
                TempData[ErrorMessage] = $"You don't have permission to access this page.";
                return RedirectToAction("Index", "Home");
            }                          
            if (classroomId != null)
            {
                ViewBag.ClassroomId = classroomId;
            }

            IEnumerable<AttendanceRecordFormModel> attendanceRecords
                = await attendanceService.GetAllAttendancesByTeacherAndClassroomIdAsync(teacherId, classroomId);

            if (attendanceRecords == null)
            {
                return BadRequest();
            }

            return View(attendanceRecords);
        }
        public async Task<IActionResult> Create(string classroomId)
        {
            try
            {
                string userId = User.GetUserId();
                string teacherId = await teacherService.GetTeacherIdByUserIdAsync(userId);

                var viewModel = await attendanceService
                    .GetAttendanceRecordFormModelByClassroomIdAsync(classroomId);

                bool isTeacher = await teacherService.IsTeacherByUserIdAsync(userId);
                bool isTeacherLeader = await teacherService.IsTeacherLeaderOfClassroomByIdAndClassroomIdAsync(teacherId, classroomId);

                if (!isTeacher)
                {
                    ModelState.AddModelError(string.Empty, "You don't have permission to access this page.");
                    TempData[ErrorMessage] = $"You don't have permission to access this page.";
                    return RedirectToAction("Index", "Home");
                }
                if (teacherId == null)
                {
                    ModelState.AddModelError(string.Empty, "You don't have permission to access this page.");
                    TempData[ErrorMessage] = $"You don't have permission to access this page.";
                    return RedirectToAction("Index", "Home");
                }
                if (!isTeacherLeader)
                {
                    return Unauthorized();
                }

                return View(viewModel);
            }
            catch (Exception)
            {
                GeneralError();
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(AttendanceRecordFormModel model)
        {
            string userId = User.GetUserId();

            bool isTeacher = await teacherService.IsTeacherByUserIdAsync(userId);
            string teacherId = await teacherService.GetTeacherIdByUserIdAsync(userId);
            bool isTeacherLeader = await teacherService.IsTeacherLeaderOfClassroomByIdAndClassroomIdAsync(teacherId, model.ClassroomId);


            if (model == null)
            {
                return BadRequest();
            }
            if (!isTeacherLeader) 
            {
                return Unauthorized();
            }
            if (!isTeacher)
            {
                ModelState.AddModelError(string.Empty, "You don't have permission to access this page.");
                TempData[ErrorMessage] = $"You don't have permission to access this page.";
                return RedirectToAction("Index", "Home");
            }
            if (teacherId == null)
            {
                ModelState.AddModelError(string.Empty, "You don't have permission to access this page.");
                TempData[ErrorMessage] = $"You don't have permission to access this page.";
                return RedirectToAction("Index", "Home");
            }


            await attendanceService.CreateAttendanceRecordAsync(model, teacherId);
            return RedirectToAction("AttendanceRecords", "Attendance" , new { teacherId, model.ClassroomId });
        }
        [HttpPost]
        public async Task<IActionResult> EditPresence(string attendanceId, string childId)
        {
            string userId = User.GetUserId();

            bool isTeacher = await teacherService.IsTeacherByUserIdAsync(userId);
            string teacherId = await teacherService.GetTeacherIdByUserIdAsync(userId);
            string classroomId = await attendanceService.GetClassroomIdByAttendancyIdAsync(attendanceId);
            bool isTeacherLeader = await teacherService.IsTeacherLeaderOfClassroomByIdAndClassroomIdAsync(teacherId, classroomId);

            if (!isTeacher)
            {
                ModelState.AddModelError(string.Empty, "You don't have permission to access this page.");
                TempData[ErrorMessage] = $"You don't have permission to access this page.";
                return RedirectToAction("Index", "Home");
            }
            if (teacherId == null)
            {
                ModelState.AddModelError(string.Empty, "You don't have permission to access this page.");
                TempData[ErrorMessage] = $"You don't have permission to access this page.";
                return RedirectToAction("Index", "Home");
            }
            if (!isTeacherLeader)
            {
                ModelState.AddModelError(string.Empty, "You don't have permission to access this page.");
                TempData[ErrorMessage] = $"You don't have permission to access this page.";
                return RedirectToAction("Index", "Home");
            }

            await attendanceService.EditPresenceAsync(attendanceId, childId);
            TempData[SuccessMessage] = $"You have succesfully changed child's presence";
            return RedirectToAction("AttendanceRecords", "Attendance" ,new {teacherId, classroomId });
        }
        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Unexpected Error occured. Please try again later :(";
            return RedirectToAction("Index", "Home");
        }
    }
}
