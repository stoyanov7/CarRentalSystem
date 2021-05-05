namespace CarRentalSystem.Identity.Services.Contracts
{
    using CarRentalSystem.Data.Models;
    using System.Collections.Generic;

    public interface ITokenGeneratorService
    {
        string GenerateToken(User user, IEnumerable<string> roles = null);
    }
}
