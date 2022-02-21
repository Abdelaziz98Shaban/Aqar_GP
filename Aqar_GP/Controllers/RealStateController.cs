//using Aqar.DataAccess.Repository.IRepository;
//using Aqar.Models.ViewModels;
//using Aqar.Utility;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace AqarWeb.Areas.Admin.Controllers
//{
//    public class RealStateController : Controller
//    {
//        private readonly IUnitOfWork _db;
//        private readonly IWebHostEnvironment _webHostEnvironment;

//        public RealStateController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
//        {
//            _db = db;
//            _webHostEnvironment = webHostEnvironment;
//        }
//        public IActionResult Index()
//        {
//            return View(_db.RealState.GetAll());
//        }

//        [HttpGet]
//        public IActionResult Create()
//        {
//            return View(new RealStateVM());
//        }
        
//        [HttpPost]
//        public IActionResult Create(RealStateVM realStateVM)
//        {
//            if (ModelState.IsValid)
//            {
//                if (realStateVM.ImageFiles != null)
//                {
//                    realStateVM.Images = new List<RealStateImagesVM>();

//                    foreach (var file in realStateVM.ImageFiles)
//                    {
//                        var img = new RealStateImagesVM()
//                        {
//                            ImageUrl = UploadImage(file)
//                        };

//                        realStateVM.Images.Add(img);
//                    }
//                }
//                    _db.RealState.AddNewRealState(realStateVM);
//                    _db.Save();
//                    return RedirectToAction(nameof(Index));
//            }
//            return View(realStateVM);
//        }

//        private string UploadImage(IFormFile file)
//        {
//            string uniqueFileName = null;

//            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, SD.FileUploadFolder);

//            uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
//            if (!Directory.Exists(uploadsFolder))
//            {
//                Directory.CreateDirectory(uploadsFolder);
//            }
//            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

//            using (var fileStream = new FileStream(filePath, FileMode.Create))
//            {
//                file.CopyTo(fileStream);
//            }

//            //file.CopyTo(new FileStream(filePath, FileMode.Create));

//            return uniqueFileName;
//        }
//    }
//}
