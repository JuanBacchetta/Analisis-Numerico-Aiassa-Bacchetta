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
    public partial class Unidad_2 : Form
    {
        public Unidad_2()
        {
            InitializeComponent();
            comboBox1.Items.Add("Gauss-Jordan");
            comboBox1.Items.Add("Gauss-Seidel");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Gauss-Seidel")
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
                textBox2.Text = "";
                textBox3.Enabled = false;
                textBox3.Text = "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label4.Text = "";
                int pointX = 10;
                int pointY = 30;
                panel1.Controls.Clear();
                textBox1.Text = ((int)double.Parse(textBox1.Text.Replace(".", ","))).ToString();
                if (int.Parse(textBox1.Text) > 5)
                {
                    textBox1.Text = 5.ToString();
                }
                if (int.Parse(textBox1.Text) < 0)
                {
                    textBox1.Text = 0.ToString();
                }
                for (int j = 0; j < int.Parse(textBox1.Text) + 1; j++)
                {
                    for (int i = 0; i < int.Parse(textBox1.Text); i++)
                    {
                        TextBox txt = new TextBox();
                        txt.Location = new Point(pointX, pointY);
                        txt.Name = $"txt{i}{j}";
                        txt.AutoSize = false;
                        txt.Size = new Size(120, 20);
                        txt.Font = new Font("Microsoft Sans Serif", 12);
                        panel1.Controls.Add(txt);
                        pointY += 50;
                    }
                    pointX += 140;
                    pointY = 30;
                }
                if (comboBox1.Text == "Gauss-Seidel")
                {
                    pointX = 10;
                    pointY = 30;
                    panel2.Controls.Clear();
                    for (int i = 0; i < int.Parse(textBox1.Text); i++)
                    {
                        TextBox txt = new TextBox();
                        txt.Location = new Point(pointX, pointY);
                        txt.Name = $"txtS{i}";
                        txt.AutoSize = false;
                        txt.Size = new Size(120, 20);
                        txt.Font = new Font("Microsoft Sans Serif", 12);
                        panel2.Controls.Add(txt);
                        pointY += 30;
                    }
                }
                else
                {
                    panel2.Controls.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F1 = new Form1();
            F1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal coeficiente = 0;
            int bandera = 0;
            switch (comboBox1.Text)
            {
                case "Gauss-Jordan":
                    for (int k = 0; k < int.Parse(textBox1.Text); k++)
                    {
                        for (int i = k; i < int.Parse(textBox1.Text); i++)
                        {
                            int flag = 0;
                            decimal NumeroParaHacer0ElTrianguloInferior = 0;
                            for (int j = k; j < int.Parse(textBox1.Text) + 1; j++)
                            {
                                if (i == j && i == k)
                                {
                                    coeficiente = decimal.Parse(panel1.Controls.Find($"txt{i}{j}", false).First().Text);
                                }
                                if (i == k)
                                {
                                    if (coeficiente == 0)
                                    {
                                        bandera = 1;
                                        break;
                                    }
                                    panel1.Controls.Find($"txt{i}{j}", false).First().Text = (decimal.Parse(panel1.Controls.Find($"txt{i}{j}", false).First().Text) / coeficiente).ToString();
                                }
                                else
                                {
                                    if (flag == 0)
                                    {
                                        flag = 1;
                                        NumeroParaHacer0ElTrianguloInferior = decimal.Parse(panel1.Controls.Find($"txt{i}{k}", false).First().Text);
                                    }
                                    panel1.Controls.Find($"txt{i}{j}", false).First().Text = (decimal.Parse(panel1.Controls.Find($"txt{i}{j}", false).First().Text) + decimal.Parse(panel1.Controls.Find($"txt{k}{j}", false).First().Text) * NumeroParaHacer0ElTrianguloInferior * -1).ToString();
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
                    break;
                default:
                    int contador = 0; 
                    double[] VectorResultados = new double[int.Parse(textBox1.Text)];
                    double[] VectorAnterior = new double[int.Parse(textBox1.Text)];
                    for (int i = 0; i < int.Parse(textBox1.Text); i++)
                    {
                        VectorResultados[i] = int.Parse(panel2.Controls.Find($"txtS{i}", false).First().Text);
                        VectorAnterior[i] = int.Parse(panel2.Controls.Find($"txtS{i}", false).First().Text);
                    }
                    int BreakIt = 0;
                    while (int.Parse(textBox2.Text) >= contador)
                    {
                        contador++;
                        if (contador > 1)
                        {
                            VectorResultados.CopyTo(VectorAnterior, 0);
                        }
                        for (int i = 0; i < int.Parse(textBox1.Text); i++)
                        {
                            var resultado = double.Parse(panel1.Controls.Find($"txt{i}{int.Parse(textBox1.Text)}", false).First().Text);
                            var x = Convert.ToDouble(double.Parse(panel1.Controls.Find($"txt{i}{i}", false).First().Text));
                            for (int j = 0; j < int.Parse(textBox1.Text); j++)
                            {
                                if (i != j)
                                {
                                    resultado = resultado - double.Parse(panel1.Controls.Find($"txt{i}{j}", false).First().Text) * VectorResultados[j];
                                }
                            }
                            x = Convert.ToDouble(resultado) / x;
                            VectorResultados[i] = x;
                        }
                        double[] R = new double[int.Parse(textBox1.Text)];
                        int ContadorTolerancia = 0;
                        for (int i = 0; i < int.Parse(textBox1.Text); i++)
                        {
                            R[i] = Math.Abs(VectorResultados[i] - VectorAnterior[i]);
                            if(R[i] < double.Parse(textBox3.Text))
                            {
                                ContadorTolerancia = ContadorTolerancia + 1;
                            }
                            if (ContadorTolerancia == int.Parse(textBox1.Text))
                            {
                                BreakIt = 1;
                                break;
                            }
                        }
                        if (BreakIt == 1)
                        {
                            break;
                        }
                    }
                    if (BreakIt == 1)
                    {
                        label4.Text = "Converge en la iteracion " + contador.ToString();
                        for (int i = 0; i < int.Parse(textBox1.Text); i++)
                        {
                            panel2.Controls.Find($"txtS{i}", false).First().Text = VectorResultados[i].ToString();
                        }
                    }
                    else
                    {
                        label4.Text = "No Converge";
                        for (int i = 0; i < int.Parse(textBox1.Text); i++)
                        {
                            panel2.Controls.Find($"txtS{i}", false).First().Text = VectorResultados[i].ToString();
                        }
                    }
                    break;
            }
            if (bandera == 1)
            {
                label4.Text = "Error al resolver debido a un 0 en el coeficiente, intente pivotear las ecuaciones";
            }
            //for (int j = 0; j < int.Parse(textBox1.Text) + 1; j++)
            //{
            //    for (int i = 0; i < int.Parse(textBox1.Text); i++)
            //    {
            //        Control TxtActual = panel1.Controls.Find($"txt{i}{j}", false).First();
            //        TxtActual.Text = i.ToString() + ',' + j.ToString();
            //        //TextBox txt = new TextBox();
            //        //txt.Location = new Point(pointX, pointY);
            //        //txt.Name = $"txt{i}{j}";
            //        //txt.AutoSize = false;
            //        //txt.Size = new Size(30, 30);
            //        //txt.Font = new Font("Microsoft Sans Serif", 12);
            //        //panel1.Controls.Add(txt);
            //    }
            //}
        }
    }
}
