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
    public class BankAccountController : Controller
    {
        private IBankAccountRepository _bankAccountRepo;
        private ICustomerRepository _customerRepo;

         public IEnumerable<客戶資料> Customers 
        {
            get { return _customerRepo.GetAllExcepDelete(); }
        }

         public BankAccountController()
        {
            this._bankAccountRepo = new BankAccountRepository();
            this._customerRepo = new CustomerRepository();
        }

        // GET: BankAccount
        public ActionResult Index()
        {
            List<客戶銀行資訊> c = this._bankAccountRepo.GetAllExcepDelete().ToList();
            return View(c);
        }

        // GET: BankAccount/Details/5
        public ActionResult Details(int id)
        {
            客戶銀行資訊 c = this._bankAccountRepo.GetByID(id);
            return View(c);
        }

        // GET: BankAccount/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(Customers, "Id", "客戶名稱");
            return View();
        }

        // POST: BankAccount/Create
        [HttpPost]
        public ActionResult Create(客戶銀行資訊 account)
        {
            if (ModelState.IsValid)
            {
                this._bankAccountRepo.Create(account);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: BankAccount/Edit/5
        public ActionResult Edit(int id)
        {

            客戶銀行資訊 c = this._bankAccountRepo.GetByID(id);
            if (c == null)
            {
                return HttpNotFound();
            }

            return View(c);
        }

        // POST: BankAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, 客戶銀行資訊 account)
        {
            if (ModelState.IsValid)
            {
                this._bankAccountRepo.Update(account);
                return RedirectToAction("Index");
            }

            return View(account);
        }

        // GET: BankAccount/Delete/5
        public ActionResult Delete(int id)
        {
            客戶銀行資訊 c = this._bankAccountRepo.GetByID(id);
            if (c == null)
            {
                return HttpNotFound();
            }

            return View(c);
            //return View();
        }

        // POST: BankAccount/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶銀行資訊 c = this._bankAccountRepo.GetByID(id);
            if (c != null)
                this._bankAccountRepo.DeleteByTag(c);
            return RedirectToAction("Index");
        }
    }
}
