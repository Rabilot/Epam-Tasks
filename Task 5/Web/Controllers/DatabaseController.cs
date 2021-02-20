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
        
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Manager, Client, Product, Date")]SaleModel sale)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Add(sale);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(sale);
        }
        
        //[HttpGet]
        public ActionResult Edit(int? id)
        {
            var saleEdit = _unitOfWork.FindByIndex(id);
            if (saleEdit == null)
            {
                return HttpNotFound();
            }
            return View(saleEdit);
        }

        // [HttpPost]
        // public ActionResult EditPost(SaleModel saleModel)
        // {
        //     if (saleModel == null)
        //     {
        //         return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //     }
        //     _unitOfWork.Edit(saleModel);
        //     return RedirectToAction("Index");
        // }
        
    }
}