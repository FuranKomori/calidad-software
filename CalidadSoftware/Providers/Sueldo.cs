using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalidadSoftware.Providers
{
    public class Sueldo
    {

        public float Carga { get; set; }

        public float Antiguedad { get; set; }

        public float Bono { get; set; }

        public float Gratificacion { get; set; }

        public float Isapre { get; set; }

        public float Seguro { get; set; }

        public float AFP { get; set; }

        public float Otros { get; set; }


        public float Bonificacion { get; set; }

        public float Descuento { get; set; }

        public float Sueldo_Final { get; set; }


        public double Calc_Bonificacion(int Sueldo, int Gratificacion, int Antiguedad, int Carga_Familiar)
        {
            double Resultado;
            double bono = 0.20;
            int Carga= 7000;
            double bono_antiguedad= 0.05;

            Resultado = Sueldo * bono;
            Resultado = Resultado + (Sueldo * (Antiguedad * bono_antiguedad));
            Resultado = Resultado + (Carga_Familiar * Carga);
            Resultado = Resultado + Gratificacion;

            return Resultado;
        }

        public double Calc_Descuento(int Sueldo)
        {
            double Resultado;
            double Isapre = 0.07;
            double Afp = 0.12;
            int Seguro = 15000;


            Resultado = Sueldo * Isapre;
            Resultado = Resultado + (Sueldo * Afp);
            Resultado = Resultado + Seguro;

            return Resultado;
        }
    }


}