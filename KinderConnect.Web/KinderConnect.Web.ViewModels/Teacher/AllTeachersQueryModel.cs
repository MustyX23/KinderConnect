using KinderConnect.Web.ViewModels.Classroom;
using KinderConnect.Web.ViewModels.Teacher;
using KinderConnect.Web.ViewModels.Teacher.Enums;
using System.ComponentModel.DataAnnotations;

using static KinderConnect.Common.GeneralApplicationConstants;

namespace KinderConnect.Web.Views.Teacher
{
    public class AllTeachersQueryModel
    {
        [Display(Name = "Search by text")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Teachers By:")]
        public TeacherSorting TeacherSorting { get; set; }

        public int CurrentPage { get; set; } = DefaultPage;

        [Display(Name = "Show Teachers on Page")]
        public int TeachersPerPage { get; set; } = EntitiesPerPage;

        public int TotalTeachers { get; set; }

        public IEnumerable<AllTeachersViewModel> Teachers { get; set; } = new HashSet<AllTeachersViewModel>();
    }
}
