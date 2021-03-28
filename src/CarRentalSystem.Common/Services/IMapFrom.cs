namespace CarRentalSystem.Common.Services
{
    using AutoMapper;

    public interface IMapFrom<TModel>
    {
        void Mapping(Profile mapper) => mapper.CreateMap(typeof(TModel), this.GetType());
    }
}
