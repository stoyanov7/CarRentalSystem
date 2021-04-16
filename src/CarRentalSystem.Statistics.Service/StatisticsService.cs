namespace CarRentalSystem.Statistics.Service
{
    using CarRentalSystem.Common.Service;
    using CarRentalSystem.Statistics.Service.Contracts;
    using CarRentalSystem.Statistics.Data.Models;
    using System.Threading.Tasks;
    using CarRentalSystem.Statistics.Data;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    public class StatisticsService : DataService<Statistics>, IStatisticsService
    {
        private readonly IMapper mapper;

        public StatisticsService(StatisticsContext context, IMapper mapper)
            : base(context)
        {
            this.mapper = mapper;
        }

        public async Task<TModel> Full<TModel>()
            => await this.mapper
                .ProjectTo<TModel>(this.All())
                .FirstOrDefaultAsync();
       
    }
}
