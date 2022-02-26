
using DataAccess.Respository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Models;

namespace Aqar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Index()
        {
            var response = await _unitOfWork.Category.GetAllCategories();
            if (response.Count() == 0)
            {
                return  BadRequest("Category List is Empty");
            }
            return Ok(response);
        }



        [HttpPost("add")]
        public IActionResult Create(Category category)
        { 
            //category.Id= Guid.NewGuid().ToString();
            if (category is null)
            {
                return BadRequest("Could not Add Empty Category");
            }
           
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                return Ok(category);

            }

            return BadRequest(ModelState);
        }


        [HttpPut("update/{id}")]
        public IActionResult Edit(Category category, [FromRoute] string id)
        {

            if (category is null)
            {
                return BadRequest("Please Enter Updated information");

            }
            if (id == category.Id)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Category.Update(category);
                    _unitOfWork.Save();
                    return Ok(category);

                }

            }
            else
            {
                return NotFound($"No category was found with ID: {id}");

            }

            return BadRequest(ModelState);
        }

        //POST
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var category = await _unitOfWork.Category.GetById(c => c.Id == id);
            if (category == null)
            {
                return NotFound($"No category was found with ID: {id}");

            }

            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            return Ok(category);
        }

    }
}
