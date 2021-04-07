namespace CarRentalSystem.Statistics.Service
{
    using AutoMapper;
    using CarRentalSystem.Common.Service;
    using CarRentalSystem.Statistics.Data;
    using CarRentalSystem.Statistics.Data.Models;
    using CarRentalSystem.Statistics.Service.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarAdViewService : DataService<CarAdView>, ICarAdViewService
    {
        private readonly IMapper mapper;

        public CarAdViewService(StatisticsContext statisticsContext, IMapper mapper)
            : base(statisticsContext)
        {
            this.mapper = mapper;
        }

        public async Task<int> GetTotalViews(int carAdId)
            => await this
                .All()
                .CountAsync(v => v.CarAdId == carAdId);

        public async Task<IEnumerable<TModel>> GetTotalViews<TModel>(IEnumerable<int> ids)
        {
            var result = await this
                           .All()
                           .Where(v => ids.Contains(v.CarAdId))
                           .GroupBy(v => v.CarAdId)
                           .Select(gr => new
                           {
                               CarAdId = gr.Key,
                               TotalViews = gr.Count()
                           })
                           .ToListAsync();

            var model = this.mapper.Map<IEnumerable<TModel>>(result);

            return model;
        }
    }
}
