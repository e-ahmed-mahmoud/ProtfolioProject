using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreLayer.Models
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public string Street { get; set; }

        public string City { get; set; }

        public int Number { get; set; }
    }
}
