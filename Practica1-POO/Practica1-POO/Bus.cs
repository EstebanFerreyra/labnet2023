using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_POO
{
    public class Bus : PublicTransport
    {
        public Bus(int passengers) : base(passengers)
        {
        }

        public override string Advance()
        {
            return $"Omnibus avanzando";
        }

        public override string Stop()
        {
            return $"Omnibus deteniendose";
        }
    }
}
