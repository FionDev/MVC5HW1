using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5HW1.Models.Interface
{
    public interface IBankAccountRepository : IRepository<客戶銀行資訊>
    {
        客戶銀行資訊 GetByID(int id);

        IEnumerable<客戶銀行資訊> GetByCustomerID(int id);

        IQueryable<客戶銀行資訊> GetAllExcepDelete();
    }
}
