using System.ComponentModel.DataAnnotations;
using static KinderConnect.Common.EntityValidationConstants.Classroom;

namespace KinderConnect.Web.ViewModels.Classroom
{
    public class CreateClassroomFormModel
    {
        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(InfoMaxLenght, MinimumLength = InfoMinLenght)]
        public string Information { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(MinimumAgeMinLenght, MinimumAgeMaxLenght)]
        public int MinimumAge { get; set; }

        [Required]
        [Range(MaximumAgeAgeMinLenght, MaximumAgeAgeMaxLenght)]
        public int MaximumAge { get; set; }

        [Required]
        public int TotalSeats { get; set; }

        [Required]
        public decimal TutionFee { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
