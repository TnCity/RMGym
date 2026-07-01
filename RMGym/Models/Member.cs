using System.ComponentModel.DataAnnotations;

namespace RMGym.Models
{
    public class Member
    {
        [Key]
        public int MembershipId { get; set; }

        [Required]
        [StringLength(100)]
        public string? FullName { get; set; }

        [Required]
        [Phone]
        public string? PhoneNumber { get; set; } 

        [Required]
        [EmailAddress]
        public string? Email {  get; set; }

        public string? Address {  get; set; }

        public string? EmergencyContactNo {  get; set; }
        [Required]
        public DateTime JoinDate { get; set; } = DateTime.Now;

        public string AssignedTrainer {  get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;
        

    }
}
