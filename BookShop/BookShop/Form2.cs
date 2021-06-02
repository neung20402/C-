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
    public partial class Form2 : Form
    {
        string userID, status;
        private MySqlConnection DatabaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bookshop;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void setuserid()
        {
            MySqlConnection conn = DatabaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT UserID FROM newlogin WHERE ID = (SELECT MAX(ID) FROM newlogin) ";
            MySqlDataReader da = cmd.ExecuteReader();
            if (da.Read())
            {
                userID = da.GetValue(0).ToString();
            }
        }
        private void setstatus()
        {
            MySqlConnection conn = DatabaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT Status FROM usersdata WHERE UserId = \"{userID}\" ";
            MySqlDataReader da = cmd.ExecuteReader();
            if (da.Read())
            {
                status = da.GetValue(0).ToString();
            }
            conn.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            setuserid();
            setstatus();
            if (status != "Admin")
            {
                AdminBut.Hide();
            }
            panel1.Controls.Add(new UserControl1());
            
        }

        private void CartBut_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new UserControl2());
        }

        private void HomeBut_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new UserControl1());
        }

        private void AdminBut_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm adfm = new AdminForm();
            adfm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogoutBut_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ออกจากระบบเรียบร้อย");
            this.Hide();
            Form1 fm1 = new Form1();
            fm1.Show();
        }
    }
}
