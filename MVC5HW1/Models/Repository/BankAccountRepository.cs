using MVC5HW1.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5HW1.Models.Repository
{
    public class BankAccountRepository : GenericRepository<客戶銀行資訊>, IBankAccountRepository
    {
        public 客戶銀行資訊 GetByID(int id)
        {
            return this.Get(x => x.Id == id);
        }

        public IEnumerable<客戶銀行資訊> GetByCustomerID(int id)
        {
            return this.GetAll().Where(x => x.客戶Id == id);
        }

        public IQueryable<客戶銀行資訊> GetAllExcepDelete()
        {
            return this.GetAll().Where(x => x.IsDelete == false);
        }
    }
}