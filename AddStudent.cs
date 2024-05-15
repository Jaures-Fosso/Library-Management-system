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
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace LMS
{
    public partial class AddStudent : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6PM9RD1\\SQLEXPRESS01;Initial Catalog=library;Integrated Security=True;");
        public AddStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("sp_addStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Student_Name", SqlDbType.NVarChar).Value = textBoxSN.Text;
            cmd.Parameters.Add("@Entrollment_Number", SqlDbType.NVarChar).Value = textBoxEN.Text;
            cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = textBoxDN.Text;
            cmd.Parameters.Add("@contact", SqlDbType.NVarChar).Value = textBoxSC.Text;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = textBoxSE.Text;
            cmd.Parameters.Add("@Semester", SqlDbType.NVarChar).Value = textBoxStudentS.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Student Details Added");
            con.Close();
            textBoxSN.Text = "";
            textBoxEN.Text = "";
            textBoxDN.Text = "";
            textBoxSC.Text = "";
            textBoxSE.Text = "";
            textBoxStudentS.Text = "";
        }
    }
}
