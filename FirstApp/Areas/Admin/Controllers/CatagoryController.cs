
using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Areas.Admin.Controllers;
      [Area("Admin")]
    [Authorize(Roles=SD.Role_Admin)]
    

  
    public class CatagoryController : Controller
        
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public CatagoryController(IUnitOfWork unitOfWork)//constructor to retrieve data from database
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Catagory> objCatagoryList = _unitOfWork.Catagory.GetAll();//retrieve data & convert it to list and assign it to objCatagoryList
            return View(objCatagoryList);
        }
        //CreateGET
        public IActionResult Create()
        {
            return View();
        }

        //CreatePOST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Catagory obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "DisplayOrder and Name cannot be same");

            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Catagory.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Catagory created successfully";

                return RedirectToAction("Index");
            }
            else { return View(obj); }
        }

        //editGET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var catagoryFromDb = _db.Catagories.Find(id);
            var catagoryFromDb = _unitOfWork.Catagory.GetFirstOrDefault(u => u.Id == id);
            if (catagoryFromDb == null)
            {
                return NotFound();
            }

            return View(catagoryFromDb);
        }

        //editPOST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Catagory obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "DisplayOrder and Name cannot be same");

            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Catagory.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Catagory edited successfully";


                return RedirectToAction("Index");
            }
            else { return View(obj); }
        }

        //deleteGET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catagoryFromDb = _unitOfWork.Catagory.GetFirstOrDefault(u => u.Id == id);
            if (catagoryFromDb == null)
            {
                return NotFound();
            }

            return View(catagoryFromDb);
        }

        //deletePOST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Catagory.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Catagory.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Catagory deleted successfully";

            return RedirectToAction("Index");

        }


    }


