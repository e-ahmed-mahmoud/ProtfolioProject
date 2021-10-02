using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _ownerUnit;
        private readonly IUnitOfWork<PortfoloItem> _portunit;

        public HomeController( IUnitOfWork<Owner> ownerUnit , IUnitOfWork<PortfoloItem> Portunit )
        {
            _ownerUnit = ownerUnit;
            _portunit = Portunit;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel { 
                Owner = _ownerUnit.GenericIRepository.GetAll().FirstOrDefault(), 
                PortfoloItems = _portunit.GenericIRepository.GetAll().ToList()
            };

            return View(homeViewModel);
        }
    }
}
