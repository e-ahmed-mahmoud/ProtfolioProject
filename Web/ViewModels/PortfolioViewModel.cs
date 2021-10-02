using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class PortfolioViewModel
    {
        public Guid Id { get; set; }
        public string ImgPath { get; set; }

        public string Descripation { get; set; }

        public IFormFile FormFile { get; set; }
        public string Name { get; set; }
    }
}
