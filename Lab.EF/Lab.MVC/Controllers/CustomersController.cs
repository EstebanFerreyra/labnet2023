using Lab.EF.Entities.DTO;
using Lab.EF.Entities.Entities;
using Lab.EF.Logic.Services;
using Lab.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class CustomersController : Controller
    {
        CustomersService customersService = new CustomersService();

        // GET: Customers
        public ActionResult Index()
        {
            List<Customers> customers = customersService.GetAll();

            List<CustomersView> customersView = customers.Select(c => new CustomersView
            {
                CustomerID = c.CustomerID,
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                Address = c.Address,
                Phone = c.Phone,
            }).ToList(); 
            
            return View(customersView);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CustomersView customersView)
        {
            try
            {
                string id = customersView.CompanyName.Substring(0, 5).ToUpper();
                var customersEntity = new Customers
                {
                    CustomerID = id,
                    CompanyName = customersView.CompanyName,
                    ContactName = customersView.ContactName,
                    Address = customersView.Address,
                    Phone = customersView.Phone,
                };

                customersService.Add(customersEntity);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(string id)
        {
            try
            {
                customersService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(UpdatePhoneView updatePhoneView)
        {
            try
            {
                customersService.Update(updatePhoneView.CustomerID, updatePhoneView.Phone);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

    }
}