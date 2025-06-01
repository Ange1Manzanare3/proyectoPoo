using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATTLESHIP_P.FINAL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 FORMA = new Form2();
            FORMA.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 PORFA = new Form3();
            PORFA.Show();
            Hide();
        }
    }
}
