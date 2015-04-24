using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC5HW1.Models;

namespace MVC5HW1.Models.Interface
{
    public interface IContactRepository : IRepository<客戶聯絡人>
    {
        客戶聯絡人 GetByContactID(int id);

        IEnumerable<客戶聯絡人> GetByCustomerID(int id);

        IQueryable<客戶聯絡人> GetAllExcepDelete();

        bool UpdateCheckEmail(客戶聯絡人 instance);

        bool CreateCheckEmail(客戶聯絡人 instance);

        bool DeleteByTag(客戶聯絡人 instance);
    }
}
