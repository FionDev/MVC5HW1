using MVC5HW1.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5HW1.Models;
using MVC5HW1.Models.Repository;

namespace MVC5HW1.Controllers
{
    public class CustmersController : Controller
    {
        private ICustomerRepository _customerRepo;

        public CustmersController()
        {
            this._customerRepo = new CustomerRepository();

        }

        // GET: Custmers
        public ActionResult Index()
        {
            List<客戶資料> c = _customerRepo.GetAllExcepDelete().ToList();
            return View(c);
        }

        // GET: Custmers/Details/5
        public ActionResult Details(int id)
        {
            客戶資料 c = _customerRepo.GetByCustomerID(id);
            return View(c);
        }

        // GET: Custmers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Custmers/Create
        [HttpPost]
        public ActionResult Create(客戶資料 customer)
        {
            if (ModelState.IsValid)
            {
                this._customerRepo.Create(customer);
                return RedirectToAction("Index"); 
            }
            return View();
        }

        // GET: Custmers/Edit/5
        public ActionResult Edit(int id=0)
        {
            客戶資料 c = this._customerRepo.GetByCustomerID(id);
            if (c == null)
            {
                return HttpNotFound();
            }

            return View(c);
        }

        // POST: Custmers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, 客戶資料 customer)
        {
            if (ModelState.IsValid)
            {
                this._customerRepo.Update(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Custmers/Delete/5
        public ActionResult Delete(int id)
        {

            客戶資料 c = this._customerRepo.GetByCustomerID(id);
            if (c == null)
            {
                return HttpNotFound();
            }

            return View(c);
            //return View();
        }

        // POST: Custmers/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 c = this._customerRepo.GetByCustomerID(id);
            if (c != null)
                this._customerRepo.Delete(c);
            return RedirectToAction("Index");
        }
    }
}
