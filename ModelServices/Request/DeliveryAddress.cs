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

    public class User
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Password { get; set; } 
        public string Role { get; set; } 
        public string AadharNumber { get; set; } 
    }
    public class UserRegistration : User
    {
        public string EmailID { get; set; }
    }

    public class UpdateUser : UserRegistration 
    {
        public int Id { get; set; }
    }

    public class UserLogin 
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
