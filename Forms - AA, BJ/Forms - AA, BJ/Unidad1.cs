using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;

namespace Forms___AA__BJ
{
    class Unidad1 //System.Globalization
    {
        public Function Funcion { get; set; }
        public Expression ExpresionXi { get; set; }
        public Expression ExpresionXd { get; set; }
        public Expression ExpresionXr { get; set; }
        public Argument ArgumentoXi { get; set; }
        public Argument ArgumentoXd { get; set; }
        public Argument ArgumentoXr { get; set; }

        //private double ResultadoFuncion(double x)
        //{
        //    return Expresion.calculate();
        //}
        public Salida Calcular(string Metodo, string Fx, double Xi, double Xd, int Iteraciones, double Toleracia)
        {
            Funcion = new Function( "Funcion(x) = " + Fx);
            ArgumentoXi = new Argument("ArgumentoXi = " + Xi.ToString(CultureInfo.CreateSpecificCulture("en-GB")));
            ArgumentoXd = new Argument("ArgumentoXd = " + Xd.ToString(CultureInfo.CreateSpecificCulture("en-GB")));
            ExpresionXi= new Expression("Funcion(x)", Funcion, ArgumentoXi);
            ExpresionXd = new Expression("Funcion(x)", Funcion, ArgumentoXd);

            switch (Metodo)
            {
                case "Bisección":
                    int IteracionActual = 0;
                    double ErrorRelativo = 1;
                    Salida Resultado;
                    double Xr = 0;
                    if (ExpresionXi.calculate() * ExpresionXd.calculate() == 0)
                    {
                        if (ExpresionXi.calculate() == 0)
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
                    while ((IteracionActual < Iteraciones))
                    {
                        Xr = (Xd + Xi) / 2;
                        IteracionActual += 1; // Preguntar donde va esto
                        //ErrorRelativo = 0; //Ver esto
                        if (ErrorRelativo < Toleracia)
                        {
                            Resultado = new Salida("Si, error relativo aceptable", Xr.ToString(), IteracionActual, ErrorRelativo);
                            return Resultado;
                        }
                        ArgumentoXr = new Argument("ArgumentoXr = " + Xr.ToString(CultureInfo.CreateSpecificCulture("en-GB")));
                        ExpresionXr = new Expression("Funcion(x)", Funcion, ArgumentoXr);
                        var asd = ExpresionXr.calculate();
                        if (ExpresionXr.calculate() == 0)
                        {
                            Resultado = new Salida("Si", Xr.ToString(), IteracionActual, ErrorRelativo);
                            return Resultado;
                        }
                        else
                        {
                            if (ExpresionXi.calculate() * ExpresionXd.calculate() > 0)
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
