using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TaskManagement.Models;
using TaskManagement.Services;
using System.Text;
using System.Security.Cryptography;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private Iuserservice _userservice;
        private IConfiguration _configuration;
        public UserController(Iuserservice userservice,IConfiguration configuration)
        {
            _userservice = userservice;
            _configuration = configuration;
        }
        [Authorize(Roles ="admin")]
        [HttpGet]
        public IActionResult Get_all()
        {
            return Ok(_userservice.GetUsers());
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public IActionResult Get_id(int id)
        {
            
            try
            {
                var user = _userservice.GetUser_id(id);

                return Ok(user);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login__(Login login)
        {
            try
            {
                var user = _userservice.Login_(login);
                string token = GetToken(user);
                return Ok(new { Token = token });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles ="admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userservice.Delete_User(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Register(Userscs user)
        {
            
            try
            {
                var exist = _userservice.Registration(user);
                if (exist != null)
                {
                    return BadRequest("please login");
                }
                return CreatedAtAction(nameof(Get_id),new {id= user.Id},user);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string GetToken(Userscs user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var  claim = new[]
            {
                //new Claim(JwtRegisteredClaimNames.Sub,user.Name),
                //new Claim(JwtRegisteredClaimNames.Jti,user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role),
            };
            //var token_des = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(claim),
            //    Expires = DateTime.UtcNow.AddDays(1),
            //    //Issuer = _configuration["Jwt:Issuer"],
            //    //Audience = _configuration["Jwt:Audience"]

            //};

            var token = new JwtSecurityToken(
                claims: claim,
                signingCredentials: credential,
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],

                expires: DateTime.Now.AddDays(1));
            /*var tokenhandler = new JwtSecurityTokenHandler();
            var token = tokenhandler.CreateToken(token_des);
            return  tokenhandler.WriteToken(token) ;*/

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
}
