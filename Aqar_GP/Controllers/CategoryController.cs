﻿
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

        [HttpGet]
        public IActionResult Index()
        {
            var response = _unitOfWork.Category.GetAll();
            if (response.Count() == 0)
            {
                return BadRequest("Category List is Empty");
            }
            return Ok(response);
        }



        [HttpPost]
        public IActionResult Create(Category category)
        {
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


        [HttpPut("{id}")]
        public IActionResult Edit(Category category, [FromRoute] int id)
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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.Category.GetById(c => c.Id == id);
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
