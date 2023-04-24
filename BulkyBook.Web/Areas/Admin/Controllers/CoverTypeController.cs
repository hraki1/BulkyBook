using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Utility;
using BullyBook_ECS.Data;
using BullyBook_ECS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BullyBook.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = SD.Role_Admin)]
	[AutoValidateAntiforgeryToken]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> CoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(CoverTypeList);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType coverType)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(coverType);
                TempData["success"] = "Cover Type Created Fuccessfully";
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(coverType);
        }
        public IActionResult Edit(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            var CoverTypeObject = _unitOfWork.CoverType.GetFirstOrDefault(c => c.Id == Id);
            if (CoverTypeObject == null)
            {
                return NotFound();
            }
            return View(CoverTypeObject);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType coverType)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(coverType);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type Updated Fuccessfully";
                return RedirectToAction("Index");
            }
            return View(coverType);
        }
        public IActionResult Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            var CoverTypeObject = _unitOfWork.CoverType.GetFirstOrDefault(c => c.Id == Id);
            if (CoverTypeObject == null)
            {
                return NotFound();
            }
            return View(CoverTypeObject);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            var CoverTypeObject = _unitOfWork.CoverType.GetFirstOrDefault(c => c.Id == Id);
            if (CoverTypeObject == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverType.Remove(CoverTypeObject);
            _unitOfWork.Save();
            TempData["success"] = "Cover Type Removed Fuccessfully";
            return RedirectToAction("Index");
        }


    }
}
