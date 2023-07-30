namespace TiffinManagement.ModelServices.Response
{
    public class AddResponse
    {
        public string Message  { get; set; }
        public int Status { get; set; }
    }

    public class Login 
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string EmailId { get; set; } 
        public string AadharNumber { get; set; } 
        public string Role { get; set; } 
    }
    public class LoginResponse 
    {
        public Login LoginData { get; set; }
        public string Token { get; set; }
    }

    
}
