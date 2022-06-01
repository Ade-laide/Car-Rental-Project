using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Car_Rental_Project.Models
{
    public partial  class CarReg
    {     [MetadataType(typeof(CarRegMetadata))]
        public class CarRegMetadata
        {
            [DisplayName("Car No")]
            public string CarNo { get; set; }
            [DisplayName("Make")]
            
            public string Make { get; set; }

            [DisplayName("Model")]
            public string Model { get; set; }

            [DisplayName("Available")]
            public string Available { get; set; }

        }
    }
}
