using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Rago;

namespace Rango.Tests
{
    [TestFixture]
   public class CompletarRangoTests
    {

        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// 01 Casuísticas: En la coleccion tipo lista se envia parámetro (1,0,5), la cual el metodo (CompletarRango) debe devolver una lista (0,1,2,3,4,5) 
        /// </summary>
        [Test]
        public static void Test_CompletarRango()
        {

            var obj = new Rangos();
            List<int> listGenerar = new List<int>();
            listGenerar.Add(1);
            listGenerar.Add(0);
            listGenerar.Add(5);

            var result = obj.CompletarRango(listGenerar);

            List<int> listAssert = new List<int>();
            listAssert.Add(0);
            listAssert.Add(1);
            listAssert.Add(2);
            listAssert.Add(3);
            listAssert.Add(4);
            listAssert.Add(5);

            Assert.AreEqual(listAssert, result);
        }

        /// <summary>
        /// 02 Casuísticas: En la coleccion tipo lista se envia parámetro con valor negativo, la cual el metodo (CompletarRango) debe devolver una lista vacía 
        /// </summary>
        [Test]
        public static void Test_CompletarRangoError()
        {
            var obj = new Rangos();
            List<int> listGenerar = new List<int>();
            listGenerar.Add(5);
            listGenerar.Add(-1);
            listGenerar.Add(9);

            var result = obj.CompletarRango(listGenerar);

            List<int> listAssert = new List<int>();
           // listAssert.Add(-1);
            Assert.AreEqual(listAssert, result);
        }
    }
}
