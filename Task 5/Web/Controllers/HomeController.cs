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
            var data = _unitOfWork.GetAll();
            return View(data);
        }

        [Authorize(Roles="admin")]
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
    }
}