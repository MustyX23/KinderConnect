using System.ComponentModel.DataAnnotations;
using static KinderConnect.Common.EntityValidationConstants.Activity;

namespace KinderConnect.Data.Models
{
    public class Activity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Display(Name = "Activity")]
        public string Name { get; set; } = null!;
    }
}
