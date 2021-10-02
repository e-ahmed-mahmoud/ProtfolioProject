using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Models
{
    public class Owner : EntityBase
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string Profile { get; set; }

        public Address Address { get; set; }
    }
}
