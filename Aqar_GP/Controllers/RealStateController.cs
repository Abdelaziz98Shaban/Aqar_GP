
using DataAccess.Respository.IRepository;

using Microsoft.AspNetCore.Mvc;
using Models;


namespace Aqar.controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Realstatecontroller : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webhostenvironment;

        public Realstatecontroller(IUnitOfWork unitOfWork, IWebHostEnvironment webhostenvironment)
        {
            _unitOfWork = unitOfWork;
            _webhostenvironment = webhostenvironment;
        }


        [HttpGet("all")]
        public IActionResult Index()
        {
            var response = _unitOfWork.Realstate.GetAll();
            if (response.Count() == 0)
            {
                return BadRequest("RealState List is Empty");
            }
            return Ok(response);
        }
        
        [HttpGet("status")]
        public IActionResult Status(string status)
        {
            var response = _unitOfWork.Realstate.GetByStatus(status);
            if (response.Count() == 0)
            {
                return BadRequest("RealState List is Empty");
            }
            return Ok(response);
        }

        [HttpPost("add")]
        public IActionResult Create(RealState realState)
        {
            if (realState is null)
            {
                return BadRequest("Could not Add Empty RealState");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Realstate.Add(realState);
                _unitOfWork.Save();
                return Ok(realState);

            }

            return BadRequest(ModelState);
        }
        [HttpPut("update/{id}")]
        public IActionResult Edit(RealState realState, [FromRoute] int id)
        {

            if (realState is null)
            {
                return BadRequest("Please Enter Updated information");

            }
            if (id == realState.Id)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Realstate.Update(realState);
                    _unitOfWork.Save();
                    return Ok(realState);

                }

            }
            else
            {
                return NotFound($"No RealState was found with ID: {id}");

            }

            return BadRequest(ModelState);
        }


        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int? id)
        {
            var realState = _unitOfWork.Realstate.GetById(realState => realState.Id == id);
            if (realState == null)
            {
                return NotFound($"No RealState was found with ID: {id}");

            }

            _unitOfWork.Realstate.Remove(realState);
            _unitOfWork.Save();
            return Ok(realState);
        }

        [HttpPost("AddTransaction")]
        public IActionResult ContactOwner(int Id)
        {
            Transactions transaction = new Transactions();

            transaction.RealstateId = Id;
            transaction.Date = DateTime.UtcNow;
            transaction.RealState = _unitOfWork.Realstate.GetById(x=> x.Id == Id);
            _unitOfWork.Transactions.Add(transaction);
            _unitOfWork.Save();
            return Ok();


        }


    }
}
