using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DAL.EF;
using DAL.Models;
using DAL.Repositories;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext _db = new DatabaseContext();
        EFUnitOfWork _unitOfWork = new EFUnitOfWork();
        
        public ActionResult Index()
        {
            // var data = _db.Sales.ToList().Select(x => new Sale()
            // {
            //     Client = x.Client,
            //     Manager = x.Manager,
            //     Product = x.Product,
            //     Date = x.Date
            // });
            var data = _unitOfWork.GetAll();
            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> DataBase()
        {
            return View(await _db.Sales.ToListAsync());
        }
        // public ActionResult Create()
        // {
        //     return View();
        // }

        [HttpPost]
        public async Task<ActionResult> Create(Sale sale)
        {
            _db.Sales.Add(sale);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}