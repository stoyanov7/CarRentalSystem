namespace CarRentalSystem.Identity.Services.Contracts
{
    using CarRentalSystem.Data.Models;

    public interface ITokenGeneratorService
    {
        string GenerateToken(User user);
    }
}
