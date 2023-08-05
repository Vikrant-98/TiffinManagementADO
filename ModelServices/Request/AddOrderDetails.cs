namespace TiffinManagement.ModelServices.Request
{
    public class AddOrderDetails
    {
        public int TiffinId { get; set; }
        public int AddressId { get; set; }
        public string PaymentMode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class AddOrderDetailsResponse
    {
        public int TiffinId { get; set; }
        public int AddressId { get; set; }
        public string PaymentMode { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class UpdateOrder 
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
    }
}
