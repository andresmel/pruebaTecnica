namespace webApi.Models.Dtos
{
    public class PredictionOrderDto
    {
        public int custid { get; set; }
        public string ?CustomerName { get; set; }
        public DateTime ?LastOrderDate { get; set; }
        public DateTime ?NextPredictedOrder { get; set; }
    }
}
 