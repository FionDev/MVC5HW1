using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5HW1.Models
{
    public class CustomerStatisticsViewModels
    {
        public string CustomerName { get; set; }

        public int ContactCount { get; set; }

        public int BankAccountCount { get; set; }
    }
}