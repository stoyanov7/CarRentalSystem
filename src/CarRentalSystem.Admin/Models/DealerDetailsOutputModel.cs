namespace CarRentalSystem.Admin.Models
{
    public class DealerDetailsOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public int TotalCarAds { get; private set; }
    }
}
