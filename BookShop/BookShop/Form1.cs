using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BookShop
{
    public partial class Form1 : Form
    {
        private MySqlConnection DatabaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bookshop;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fm3 = new Form3();
            fm3.Show();
        }
        private void label7_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = DatabaseConnection();
            string sql = "INSERT INTO newlogin(UserID) VALUES(\"Geust\")";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                MessageBox.Show("Guest Login Success", "Login");
                this.Hide();
                Form2 fm2 = new Form2();
                fm2.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DatabaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM usersdata WHERE UserID = \"{UserBox.Text}\" AND UserPass = \"{PassBox.Text}\"";

            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MySqlConnection conn2 = DatabaseConnection();
                MySqlCommand cmd2 = conn2.CreateCommand();
                conn2.Open();
                cmd2.CommandText = $"INSERT INTO newlogin(UserID) VALUES(\"{UserBox.Text}\")";
                int row = cmd2.ExecuteNonQuery();
                if (row>0)
                {
                    MessageBox.Show("Login Success", "Login");
                    this.Hide();
                    MySqlConnection conn3 = DatabaseConnection();
                    MySqlCommand cmd3 = conn3.CreateCommand();
                    conn3.Open();
                    cmd3.CommandText = $"SELECT Status FROM usersdata WHERE UserID = \"{UserBox.Text}\"";
                    MySqlDataReader da = cmd3.ExecuteReader();
                    string status;
                    if (da.Read())
                    {
                        status = da.GetValue(0).ToString();
                        if (status == "Admin")
                        {
                            AdminForm adfm = new AdminForm();
                            adfm.Show();
                        }
                        else
                        {
                            Form2 f2 = new Form2();
                            f2.Show();
                        }
                    }
                }
                conn2.Close();
            }
            else { MessageBox.Show("Login Error : The user account cannot be found or password is incorrect", "Login"); ; }
            conn.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.ImageLocation == @"C:\Users\acer\Pictures\เปิดลูกตา.png")
            {
                PassBox.UseSystemPasswordChar = true;
                pictureBox2.ImageLocation = @"C:\Users\acer\Pictures\ปิดลูกตา.png";
            }
            else if (pictureBox2.ImageLocation == @"C:\Users\acer\Pictures\ปิดลูกตา.png")
            {
                PassBox.UseSystemPasswordChar = false;
                pictureBox2.ImageLocation = @"C:\Users\acer\Pictures\เปิดลูกตา.png";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox2.ImageLocation = @"C:\Users\acer\Pictures\เปิดลูกตา.png";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
