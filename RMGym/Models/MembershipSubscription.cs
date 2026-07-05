//using System.ComponentModel.DataAnnotations;

//namespace RMGym.Models
//{
//    public class MembershipSubscription
//    {
//        [Key]
//        public int SubscriptionId { get; set; }

//        [Required]
//        public int MemberId { get; set; }

//        public Member? Member { get; set; }

//        [Required]
//        public int PlanId { get; set; }

//        public MembershipPlan? MembershipPlan { get; set; }

//        public DateTime StartDate { get; set; } = DateTime.Today;

//        public DateTime EndDate { get; set; }

//        public decimal AmountPaid { get; set; }

//        public bool IsActive { get; set; } = true;
//    }
//}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMGym.Models
{
    public class MembershipSubscription
    {
        [Key]
        public int SubscriptionId { get; set; }

        [Required]
        public int MemberId { get; set; }

        [ForeignKey("MemberId")]
        public Member? Member { get; set; }

        [Required]
        public int PlanId { get; set; }

        [ForeignKey("PlanId")]
        public MembershipPlan? MembershipPlan { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Today;

        public DateTime EndDate { get; set; }

        public decimal AmountPaid { get; set; }

        public bool IsActive { get; set; } = true;
    }
}