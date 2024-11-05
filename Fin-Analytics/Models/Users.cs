
using System.ComponentModel.DataAnnotations;

namespace Fin_Analytics.Models
{
    /// <summary>
    /// Represents a user of the financial analytics system.
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        /// <remarks>
        /// This is a system-generated ID that is used to uniquely identify each user.
        /// </remarks>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the full name of the user.
        /// Required.
        /// </summary>
        /// <remarks>
        /// This field stores the user's full name, which is used for display purposes.
        /// </remarks>
        [Required]
        public required string FullName { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the user.
        /// Required.
        /// </summary>
        public required DateTime DoB { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// Required.
        /// </summary>
        public required string Phone { get; set; }

        /// <summary>
        /// Gets or sets the address of the user.
        /// Required.
        /// </summary>
        public required string Address { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// Required.
        /// </summary>
        [EmailAddress]
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the company of the user.
        /// Required.
        /// </summary>
        public string? Company { get; set; }


        /// <summary>
        /// Gets or sets the date and time when the user was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}