using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms___AA__BJ
{
    class Unidad2
    {
        public Salida Calcular(string Metodo, string Fx, double Xi, double Xd, int Iteraciones, double Toleracia, int Tamaño)
        {
            switch (Metodo)
            {
                case "Gauss-Jordan":
                    for (int j = 0; j < Tamaño + 1; j++)
                    {
                        for (int i = 0; i < Tamaño; i++)
                        {
                            if (i==j)
                            {
                                //double coeficiente = 
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            Salida asd = new Salida("", "", 0, 0);
            return asd;
        }
    }
}
