namespace CarRentalSystem.Dealers.API.Models.CarAds.OutputModels
{
    public class CreateCarAdOutputModel
    {
        public CreateCarAdOutputModel(int id, string manufacturer, string model, int category, string imageUrl, decimal pricePerDay, bool hasClimateControl, int numberOfSeats, int transmissionType)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Category = category;
            this.ImageUrl = imageUrl;
            this.PricePerDay = pricePerDay;
            this.HasClimateControl = hasClimateControl;
            this.NumberOfSeats = numberOfSeats;
            this.TransmissionType = transmissionType;
        }

        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Category { get; set; }

        public string ImageUrl { get; set; }

        public decimal PricePerDay { get; set; }

        public bool HasClimateControl { get; set; }

        public int NumberOfSeats { get; set; }

        public int TransmissionType { get; set; }
    }
}
