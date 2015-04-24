using MVC5HW1.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5HW1.Models.Repository
{
    public class ContactRepository : GenericRepository<客戶聯絡人>,IContactRepository
    {
        public 客戶聯絡人 GetByContactID(int id)
        {
            return this.Get(x => x.Id == id);
        }

        public IEnumerable<客戶聯絡人> GetByCustomerID(int id) 
        {
            return this.GetAll().Where(x => x.客戶Id == id);
        }

        public IQueryable<客戶聯絡人> GetAllExcepDelete()
        {
            return this.GetAll().Where(x => x.IsDelete == false);
        }


        public bool UpdateCheckEmail(客戶聯絡人 instance) 
        {
            bool uok = false;

            if (instance == null)
                return uok;

            客戶聯絡人 duplicate = this.Get(x => x.Email == instance.Email);
            if (duplicate != null)
                return uok;

            this.Update(instance);
            uok = true;

            return uok;

        }

        public bool CreateCheckEmail(客戶聯絡人 instance)
        {
            bool cok = false;

            if (instance == null)
                return cok;

            客戶聯絡人 duplicate = this.Get(x => x.Email == instance.Email);
            if (duplicate != null)
                return cok;

            this.Create(instance);
            cok = true;

            return cok;

        }

        public bool DeleteByTag(客戶聯絡人 instance)
        {
            bool cok = false;
            if (instance == null)
                return cok;

            客戶聯絡人 c = this.GetByContactID(instance.Id);
            if (c != null)
            {
                c.IsDelete = true;
                this.Update(c);
            }
            cok = true;
            return cok;

        }
    }
}