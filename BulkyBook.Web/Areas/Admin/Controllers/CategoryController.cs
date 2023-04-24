using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Utility;
using BullyBook_ECS.Data;
using BullyBook_ECS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BullyBook.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _unitOfWork.Category.GetAll();
            return View(CategoryList);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayNumber.ToString())
            {
                ModelState.AddModelError("Name", "Can`t Name Be As Dsplay Number");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                TempData["success"] = "Category Created Fuccessfully";
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Edit(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            var CategoryObject = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == Id);
            if (CategoryObject == null)
            {
                return NotFound();
            }
            return View(CategoryObject);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayNumber.ToString())
            {
                ModelState.AddModelError("Name", "Can`t Name Be As Dsplay Number");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated Fuccessfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            var CategoryObject = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == Id);
            if (CategoryObject == null)
            {
                return NotFound();
            }
            return View(CategoryObject);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            var CategoryObject = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == Id);
            if (CategoryObject == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(CategoryObject);
            _unitOfWork.Save();
            TempData["success"] = "Category Removed Fuccessfully";
            return RedirectToAction("Index");
        }


    }
}
