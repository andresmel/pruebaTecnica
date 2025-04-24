namespace webApi.Models.Dtos
{
    public class postOrderDto
    {
        public int custid { get; set; }
        public int discount { get; set; }
        public int employee { get; set; }
        public int freight { get; set; }
        public DateTime orderDate { get; set; }
        public int product { get; set; }
         public short quantity { get; set; }

        public DateTime requiredDate { get; set; }

        public string shipAddress { get; set; }
        public string shipCity { get; set; }
        public string shipCountry { get; set; }

        public string shipName { get; set; }

        public DateTime shippedDate { get; set; }

        public int shipper { get; set; }

        public int unitPrice { get; set; }


    }
}
