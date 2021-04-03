namespace CarRentalSystem.Dealers.Service
{
    using AutoMapper;
    using CarRentalSystem.Dealers.Data;
    using CarRentalSystem.Dealers.Data.Models;
    using CarRentalSystem.Dealers.Service.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class ManufacturerService : DataService<Manufacturer>, IManufacturerService
    {
        private readonly IMapper mapper;

        public ManufacturerService(DealersContext dealersContext, IMapper mapper)
            : base(dealersContext)
        {
            this.mapper = mapper;
        }

        public async Task<TModel> FindByNameAsync<TModel>(string name)
        {
            var manufacturer = await this
                .DealersContext
                .Manufacturers
                .FirstOrDefaultAsync(m => m.Name == name);

            var model = this.mapper.Map<TModel>(manufacturer);

            return model;
        }
    }
}
