using System.Data;
using System.Web.Mvc;
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
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName, FirstMidName, EnrollmentDate")]SaleModel sale)
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
    }
}