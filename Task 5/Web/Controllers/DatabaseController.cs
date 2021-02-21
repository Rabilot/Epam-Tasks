using System;
using System.Data;
using System.Net;
using System.Web.Mvc;
using DAL.Models;
using DAL.Repositories;
using Model;

namespace Web.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly EFUnitOfWork _unitOfWork = new EFUnitOfWork();
        // GET
        public ActionResult Index()
        {
            return View(_unitOfWork.GetAll());
        }
        
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var saleEdit = _unitOfWork.FindByIndex(id);
            if (saleEdit == null)
            {
                return HttpNotFound();
            }
            return View(saleEdit);
        }
        
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(SaleModel saleModel)
        {
            if (saleModel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _unitOfWork.Edit(saleModel);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Console.WriteLine(id);
            _unitOfWork.DeleteByIndex(id);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            SaleModel saleModel = new SaleModel();
            return View(saleModel);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(SaleModel saleModel)
        {
            _unitOfWork.Add(saleModel);
            return RedirectToAction("Index");
        }
    }
}