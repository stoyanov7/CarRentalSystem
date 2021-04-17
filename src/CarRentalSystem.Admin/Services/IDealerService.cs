namespace CarRentalSystem.Admin.Services
{
    using CarRentalSystem.Admin.Models;
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDealerService
    {
        [Get("/Dealers/GetAllDealers")]
        Task<IEnumerable<DealerDetailsOutputModel>> GetAllDealersAsync();
    }
}
