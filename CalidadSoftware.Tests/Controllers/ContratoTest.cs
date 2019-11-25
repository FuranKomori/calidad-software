using CalidadSoftware.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalidadSoftware.Tests.Controllers
{
    [TestClass()]
    public class ContratoTest
    {
        //Calc_Descuento
        //Calc_Bonificacion
        [TestMethod()]
        public void Calcular_DescuentoTest_T1()
        {

            int Sueldo = 102500;
            int ResEsperado = 34475;

            Sueldo calcular = new Sueldo();

            var result = calcular.Calc_Descuento(Sueldo);
            try
            {
                Assert.AreEqual(ResEsperado, result);
            }
            catch (Exception ex)
            {
                //Resultado
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod()]
        public void Calcular_DescuentoTest_T2()
        {

            int Sueldo = 305000;
            int ResEsperado = 72950;

            Sueldo calcular = new Sueldo();

            var result = calcular.Calc_Descuento(Sueldo);
            try
            {
                Assert.AreEqual(ResEsperado, result);
            }
            catch (Exception ex)
            {
                //Resultado
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod()]
        public void Calcular_DescuentoTest_T3()
        {

            int Sueldo = 420000;
            int ResEsperado = 94800;

            Sueldo calcular = new Sueldo();

            var result = calcular.Calc_Descuento(Sueldo);
            try
            {
                Assert.AreEqual(ResEsperado, result);
            }
            catch (Exception ex)
            {
                //Resultado
                Assert.Fail(ex.Message);
            }

        }


        [TestMethod()]
        public void Calcular_DescuentoTest_T4()
        {

            int Sueldo = 750000;
            int ResEsperado = 157500;

            Sueldo calcular = new Sueldo();

            var result = calcular.Calc_Descuento(Sueldo);
            try
            {
                Assert.AreEqual(ResEsperado, result);
            }
            catch (Exception ex)
            {
                //Resultado
                Assert.Fail(ex.Message);
            }

        }

        
        [TestMethod()]
        public void Calcular_DescuentoTest_T5()
        {

            int Sueldo = 1250000;
            int ResEsperado = 252500;

            Sueldo calcular = new Sueldo();

            var result = calcular.Calc_Descuento(Sueldo);
            try
            {
                Assert.AreEqual(ResEsperado, result);
            }
            catch (Exception ex)
            {
                //Resultado
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod()]
        public void Calcular_BonoTest_T1()
        {

            int Sueldo = 125000;
            int Gratificacion = 15000;
            int Antiguedad = 5;
            int Carga_Familiar = 1;

            int ResEsperado = 78250;

            Sueldo calcular = new Sueldo();

            var result = calcular.Calc_Bonificacion(Sueldo,Gratificacion,Antiguedad,Carga_Familiar);
            try
            {
                Assert.AreEqual(ResEsperado, result);
            }
            catch (Exception ex)
            {
                //Resultado
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod()]
        public void Calcular_BonoTest_T2()
        {

            int Sueldo = 225000;
            int Gratificacion = 15000;
            int Antiguedad = 2;
            int Carga_Familiar = 0;

            int ResEsperado = 82500;

            Sueldo calcular = new Sueldo();

            var result = calcular.Calc_Bonificacion(Sueldo, Gratificacion, Antiguedad, Carga_Familiar);
            try
            {
                Assert.AreEqual(ResEsperado, result);
            }
            catch (Exception ex)
            {
                //Resultado
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod()]
        public void Calcular_BonoTest_T3()
        {

            int Sueldo = 525000;
            int Gratificacion = 15000;
            int Antiguedad = 10;
            int Carga_Familiar = 5;

            int ResEsperado = 417500;

            Sueldo calcular = new Sueldo();

            var result = calcular.Calc_Bonificacion(Sueldo, Gratificacion, Antiguedad, Carga_Familiar);
            try
            {
                Assert.AreEqual(ResEsperado, result);
            }
            catch (Exception ex)
            {
                //Resultado
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod()]
        public void Calcular_BonoTest_T4()
        {

            int Sueldo = 1200000;
            int Gratificacion = 15000;
            int Antiguedad = 3;
            int Carga_Familiar = 0;

            int ResEsperado = 435000;

            Sueldo calcular = new Sueldo();

            var result = calcular.Calc_Bonificacion(Sueldo, Gratificacion, Antiguedad, Carga_Familiar);
            try
            {
                Assert.AreEqual(ResEsperado, result);
            }
            catch (Exception ex)
            {
                //Resultado
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod()]
        public void Calcular_BonoTest_T5()
        {

            int Sueldo = 350000;
            int Gratificacion = 15000;
            int Antiguedad = 1;
            int Carga_Familiar = 2;

            int ResEsperado = 116500;

            Sueldo calcular = new Sueldo();

            var result = calcular.Calc_Bonificacion(Sueldo, Gratificacion, Antiguedad, Carga_Familiar);
            try
            {
                Assert.AreEqual(ResEsperado, result);
            }
            catch (Exception ex)
            {
                //Resultado
                Assert.Fail(ex.Message);
            }

        }







    }
}
