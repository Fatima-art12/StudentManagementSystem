using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentManagementSystems
{
    public partial class FrmAddStudent : Form
    {
        public FrmAddStudent()
        {
            InitializeComponent();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtRollNo.Text == "" || txtFullName.Text == "")
            {
                MessageBox.Show("Roll No and Full Name are required!");
                return;
            }

            // Full Name check - only letters and spaces
            if (!Regex.IsMatch(txtFullName.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Full Name should contain only letters, no numbers!");
                return;
            }

            // Email check - valid format
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address!");
                return;
            }

            // Phone check - exactly 11 digits
            if (!Regex.IsMatch(txtPhone.Text, @"^\d{11}$"))
            {
                MessageBox.Show("Phone number must be exactly 11 digits!");
                return;
            }

            string connectionString = "Server=localhost;Database=student_management;Uid=root;Pwd=fatimajk6;";

            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                string query = "INSERT INTO students (roll_no, full_name, department, semester, email, phone) VALUES (@rollNo, @fullName, @department, @semester, @email, @phone)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@rollNo", txtRollNo.Text);
                cmd.Parameters.AddWithValue("@fullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@department", cmbDepartment.Text);
                cmd.Parameters.AddWithValue("@semester", cmbSemester.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Student saved successfully!");

                conn.Close();

                txtRollNo.Clear();
                txtFullName.Clear();
                cmbDepartment.Text = "";
                cmbSemester.Text = "";
                txtEmail.Clear();
                txtPhone.Clear();
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

        private void FrmAddStudent_Load(object sender, EventArgs e)
        {

        }
    }
}