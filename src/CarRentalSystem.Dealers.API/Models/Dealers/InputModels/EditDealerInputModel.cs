﻿namespace CarRentalSystem.Dealers.API.Models.Dealers.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using static CarRentalSystem.Common.DataConstants;

    public class EditDealerInputModel
    {
        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(MinPhoneNumberLength)]
        [MaxLength(MaxPhoneNumberLength)]
        [RegularExpression(PhoneNumberRegularExpression)]
        public string PhoneNumber { get; set; }
    }
}
