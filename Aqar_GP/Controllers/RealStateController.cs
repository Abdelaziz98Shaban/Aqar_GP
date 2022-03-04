

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
            
            if (response.Count() == 0) return BadRequest(new { message = "Empty list"});
            return Ok(response);
        }



        [HttpGet("details/{id}")]

        public async Task<IActionResult> GetRealState(string id)
        {
            var realstate = await _unitOfWork.Realstate.GetById(real=> real.Id == id);
            if (realstate !=null)
            {
                return Ok(realstate);

            }
            return BadRequest("Realstate doesn't Exist");
           
        }
        
        [HttpGet("myrealStates/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetMyRealState([FromRoute] string userId)
        {
            var realstate = await _unitOfWork.Realstate.GetById(real=> real.UserId == userId);
            if (realstate !=null)
            {
                return Ok(realstate);

            }
            return BadRequest("Realstate doesn't Exist");
           
        }


        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> CreateAsync([FromForm] RealStateVModel realVm)
        {
            if (realVm.Image == null)
                return BadRequest("Poster is required!");

            if (!_allowedExtenstions.Contains(Path.GetExtension(realVm.Image.FileName).ToLower()))
                return BadRequest("Only .png and .jpg images are allowed!");

            if (realVm.Image.Length > _maxAllowedPosterSize)
                return BadRequest("Max allowed size for Image is 1MB!");

            var isValidGenre = await _unitOfWork.Category.IsvalidCategory(realVm.CategoryId);

            if (!isValidGenre) return BadRequest("Invalid Cateory ID!");
               
            if (!ModelState.IsValid) return BadRequest(ModelState);
       
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

        [Authorize]
        [HttpPut("update/{id}/{userId}")]
        public async  Task<IActionResult> Edit([FromForm] RealStateVModel realVm, [FromRoute] string id,[FromRoute] string userId)
        {
           

            if (realVm is null) return BadRequest("Please Enter Updated information");
            var isValidGenre = await _unitOfWork.Category.IsvalidCategory(realVm.CategoryId);

            if (!isValidGenre) return BadRequest("Invalid Cateory ID!");

            var real = await _unitOfWork.Realstate.GetById(real=>real.Id == id);
            var user = await _unitOfWork.Realstate.GetById(real => real.UserId == userId);
            if (real is not null && user is not null)
            {
                if (ModelState.IsValid)
                {
                    if(realVm.Image !=null)
                    {
                        if (!_allowedExtenstions.Contains(Path.GetExtension(realVm.Image.FileName).ToLower()))
                            return BadRequest("Only .png and .jpg images are allowed!");

                        if (realVm.Image.Length > _maxAllowedPosterSize)
                            return BadRequest("Max allowed size for Image is 1MB!");

                        using var dataStream = new MemoryStream();
                        await realVm.Image.CopyToAsync(dataStream);
                        real.Image = dataStream.ToArray();
                    }
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
                    _unitOfWork.Realstate.Update(real);
                    _unitOfWork.Save();
                    return Ok(real);

                }

            }
            else return NotFound($"No RealState was found with ID: {id}");
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpDelete("delete/{id}/{userId}")]
        public async Task<IActionResult> Delete([FromRoute]  string id, [FromRoute]  string userId)
        {
            var realState = await _unitOfWork.Realstate.GetById(realState => realState.Id == id);
            var user = await _unitOfWork.Realstate.GetById(realState => realState.UserId == userId);
            if (realState is not null && user is not null)
            {
                _unitOfWork.Realstate.Remove(realState);
                _unitOfWork.Save();
                return Ok(realState);
            }
            return NotFound($"No RealState was found with ID: {id}");
        }
        [Authorize]
        [HttpPost("AddTransaction")]
        public async Task<IActionResult> ContactOwner([FromRoute] string RealStateId, [FromRoute] string userID)
        {
            Transactions transaction = new Transactions();
            transaction.RealstateId = RealStateId;
            transaction.UserId = userID;
            transaction.Date = DateTime.UtcNow;
            transaction.RealState = await _unitOfWork.Realstate.GetById(x => x.Id == RealStateId);
            _unitOfWork.Transactions.Add(transaction);
            _unitOfWork.Save();
            return Ok();


        }
        [Authorize]
        [HttpPost("AddFavorite/{RealStateId}/{userID}")]
        public async Task<IActionResult> AddToFavorite([FromRoute] string RealStateId, [FromRoute] string userID)
        {
            var reaState = await _unitOfWork.Realstate.GetById(x => x.Id == RealStateId);
            var user = await _unitOfWork.Users.GetById(x => x.Id == userID);
            if(user != null && reaState != null)
            {
                var favItem = await _unitOfWork.FavoriteList.GetById(x => x.RealstateId == RealStateId && x.UserId == userID);
                if (favItem != null)
                 return BadRequest("This RealState is Already in Favorites ");

            FavoriteList fav = new FavoriteList();
            fav.RealstateId = RealStateId;
            fav.UserId = userID;
            fav.Date = DateTime.UtcNow;
            fav.RealState = reaState;

                // var favUser = await _unitOfWork.FavoriteList.GetById(x => x.UserId == userID);
                 _unitOfWork.FavoriteList.Add(fav);
                  _unitOfWork.Save();
                 return Ok(fav);
            }
            return BadRequest("SomeThing Went Wrong :( ");


        }
       
        [Authorize]
        [HttpDelete("DeleteFavorite")]
        public async Task<IActionResult> DeleteFromFavorite([FromRoute] string RealStateId, [FromRoute] string userID)
        {
            var reaState = await _unitOfWork.Realstate.GetById(x => x.Id == RealStateId);
            var user = await _unitOfWork.Users.GetById(x => x.Id == userID);
            if(user != null && reaState != null)
            {
                var favItem = await _unitOfWork.FavoriteList.GetById(x => x.RealstateId == RealStateId && x.UserId == userID);
                if (favItem == null)
                 return BadRequest("This RealState doesen't exist in favorite list ");

                _unitOfWork.FavoriteList.Remove(favItem);
                  _unitOfWork.Save();
                 return Ok(favItem);
            }
            return BadRequest("SomeThing Went Wrong :( ");


        }
        [Authorize]
        [HttpGet("getFavorite")]
        public IActionResult ShowFavourite([FromRoute] string UserId)
        { 
            var favrealState =  _unitOfWork.Realstate.favoriteLists(UserId);
            if(favrealState != null) return Ok(favrealState);

            return BadRequest("No Favourites Added");

           var result =  _unitOfWork.Realstate.favoriteLists(UserId);
                if(result.Count !=0 ) return Ok(result);
                return BadRequest("No Favourites Added");

            
        }
       
    }
}
