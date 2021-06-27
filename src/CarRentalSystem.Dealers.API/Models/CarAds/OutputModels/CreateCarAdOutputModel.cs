namespace CarRentalSystem.Dealers.API.Models.CarAds.OutputModels
{
    using AutoMapper;
    using CarRentalSystem.Common.MappingProfiles;
    using CarRentalSystem.Dealers.Data.Models;

    public class CreateCarAdOutputModel : IMapFrom<CarAd>
    {       
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Category { get; set; }

        public string ImageUrl { get; set; }

        public decimal PricePerDay { get; set; }

        public bool HasClimateControl { get; set; }

        public int NumberOfSeats { get; set; }

        public int TransmissionType { get; set; }

        public void Mapping(Profile profile)
            => profile
                .CreateMap<CarAd, CreateCarAdOutputModel>()
                .ForMember(ad => ad.Manufacturer, cfg => cfg.MapFrom(ad => ad.Manufacturer.Name))
                .ForMember(ad => ad.Category, cfg => cfg.MapFrom(ad => ad.Category.Id))
                .ForMember(ad => ad.HasClimateControl, cfg => cfg.MapFrom(ad => ad.Options.HasClimateControl))
                .ForMember(ad => ad.NumberOfSeats, cfg => cfg.MapFrom(ad => ad.Options.NumberOfSeats))
                .ForMember(ad => ad.TransmissionType, cfg => cfg.MapFrom(ad => ad.Options.TransmissionType))
                .ReverseMap();
    }
}
