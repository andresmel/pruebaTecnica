using webApi.Models;

namespace webApi.Repositories.Interfaces
{
    public interface IShippersRepository
    {
        Task<ICollection<Shipper>> GetShipperAsync();
    }
}
