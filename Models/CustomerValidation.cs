using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Car_Rental_Project.Models
{
    public partial class Customer

    {   [MetadataType(typeof(CustomerMetaData))]
        public class CustomerMetaData
        {
            [DisplayName("Customer Name")]
            public string CustName { get; set; }
            [DisplayName("Address")]

            public string Address { get; set; }
            [DisplayName("Mobile")]
            [RegularExpression(@"^[0][1-9]{10}$", ErrorMessage = "Please Enter correct Mobile Number")]
            public Nullable<int> Mobile { get; set; }

        }
    }
}