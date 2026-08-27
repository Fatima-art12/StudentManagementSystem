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

namespace StudentManagementSystems
{
    public partial class FrmUpdateStudent : Form
    {
        public FrmUpdateStudent()
        {
            InitializeComponent();
        }

        string connectionString = "Server=localhost;Database=student_management;Uid=root;Pwd=fatimajk6;";

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtRollNo.Text == "")
            {
                MessageBox.Show("Please enter a Roll No or Name to search!");
                return;
            }

            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                string query = "SELECT * FROM students WHERE roll_no = @search OR full_name LIKE @searchLike";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", txtRollNo.Text);
                cmd.Parameters.AddWithValue("@searchLike", "%" + txtRollNo.Text + "%");

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtRollNo.Text = reader["roll_no"].ToString();
                    txtFullName.Text = reader["full_name"].ToString();
                    cmbDepartment.Text = reader["department"].ToString();
                    cmbSemester.Text = reader["semester"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                    txtPhone.Text = reader["phone"].ToString();
                }
                else
                {
                    MessageBox.Show("No student found!");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtRollNo.Text == "")
            {
                MessageBox.Show("First, search for the student using the Roll No.");
                return;
            }

            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                string query = "UPDATE students SET full_name=@fullName, department=@department, semester=@semester, email=@email, phone=@phone WHERE roll_no=@rollNo";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@department", cmbDepartment.Text);
                cmd.Parameters.AddWithValue("@semester", cmbSemester.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@rollNo", txtRollNo.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Student updated successfully!");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard frm = new Dashboard();
            frm.Show();
            this.Hide();
        }

        private void FrmUpdateStudent_Load(object sender, EventArgs e)
        {

        }
    }
}