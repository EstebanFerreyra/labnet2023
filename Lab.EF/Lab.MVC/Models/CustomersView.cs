using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.MVC.Models
{
    public class CustomersView
    {
        [Required(ErrorMessage = "El id del cliente es obligatorio.")]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "El nombre de la compania es obligatorio.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "La direccion del cliente es obligatorio.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El numero de telefono del cliente es obligatorio.")]
        public string Phone { get; set; }
    }
}