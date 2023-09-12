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
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            EmployeesService employeesService = new EmployeesService();
            List<Employees> employees = employeesService.GetAll();
            List<EmployeesView> employeesViews = employees.Select(e => new EmployeesView
            {
                LastName = e.LastName,
                FirstName = e.FirstName,
                Address = e.Address,
                City = e.City,
                HomePhone = e.HomePhone,
            }).ToList();

            return View(employeesViews);
        }
    }
}