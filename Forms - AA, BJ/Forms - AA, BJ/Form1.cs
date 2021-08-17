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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Unidad_1 U1 = new Unidad_1();
            U1.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Unidad_2 U2 = new Unidad_2();  
            U2.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Unidad_3 U3 = new Unidad_3();
            U3.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Unidad_4 U4 = new Unidad_4(); 
            U4.ShowDialog();
        }
    }
}
