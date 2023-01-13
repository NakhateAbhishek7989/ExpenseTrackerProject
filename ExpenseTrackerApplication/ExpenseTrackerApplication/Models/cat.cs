using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpenseTrackerApplication.Models
{
    public class cat
    {
        
        public int ID { get; set; }
        [Required]
        public string Category_Name { get; set; }
        [Required]
        public string Category_Limit { get; set; }


    }
}