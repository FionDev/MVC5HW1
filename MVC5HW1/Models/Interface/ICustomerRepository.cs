using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC5HW1.Models;

namespace MVC5HW1.Models.Interface
{
    public interface ICustomerRepository : IRepository<客戶資料>
    {
        客戶資料 GetByCustomerID(int id);

        IQueryable<客戶資料> GetAllExcepDelete();

        bool DeleteByTag(客戶資料 instance);
    }
}
