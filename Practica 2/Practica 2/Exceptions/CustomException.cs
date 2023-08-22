using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException() : base("Este es el mensaje de la custom exception")
        {
            
        }

        public CustomException(string message) : base(message)
        {

        }
    }
}
