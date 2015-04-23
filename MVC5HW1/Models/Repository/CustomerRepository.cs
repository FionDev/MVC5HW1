using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC5HW1.Models;
using MVC5HW1.Models.Interface;

namespace MVC5HW1.Models.Repository
{
    public class CustomerRepository : GenericRepository<客戶資料>, ICustomerRepository
    {
        public 客戶資料 GetByCustomerID(int id)
        {
            return this.Get(x=>x.Id==id);
        }


        public IQueryable<客戶資料> GetAllExcepDelete()
        {
            return this.GetAll().Where(x => x.IsDelete == false);
        }

        public bool DeleteByTag(客戶資料 instance)
        {
            bool cok = false;
            if (instance == null)
                return cok;

            客戶資料 c = this.GetByCustomerID( instance.Id);
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