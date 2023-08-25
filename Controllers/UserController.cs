using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TiffinManagement.Business.Interface;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;
using TiffinManagement.Repository.Services;

namespace TiffinManagement.Controllers
{
    public class UserController : Controller
    {
        private IUserBusiness _userBusiness;
        private IConfiguration _configuration;
        public UserController(IUserBusiness userBusiness, IConfiguration configuration) 
        {
            _userBusiness = userBusiness;
            _configuration = configuration;
        }
        [HttpPost("UserLogin")]
        public async Task<LoginResponse> UserLogin([FromBody] UserLogin User)
        {
            try
            {
                string? token = string .Empty;
                Login? Result = await _userBusiness.UserLogin(User).ConfigureAwait(false);
                if (Result != null)
                {
                    token = GenerateToken(Result);
                    
                }
                LoginResponse loginResponse = new LoginResponse()
                {
                    LoginData = Result,
                    Token = token
                };

                return loginResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("UserRegistration")]
        public async Task<AddResponse> UserRegistration([FromBody] UserRegistration User)
        {
            try
            {

                AddResponse? Result = await _userBusiness.AddUser(User).ConfigureAwait(false);              
                
                return Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("UpdateUser")]
        [Authorize(Roles = "Customer")]
        public async Task<AddResponse> UpdateUser([FromBody] User User)
        {
            AddResponse? Result = new AddResponse();
            try
            {
                var user = HttpContext.User;
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);
                Result = await _userBusiness.UpdateUser(User, userId).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        [HttpPost("AddUserAddress")]
        [Authorize(Roles = "Customer")]
        public async Task<AddResponse> AddUserAddress([FromBody] UserAddress UserAddress)
        {
            AddResponse? Result = new AddResponse();
            try
            {
                var user = HttpContext.User;
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);
                Result = await _userBusiness.AddUserAddress(UserAddress, userId).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        [HttpPost("AddAddress")]
        [Authorize(Roles = "Admin")]
        public async Task<AddResponse> AddAddress([FromBody] TiffinAddress UserAddress)
        {
            AddResponse? Result = new AddResponse();
            try
            {
                var user = HttpContext.User;
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);
                Result = await _userBusiness.AddAddress(UserAddress, userId).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        [HttpGet("GetRoleBaseDetails")]
        [Authorize(Roles = "Admin")]
        public async Task<List<Login>> GetRoleBaseDetails(string UserType)
        {
            List<Login>? Result = new List<Login>();
            try
            {
                Result = await _userBusiness.GetRoleBaseDetails(UserType).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        [HttpGet("GetActiveUserDetail")]
        [Authorize(Roles = "Admin")]
        public async Task<List<Login>> GetActiveUserDetail()
        {
            List<Login>? Result = new List<Login>();
            try
            {
                Result = await _userBusiness.GetUserActiveDetails().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        private string GenerateToken(Login Info)
        {
            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, Info.Role.ToString()),
                    new Claim("EmailID", Info.EmailId.ToString()),
                    new Claim("UserID", Info.Id.ToString())
                };
                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                    _configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingCreds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
