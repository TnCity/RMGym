using System.ComponentModel.DataAnnotations;

namespace RMGym.Models
{
    public class MembershipPlan
    {
        [Key]
        public int PlanId { get; set; }

        [Required]
        [StringLength(100)]
        public string? PlanName { get; set; }

        public string Description { get; set; } = "";

        // Stored as a string in the database (e.g. "3 Months") so keep property as string
        // and parse as needed when performing numeric operations.
        public string DurationMonths { get; set; } = "";

        public int Price { get; set; }

        public bool IsActive { get; set; } = true;


    }
}
