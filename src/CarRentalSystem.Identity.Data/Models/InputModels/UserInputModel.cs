namespace CarRentalSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static CarRentalSystem.Data.Constants.DataConstants;

    public class UserInputModel
    {
        [EmailAddress]
        [Required]
        [MinLength(MinEmailLength)]
        [MaxLength(MaxEmailLength)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
