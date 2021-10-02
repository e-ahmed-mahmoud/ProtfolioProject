using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class PortfolioItemsController : Controller
    {
        private readonly IUnitOfWork<PortfoloItem> _unitOfWokr;
        private readonly IHostingEnvironment _hosting;

        public PortfolioItemsController(IUnitOfWork<PortfoloItem> unitOfWokr, IHostingEnvironment hosting )
        {
            _unitOfWokr = unitOfWokr;
            _hosting = hosting;
        }

        // GET: PortfolioItemsController
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel { PortfoloItems = _unitOfWokr.GenericIRepository.GetAll().ToList() };

            return View(homeViewModel);
        }

        // GET: PortfolioItemsController/Details/5
        public ActionResult Details(Guid id)
        {
            var item = _unitOfWokr.GenericIRepository.GetById(id);
            
            return View(item);
        }

        // GET: PortfolioItemsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortfolioItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PortfolioViewModel portfolio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (portfolio.FormFile != null)
                    {
                        string upload = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string fullPath = Path.Combine(upload, portfolio.FormFile.FileName);
                        portfolio.FormFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                    var port = new PortfoloItem
                    {
                        Descripation = portfolio.Descripation,
                        Id = portfolio.Id,
                        PicturePath = portfolio.FormFile.FileName,
                        Name = portfolio.Name
                    };
                    _unitOfWokr.GenericIRepository.Insert(port);
                    _unitOfWokr.Save();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PortfolioItemsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var item = _unitOfWokr.GenericIRepository.GetById(id);

            var port = new PortfolioViewModel
            {
                Descripation = item.Descripation,
                Id = item.Id,
                ImgPath = item.PicturePath,
                Name = item.Name,
            };

            return View(port);
        }

        // POST: PortfolioItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PortfolioViewModel portfolio)
        {
            try
            {
                if (portfolio.FormFile != null)
                {
                    string upload = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath = Path.Combine(upload, portfolio.FormFile.FileName);
                    portfolio.FormFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                var port = new PortfoloItem
                {
                    Descripation = portfolio.Descripation,
                    Id = portfolio.Id,
                    PicturePath = portfolio.FormFile !=null ? portfolio.FormFile.FileName: portfolio.ImgPath,
                    Name = portfolio.Name
                };

                if (_unitOfWokr.GenericIRepository.Update(port))
                    _unitOfWokr.Save();
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PortfolioItemsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            try
            {
                var item = _unitOfWokr.GenericIRepository.GetById(id);

                if (_unitOfWokr.GenericIRepository.Delete(item.Id))
                    _unitOfWokr.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
