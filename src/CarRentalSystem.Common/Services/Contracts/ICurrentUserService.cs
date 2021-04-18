namespace CarRentalSystem.Common.Service.Contracts
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        bool IsAdministrator { get; }
    }
}