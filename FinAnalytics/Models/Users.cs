using System.ComponentModel.DataAnnotations;

namespace FinAnalytics.Models
{

    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public required string FullName { get; set; }

        public DateTime? DoB { get; set; }

        public required string Phone { get; set; }

        public required string Address { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public required string Company { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}