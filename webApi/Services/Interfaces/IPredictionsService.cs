using webApi.Models.Dtos;

namespace webApi.Services.Interfaces
{
    public interface IPredictionsService
    {
        Task<ICollection<PredictionOrderDto>> GetPredictionOrderAsync();

        Task<ICollection<PredictionOrderDto>> GetPredictionByCustomeName(PredictionOrderDto datos);
    }
}
