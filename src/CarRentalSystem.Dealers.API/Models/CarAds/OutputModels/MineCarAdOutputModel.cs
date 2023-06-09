﻿namespace CarRentalSystem.Dealers.API.Models.CarAds.OutputModels
{
    using AutoMapper;
    using CarRentalSystem.Dealers.Data.Models;

    public class MineCarAdOutputModel : CarAdOutputModel
    {
        public bool IsAvailable { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<CarAd, MineCarAdOutputModel>()
                .IncludeBase<CarAd, CarAdOutputModel>();
    }
}
