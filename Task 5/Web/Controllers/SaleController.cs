using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Task5_DAL.Models;
using Task5_DAL.Repositories;
using PagedList;
using Task5_Model;
using Web.Models;

namespace Web.Controllers
{
    public class SaleController : Controller
    {
        private readonly EFUnitOfWork _unitOfWork = new EFUnitOfWork();
        
        //[Authorize(Roles="user")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles="admin")]
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
        [Authorize(Roles="admin")]
        public ActionResult EditPost(SaleModel saleModel)
        {
            if (saleModel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!saleModel.IsValid())
            {
                throw new ArgumentException();
            }

            _unitOfWork.Edit(saleModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles="admin")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.DeleteByIndex(id);
            return UpdateSalesTable(null, null, null, null);
        }

        [Authorize(Roles="admin")]
        public ActionResult Create()
        {
            SaleModel saleModel = new SaleModel();
            return View(saleModel);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="admin")]
        public ActionResult CreatePost(SaleModel saleModel)
        {
            _unitOfWork.Add(saleModel);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateSalesTable(int? page, string name, DateTime? fromDate, DateTime? toDate)
        {
            if (name != null && name.Length > 20)
            {
                throw new ArgumentException();
            }
            var sales = _unitOfWork.GetAll(name, fromDate, toDate);
            return PartialView("_SalesTable", sales);
        }
    }
}