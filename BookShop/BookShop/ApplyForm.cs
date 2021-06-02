using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
        }
        private void show_hide(int args)
        {
            if (args == 1)
            {
                label1.Hide();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                label6.Hide();
                label7.Hide();
                UserBox.Hide();
                PassBox.Hide();
                button1.Hide();
            }
            if (args == 0)
            {
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                label6.Show();
                label7.Show();
                UserBox.Show();
                PassBox.Show();
                button1.Show();
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {
            show_hide(1);
            pictureBox1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            show_hide(0);
        }
    }
}
