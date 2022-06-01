using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rental_Project.Models
{
    public class RentailViewModel
    {
        public int id { get; set; }
        public string CarId { get; set; }
        public Nullable<int> CustId { get; set; }
        public Nullable<int> Fee { get; set; }
        public Nullable< System.DateTime> sDate { get; set; }
        public Nullable<System.DateTime> eDate { get; set; }
        public string Available { get; set; }

    }
}