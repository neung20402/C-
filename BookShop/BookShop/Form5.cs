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
    public partial class Form5 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bookshop;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void ShowHis()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM tradinghistory";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        public Form5()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            int selectRow = dataGridView1.CurrentCell.RowIndex;
            var selectUserID =dataGridView1.Rows[selectRow].Cells["UserID"].Value;
            var selectName = dataGridView1.Rows[selectRow].Cells["BookName"].Value;
            var selectPrice = dataGridView1.Rows[selectRow].Cells["Price"].Value;
            var selectAmount = dataGridView1.Rows[selectRow].Cells["Amount"].Value;
            var selectStatus = dataGridView1.Rows[selectRow].Cells["Status"].Value;
            userText.Text = selectUserID.ToString();
            nameText.Text = selectName.ToString();
            priceText.Text = selectPrice.ToString();
            amountText.Text = selectAmount.ToString();
            statusText.Text = selectStatus.ToString();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            ShowHis();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm adfm = new AdminForm();
            adfm.Show();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
