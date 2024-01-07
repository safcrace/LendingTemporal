using API.Dtos;
using API.DTOs;
using API.Errors;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Infrastructure.Data.DBContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly ApplicationDbContext _dbContext;

        public AccountController(UserManager<AppUser> userManager, 
                                 SignInManager<AppUser> signInManager, 
                                 ITokenService tokenService, 
                                 IMapper mapper, 
                                 IMailService mailService,
                                 ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _mailService = mailService;
            _dbContext = dbContext;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<object>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailFromClaimsPrinciple(User);

            return await _tokenService.CreateToken(user);

        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync(string? email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }        


        [HttpPost("login")]
        public async Task<ActionResult<object>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return Unauthorized(new ApiResponse(401));
            }



            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized(new ApiResponse(401));
            }

            return await _tokenService.CreateToken(user);                       
        }

        [HttpPost("register")]
        public async Task<ActionResult<object>> Register(RegisterDto registerDto)
        {
            if(CheckEmailExistsAsync(registerDto.Email).Result.Value)
            {
                return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = new[] { "Cuenta de Correo Electrónico ya se encuentra en uso!" } });
            }


            var user =  new AppUser
            {                
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400));
            }

            return await _tokenService.CreateToken(user);
        }

        [HttpPost("user/forgotPassword")]
        public async Task<ActionResult<Object>> ForgotPassword(ForgotPasswordDto forgotPassword)
        {
            var user = await _userManager.FindByEmailAsync(forgotPassword.Email);

            if (user == null)
            {
                return BadRequest("Please check your username to reset your password");
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var url = $"http://localhost:3000/#/reset-password?appUserId={user.Id}&code={code}";

            /** Envío de Correo Electróncio **/
            string to = forgotPassword.Email;
            string subject = "Reset Password";
            string body = $"<h3>Dear User:</h3>" +
                           $"<p>Please reset your password by clicking here: </p>" +
                           $"<a href='{url}'>Reset Password</a>" +
                           $"<h4>Thank you for using our platform.</h4>";

            await _mailService.SendEmailAsync(to, subject, body);

            return Ok(new { message = "Please check your mail!!" });

        }


        [HttpPost("user/resetPassword")] //$inFin@2024
        public async Task<ActionResult> ResetPassword(ResetPasswordDto resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            //var user = await _userManager.FindByIdAsync("f07c7f0c-83f8-4a3f-b5dc-42a35f645076");

            if (user == null)
            {
                return BadRequest("An error has occurred. Please redo the process.");
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, code, resetPassword.Password);

            if (result.Succeeded)
            {
                return Ok(new { message = "Su Password se ha cambiado satisfactoriamente!!" });
            }

            return BadRequest("Ha ocurrido un error por favor contacte al administrador del Sistema.");
        }

        [HttpGet("user/confirmMail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null | code == null)
            {
                return BadRequest("An error has occurred. Please redo the process");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return BadRequest("An error has occurred. User not exist");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            return Ok(new { message = result.Succeeded ? "Succsesful Action" : "An Error has ocurred" });
        }
        
        //[HttpGet("token/is-valid/{token}")]
        //public async Task<IActionResult> TokenIsValid(string token, string appUserId)
        //{
        //    if (appUserId is null)
        //    {
        //        return BadRequest("Parámetros inválidos");
        //    }

        //    var currentUser = await _dbContext.Sessions.Where(s => s.AppUserId == appUserId).Select(s => new { s.Id, s.Token, s.TipoBitacoraId }).OrderByDescending(s => s.Id).FirstOrDefaultAsync();

        //    if (currentUser is null)
        //    {
        //        return BadRequest($"El Usuario no ha abierto sesión.");
        //    }
        //    if (currentUser.TipoBitacoraId != 1)
        //    {
        //        return BadRequest($"El Usuario no tiene una sesión abierta.");
        //    }
        //    if (currentUser.Token != token)
        //    {
        //        return BadRequest($"El Token no es válido para la Sesión Actual.");
        //    }

        //    var person = await _dbContext.Persons.Where(p => p.AppUserId == appUserId).Select(s => new { s.Id, s.AreaId }).FirstOrDefaultAsync();            

        //    return Ok(new { isValid = true, personId = person?.Id, areadId = person?.AreaId, canKillFile = true });
        //}

        [HttpPost("logout")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> LogOff()
        {
            var idClaim = HttpContext.User.Claims.Where(claim => claim.Type == "UserId").FirstOrDefault();
            var userId = idClaim?.Value;

            var userSessionClose = new Sesion
            {
                TipoBitacoraId = 2,
                AppUserId = userId,
                Token = "Token Vencido."
            };

            _dbContext.Sesiones.Add(userSessionClose);
            await _dbContext.SaveChangesAsync();

            await _signInManager.SignOutAsync();
            //HttpContext.Session.Remove("SessionName");
            return Ok(new { message = "Successful Action" });
        }
    }
}
