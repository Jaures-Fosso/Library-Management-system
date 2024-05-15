using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class AddBooks : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6PM9RD1\\SQLEXPRESS01;Initial Catalog=library;Integrated Security=True;");
        public AddBooks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_add_books", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar).Value=textBoxName.Text;
            cmd.Parameters.Add("@AuthorName", SqlDbType.NVarChar).Value = textBoxAN.Text;
            cmd.Parameters.Add("@publication", SqlDbType.NVarChar).Value = textBoxPublication.Text;
            cmd.Parameters.Add("@purchaseDate", SqlDbType.NVarChar).Value = dateTimePickerAB.Value;
            cmd.Parameters.Add("@BookPrice", SqlDbType.NVarChar).Value = textBoxBookPrice.Text;
            cmd.Parameters.Add("@Quantity", SqlDbType.NVarChar).Value = textBoxBQ.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Book Added");
            con.Close();
            textBoxName.Text = "";
            textBoxAN.Text = "";
            textBoxPublication.Text = "";
            textBoxBookPrice.Text = "";
            textBoxBQ.Text = "";
        }
    }
}
