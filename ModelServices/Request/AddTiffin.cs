namespace TiffinManagement.ModelServices.Request
{
    public class AddTiffinRequest
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public int TiffinAddress { get; set; }
    }


    public class AddTiffinModifier : AddTiffinRequest
    {
        public int TiffinId { get; set; }
    }

    public class AddTiffin : AddTiffinRequest
    {
        public string ImageURL { get; set; }
    }
}
