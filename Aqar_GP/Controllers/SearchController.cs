using DataAccess.Respository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.viewModel;

namespace Aqar_GP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webhostenvironment;

        public SearchController(IUnitOfWork unitOfWork, IWebHostEnvironment webhostenvironment)
        {
            _unitOfWork = unitOfWork;
            _webhostenvironment = webhostenvironment;
        }
        [HttpPost]
        public async Task<IActionResult> Search(RealStateVm param)
        {
            var result = await _unitOfWork.Realstate.SearchByProp(param);
            if(result.Count() == 0)
            {
                return NotFound("no result found");
            }
            return Ok(result);
        }

    }
}
