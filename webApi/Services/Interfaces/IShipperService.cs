using webApi.Models.Dtos;

namespace webApi.Services.Interfaces
{
    public interface IShipperService
    {
        Task<ICollection<ShipperDto>> GetShipperAsync();
    }
}
