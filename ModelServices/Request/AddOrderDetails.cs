namespace TiffinManagement.ModelServices.Request
{
    public class AddOrderDetails
    {
        public int TiffinId { get; set; }
        public int AddressId { get; set; }
        public string PaymentMode { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class UpdateOrder 
    {
        public int OrderId { get; set; }
        public int DeliveryHolderId { get; set; }
        public string Status { get; set; }
    }
}
