namespace CarRentalSystem.Schedule.Services.Contracts
{
    using System.Threading.Tasks;

    public interface IRentedCarService
    {
        Task UpdateInformation(int carAdId, string manufacturer, string model);
    }
}
