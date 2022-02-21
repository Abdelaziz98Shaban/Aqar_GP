
using DataAccess.Respository.IRepository;
using Microsoft.AspNetCore.Mvc;
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
        public  IActionResult Index()
        {
            var response = _unitOfWork.Category.GetAll();
            if(response.Count() == 0)
            {
                return BadRequest("Category List is Empty");
            }
            return Ok(response);
        }

      

        [HttpPost("AddCategory")]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                 return Ok(category);

            }

            return BadRequest(ModelState);
        }

        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    Category category = _unitOfWork.Category.GetById(c => c.Id == id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}
        //[HttpPost]
        //public IActionResult Edit(int? id, Category category)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Category.Update(category);
        //        _unitOfWork.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(category);
        //}

        ////GET
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var category = _unitOfWork.Category.GetById(c => c.Id == id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(category);
        //}

        ////POST
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePOST(int? id)
        //{
        //    var obj = _unitOfWork.Category.GetById(c => c.Id == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    _unitOfWork.Category.Remove(obj);
        //    _unitOfWork.Save();
        //    return RedirectToAction("Index");
        //}
    }
}
