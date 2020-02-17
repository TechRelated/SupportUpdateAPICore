using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SupportUpdateAPICore.Data;
using SupportUpdateAPICore.Models;


namespace SupportUpdateAPICore.Controllers
{
    //here in this line, we are declaring the route path for API.
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        //here in this line, we are injecting the user manager.
        private UserManager<ApplicationUser> _userManager;

        public AuthenticateController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            //here in this line, we are getting the specific user.
            var user = await _userManager.FindByNameAsync(model.USER_NAME);

            //here in this line, we are checking the user value and password. If the condition is true, 
            //then we will generate the token otherwise it will return Unauthorized response
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //here in these lines, we are creating claims.
                var authClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                //here in this line, we are creating signing key.
                var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("SecureKey1234567890123456789012345678901234567890123456789012345678901234567890"));

                //here in this block of code, we are generating token using JWT.
                var token = new JwtSecurityToken(
                    issuer: "http://localhost:59001",
                    audience: "http://localhost:59001",
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                //here in this block, we are returning the ok status with token 
                //and expiration time after generating token successfully.
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
    }
 }