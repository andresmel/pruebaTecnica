using webApi.Models;
using webApi.Models.Dtos;
using webApi.Repositories.Interfaces;
using webApi.Services.Interfaces;

namespace webApi.Services
{
    public class ShippersService:IShipperService
    {
        private readonly IShippersRepository _shipperRepository;
        public ShippersService(IShippersRepository _repository) {
             this._shipperRepository = _repository;
        }

        public async Task<ICollection<ShipperDto>> GetShipperAsync()
        {
            try
            {
                ICollection<Shipper> shiper = await this._shipperRepository.GetShipperAsync();
                return shiper.Select(o => new ShipperDto
                {
                    Shipperid = o.Shipperid,
                    Companyname = o.Companyname,
                }).ToList();
            }
            catch (Exception ex) {
                throw new ApplicationException("Error processing order", ex);
            }
        }
    }
}
