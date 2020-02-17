using Microsoft.IdentityModel.Tokens;
using NUnit.Framework;
using SupportUpdateAPICore.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace SupportUpdateAPICore
{
    public class TokenProvider
    {
        //Using hard coded collection list as Data Store for demo purposes
        //In reality, User data comes from Database or other Data Source.
        List<User> UserList = new List<User>()
        {
            new User
            {
                USER_NAME = "jsmith@email.com",
                PASSWORD = "test",
                EMAILID = "jsmith@email.com",
                FIRST_NAME = "John",
                LAST_NAME = "Smith",
                PHONE = "356-735-2748",
                ACCESS_LEVEL = "Director",
                READ_ONLY = "true"
            },

            new User
            {
                USER_NAME = "srob@email.com",
                PASSWORD = "test",
                FIRST_NAME = "Steve",
                LAST_NAME = "Rob",
                EMAILID = "srob@email.com",
                PHONE = "567-479-8537",
                ACCESS_LEVEL = "Supervisor",
                READ_ONLY = "false"
            },

            new User
            {
                USER_NAME = "dwill@email.com",
                PASSWORD = "test",
                FIRST_NAME = "DJ",
                LAST_NAME = "Will",
                EMAILID = "dwill@email.com",
                PHONE = "599-306-6010",
                ACCESS_LEVEL = "Analyst",
                READ_ONLY = "false"
            },

            new User
            {
                USER_NAME = "JBlack@email.com",
                PASSWORD = "test",
                FIRST_NAME = "Joe",
                LAST_NAME = "Black",
                EMAILID = "JBlack@email.com",
                PHONE = "764-460-8610",
                ACCESS_LEVEL = "Analyst",
                READ_ONLY = "true"
            }

        };

        //Using hard coded values in claims collection list as Data Store for demo. 
        //In reality, User data comes from Database or other Data Source.
        private IEnumerable<Claim> GetUserClaims(User user)
        {
            IEnumerable<Claim> claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.FIRST_NAME + " " + user.LAST_NAME),
                new Claim("USER_NAME", user.USER_NAME),
                new Claim("EMAILID", user.EMAILID),
                new Claim("PHONE", user.PHONE),
                new Claim("ACCESS_LEVEL", user.ACCESS_LEVEL.ToUpper()),
                new Claim("READ_ONLY", user.READ_ONLY.ToUpper())
            };
         return claims;
        }

        public string LoginUser(string USER_NAME, string Password)
        {
            //Get user details for the user who is trying to login
            //var user = UserList.AsEnumerable<User>().SingleOrDefault(x => x.USER_NAME == USER_NAME);
            var user = UserList.Where(x => x.USER_NAME.Equals(USER_NAME)).FirstOrDefault();
            // var user = UserList.Where(x => x.USER_NAME == USER_NAME).ToList();

            //Authenticate User, Check if it’s a registered user in Database 
            if (user == null)
                return null;

            //If it is registered user, check user password stored in Database
            //For demo, password is not hashed. It is just a string comparision 
            //In reality, password would be hashed and stored in Database. 
            //Before comparing, hash the password again.
            if (Password == user.PASSWORD)
            {
                //Authentication successful, Issue Token with user credentials 
                //Provide the security key which is given in 
                //Startup.cs ConfigureServices() method 
                var key = System.Text.Encoding.ASCII.GetBytes
                ("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");
                //Generate Token for user 
                var JWToken = new JwtSecurityToken(
                    issuer: "http://localhost:45092/",
                    audience: "http://localhost:45092/",
                    claims: GetUserClaims(user),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                    //Using HS256 Algorithm to encrypt Token  
                    signingCredentials: new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );
                var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                return token;
            }
            else
            {
                return null;
            }
        }
    }
}
