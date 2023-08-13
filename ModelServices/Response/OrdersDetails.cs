namespace TiffinManagement.ModelServices.Response
{
    public class OrdersDetails
    {
        public int OrderId { get; set; }
        public int TiffinId { get; set; }
        public string TiffinName { get; set; }
        public string TiffinDescription { get; set; }
        public string ImageURL { get; set; }
        public string Price { get; set; }
        public string OrderStatus { get; set; }
        public double TotalDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FirstName { get; set; }
    }
}
