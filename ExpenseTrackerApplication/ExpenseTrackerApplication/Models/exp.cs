using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTrackerApplication.Models
{
    public class exp
    {
        public int  ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Category_ID { get; set; }
        public string Date_Time { get; set; }

    }
}