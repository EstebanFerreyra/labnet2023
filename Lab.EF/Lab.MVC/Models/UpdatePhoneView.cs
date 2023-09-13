using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.MVC.Models
{
    public class UpdatePhoneView
    {
        [Required(ErrorMessage = "El id del cliente es obligatorio.")]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "El nuevo numero de telefono es obligatorio.")]
        public string Phone { get; set; }
    }
}