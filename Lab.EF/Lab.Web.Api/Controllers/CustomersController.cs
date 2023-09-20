using Lab.EF.Entities.Entities;
using Lab.EF.Logic.Services;
using Lab.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab.Web.Api.Controllers
{
    [AllowAnonymous]
    public class CustomersController : ApiController
    {
        CustomersService customersService = new CustomersService();

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Customers> customers = customersService.GetAll();

                if (customers == null)
                {
                    return BadRequest("Error al obtener la lista de clientes");
                }

                List<CustomersView> customersView = customers.Select(c => new CustomersView
                {
                    CustomerID = c.CustomerID,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    Address = c.Address,
                    Phone = c.Phone,
                }).ToList();

                return Ok(customersView);
            }
            catch (Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult AddCustomer([FromBody] CustomersView customer)
        {
            try
            {
                string id = customer.CompanyName.Substring(0, 5).ToUpper();

                var customerAdd = new Customers
                {
                    CustomerID = id,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    Address = customer.Address,
                    Phone = customer.Phone,
                };

                bool result = customersService.Add(customerAdd);

                if (result == false)
                {
                    return BadRequest("Error al agregar clientes");
                }

                return Ok("Cliente agregado con exito");
            }
            catch (Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri] string id)
        {
            try
            {
                bool result = customersService.Delete(id);

                if (result == false)
                {
                    return BadRequest("No se pudo borrar el registro");
                }

                return Ok("Registro borrado con exito");
            }
            catch (Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }

        [HttpPatch]
        public IHttpActionResult UpdatePhone([FromBody] UpdatePhoneView updatePhoneView)
        {
            try
            {
                bool result = customersService.Update(updatePhoneView.CustomerID, updatePhoneView.Phone);

                if (result == false)
                {
                    return BadRequest("No se pudo actualizar el registro");
                }

                return Ok("Telefono actualizado con exito");
            }
            catch (Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
    }
}
