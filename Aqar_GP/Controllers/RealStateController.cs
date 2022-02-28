
using DataAccess.Respository.IRepository;

using Microsoft.AspNetCore.Mvc;
using Models;
using Models.viewModel;

namespace Aqar.controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Realstatecontroller : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        private long _maxAllowedPosterSize = 1048576;
        public Realstatecontroller(IUnitOfWork unitOfWork, IWebHostEnvironment webhostenvironment)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("all")]
        public async Task<IActionResult> Index()
        {
            var response = await _unitOfWork.Realstate.GetAll();
            if (response.Count() == 0) return BadRequest("RealState List is Empty");
            return Ok(response);
        }

        [HttpGet("searchBystatus")]
        public async Task<IActionResult> Status(string status)
        {
            var response = await _unitOfWork.Realstate.GetByStatus(status);
            if (response.Count() == 0) return BadRequest("RealState List is Empty");
            return Ok(response);
        }





        [HttpPost("add")]
        public async Task<IActionResult> CreateAsync([FromForm] RealStateVModel realVm)
        {
            if (realVm.Image == null)
                return BadRequest("Poster is required!");

            if (!_allowedExtenstions.Contains(Path.GetExtension(realVm.Image.FileName).ToLower()))
                return BadRequest("Only .png and .jpg images are allowed!");

            if (realVm.Image.Length > _maxAllowedPosterSize)
                return BadRequest("Max allowed size for poster is 1MB!");

            var isValidGenre = await _unitOfWork.Category.IsvalidCategory(realVm.CategoryId);

            if (!isValidGenre)
                return BadRequest("Invalid genere ID!");
            if (!ModelState.IsValid)
            return BadRequest(ModelState);
           

            using var dataStream = new MemoryStream();

            await realVm.Image.CopyToAsync(dataStream);

            var newRealState = new RealState {
                Title = realVm.Title,
                Description = realVm.Description,
                Price = realVm.Price,
                VideoLink = realVm.VideoLink,
                BuildingView = realVm.BuildingView,
                Area = realVm.Area,
                Address = realVm.Address,
                Floor = realVm.Floor,
                BuildingNumber = realVm.BuildingNumber,
                AppartmentNumber = realVm.AppartmentNumber,
                Rooms = realVm.Rooms,
                Baths = realVm.Baths,
                Status = realVm.Status,
                SwimmingPool = realVm.SwimmingPool,
                LaundryRoom = realVm.LaundryRoom,
                EmergencyExit = realVm.EmergencyExit,
                FirePlace = realVm.FirePlace,
                CategoryId = realVm.CategoryId,
                UserId = realVm.userId,
            };
            newRealState.Image = dataStream.ToArray();

            _unitOfWork.Realstate.Add(newRealState);
            _unitOfWork.Save();
            return Ok(newRealState);
        }





        [HttpPut("update/{id}")]
        public async  Task<IActionResult> Edit([FromForm] RealStateVModel realVm, [FromRoute] string id)
        {
            if (realVm.Image == null)
                return BadRequest("Poster is required!");

            if (!_allowedExtenstions.Contains(Path.GetExtension(realVm.Image.FileName).ToLower()))
                return BadRequest("Only .png and .jpg images are allowed!");

            if (realVm.Image.Length > _maxAllowedPosterSize)
                return BadRequest("Max allowed size for poster is 1MB!");


            if (realVm is null) return BadRequest("Please Enter Updated information");

            var real = await _unitOfWork.Realstate.GetById(real=>real.Id == id);
            if (real is not null)
            {
                if (ModelState.IsValid)
                {
                    using var dataStream = new MemoryStream();

                    await realVm.Image.CopyToAsync(dataStream);



                    real.Title = realVm.Title;
                    real.Description = realVm.Description;
                    real.Price = realVm.Price;
                    real.VideoLink = realVm.VideoLink;
                    real.BuildingView = realVm.BuildingView;
                    real.Area = realVm.Area;
                    real.Address = realVm.Address;
                    real.Floor = realVm.Floor;
                    real.BuildingNumber = realVm.BuildingNumber;
                    real.AppartmentNumber = realVm.AppartmentNumber;
                    real.Rooms = realVm.Rooms;
                    real.Baths = realVm.Baths;
                    real.Status = realVm.Status;
                    real.SwimmingPool = realVm.SwimmingPool;
                    real.LaundryRoom = realVm.LaundryRoom;
                    real.EmergencyExit = realVm.EmergencyExit;
                    real.FirePlace = realVm.FirePlace;
                    real.CategoryId = realVm.CategoryId;
                    real.UserId = realVm.userId;
                    
                    real.Image = dataStream.ToArray();
                    _unitOfWork.Realstate.Update(real);
                    _unitOfWork.Save();
                    return Ok(real);

                }

            }
            else return NotFound($"No RealState was found with ID: {id}");
            return BadRequest(ModelState);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var realState = await _unitOfWork.Realstate.GetById(realState => realState.Id == id);
            if (realState == null) return NotFound($"No RealState was found with ID: {id}");
            _unitOfWork.Realstate.Remove(realState);
            _unitOfWork.Save();
            return Ok(realState);
        }

        [HttpPost("AddTransaction")]
        public async Task<IActionResult> ContactOwner(string RealStateId,string userID)
        {
            Transactions transaction = new Transactions();
            transaction.RealstateId = RealStateId;
            transaction.UserId = userID;
            transaction.Date = DateTime.UtcNow;
            transaction.RealState = await _unitOfWork.Realstate.GetById(x => x.Id== RealStateId);
            //transaction.ApplicationUser = await _unitOfWork.Realstate.GetById(x => int.Parse(x.Id) == RealStateId);
            _unitOfWork.Transactions.Add(transaction);
            _unitOfWork.Save();
            return Ok();


        }      
        [HttpPost("AddFavorite")]
        public async Task<IActionResult> AddToFavorite(string RealStateId,string userID)
        {
            FavoriteList List = new FavoriteList();
            List.RealstateId = RealStateId;
            List.UserId = userID;
            List.Date = DateTime.UtcNow;
            List.RealState = await _unitOfWork.Realstate.GetById(x => x.Id== RealStateId);
            //transaction.ApplicationUser = await _unitOfWork.Realstate.GetById(x => int.Parse(x.Id) == RealStateId);
            _unitOfWork.FavoriteList.Add(List);
            _unitOfWork.Save();
            return Ok();
        }

        public IActionResult ShowFavourite(string UserId)
        {

           var result =  _unitOfWork.Realstate.favoriteLists(UserId);
                if(result != null) return Ok(result);
                return BadRequest("No Favourites Added");
            
        }
       
    }
}
