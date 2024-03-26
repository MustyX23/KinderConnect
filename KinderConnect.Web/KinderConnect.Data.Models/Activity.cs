using System.ComponentModel.DataAnnotations;
using static KinderConnect.Common.EntityValidationConstants.Activity;

namespace KinderConnect.Data.Models
{
    public class Activity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DesctiptionMinLength)]
        public string Description { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
