using Practica_2.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Exercise1();
            Exercise2();
            Exercise3();
            Exercise4();

            Console.ReadKey();
        }

        public static double ThrowDivisionByZeroException(string num)
        {
            try
            {
                return Int32.Parse(num) / 0;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Mensaje de la excepcion de dividir por cero: {ex.Message}");
                return 0;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Mensaje de la excepcion: {ex.Message}");
                return 0;
            }
            finally
            {
                Console.WriteLine("Fin del ejercico 1.");
            }
        }

        public static double Division(string num1, string num2)
        {
            try
            {
                return Int32.Parse(num1) / Int32.Parse(num2);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("¡Solo Chuck Norris divide por cero!");
                Console.WriteLine($"Mensaje de la excepcion: {ex.Message}");
                return 0;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
                Console.WriteLine($"Mensaje de la excepcion: {ex.Message}");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Mensaje de la excepcion: {ex.Message}");
                return 0;
            }
            finally
            {
                Console.WriteLine("Fin del ejercico 2.");
            }
        }

        public static void Exercise1()
        {
            Console.WriteLine("EJERCICIO 1");
            Console.WriteLine("Ingrese el numero del dividendo: ");
            string num = Console.ReadLine();

            ThrowDivisionByZeroException(num);
        }

        public static void Exercise2()
        {
            Console.WriteLine("EJERCICIO 2");
            Console.WriteLine("Ingrese el numero del dividendo: ");
            string num1 = Console.ReadLine();
            Console.WriteLine("Ingrese el numero del divisor: ");
            string num2 = Console.ReadLine();

            Division(num1, num2);
        }

        public static void Exercise3()
        {
            Console.WriteLine("EJERCICIO 3");
            try
            {
                Logic.ThrowException();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Mensaje de la excepcion: {ex.Message}");
                Console.WriteLine($"Tipo de excepcion: {ex.GetType()}");
            }
            finally
            {
                Console.WriteLine("Fin del ejercico 3.");
            }
        }

        public static void Exercise4()
        {
            Console.WriteLine("EJERCICIO 4");
            try
            {
                Logic.ThrowCustomException();
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Mensaje de la excepcion: {ex.Message}");
                Console.WriteLine($"Tipo de excepcion: {ex.GetType()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Mensaje de la excepcion: {ex.Message}");
                Console.WriteLine($"Tipo de excepcion: {ex.GetType()}");
            }
            finally
            {
                Console.WriteLine("Fin del ejercico 4.");
            }
        }
    }
}
