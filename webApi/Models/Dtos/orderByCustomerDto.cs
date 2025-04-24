namespace webApi.Models.Dtos
{
    public class orderByCustomerDto
    {
        public int custid { get; set; }
        public string ?customerName { get; set; }
        public DateTime lastOrderDate { get; set; }
        public DateTime nextPredictedOrder { get; set; }
    }
}
