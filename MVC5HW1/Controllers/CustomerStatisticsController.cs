using MVC5HW1.Models;
using MVC5HW1.Models.Interface;
using MVC5HW1.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5HW1.Controllers
{
    public class CustomerStatisticsController : Controller
    {
        private IStoreProcedureRepository _spRepo;

        public CustomerStatisticsController()
        {
            this._spRepo = new StoreProcedureRepository();

        }

        // GET: Custmers
        public ActionResult Index()
        {
            List<SP_GetAllCustomerStatistics_Result> data = this._spRepo.GetCustomerStatistics().ToList();
            return View(data);
        }
    }
}
