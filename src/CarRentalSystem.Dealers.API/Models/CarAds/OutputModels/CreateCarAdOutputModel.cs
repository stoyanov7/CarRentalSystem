namespace CarRentalSystem.Dealers.API.Models.CarAds.OutputModels
{
    public class CreateCarAdOutputModel
    {
        public CreateCarAdOutputModel(int carAdId) => this.CarAdId = carAdId;

        public int CarAdId { get; }
    }
}
