using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility;
using BullyBook_ECS.Data;
using BullyBook_ECS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace BullyBook.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = SD.Role_Admin)]
	public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        [AutoValidateAntiforgeryToken]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? Id)
        {
            Company company = new();
        
            if (Id == null || Id == 0)
            {
                
                return View(company);
            }
            else
            {
              company=_unitOfWork.Company.GetFirstOrDefault(u => u.Id == Id);

                return View(company);
            }

        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(Company company)
        {

            if (ModelState.IsValid)
            {
               
                if (company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                    TempData["success"] = "Creatd Successfully";
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                    TempData["success"] = "Updated Successfully";
                }
                _unitOfWork.Save();

                return RedirectToAction("Index");              
            }
            
            return View(company);
          
        }


        #region API CALLS
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Company.GetAll();
            return Json(new { data = productList });
        }

        [HttpDelete]
        public IActionResult Delete(int? Id)
        {
            var CompanytObject = _unitOfWork.Company.GetFirstOrDefault(c => c.Id == Id);
            if (CompanytObject == null)
            {
                return Json(new { success= false, message="Error While Deleting" });
            }
           
            _unitOfWork.Company.Remove(CompanytObject);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
