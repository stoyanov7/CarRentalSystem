namespace CarRentalSystem.Common
{
    public class DataConstants
    {
        public const int MinDescriptionLength = 20;

        public const int MaxDescriptionLength = 1000;

        public const int MinNameLength = 2;

        public const int MaxNameLength = 20;

        public const int MinModelLength = 2;

        public const int MaxModelLength = 20;

        public const int MaxUrlLength = 2048;

        public const int MaxPhoneNumberLength = 20;

        public const int MinPhoneNumberLength = 5;

        public const string PhoneNumberRegularExpression = @"\+[0-9]*";

        public const int MinNumberOfSeats = 2;

        public const int MaxNumberOfSeats = 50;
    }
}
