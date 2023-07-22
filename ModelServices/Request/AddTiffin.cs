namespace TiffinManagement.ModelServices.Request
{
    public class AddTiffin
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string Address { get; set; }
    }
}
