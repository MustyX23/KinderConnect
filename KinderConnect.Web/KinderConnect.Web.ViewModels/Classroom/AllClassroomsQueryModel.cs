using KinderConnect.Web.ViewModels.Classroom.Enums;
using System.ComponentModel.DataAnnotations;

using static KinderConnect.Common.GeneralApplicationConstants;
namespace KinderConnect.Web.ViewModels.Classroom
{
    public class AllClassroomsQueryModel
    {
        [Display(Name = "Search by text")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Classes By:")]
        public ClassroomSorting ClassroomSorting { get; set; }

        public int CurrentPage { get; set; } = DefaultPage;

        [Display(Name = "Show Classes on Page")]
        public int ClassesPerPage { get; set; } = EntitiesPerPage;

        public int TotalClasses { get; set; }

        public IEnumerable<AllClassroomViewModel> Classes { get; set; } = new HashSet<AllClassroomViewModel>();
    }
}
