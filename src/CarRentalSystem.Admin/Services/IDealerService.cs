namespace CarRentalSystem.Admin.Services
{
    using CarRentalSystem.Admin.Models.Dealers;
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDealerService
    {
        [Get("/Dealers/GetAllDealers")]
        Task<IEnumerable<DealerDetailsOutputModel>> GetAllDealersAsync();

        [Get("/Dealers/Details/{id}")]
        Task<DealerDetailsOutputModel> GetDetailsAsync(int id);

        [Put("/Dealers/Edit/{id}")]
        Task Edit(int id, DealerInputModel dealerInputModel);
    }
}
