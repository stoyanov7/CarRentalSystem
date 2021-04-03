namespace CarRentalSystem.Dealers.API.Models.Dealers.OutputModels
{
    using AutoMapper;
    using CarRentalSystem.Dealers.Data.Models;
    using System.Linq;

    public class DealerDetailsOutputModel : DealerOutputModel
    {
        public int TotalCarAds { get; private set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<Dealer, DealerDetailsOutputModel>()
                .IncludeBase<Dealer, DealerOutputModel>()
                .ForMember(d => d.TotalCarAds, cfg => cfg.MapFrom(d => d.CarAds.Count()));
    }
}
