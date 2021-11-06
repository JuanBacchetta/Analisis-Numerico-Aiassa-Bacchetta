using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms___AA__BJ
{
    public partial class Unidad_3 : Form
    {
        public Unidad_3()
        {
            InitializeComponent();
            comboBox1.Items.Add("Regresión Lineal");
            comboBox1.Items.Add("Regresión Polinomial");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F1 = new Form1();
            F1.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Regresión Lineal")
            {
                textBox2.Enabled = false;
                textBox4.Enabled = false;
                textBox2.Text = "1";
                textBox4.Text = "";
            }
            else
            {
                textBox2.Enabled = true;
                textBox4.Enabled = true;
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double N = dataGridView1.Rows.Count - 1;
            if (comboBox1.Text == "Regresión Lineal")
            {
                double SumaXi = 0;
                double SumaXiCuadrado = 0;
                double SumaYi = 0;
                double SumaXiYi = 0;
                foreach (DataGridViewRow Row in dataGridView1.Rows)
                {
                    if (Row.Index != N)
                    {
                        SumaXi = SumaXi + double.Parse(Row.Cells[0].Value.ToString());
                        SumaXiCuadrado = SumaXiCuadrado + (double.Parse(Row.Cells[0].Value.ToString())) * (double.Parse(Row.Cells[0].Value.ToString()));
                        SumaYi = SumaYi + double.Parse(Row.Cells[1].Value.ToString());
                        SumaXiYi = SumaXiYi + double.Parse(Row.Cells[0].Value.ToString()) * double.Parse(Row.Cells[1].Value.ToString());
                    }
                }
                double Determinante = N * SumaXiCuadrado - Math.Pow(SumaXi,2);
                double DeterminanteA1 = N * SumaXiYi - SumaXi * SumaYi;
                double A1 = DeterminanteA1 / Determinante;
                double A0 = (SumaYi - A1 * SumaXi) / N;
                double PromedioYi = SumaYi / N;
                textBox6.Text = "y = " + A1.ToString() + "x + " + A0.ToString();
                double SumaDiCuadradoRectaHallada = 0;
                double SumaDiCuadradoRectaPromedioY = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index != N)
                    {
                        double y = A1 * double.Parse(row.Cells[0].Value.ToString()) + A0;
                        SumaDiCuadradoRectaHallada = SumaDiCuadradoRectaHallada + Math.Pow(y - double.Parse(row.Cells[1].Value.ToString()), 2);
                        SumaDiCuadradoRectaPromedioY = SumaDiCuadradoRectaPromedioY + Math.Pow(double.Parse(row.Cells[1].Value.ToString()) - PromedioYi, 2);
                    }
                }
                double CoeficienteCorrelacion = Math.Sqrt((SumaDiCuadradoRectaPromedioY - SumaDiCuadradoRectaHallada) / SumaDiCuadradoRectaPromedioY) * 100;
                textBox5.Text = CoeficienteCorrelacion.ToString(); //Pasar a porcentaje 0,88 = 88%
                if (CoeficienteCorrelacion >= 80)
                {
                    textBox3.Text = "Ajuste Aceptable";
                }
                else
                {
                    textBox3.Text = "Ajuste insuficiente";
                }

            }
            else
            {
                if (comboBox1.Text == "Regresión Polinomial")
                {
                    X0X.Text = "";
                    X1X.Text = "";
                    X2X.Text = "";
                    X3X.Text = "";
                    X4X.Text = "";
                    X5X.Text = "";
                    X6X.Text = "";
                    X7X.Text = "";
                    X8X.Text = "";
                    X9X.Text = "";
                    X10X.Text = "";
                    int grado = int.Parse(textBox2.Text);
                    double SumaYi = 0;
                    double[,] Matriz = new double[grado + 1, grado + 2];
                    foreach (DataGridViewRow Row in dataGridView1.Rows)
                    {
                        if (Row.Index != N)
                        {
                            SumaYi = SumaYi + double.Parse(Row.Cells[1].Value.ToString());
                            for (int j = 0; j <= grado; j++)
                            {
                                for (int k = 0; k <= grado; k++)
                                {
                                    Matriz[j, k] += Math.Pow(double.Parse(Row.Cells[0].Value.ToString()), j + k);
                                }
                                Matriz[j, grado + 1] += double.Parse(Row.Cells[1].Value.ToString()) * Math.Pow(double.Parse(Row.Cells[0].Value.ToString()), j);
                            }
                        }
                    }
                    double PromedioYi = SumaYi / N;
                    for (int k = 0; k <= grado; k++)
                    {
                        int bandera = 0;
                        for (int i = k; i <= grado; i++)
                        {
                            double coeficiente = 9999999;
                            int flag = 0;
                            double NumeroParaHacer0ElTrianguloInferior = 0;
                            for (int j = k; j <= grado + 1; j++)
                            {
                                if (i == j && i == k)
                                {
                                    coeficiente = Matriz[i, j];
                                    Matriz[i, j] = Matriz[i, j] / coeficiente;
                                }
                                else
                                {
                                    if (i == k)
                                    {
                                        if (coeficiente == 0)
                                        {
                                            bandera = 1;
                                            break;
                                        }
                                        Matriz[i, j] = Matriz[i, j] / coeficiente;
                                    }
                                    else
                                    {
                                        if (flag == 0)
                                        {
                                            flag = 1;
                                            NumeroParaHacer0ElTrianguloInferior = Matriz[i, k];
                                        }
                                        Matriz[i, j] = Matriz[i, j] + Matriz[k, j] * NumeroParaHacer0ElTrianguloInferior * -1;
                                    }
                                }
                            }
                            if (bandera == 1)
                            {
                                break;
                            }
                        }
                        if (bandera == 1)
                        {
                            break;
                        }
                    }
                    Controls.Find($"X{grado}X", false).First().Text = Matriz[grado, grado + 1].ToString();
                    //Aca posiblemente va un if por si la bandera q controla la division por 0 se activa
                    //for (int i = 0; i <= grado; i++)
                    //{
                    //    Controls.Find($"X{i}X", false).First().Text = Matriz[i, grado+1].ToString();
                    //}
                    for (int i = grado; i >= 0; i--)
                    {
                        double X = 0;
                        for (int j = grado; j >= 0; j--)
                        {
                            if (i == j)
                            {
                                X = X + Matriz[i, grado + 1];
                            }
                            else
                            {
                                if (Controls.Find($"X{j}X", false).First().Text == "")
                                {
                                    X = X - Matriz[i, j] * 0;
                                }
                                else
                                {
                                    X = X - Matriz[i, j] * double.Parse(Controls.Find($"X{j}X", false).First().Text);
                                }
                            }

                            //if (i < j && j != grado)
                            //{
                            //    X = X - Matriz[i, j] * double.Parse(Controls.Find($"X{j}X", false).First().Text); // Puede estar aca el error (agarrando un LabelX equivocado)
                            //}
                            //if (j == grado)
                            //{
                            //    X = Matriz[i, j];
                            //}
                        }
                        Controls.Find($"X{i}X", false).First().Text = X.ToString();
                    }

                    double SumaDiCuadradoRectaHallada = 0;
                    double SumaDiCuadradoRectaPromedioY = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Index != N)
                        {
                            double y = 0;
                            for (int i = grado; i >= 0; i--)
                            {
                                y += double.Parse(Controls.Find($"X{i}X", false).First().Text) * Math.Pow(double.Parse(row.Cells[0].Value.ToString()), i);
                            }
                            SumaDiCuadradoRectaHallada = SumaDiCuadradoRectaHallada + Math.Pow(y - double.Parse(row.Cells[1].Value.ToString()), 2);
                            SumaDiCuadradoRectaPromedioY = SumaDiCuadradoRectaPromedioY + Math.Pow(double.Parse(row.Cells[1].Value.ToString()) - PromedioYi, 2);
                        }
                    }
                    string yEscrito = "";
                    for (int i = grado; i >= 0; i--)
                    {
                        if (double.Parse(Controls.Find($"X{i}X", false).First().Text) >= 0)
                        {
                            if (i == grado)
                            {
                                yEscrito = "+" + Controls.Find($"X{i}X", false).First().Text + "x^(" + i + ")";
                            }
                            if (i == 0)
                            {
                                yEscrito = yEscrito + "+" + Controls.Find($"X{i}X", false).First().Text;
                            }
                            if (i != grado && i != 0)
                            {
                                yEscrito = yEscrito + "+" + Controls.Find($"X{i}X", false).First().Text + "x^(" + i + ")";
                            }
                        }
                        else
                        {
                            if (i == grado)
                            {
                                yEscrito = "-" + Controls.Find($"X{i}X", false).First().Text + "x^(" + i + ")";
                            }
                            if (i == 0)
                            {
                                yEscrito = yEscrito + "-" + Controls.Find($"X{i}X", false).First().Text;
                            }
                            if (i != grado && i != 0)
                            {
                                yEscrito = yEscrito + "-" + Controls.Find($"X{i}X", false).First().Text + "x^(" + i + ")";
                            }
                        }
                    }
                    var ASD10 = (SumaDiCuadradoRectaPromedioY - SumaDiCuadradoRectaHallada);
                    var ASD20 = ASD10 / SumaDiCuadradoRectaPromedioY;
                    var ASD3 = Math.Sqrt(ASD20);
                    var ASD4 = ASD3 * 100;
                    double CoeficienteCorrelacion = Math.Sqrt((SumaDiCuadradoRectaPromedioY - SumaDiCuadradoRectaHallada) / SumaDiCuadradoRectaPromedioY) * 100;
                    textBox5.Text = CoeficienteCorrelacion.ToString(); //Pasar a porcentaje 0,88 = 88%
                    if (CoeficienteCorrelacion >= 80)
                    {
                        textBox3.Text = "Ajuste Aceptable";
                    }
                    else
                    {
                        textBox3.Text = "Ajuste insuficiente";
                    }
                    textBox6.Text = yEscrito;
                }
            }
        }
    }
}
