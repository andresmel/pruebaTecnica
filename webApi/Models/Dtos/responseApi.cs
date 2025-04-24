namespace webApi.Models.Dtos
{
    public class responseApi
    {
        public int status { get; set; }
        public dynamic ?data { get; set; }
        public string ?message { get; set; }

        //public responseApi(int status, dynamic data, string message) { 
        // this.status = status;
        //    this.data = data;
        //    this.message = message;
        //}
    }
}
