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
    public partial class Unidad_1 : Form
    {
        public Unidad_1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Bisección");
            comboBox1.Items.Add("Regla Falsa");
            comboBox1.Items.Add("Newton-Raphson");
            comboBox1.Items.Add("Secante");
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
            Unidad1 U1 = new Unidad1();
            Salida SalidaAMostrar = U1.Calcular(comboBox1.Text,textBox1.Text,double.Parse(textBox2.Text),double.Parse(textBox3.Text),int.Parse(textBox4.Text),double.Parse(textBox5.Text));
            textBox6.Text = SalidaAMostrar.Convergencia;
            textBox7.Text = SalidaAMostrar.Xr;
            textBox8.Text = SalidaAMostrar.IteracionesRealizadas.ToString();
            textBox9.Text = SalidaAMostrar.ErrorRelativo.ToString();
        }
        private void Unidad_1_Load(object sender, EventArgs e)
        {

        }
    }
}
