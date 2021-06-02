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
    public partial class Form3 : Form
    {
        bool check = false;
        private MySqlConnection DatabaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bookshop;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm1 = new Form1();
            fm1.Show();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void PassBox_TextChanged(object sender, EventArgs e)
        {
            if (PassBox.Text != confirmPassBox.Text & confirmPassBox.Text != "")
            {
                passmatchText.Text = "Password do not match!";
            }
            else
            {
                passmatchText.Text = "";
            }
            if (PassBox.TextLength < 5)
            {
                passmatchText.Text = "Password should not be less than 5 characters";
            }
        }
        private void confirmPassBox_TextChanged(object sender, EventArgs e)
        {
            if (PassBox.Text != confirmPassBox.Text)
            {
                passmatchText.Text = "Password do not match!";
            }
            else
            {
                passmatchText.Text = "";
            }
            if (confirmPassBox.TextLength < 5)
            {
                passmatchText.Text = "Password should not be less than 5 characters";
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox2.ImageLocation = @"C:\Users\acer\Pictures\เปิดลูกตา.png";
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
        private void checkUserID()
        {
            MySqlConnection conn = DatabaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT UserID FROM usersdata WHERE UserID = '{UserBox.Text}'";
            MySqlDataReader da = cmd.ExecuteReader();
            if (da.Read())
            {
                check = true;
            }
            conn.Close();
        }

        private void SubmitBut_Click(object sender, EventArgs e)
        {
            checkUserID();
            if (FnameBox.Text == "" || LnameBox.Text == "" || AddressBox.Text == "" || UserBox.Text == "")
            {
                MessageBox.Show("Please complete all informatiom");
            }
            else if (check == true)
            {
                MessageBox.Show("This account is already in use!");
            }
            else if (UserBox.Text == "Guest" || UserBox.Text == "guest")
            {
                MessageBox.Show("This account is already in use!");
            }
            else if (UserBox.TextLength <5)
            {
                MessageBox.Show("Username should not be less than 5 characters");
            }
            else if (PassBox.TextLength < 5)
            {
                MessageBox.Show("Password should not be less than 5 characters");
            }
            else if (PassBox.Text != confirmPassBox.Text)
            {
                MessageBox.Show("Password do not match!");
            }
            else
            {
                MySqlConnection conn = DatabaseConnection();
                string sql = $"INSERT INTO usersdata (UserFname, UserLname, Address, UserID, UserPass, Status) VALUES(\"{FnameBox.Text}\",\"{LnameBox.Text}\",\"{AddressBox.Text}\",\"{UserBox.Text}\",\"{PassBox.Text}\",\"User\")"; ;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                conn.Close();
                if (row > 0)
                {
                    MessageBox.Show("Sign in  success");
                    this.Hide();
                    Form1 fm1 = new Form1();
                    fm1.Show();
                }
            }
        }
        private void UserBox_TextChanged(object sender, EventArgs e)
        {
            check = false;
            usercheckText.Text = "";
            MySqlConnection conn = DatabaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT UserID FROM usersdata WHERE UserID = '{UserBox.Text}'";
            MySqlDataReader da = cmd.ExecuteReader();
            if (UserBox.TextLength < 5)
            {
                usercheckText.Text = "Username should not be less than 5 characters";
            }
            if (da.Read() || UserBox.Text == "Guest" || UserBox.Text == "guest")
            {
                usercheckText.Text = "This account is already in use!";
            }
        }

        private void UserBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == ' '))
            {
                e.Handled = true;
            }
            if (UserBox.TextLength >= 20 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void PassBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == ' '))
            {
                e.Handled = true;
            }
            if (PassBox.TextLength >= 20 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void confirmPassBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            object ch = e.KeyChar;
            if (confirmPassBox.TextLength >= 20 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
