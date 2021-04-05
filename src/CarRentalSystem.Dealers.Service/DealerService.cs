namespace CarRentalSystem.Dealers.Service
{
    using AutoMapper;
    using CarRentalSystem.Dealers.Data;
    using CarRentalSystem.Dealers.Data.Models;
    using CarRentalSystem.Dealers.Service.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class DealerService : DataService<Dealer>, IDealerService
    {
        private readonly IMapper mapper;

        public DealerService(DealersContext dealersContext, IMapper mapper)
            : base(dealersContext)
        {
            this.mapper = mapper;
        }

        public async Task<TModel> GetDetailsAsync<TModel>(int id)
            => await this.mapper
                .ProjectTo<TModel>(this.All().Where(d => d.Id == id))
                .FirstOrDefaultAsync();

        public async Task<Dealer> FindByUserAsync(string userId) => await this.FindByUserAsync(userId, dealer => dealer);

        public async Task<bool> IsDealerAsync(string userId) => await this.All().AnyAsync(d => d.UserId == userId);

        public Task<int> GetDealerIdByUserIdAsync(string userId) => this.FindByUserAsync(userId, dealer => dealer.Id);

        public async Task<bool> HasCarAd(int dealerId, int carAdId)
            => await this
                .All()
                .Where(d => d.Id == dealerId)
                .AnyAsync(d => d.CarAds.Any(c => c.Id == carAdId));

        private async Task<T> FindByUserAsync<T>(string userId, Expression<Func<Dealer, T>> selector)
        {
            var dealerData = await this
                .DealersContext
                .Dealers
                .Where(u => u.UserId == userId)
                .Select(selector)
                .FirstOrDefaultAsync();

            if (dealerData == null)
            {
                throw new InvalidOperationException("This user is not a dealer.");
            }

            return dealerData;
        }
    }
}
