

namespace Aqar_GP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchController(IUnitOfWork unitOfWork, IWebHostEnvironment webhostenvironment)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> Search(RealStateSearchVM param)
        {
            var result = await _unitOfWork.Realstate.SearchByProp(param);
           
            return Ok(result);
        }

    }
}
