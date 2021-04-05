﻿namespace CarRentalSystem.Dealers.API.Models.Categories
{
    using AutoMapper;
    using CarRentalSystem.Common.Services;
    using CarRentalSystem.Dealers.Data.Models;
    using System.Linq;

    public class CategoryOutputModel : IMapFrom<Category>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public int TotalCarAds { get; set; }

        public void Mapping(Profile profile)
            => profile
                .CreateMap<Category, CategoryOutputModel>()
                .ForMember(c => c.TotalCarAds, cfg => cfg.MapFrom(c => c.CarAds.Count()));
    }
}
