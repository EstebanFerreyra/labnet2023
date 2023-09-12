using Lab.EF.Data.Context;
using Lab.EF.Entities.Entities;
using Lab.EF.Logic.Services;
using Lab.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{ 
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            CategoriesService categoriesService = new CategoriesService();
            List<Categories> categories = categoriesService.GetAll();

            List<CategoriesView> categoriesViews = categories.Select(c => new CategoriesView
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description
            }).ToList();

            return View(categoriesViews);
        }
    }
}