using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_POO
{
    public class Cab : PublicTransport
    {
        public Cab(int passengers) : base(passengers)
        {
        }

        public override string Advance()
        {
            return $"Taxi avanzando";
        }

        public override string Stop()
        {
            return $"Taxi deteniendose";
        }
    }
}
