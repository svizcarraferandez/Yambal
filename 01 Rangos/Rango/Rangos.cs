using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Rago
{
   public class Rangos
    {
        /// <summary>
        /// Método toma un parámetro de colección de números enteros positivos 
        /// (1,2,3, ...n) en cualquier orden.
        /// El algoritmo debe completar si faltan números en la colección en el rango dado.
        /// Finalmente devolver la colección completa y ordenada de manera ascendente
        /// </summary>
        /// <param name="listNumber"></param>
        /// <returns>Lista completada y ordenada</returns>
        public List<int> CompletarRango(List<int> listNumber)
        {
            try
            {
                int nroMin = listNumber.Min();
                int nroMax = listNumber.Max();
                int count = nroMin;
                List<int> listGenerar = new List<int>();

                var valList = listNumber.Exists(x => x < 0);
                if (!valList)
                {
                    while (count <= nroMax)
                    {
                        listGenerar.Add(count);
                        count++;
                    }
                }

                return listGenerar;

            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

    }
}
