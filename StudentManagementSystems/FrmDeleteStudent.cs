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
    public partial class FrmDeleteStudent : Form
    {
        public FrmDeleteStudent()
        {
            InitializeComponent();
        }

        string connectionString = "Server=localhost;Database=student_management;Uid=root;Pwd=fatimajk6;";

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtRollNo.Text == "")
            {
                MessageBox.Show("Please enter a Roll No to search!");
                return;
            }

            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                string query = "SELECT * FROM students WHERE roll_no = @rollNo";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@rollNo", txtRollNo.Text);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtFullName.Text = reader["full_name"].ToString();
                    cmbDepartment.Text = reader["department"].ToString();
                    cmbSemester.Text = reader["semester"].ToString();
                }
                else
                {
                    MessageBox.Show("No student found with this Roll No!");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtRollNo.Text == "")
            {
                MessageBox.Show("Please search for a student first!");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete " + txtFullName.Text + "?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(connectionString);
                    conn.Open();

                    string query = "DELETE FROM students WHERE roll_no = @rollNo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@rollNo", txtRollNo.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student deleted successfully!");

                    conn.Close();

                    txtRollNo.Clear();
                    txtFullName.Clear();
                    cmbDepartment.Text = "";
                    cmbSemester.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard frm = new Dashboard();
            frm.Show();
            this.Hide();
        }
    }
}