using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5HW1.Models.Interface
{
    interface IStoreProcedureRepository
    {
        IQueryable<SP_GetAllCustomerStatistics_Result> GetCustomerStatistics();
    }
}
