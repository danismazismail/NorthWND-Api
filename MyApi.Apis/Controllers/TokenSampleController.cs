using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyApi.DAL.Interfaces;
using MyApi.Dtos.LoginDTO;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyApi.Apis.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [AllowAnonymous]
    public class TokenSampleController : ControllerBase
    {
        private readonly IAuthDAL _authDAL;
        private readonly IConfiguration _conf;

        public TokenSampleController(IAuthDAL authDAL, IConfiguration conf)
        {
            _authDAL = authDAL;
            _conf = conf;
        }

        [HttpPost("~/api/userlogin")]
        public async Task<IActionResult> LoginPOST([FromBody] UserLoginDTO userinfo)
        {

            var user = _authDAL.Login(userinfo.UserName, userinfo.Password);

            if (user == null)
            {
                //ilk önce kayıt edilsin.
                await _authDAL.Register(new Core.User() { UserName = userinfo.UserName }, userinfo.Password);
                return null;
            }
            //token üret.

            var secretKey = Encoding.UTF8.GetBytes(_conf.GetSection("TokenSettings:TokenSignature").Value);

            var tokenDesc = new SecurityTokenDescriptor()
            {

                Expires = DateTime.Now.AddMinutes(20),
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,userinfo.UserName)
                //new Claim(ClaimTypes.Name,userinfo.UserName)
                //new Claim(ClaimTypes.Name,userinfo.UserName)
                //new Claim(ClaimTypes.Name,userinfo.UserName)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha512Signature)

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var secureToken = tokenHandler.CreateToken(tokenDesc);
            string token = tokenHandler.WriteToken(secureToken);

            return Ok(token);

        }

        [HttpPost("~/api/userregister")]
        public async Task<IActionResult> RegisterPOST([FromBody] UserLoginDTO userinfo)
        {
            var user = await _authDAL.Register(new Core.User() { UserName = userinfo.UserName }, userinfo.Password);
            if (user == null)
            {
                return BadRequest("böyle bir kullanıcı zaten var. başka bir username ile kayıt olmayı deneyiniz. ");

            }

            //  return Ok(user);
            //created  
            return StatusCode(201);
        }





    }
}
