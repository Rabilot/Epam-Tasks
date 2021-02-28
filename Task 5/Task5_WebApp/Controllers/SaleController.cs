using System;
using System.Web.Mvc;
using Serilog;
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
            try
            {
                var saleEdit = _unitOfWork.FindByIndex(id);
                if (saleEdit == null)
                {
                    return HttpNotFound();
                }

                return View(saleEdit);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult EditPost(SaleModel saleModel)
        {
            try
            {
                if (saleModel != null && saleModel.IsValid())
                {
                    throw new ArgumentException();
                }

                _unitOfWork.Edit(saleModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id < 0)
                {
                    throw new ArgumentException();
                }

                _unitOfWork.DeleteByIndex(id);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
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
            try
            {
                if (saleModel != null && !saleModel.IsValid())
                {
                    throw new ArgumentException();
                }

                _unitOfWork.Add(saleModel);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }

            return RedirectToAction("Index");
        }

        public ActionResult UpdateSalesTable(string name, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                if (name != null && name.Length > 20)
                {
                    throw new ArgumentException();
                }

                var sales = _unitOfWork.GetAll(name, fromDate, toDate);
                return PartialView("_SalesTable", sales);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return RedirectToAction("Index");
            }
        }
    }
}