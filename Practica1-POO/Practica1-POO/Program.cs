using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_POO
{
    internal class Program
    {
        // Definimos las cantidades maximas de pasajeros depende el tipo de transporte.
        private const int _maxCabPassengers = 4;
        private const int _maxBusPassengers = 120;

        static void Main(string[] args)
        {
            List<PublicTransport> publicTransport = new List<PublicTransport>();

            publicTransport = PassengerEntry();

            ShowListTransports(publicTransport);

            Console.ReadKey();
        }

        // Metodo que realiza la carga de los pasajeros en cada vehiculo.
        public static List<PublicTransport> PassengerEntry()
        {
            List<PublicTransport> publicTransport = new List<PublicTransport>();

            for (int i = 0; i < 10; i++)
            {
                if (i <= 4)
                {
                    Console.WriteLine($"Ingrese la cantidad de pasajeros del {i + 1}° omnibus");
                    int cantPasajeros = ValidationPassengers(_maxBusPassengers);
                    publicTransport.Add(new Bus(cantPasajeros));
                } 
                else
                {
                    Console.WriteLine($"Ingrese la cantidad de pasajeros del {i-4}° taxi");
                    int cantPasajeros = ValidationPassengers(_maxCabPassengers);
                    publicTransport.Add(new Cab(cantPasajeros));
                }                
            }

            return publicTransport;
        }

        // Metodo que valida si la cantidad de pasajeros ingresada es válida o no dependiendo del vehiculo.
        private static int ValidationPassengers(int maxPassengers)
        {
            int numberPassengers;

            while ((!int.TryParse(Console.ReadLine(), out numberPassengers)) || (numberPassengers <= 0) || (numberPassengers > maxPassengers))
            {
                Console.WriteLine($"Ingrese una cantidad válida de pasajeros - Desde 1 a {maxPassengers} pasajeros");
            }

            return numberPassengers;
        }

        // Metodo que recorre la lista de transportes publicos y va mostrando la cantidad de pasajeros que hay en cada uno.
        public static void ShowListTransports(List<PublicTransport> publicTransport)
        {
            int i = 0;
            foreach (var transport in publicTransport)
            {
                if (i < 5)
                {
                    Console.WriteLine($"Omnibus {i + 1}: {transport.GetPassengers()} pasajeros");
                }
                else
                {
                    Console.WriteLine($"Taxi {i - 4}: {transport.GetPassengers()} pasajeros");
                }
                i++;
            }
        }
    }
}
