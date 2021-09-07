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
        public Expression ExpresionTole { get; set; }
        public string ArgumentoXi { get; set; }
        public string ArgumentoXd { get; set; }
        public string ArgumentoXr { get; set; }
        public string ArgumentoTole { get; set; }
        public double ToleranciaOK { get; set; }
        public double VarParaTole { get; set; }

        //private double ResultadoFuncion(double x)
        //{
        //    return Expresion.calculate();
        //}
        public Salida Calcular(string Metodo, string Fx, double Xi, double Xd, int Iteraciones, double Toleracia)
        {
            Funcion = new Function( "Funcion(x) = " + Fx);
            ArgumentoXi = Xi.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            ArgumentoXd = Xd.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            ArgumentoTole = Toleracia.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            ToleranciaOK = double.Parse(ArgumentoTole.Replace(".",","));
            VarParaTole = double.Parse(ArgumentoXi) + ToleranciaOK;
            ExpresionXi = new Expression("Funcion(" + ArgumentoXi + ")",Funcion);
            ExpresionXd = new Expression("Funcion(" + ArgumentoXd + ")",Funcion);
            ExpresionTole = new Expression("Funcion(" + VarParaTole.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ")", Funcion);
            int IteracionActual = 0;
            double ErrorRelativo = 99999999;
            Salida Resultado;
            double Xr = 0;

            var PrimeraIteracion = 0;
            double XrAnt = 0;
            switch (Metodo)
            {
                case "Bisección":
                    
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
                        if (PrimeraIteracion == 1)
                        {
                            XrAnt = Xr;
                            
                        }
                        Xr = (Xd + Xi) / 2;
                        IteracionActual += 1; // Preguntar donde va esto
                        if (PrimeraIteracion == 1)
                        {
                            ErrorRelativo = Math.Abs((( Xr - XrAnt) / Xr)); //Ver esto
                        }
                        if (PrimeraIteracion == 0)
                        {
                            PrimeraIteracion = 1;
                        }
                        if (ErrorRelativo < ToleranciaOK)
                        {
                            Resultado = new Salida("Si, error relativo aceptable", Xr.ToString(), IteracionActual, ErrorRelativo);
                            return Resultado;
                        }
                        ArgumentoXr = Xr.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                        ExpresionXr = new Expression("Funcion(" + ArgumentoXr + ")", Funcion);
                        var asd2 = ExpresionXr.calculate();
                        if (ExpresionXr.calculate() == 0)
                        {
                            Resultado = new Salida("Si", Xr.ToString(), IteracionActual, ErrorRelativo);
                            return Resultado;
                        }
                        else
                        {
                            var asd = ExpresionXi.calculate() * ExpresionXr.calculate();
                            if (ExpresionXi.calculate() * ExpresionXr.calculate() > 0)
                            {
                                Xi = Xr;
                                ArgumentoXi = Xi.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                                ExpresionXi = new Expression("Funcion(" + ArgumentoXi + ")", Funcion);
                            }
                            else
                            {
                                Xd = Xr;
                                ArgumentoXd = Xd.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                                ExpresionXd = new Expression("Funcion(" + ArgumentoXd + ")", Funcion);
                            }
                        }
                    }
                    Resultado = new Salida("No", "", IteracionActual, ErrorRelativo);
                    return Resultado;
                case "Regla Falsa":
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
                        if (PrimeraIteracion == 1)
                        {
                            XrAnt = Xr;
                            
                        }
                        Xr = (ExpresionXd.calculate() * Xi - ExpresionXi.calculate() * Xd) / (ExpresionXd.calculate() - ExpresionXi.calculate()) ;
                        IteracionActual += 1; // Preguntar donde va esto
                        if (PrimeraIteracion == 1)
                        {
                            ErrorRelativo = Math.Abs((( Xr - XrAnt) / Xr)); //Ver esto
                        }
                        if (PrimeraIteracion == 0)
                        {
                            PrimeraIteracion = 1;
                        }
                        if (ErrorRelativo < ToleranciaOK)
                        {
                            Resultado = new Salida("Si, error relativo aceptable", Xr.ToString(), IteracionActual, ErrorRelativo);
                            return Resultado;
                        }
                        ArgumentoXr = Xr.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                        ExpresionXr = new Expression("Funcion(" + ArgumentoXr + ")", Funcion);
                        var asd2 = ExpresionXr.calculate();
                        if (ExpresionXr.calculate() == 0)
                        {
                            Resultado = new Salida("Si", Xr.ToString(), IteracionActual, ErrorRelativo);
                            return Resultado;
                        }
                        else
                        {
                            var asd = ExpresionXi.calculate() * ExpresionXr.calculate();
                            if (ExpresionXi.calculate() * ExpresionXr.calculate() > 0)
                            {
                                Xi = Xr;
                                ArgumentoXi = Xi.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                                ExpresionXi = new Expression("Funcion(" + ArgumentoXi + ")", Funcion);
                            }
                            else
                            {
                                Xd = Xr;
                                ArgumentoXd = Xd.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                                ExpresionXd = new Expression("Funcion(" + ArgumentoXd + ")", Funcion);
                            }
                        }
                    }
                    Resultado = new Salida("No", "", IteracionActual, ErrorRelativo);
                    return Resultado;
                case "Newton-Raphson":                    
                    if (Math.Abs(ExpresionXi.calculate()) < ToleranciaOK)
                    {
                        Resultado = new Salida("Si, X Inicial es Raiz", Xi.ToString(), IteracionActual, ErrorRelativo);
                        return Resultado;
                    }
                    while (IteracionActual < Iteraciones)
                    {
                        IteracionActual += 1;
                        var LOL1 = ExpresionTole.calculate();
                        var LOL2 = ExpresionXi.calculate();
                        double DerivadaXi = (ExpresionTole.calculate() - ExpresionXi.calculate()) / ToleranciaOK;
                        if (PrimeraIteracion == 1)
                        {
                            XrAnt = Xr;
                        }
                        Xr = Xi - (ExpresionXi.calculate() / DerivadaXi);
                        if (PrimeraIteracion == 1)
                        {
                            ErrorRelativo = Math.Abs((Xr - XrAnt) / Xr);
                        }
                        if (PrimeraIteracion == 0)
                        {
                            PrimeraIteracion = 1;
                        }
                        ArgumentoXr = Xr.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                        ExpresionXr = new Expression("Funcion(" + ArgumentoXr + ")", Funcion);
                        if (Math.Abs(ExpresionXr.calculate()) < ToleranciaOK)
                        {
                            Resultado = new Salida("Si, valor de funcion en Xr < Tolerancia", Xr.ToString(), IteracionActual, ErrorRelativo);
                            return Resultado;
                        }
                        if (ErrorRelativo < ToleranciaOK)
                        {
                            Resultado = new Salida("Si, error relativo aceptable", Xr.ToString(), IteracionActual, ErrorRelativo);
                            return Resultado;
                        }
                        Xi = Xr;
                        ArgumentoXi = Xi.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                        ExpresionXi = new Expression("Funcion(" + ArgumentoXi + ")", Funcion);
                        //VarParaTole = double.Parse(ArgumentoXi) + ToleranciaOK;
                        //ExpresionTole = new Expression("Funcion(" + VarParaTole.ToString(CultureInfo.CreateSpecificCulture("en-GB")) + ")", Funcion);
                        XrAnt = Xr;
                    }
                    Resultado = new Salida("No", "", IteracionActual, ErrorRelativo);
                    return Resultado;
                case "Secante":
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
                    if (ExpresionXi.calculate() == ExpresionXd.calculate())
                    {
                        Resultado = new Salida("No, Valores de Funcion Iguales", "", IteracionActual, ErrorRelativo);
                        return Resultado;
                    }
                    while (IteracionActual < Iteraciones)
                    {
                        if (PrimeraIteracion == 1)
                        {
                            XrAnt = Xr;

                        }
                        Xr = (ExpresionXi.calculate() * Xd - ExpresionXd.calculate() * Xi) / (ExpresionXi.calculate() - ExpresionXd.calculate());
                        IteracionActual += 1; // Preguntar donde va esto
                        if (PrimeraIteracion == 1)
                        {
                            ErrorRelativo = Math.Abs(((Xr - XrAnt) / Xr)); //Ver esto
                        }
                        if (PrimeraIteracion == 0)
                        {
                            PrimeraIteracion = 1;
                        }
                        ArgumentoXr = Xr.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                        ExpresionXr = new Expression("Funcion(" + ArgumentoXr + ")", Funcion);
                        var AAA = Math.Abs(ExpresionXr.calculate());
                        if (Math.Abs(ExpresionXr.calculate()) < ToleranciaOK)
                        {
                            Resultado = new Salida("Si", Xr.ToString(), IteracionActual, ErrorRelativo);
                            return Resultado;
                        }
                        Xd = Xi;
                        Xi = Xr;
                    }
                    Resultado = new Salida("No", "", IteracionActual, ErrorRelativo);
                    return Resultado;
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
