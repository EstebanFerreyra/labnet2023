using Lab.EF.Entities.Entities;
using Lab.EF.Logic.Services;
using Lab.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                bool success = true;
                string id = customersView.CompanyName.Substring(0, 5).ToUpper();
                var customersEntity = new Customers
                {
                    CustomerID = id,
                    CompanyName = customersView.CompanyName,
                    ContactName = customersView.ContactName,
                    Address = customersView.Address,
                    Phone = customersView.Phone,
                };

                var result =  customersService.Add(customersEntity);
                if (!result)
                {
                    success = false;
                    return Json(new { success = false, errorMessage = "Error al insertar el cliente." });
                }

                return Json(new { success = true });
            }
            catch (System.NullReferenceException)
            {
                return RedirectToAction("Index", "Error");
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
                bool success = true;
                var result = customersService.Delete(id);
                if (!result)
                {
                    success = false;    
                }
                return Json(new { success = success });
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
                bool success = true;
                var result = customersService.Update(updatePhoneView.CustomerID, updatePhoneView.Phone);
                if (!result)
                {
                    return Json(new { success = false, errorMessage = "Error al actualizar el teléfono." });
                }
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}