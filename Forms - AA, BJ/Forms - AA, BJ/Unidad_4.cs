using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms___AA__BJ
{
    public partial class Unidad_4 : Form
    {
        public Unidad_4()
        {
            InitializeComponent();
            comboBox1.Items.Add("Trapecio Simple");
            comboBox1.Items.Add("Trapecio Multiple");
            comboBox1.Items.Add("Simpson 1/3 Simple");
            comboBox1.Items.Add("Simpson 1/3 Multiple");
            comboBox1.Items.Add("Simpson 3/8");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F1 = new Form1();
            F1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Function Funcion = new Function("Funcion(x) =" + textBox1.Text);
            Expression ExpresionXi = new Expression("Funcion(" + textBox2.Text.Replace(",", ".") + ")", Funcion);
            Expression ExpresionXf = new Expression("Funcion(" + textBox3.Text.Replace(",", ".") + ")", Funcion);
            if (comboBox1.Text == "Trapecio Simple")
            {
                var sarasa = ExpresionXi.calculate();
                var error1 = ExpresionXi.getErrorMessage();
                var sarasasarasa = ExpresionXf.calculate();
                var error2 = ExpresionXf.getErrorMessage();
                textBox5.Text = (((ExpresionXf.calculate() + ExpresionXi.calculate()) * (double.Parse(textBox3.Text.Replace(".", ",")) - double.Parse(textBox2.Text.Replace(".", ","))) / 2).ToString());
            }
            if (comboBox1.Text == "Trapecio Multiple")
            {
                double h = (double.Parse(textBox3.Text.Replace(".", ",")) - double.Parse(textBox2.Text.Replace(".", ","))) / double.Parse(textBox4.Text);
                textBox5.Text = "0";
                for (int i = 1; i < int.Parse(textBox4.Text); i++)
                {
                    Expression expresionXParcial = new Expression("Funcion(" + (double.Parse(textBox2.Text.Replace(".", ",")) + i * h).ToString().Replace(",",".") + ")", Funcion);
                    textBox5.Text = (double.Parse(textBox5.Text) + expresionXParcial.calculate()).ToString().Replace(".",",");
                }
                textBox5.Text = (double.Parse(textBox5.Text) * 2).ToString();
                textBox5.Text = (ExpresionXf.calculate() + ExpresionXi.calculate() + (double.Parse(textBox5.Text))).ToString();
                textBox5.Text = ((h / 2) * double.Parse(textBox5.Text)).ToString().Replace(".",",");
            }
            if (comboBox1.Text == "Simpson 1/3 Simple")
            {
                double h = (double.Parse(textBox3.Text.Replace(".", ",")) - double.Parse(textBox2.Text.Replace(".", ",")))/2;
                Expression expresionXPromedio = new Expression("Funcion(" + ((double.Parse(textBox2.Text.Replace(".", ",")) + double.Parse(textBox3.Text.Replace(".", ",")))/2).ToString().Replace(",", ".") + ")", Funcion);
                textBox5.Text = ((h / 3) * (ExpresionXi.calculate() + 4 * expresionXPromedio.calculate() + ExpresionXf.calculate())).ToString().Replace(".", ",");
            }
            if (comboBox1.Text == "Simpson 1/3 Multiple")
            {
                double h = (double.Parse(textBox3.Text.Replace(".", ",")) - double.Parse(textBox2.Text.Replace(".", ","))) / double.Parse(textBox4.Text);
                if (Math.Floor(double.Parse(textBox4.Text)/2) == double.Parse(textBox4.Text)/2)
                {
                    textBox5.Text = "0";
                    textBox5.Text = (ExpresionXi.calculate() + ExpresionXf.calculate()).ToString().Replace(".", ",");
                    for (int i = 1; i < double.Parse(textBox4.Text); i += 2)
                    {
                        Expression expresionXParcial = new Expression("Funcion(" + (double.Parse(textBox2.Text.Replace(".", ",")) + i * h).ToString().Replace(",", ".") + ")", Funcion);
                        textBox5.Text = (double.Parse(textBox5.Text) + expresionXParcial.calculate() * 4).ToString().Replace(".", ",");
                    }
                    for (int i = 2; i < double.Parse(textBox4.Text); i += 2)
                    {
                        Expression expresionXParcial = new Expression("Funcion(" + (double.Parse(textBox2.Text.Replace(".", ",")) + i * h).ToString().Replace(",", ".") + ")", Funcion);
                        textBox5.Text = (double.Parse(textBox5.Text) + expresionXParcial.calculate() * 2).ToString().Replace(".", ",");
                    }
                    textBox5.Text = (double.Parse(textBox5.Text) * (h / 3)).ToString().Replace(".", ",");
                }
            }
            if (comboBox1.Text == "Simpson 3/8")
            {
                double h = (double.Parse(textBox3.Text.Replace(".", ",")) - double.Parse(textBox2.Text.Replace(".", ","))) / double.Parse(textBox4.Text);
                if (Math.Floor(double.Parse(textBox4.Text) / 2) != double.Parse(textBox4.Text) / 2 && double.Parse(textBox4.Text) >= 3)
                {
                    textBox5.Text = "0";
                    if (double.Parse(textBox4.Text) > 3)
                    {
                        ExpresionXf = new Expression("Funcion(" + (double.Parse(textBox3.Text.Replace(".", ",")) - 3 * h).ToString().Replace(",", ".") + ")", Funcion);
                        textBox5.Text = (ExpresionXi.calculate() + ExpresionXf.calculate()).ToString().Replace(".", ",");
                        for (int i = 1; i < double.Parse(textBox4.Text) - 3; i += 2)
                        {
                            Expression expresionXParcial = new Expression("Funcion(" + (double.Parse(textBox2.Text.Replace(".", ",")) + i * h).ToString().Replace(",", ".") + ")", Funcion);
                            textBox5.Text = (double.Parse(textBox5.Text) + expresionXParcial.calculate() * 4).ToString().Replace(".", ",");
                        }
                        for (int i = 2; i < double.Parse(textBox4.Text) - 3; i += 2)
                        {
                            Expression expresionXParcial = new Expression("Funcion(" + (double.Parse(textBox2.Text.Replace(".", ",")) + i * h).ToString().Replace(",", ".") + ")", Funcion);
                            textBox5.Text = (double.Parse(textBox5.Text) + expresionXParcial.calculate() * 2).ToString().Replace(".", ",");
                        }
                        textBox5.Text = (double.Parse(textBox5.Text) * (h / 3)).ToString().Replace(".", ",");
                        ExpresionXi = ExpresionXf;
                    }
                    Expression expresionXIntermedia1 = new Expression("Funcion(" + (double.Parse(textBox3.Text.Replace(".", ",")) - 2 * h).ToString().Replace(",", ".") + ")", Funcion);
                    Expression expresionXIntermedia2 = new Expression("Funcion(" + (double.Parse(textBox3.Text.Replace(".", ",")) - 1 * h).ToString().Replace(",", ".") + ")", Funcion);
                    ExpresionXf = new Expression("Funcion(" + textBox3.Text.Replace(",", ".") + ")", Funcion);
                    var sar = ExpresionXi.calculate();
                    var asa = expresionXIntermedia1.calculate() * 3;
                    var sa = expresionXIntermedia2.calculate() * 3;
                    var rasa = ExpresionXf.calculate();
                    textBox5.Text = (double.Parse(textBox5.Text) + (0.375) * h * (ExpresionXi.calculate() + expresionXIntermedia1.calculate() * 3 + expresionXIntermedia2.calculate() * 3 + ExpresionXf.calculate())).ToString().Replace(".", ",");
                }
            }
        }
    }
}
