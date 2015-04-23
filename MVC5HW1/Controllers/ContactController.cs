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
    public class ContactController : Controller
    {
        private IContactRepository _contactRepo;
        private ICustomerRepository _customerRepo;

        public IEnumerable<客戶資料> Customers 
        {
            get { return _customerRepo.GetAllExcepDelete(); }
        }

        public ContactController()
        {
            this._contactRepo = new ContactRepository();
            this._customerRepo = new CustomerRepository();
        }
        // GET: Contact
        public ActionResult Index()
        {

            List<客戶聯絡人> c = this._contactRepo.GetAllExcepDelete().ToList();
            return View(c);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            客戶聯絡人 c = this._contactRepo.GetByContactID(id);
            return View(c);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(Customers, "Id", "客戶名稱");
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(客戶聯絡人 contact)
        {
            if (ModelState.IsValid)
            {
                this._contactRepo.CreateCheckEmail(contact);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            客戶聯絡人 c = this._contactRepo.GetByContactID(id);
            if (c == null)
            {
                return HttpNotFound();
            }

            return View(c);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, 客戶聯絡人 contact)
        {
            if (ModelState.IsValid)
            {
                this._contactRepo.UpdateCheckEmail(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            客戶聯絡人 c = this._contactRepo.GetByContactID(id);
            if (c == null)
            {
                return HttpNotFound();
            }

            return View(c);
            //return View();
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 c = this._contactRepo.GetByContactID(id);
            if (c != null)
                this._contactRepo.Delete(c);
            return RedirectToAction("Index");
        }
    }
}
