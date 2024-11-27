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
        [Display(Name = "User ID")]
        public int UserId { get; init; }

        /// <summary>
        /// Gets or sets the full name of the user.
        /// Required.
        /// </summary>
        /// <remarks>
        /// This field stores the user's full name, which is used for display purposes.
        /// </remarks>
        [Required]
        [Display(Name = "Full Name")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+(?:\s[a-zA-Z]+)*$", ErrorMessage = "Full name must contain only letters.")]
        [MinLength(3, ErrorMessage = "Full name must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Full name cannot be longer than 50 characters.")]
        public required string FullName { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the user.
        /// Required.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public required DateTime DoB { get; init; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// Required.
        /// </summary>
        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[0-9]+(-[0-9]+)*$", ErrorMessage = "Phone number must be a number.")]
        [MinLength(6, ErrorMessage = "Phone number must be at least 6 characters long.")]
        [MaxLength(15, ErrorMessage = "Phone number cannot be longer than 15 characters.")]
        public required string Phone { get; set; }

        /// <summary>
        /// Gets or sets the address of the user.
        /// Required.
        /// </summary>

        [Required]
        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 characters.")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z0-9\s,]+$", ErrorMessage = "Address must contain only letters and numbers.")]
        [MinLength(3, ErrorMessage = "Address must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Address cannot be longer than 50 characters.")]
        public required string Address { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// Required.
        /// </summary>
        /// 
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Email address is invalid.")]
        [MinLength(3, ErrorMessage = "Email address must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Email address cannot be longer than 50 characters.")]
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the company of the user.
        /// Required.
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "Company cannot be longer than 50 characters.")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Company must contain only letters and numbers.")]
        [MinLength(3, ErrorMessage = "Company must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Company cannot be longer than 50 characters.")]
        public string? Company { get; set; }


        /// <summary>
        /// Gets or sets the date and time when the user was created.
        /// </summary>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
    }
}