using System;
using System.Collections.Generic;
using System.Linq;

namespace Rago
{
 public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Ingresar numeros enteros separados por una ',':");
                Console.WriteLine("### Ejemplo 1,2,8 ###");
                var numberString = Console.ReadLine();
                List<string> myStringList = numberString.Split(',').ToList();
                List<int> myIntList = myStringList.Select(s => int.Parse(s)).ToList();

                var returnList = new Rangos().CompletarRango(myIntList);
                string combindedString = string.Join(",", returnList.ToArray());
                
                if(combindedString != string.Empty)
                {
                    Console.WriteLine("Salida: [" + combindedString + "]");
                }
                else
                {
                    Console.WriteLine("Error: Existe número(s) negativo(s)");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

    }
}
