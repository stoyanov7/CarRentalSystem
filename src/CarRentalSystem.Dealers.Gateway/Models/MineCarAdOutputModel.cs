namespace CarRentalSystem.Dealers.Gateway.Models
{
    using CarRentalSystem.Common.MappingProfiles;

    public class MineCarAdOutputModel : CarAdOutputModel, IMapFrom<CarAdOutputModel>
    {
        public int TotalViews { get; set; }
    }
}
