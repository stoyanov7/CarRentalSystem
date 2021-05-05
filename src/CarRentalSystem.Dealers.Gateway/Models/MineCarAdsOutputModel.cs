namespace CarRentalSystem.Dealers.Gateway.Models
{
    using System.Collections.Generic;

    public class MineCarAdsOutputModel
    {
        public IEnumerable<CarAdOutputModel> CarAds { get; set; }
    }
}
