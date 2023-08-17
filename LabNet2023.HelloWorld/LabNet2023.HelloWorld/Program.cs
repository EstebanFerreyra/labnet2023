using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNet2023.HelloWorld
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello World");
        //}

        // En este metodo esta el menu principal. Es el encargado de llamar a los demas metodos para que el programa funcione.
        static void Main(string[] args)
        {
            Console.WriteLine("SALUDO (i - ingles | e - español | 0 - salir)");
            string letter;

            do
            {
                letter = LetterValidation();
                Console.WriteLine(Greeting(letter));
                if (letter != "0")
                {
                    Console.WriteLine("SALUDO (i - ingles | e - español | 0 - salir)");
                }
            } while (letter != "0");
            Console.ReadKey();
        }

        // Este motodo valida que el caracter ingresado sea valido para el programa (i, e o 0).
        static string LetterValidation()
        {
            string letter = Console.ReadLine();

            while ((letter.Length != 0) && (letter != "i") && (letter != "e") && (letter != "0"))
            {
                Console.WriteLine("Porfavor ingrese una opción válida: ");
                letter = Console.ReadLine();
            }
            return letter;
        }

        // Este metodo devuelve un string de acuerdo al caracter que le pasamos por parametro.
        static string Greeting(string letter)
        {
            const string greetingInSpanish = "Hola mundo!";
            const string greetingInEnglish = "Hello world!";
            const string farewell = "Hasta la proxima!";

            if (letter != "e")
            {
                if (letter == "i")
                {
                    return greetingInEnglish;
                }
            }
            else
            {
                return greetingInSpanish;
            }
            return farewell;
        }
    }
}