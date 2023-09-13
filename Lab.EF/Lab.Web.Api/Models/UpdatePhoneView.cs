using System.ComponentModel.DataAnnotations;

namespace Lab.Web.Api.Models
{
    public class UpdatePhoneView
    {
        [Required(ErrorMessage = "El id del cliente es obligatorio.")]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "El nuevo numero de telefono es obligatorio.")]
        public string Phone { get; set; }
    }
}