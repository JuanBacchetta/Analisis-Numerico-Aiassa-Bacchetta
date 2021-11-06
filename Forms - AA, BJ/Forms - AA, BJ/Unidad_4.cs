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
                textBox5.Text = (((ExpresionXf.calculate() + ExpresionXi.calculate()) * (double.Parse(textBox3.Text.Replace(".", ",")) - double.Parse(textBox2.Text.Replace(".", ","))) / 2).ToString());
            }
            if (comboBox1.Text == "Trapecio Multiple")
            {
                textBox5.Text = "0";
                double h = (double.Parse(textBox3.Text.Replace(".",",")) - double.Parse(textBox2.Text.Replace(".",",")))/double.Parse(textBox4.Text);
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

            }
            if (comboBox1.Text == "Simpson 1/3 Multiple")
            {

            }
            if (comboBox1.Text == "Simpson 3/8")
            {

            }
        }
    }
}
