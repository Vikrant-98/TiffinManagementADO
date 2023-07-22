namespace TiffinManagement.ModelServices.Request
{
    public class DeliveryAddress
    {
        public string Address { get; set; }
        public string Area { get; set; }
        public string Pin { get; set; }
    }

    public class UserAddress
    {
        public string Address { get; set; }
        public int id { get; set; }
    }
}
