
namespace Aqar_GP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("Update")]

        [Authorize]
        public async Task <IActionResult> Update(string Id, RegisterViewModel Model)
        {
            if (Model == null) return BadRequest("Please Enter valid information");

            var User = await _unitOfWork.Users.GetById(x=> x.Id == Id);
            if (User != null)
            {
                if (ModelState.IsValid)
                {
                    User.FirstName = Model.FirstName;
                    User.LastName = Model.LastName;
                    User.UserName = Model.Username;
                    User.Email = Model.Email;
                    User.Address = Model.Address;
                    User.PasswordHash = Model.Password;
                    User.MobileNumber = Model.MobileNumber;
                    _unitOfWork.Users.update(User);
                    _unitOfWork.Save();
                    return Ok(User);
                }
            }
            return BadRequest("User Not found ");
      
            
        }
    }
}
