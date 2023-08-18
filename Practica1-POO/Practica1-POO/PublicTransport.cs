using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_POO
{
    public abstract class PublicTransport
    {
        private int _passengers { get; set; }

        public PublicTransport(int passengers)
        {
            this._passengers = passengers;
        }

        public abstract string Advance();
        public abstract string Stop();

        public int GetPassengers()
        {
            return this._passengers;
        }
    }
}
