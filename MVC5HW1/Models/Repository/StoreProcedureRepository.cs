using MVC5HW1.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5HW1.Models.Repository
{
    public class StoreProcedureRepository : GenericRepository<SP_GetAllCustomerStatistics_Result>, IStoreProcedureRepository
    {
        private readonly string ProcedureName = "SP_GetAllCustomerStatistics";

        public StoreProcedureRepository()
        {
            
        }

        public IQueryable<SP_GetAllCustomerStatistics_Result> GetCustomerStatistics()
        {
            return this.GetStoreProcedureWithoutParameters(this.ProcedureName);
        }

    }
}