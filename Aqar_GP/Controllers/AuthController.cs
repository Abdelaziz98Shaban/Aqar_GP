
namespace Aqar_GP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("register")]

        public async Task<ActionResult> RegisterAsync(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _unitOfWork.Users.RegisterAsync(model);

            if (!response.IsAuthenticated)
                return BadRequest(response.Message);
            SetRefreshTokenInCookie(response.RefreshToken, response.RefreshTokenExpiration);

            return Ok(response);
        }


        [HttpPost("login")]

        public async Task<ActionResult> LoginAsync(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _unitOfWork.Users.LoginAsync(model);

            if (!response.IsAuthenticated)
                return BadRequest(response.Message);

            if (!string.IsNullOrEmpty(response.RefreshToken))
                SetRefreshTokenInCookie(response.RefreshToken, response.RefreshTokenExpiration);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _unitOfWork.Users.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }

        [HttpGet("refreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var result = await _unitOfWork.Users.RefreshTokenAsync(refreshToken);

            if (!result.IsAuthenticated)
                return BadRequest(result);

            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> RevokeToken([FromBody] LogoutViewModel model)
        {
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest("Token is required!");

            var result = await _unitOfWork.Users.RevokeTokenAsync(token);

            if (!result)
                return BadRequest("Token is invalid!");

            return Ok("logged out");
        }
        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime()
            };
            if(refreshToken is not null)
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}
