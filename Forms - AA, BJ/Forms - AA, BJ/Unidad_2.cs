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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int pointX = 30;
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
                        txt.Size = new Size(30, 30);
                        txt.Font = new Font("Microsoft Sans Serif", 12);
                        panel1.Controls.Add(txt);
                        pointY += 50;
                    }
                    pointX += 50;
                    pointY = 30;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
