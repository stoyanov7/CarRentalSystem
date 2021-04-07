namespace CarRentalSystem.Dealers.Service
{
    using AutoMapper;
    using CarRentalSystem.Common.Service;
    using CarRentalSystem.Dealers.Data;
    using CarRentalSystem.Dealers.Data.Models;
    using CarRentalSystem.Dealers.Service.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoryService : DataService<Category>, ICategoryService
    {
        private readonly IMapper mapper;

        public CategoryService(DealersContext dealersContext, IMapper mapper)
            : base(dealersContext)
        {
            this.mapper = mapper;
        }

        public async Task<TModel> FindByIdAsync<TModel>(int categoryId)
        {
            var category = await this
                .Context
                .FindAsync<Category>(categoryId);

            var model = this.mapper.Map<TModel>(category);

            return model;
        }

        public async Task<IEnumerable<TModel>> GetAll<TModel>()
            => await this.mapper
                .ProjectTo<TModel>(this.All())
                .ToListAsync();
    }
}
