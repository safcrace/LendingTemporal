using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Infrastructure.Data.DBContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config, ApplicationDbContext dbContext, UserManager<AppUser> userManager)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<object> CreateToken(AppUser user)
        {
            /** Se registra Sesión de Usuario **/
            var lastSession = await _dbContext.Sesiones.Where(s => s.AppUserId == user.Id).OrderByDescending(s => s.Id).FirstOrDefaultAsync();

            if (lastSession is null)
            {
                var userFirstSession = new Sesion
                {
                    TipoBitacoraId = 1,
                    AppUserId = user.Id,
                    Token = "Registro de Usuario en Sesiones"
                };
                _dbContext.Sesiones.Add(userFirstSession);
                await _dbContext.SaveChangesAsync();
                lastSession = _dbContext.Sesiones.Where(s => s.AppUserId == user.Id).OrderByDescending(s => s.Id).FirstOrDefault();
            }

            if (lastSession?.TipoBitacoraId == 1)
            {
                var userSessionClose = new Sesion
                {
                    TipoBitacoraId = 2,
                    AppUserId = user.Id,
                    Token = "Token Vencido."
                };

                _dbContext.Sesiones.Add(userSessionClose);
                await _dbContext.SaveChangesAsync();
            }


            var claims = new List<Claim>
            {
                new Claim("UserName", user.UserName),   
                new Claim("UserId", user.Id)
            };

            var usuario = await _userManager.FindByEmailAsync(user.Email);
            var claimsDB = await _userManager.GetClaimsAsync(usuario);

            claims.AddRange(claimsDB);

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["Token:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            /** Se registra sessión del usuario **/
            var userSession = new Sesion
            {
                TipoBitacoraId = 1,
                AppUserId = user.Id,
                Token = tokenHandler.WriteToken(token)
            };
            _dbContext.Sesiones.Add(userSession);
            await _dbContext.SaveChangesAsync();

            return new { token = tokenHandler.WriteToken(token), expiration = tokenDescriptor.Expires };
        }
    }
}
