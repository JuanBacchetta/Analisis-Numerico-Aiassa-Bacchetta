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
            if (comboBox1.Text == "Regresión Lineal")
            {
                double N = dataGridView1.Rows.Count;
                double SumaXi = 0;
                double SumaXiCuadrado = 0;
                double SumaYi = 0;
                double SumaXiYi = 0;
                foreach (DataGridViewRow Row in dataGridView1.Rows)
                {
                    SumaXi = SumaXi + double.Parse(Row.Cells["X"].Value.ToString());
                    SumaXiCuadrado = SumaXiCuadrado + (double.Parse(Row.Cells["X"].Value.ToString())) * (double.Parse(Row.Cells["X"].Value.ToString()));
                    SumaYi = SumaYi + double.Parse(Row.Cells["Y"].Value.ToString());
                    SumaXiYi = SumaXiYi + double.Parse(Row.Cells["X"].Value.ToString()) * double.Parse(Row.Cells["Y"].Value.ToString());
                }
                double Determinante = N * SumaXiCuadrado - Math.Pow(SumaXi,2);
                double DeterminanteA1 = N * SumaXiYi - SumaXi * SumaYi;
                double A1 = DeterminanteA1 / Determinante;
                double A0 = (SumaYi - A1 * SumaXi) / N;
            }
        }
    }
}
