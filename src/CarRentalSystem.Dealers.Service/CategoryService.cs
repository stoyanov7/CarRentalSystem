﻿namespace CarRentalSystem.Dealers.Service
{
    using AutoMapper;
    using CarRentalSystem.Dealers.Data;
    using CarRentalSystem.Dealers.Data.Models;
    using CarRentalSystem.Dealers.Service.Contracts;
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
            var category = await this.DealersContext.Categories.FindAsync(categoryId);
            var model = this.mapper.Map<TModel>(category);

            return model;
        }
    }
}
