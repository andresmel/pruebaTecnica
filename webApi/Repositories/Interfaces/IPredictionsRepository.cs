using webApi.Models.Dtos;

namespace webApi.Repositories.Interfaces
{
    public interface IPredictionsRepository
    {
        Task<ICollection<PredictionOrderDto>> GetPredictionOrderAsync(string query);
    }
}
