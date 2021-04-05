namespace CarRentalSystem.Dealers.API.Models.CarAds.OutputModels
{
    using AutoMapper;
    using CarRentalSystem.Dealers.API.Models.Dealers.OutputModels;
    using CarRentalSystem.Dealers.Data.Models;

    public class CarAdDetailsOutputModel : CarAdOutputModel
    {
        public bool HasClimateControl { get; private set; }

        public int NumberOfSeats { get; private set; }

        public string TransmissionType { get; private set; }

        public DealerOutputModel Dealer { get; set; }

        public override void Mapping(Profile profile)
        {          
            profile.CreateMap<CarAd, CarAdDetailsOutputModel>()
                .ForMember(m => m.Manufacturer, cfg => cfg.MapFrom(x => x.Manufacturer.Name))
                .ForMember(c => c.Category, cfg => cfg.MapFrom(x => x.Category.Name))
                .ForMember(c => c.HasClimateControl, cfg => cfg.MapFrom(x => x.Options.HasClimateControl))
                .ForMember(c => c.NumberOfSeats, cfg => cfg.MapFrom(x => x.Options.NumberOfSeats))
                .ForMember(c => c.TransmissionType, cfg => cfg.MapFrom(x => x.Options.TransmissionType))
                .ForMember(d => d.Dealer, cfg => cfg.MapFrom(x => x.Dealer));
        }
    }
}
