namespace TiffinManagement.ModelServices.Response
{
    public class AddResponse
    {
        public string Message  { get; set; }
        public int Status { get; set; }
    }

    public class LoginResponse 
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string EmailId { get; set; } 
        public string AadharNumber { get; set; } 
        public string Role { get; set; } 
    }

    
}
