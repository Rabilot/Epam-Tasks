using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL.Models;
using DAL.Repositories;
using Model;
using PagedList;

namespace Web.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly EFUnitOfWork _unitOfWork = new EFUnitOfWork();

        // GET
        [Authorize(Roles="user")]
        public ActionResult Index(int? page, string name, DateTime? fromDate, DateTime? toDate)
        {
            var dbSales = _unitOfWork.GetAll();
            var sales = Filtration(dbSales, name, fromDate, toDate).ToList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(sales.ToPagedList(pageNumber, pageSize));
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

            _unitOfWork.Edit(saleModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles="admin")]
        public ActionResult Delete(int id)
        {
            Console.WriteLine(id);
            _unitOfWork.DeleteByIndex(id);
            return RedirectToAction("Index");
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
            Console.WriteLine(saleModel.ProductModel.Price);
            _unitOfWork.Add(saleModel);
            return RedirectToAction("Index");
        }

        private IList<SaleModel> Filtration(IList<SaleModel> sales, string lastName, DateTime? fromDate, DateTime? toDate)
        {
            var result = sales;
            if (!string.IsNullOrEmpty(lastName))
            {
                result = result.Where(sale => sale.ManagerModel.LastName == lastName).ToList();
            }

            if (fromDate != null && toDate != null)
            {
                result = result.Where(sale => sale.DateOfSale >= fromDate && sale.DateOfSale <= toDate).ToList();
            }

            return result;
        }
    }
}