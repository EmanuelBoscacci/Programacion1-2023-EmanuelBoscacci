using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAPISatelite.Helper
{
    public class Calculos
    {



        public static double TerminoIndependiente(double valorx1, double valory1, double valordist)
        {
            // Ejemplo x1^2 + y1^2 - d^2


            double result;
            result = 0;


            result = Math.Pow(valorx1, 2) + Math.Pow(valory1, 2) - Math.Pow(valordist, 2);


            return result;
        }



        public static class cCoordenadas
        {
            public static string CoordAString(double x, double y)
            {
                return "X: " + Math.Round(x, 2).ToString() + "  , Y:  " + Math.Round(y, 2).ToString();
            }
        }
    }
}
