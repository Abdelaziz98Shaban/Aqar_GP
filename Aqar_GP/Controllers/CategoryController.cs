
using DataAccess.Respository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Web.Http;

namespace Aqar.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("all")]
        public  IActionResult Index()
        {
            var response = _unitOfWork.Category.GetAll();
            if(response.Count() == 0)
            {
                return BadRequest("Category List is Empty");
            }
            return Ok(response);
        }
        
      

        [Microsoft.AspNetCore.Mvc.HttpPost("Add")]
        public IActionResult Create(Category category)
        {
            if(category is null)
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


        [Microsoft.AspNetCore.Mvc.HttpPost("Edit")]
        public IActionResult Edit(Category category,[FromUri]int id)
        {
            if(category is null)
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
                return BadRequest("No Category found with such an id");

            }

            return BadRequest(ModelState);
        }

        //POST
        [Microsoft.AspNetCore.Mvc.HttpPost("Delete")]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Category.GetById(c => c.Id == id);
            if (obj == null)
            {
                return BadRequest("Category Not Found");

            }

            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            return Ok("Category Deleted Successefully");
        }

    }
}
