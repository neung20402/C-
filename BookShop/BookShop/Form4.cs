using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BookShop
{
    public partial class Form4 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bookshop;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void ShowBook()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ID,BookName,Price,Amount,Picture FROM booksdata";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void PicText_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = PicText.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                PicText.Text = openFileDialog1.FileName;
            }
        }

        private void resetvalue()
        {
            NameText.Text = "";
            PicText.Text = "";
            AmountText.Text = "";
            PriceText.Text = "";
            pictureBox1.Image = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(NameText.Text == "" || PicText.Text == "" || AmountText.Text == "" || PriceText.Text == "")
            {
                MessageBox.Show("Please complete all information","Error");
            }
            else
            {
                MySqlConnection conn = databaseConnection();
                MySqlCommand cmd = conn.CreateCommand();
                byte[] bytes = File.ReadAllBytes(PicText.Text);
                cmd.CommandText = $"INSERT INTO booksdata (Bookname,Price,Amount,Picture,PicturePath) VALUES(\"{NameText.Text}\",\"{PriceText.Text}\",\"{AmountText.Text}\",@Picture,@Path)";
                cmd.Parameters.AddWithValue("@Picture", bytes);
                cmd.Parameters.AddWithValue("@Path", PicText.Text);
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                conn.Close();
                if (row > 0)
                {
                    MessageBox.Show("Add product success");
                    resetvalue();
                    ShowBook();
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ShowBook();
        }

        private void PriceText_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void AmountText_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            int selectRow = dataGridView1.CurrentCell.RowIndex;
            var selectID = Convert.ToInt32(dataGridView1.Rows[selectRow].Cells["ID"].Value);
            var selectName = dataGridView1.Rows[selectRow].Cells["BookName"].Value;
            var selectPrice = dataGridView1.Rows[selectRow].Cells["Price"].Value;
            var selectAmount = dataGridView1.Rows[selectRow].Cells["Amount"].Value;
            NameText.Text = selectName.ToString();
            PriceText.Text = selectPrice.ToString();
            AmountText.Text = selectAmount.ToString();
            MySqlConnection conn = databaseConnection();
            MySqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = $"SELECT PicturePath FROM booksdata WHERE ID = \"{selectID}\"";
            MySqlDataReader da = cmd.ExecuteReader();
            if (da.Read())
            {
                PicText.Text = da.GetValue(0).ToString();
            }
        }

        private void UpdateBut_Click(object sender, EventArgs e)
        {
            if (NameText.Text == "" || PicText.Text == "" || AmountText.Text == "" || PriceText.Text == "")
            {
                MessageBox.Show("Please complete all information", "Error");
            }
            else
            {
                int selectRow = dataGridView1.CurrentCell.RowIndex;
                int selectID = Convert.ToInt32(dataGridView1.Rows[selectRow].Cells["ID"].Value);
                MySqlConnection conn = databaseConnection();
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                byte[] bytes = File.ReadAllBytes(PicText.Text);
                cmd.CommandText = $"UPDATE booksdata SET Bookname = \"{NameText.Text}\",Price = \"{PriceText.Text}\",Amount = \"{AmountText.Text}\" ,Picture = @Picture,PicturePath = @Path WHERE ID = \"{selectID}\"";
                cmd.Parameters.AddWithValue("@Picture", bytes);
                cmd.Parameters.AddWithValue("@Path", PicText.Text);
                int row = cmd.ExecuteNonQuery();
                conn.Close();
                if (row > 0)
                {
                    MessageBox.Show("Update product success");
                    resetvalue();
                    ShowBook();
                }
            }    
        }

        private void DelBut_Click(object sender, EventArgs e)
        {
            if (NameText.Text == "" || PicText.Text == "" || AmountText.Text == "" || PriceText.Text == "")
            {
                MessageBox.Show("Please complete all information", "Error");
            }
            else
            {
                int selectRow = dataGridView1.CurrentCell.RowIndex;
                int selectID = Convert.ToInt32(dataGridView1.Rows[selectRow].Cells["ID"].Value);
                MySqlConnection conn = databaseConnection();
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = $"DELETE FROM booksdata WHERE ID = \"{selectID}\"";
                int row = cmd.ExecuteNonQuery();
                conn.Close();
                if (row > 0)
                {
                    MessageBox.Show("Delete product success");
                    resetvalue();
                    ShowBook();
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm adfm = new AdminForm();
            adfm.Show();
        }

        private void resetBut_Click(object sender, EventArgs e)
        {
            resetvalue();
        }
    }
}
