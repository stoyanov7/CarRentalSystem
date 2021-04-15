namespace CarRentalSystem.Common.Services.Contracts
{
    public interface ICurrentTokenService
    {
        string Get();

        void Set(string token);
    }
}
