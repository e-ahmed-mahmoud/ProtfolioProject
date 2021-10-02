using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Models
{
    public class PortfoloItem : EntityBase
    {
        public string Name { get; set; }

        public string PicturePath { get; set; }

        public string Descripation { get; set; }
    }
}
