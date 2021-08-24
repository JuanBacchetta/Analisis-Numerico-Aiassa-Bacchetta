using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;

namespace Forms___AA__BJ
{
    class Unidad1 //System.Globalization
    {
        public Function Expresion { get; set; }

        private double ResultadoFuncion(double x)
        {
            return Expresion.calculate(x);
        }
        public Salida Calcular(string Metodo, string Fx, double Xi, double Xd, int Iteraciones, double Toleracia)
        {
            Expresion = new Function(Fx);
            switch (Metodo)
            {
                case "Bisección":
                    int IteracionActual = 0;
                    double ErrorRelativo = 1;
                    Salida Resultado;
                    double Xr = 0;
                    while ((IteracionActual < Iteraciones))
                    {
                        if (ResultadoFuncion(Xi) * ResultadoFuncion(Xd) == 0)
                        {
                            if (ResultadoFuncion(Xi)==0)
                            {
                                Resultado = new Salida("Si, Xi ya era Raiz", Xi.ToString(), IteracionActual, ErrorRelativo);
                                return Resultado;
                            }
                            else
                            {
                                Resultado = new Salida("Si, Xd ya era Raiz", Xd.ToString(), IteracionActual, ErrorRelativo);
                                return Resultado;
                            }
                        }
                        Xr = (Xd * Xi) / 2;
                        IteracionActual += 1; // Preguntar donde va esto
                        //ErrorRelativo = 0; //Ver esto
                        if (ErrorRelativo < Toleracia)
                        {
                            Resultado = new Salida("Si, error relativo aceptable", Xr.ToString(), IteracionActual, ErrorRelativo);
                            return Resultado;
                        }
                        if (ResultadoFuncion(Xr) == 0)
                        {
                            Resultado = new Salida("Si", Xr.ToString(), IteracionActual, ErrorRelativo);
                            return Resultado;
                        }
                        else
                        {
                            if (ResultadoFuncion(Xi) * ResultadoFuncion(Xd) > 0)
                            {
                                Xi = Xr;
                            }
                            else
                            {
                                Xd = Xr;
                            }
                        }
                    }
                    Resultado = new Salida("No", "", IteracionActual, ErrorRelativo);
                    return Resultado;
                //case "Regla Falsa":
                //    break;
                //case "Newton-Raphson":
                //    break;
            }
            return new Salida("ERROR","ERROR",-1,-1) ;
        }
    }
    class Salida
    {
        public string Convergencia { get; set; }
        public string Xr { get; set; }
        public int IteracionesRealizadas { get; set; }
        public double ErrorRelativo { get; set; }
        public Salida(string converge, string xr, int iteracionesRealizadas, double errorRelativo)
        {
            Convergencia = converge;
            Xr = xr;
            IteracionesRealizadas = iteracionesRealizadas;
            ErrorRelativo = errorRelativo;
        }
    }
}
