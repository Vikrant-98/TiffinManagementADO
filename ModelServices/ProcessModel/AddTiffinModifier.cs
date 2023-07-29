using TiffinManagement.ModelServices.Request;

namespace TiffinManagement.ModelServices.ProcessModel
{
    public class AddTiffinModifier : AddTiffin
    {
        public string ImageUrl { get; set; }
        public int TiffinId { get; set; }
        public int TiffinAddress { get; set; }
    }
}
