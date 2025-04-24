using webApi.Models.Dtos;
using webApi.Repositories.Interfaces;
using webApi.Services.Interfaces;
using System.Text.Json;

namespace webApi.Services
{
    public class PredictionsService:IPredictionsService
    {
        private readonly IPredictionsRepository _predictionRepository;
        private readonly Dictionary<string, string> ?_queries;
        public PredictionsService(IPredictionsRepository _predictionRepository) {
            this._predictionRepository = _predictionRepository;
            var json = File.ReadAllText("Queries/queries.json");
            this._queries = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        }

        public async Task<ICollection<PredictionOrderDto>> GetPredictionOrderAsync()
        {
            try
            {
                var query = this._queries["queryPredictions"];
                return await _predictionRepository.GetPredictionOrderAsync(query);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error processing order", ex);
            }
        }

        public async Task<ICollection<PredictionOrderDto>> GetPredictionByCustomeName(PredictionOrderDto datos)
        {
            try
            {
                var query = this._queries["queryPredictions"];
                ICollection<PredictionOrderDto> order= await _predictionRepository.GetPredictionOrderAsync(query);
                return order.Where(o => o.CustomerName != null &&
                        o.CustomerName.Contains(datos.CustomerName, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error processing order", ex);
            }
        }
    }
}
