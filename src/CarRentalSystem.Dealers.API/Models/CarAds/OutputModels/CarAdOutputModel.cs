﻿namespace CarRentalSystem.Dealers.API.Models.CarAds.OutputModels
{
    using AutoMapper;
    using CarRentalSystem.Common.MappingProfiles;
    using CarRentalSystem.Dealers.Data.Models;

    public class CarAdOutputModel : IMapFrom<CarAd>
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public decimal PricePerDay { get; set; }

        public virtual void Mapping(Profile prifile)
            => prifile
                .CreateMap<CarAd, CarAdOutputModel>()
                .ForMember(ad => ad.Manufacturer, cfg => cfg.MapFrom(ad => ad.Manufacturer.Name))
                .ForMember(ad => ad.Category, cfg => cfg.MapFrom(ad => ad.Category.Name));
    }
}
