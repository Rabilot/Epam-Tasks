using System;
using System.Web.Mvc;
using Task5_DAL.Repositories;
using Task5_Model;

namespace Web.Controllers
{
    public class SaleController : Controller
    {
        private readonly EFUnitOfWork _unitOfWork = new EFUnitOfWork();

        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public ActionResult EditPost(SaleModel saleModel)
        {
            if (saleModel != null && saleModel.IsValid())
            {
                _unitOfWork.Edit(saleModel);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            if (id >= 0)
            {
                _unitOfWork.DeleteByIndex(id);
            }

            return UpdateSalesTable(null, null, null);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            SaleModel saleModel = new SaleModel();
            return View(saleModel);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult CreatePost(SaleModel saleModel)
        {
            if (saleModel != null && saleModel.IsValid())
            {
                _unitOfWork.Add(saleModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult UpdateSalesTable(string name, DateTime? fromDate, DateTime? toDate)
        {
            if (name.Length > 20)
            {
                throw new ArgumentException();
            }

            var sales = _unitOfWork.GetAll(name, fromDate, toDate);
            return PartialView("_SalesTable", sales);
        }
    }
}