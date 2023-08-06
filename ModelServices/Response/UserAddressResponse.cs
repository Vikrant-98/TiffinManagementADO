namespace TiffinManagement.ModelServices.Response
{
    public class UserAddressResponse
    {
        public int AddressId { get; set; }
        public string UserAddress { get; set; }
        public string Area { get; set; }
        public string Pin { get; set; }
        public string Address { get; set; }
    }

    public class AddressResponse
    {
        public int AddressId { get; set; }
        public string Area { get; set; }
        public string Pin { get; set; }
        public string Address { get; set; }
    }
}
