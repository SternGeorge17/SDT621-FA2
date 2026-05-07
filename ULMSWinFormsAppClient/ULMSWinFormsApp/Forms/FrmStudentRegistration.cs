using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp.Models;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmStudentRegistration : Form
    {
        public FrmStudentRegistration()
        {
            InitializeComponent();
        }


        private void btnSaveStudent_Click(object sender, EventArgs e)
        {
            try
            {
                // Empty field validation
                if (txtStudentId.Text == "" ||
                    txtFullName.Text == "" ||
                    txtEmail.Text == "" ||
                    txtAge.Text == "" ||
                    cmbProgramme.SelectedIndex == -1)
                {
                    MessageBox.Show("Please complete all fields.");
                    return;
                }

                //age validation
                int age;

                bool validAge = int.TryParse(txtAge.Text, out age);

                if (!validAge)
                {
                    MessageBox.Show("Age must be a numeric value.");
                    return;
                }

                // Age range validation
                if (age < 16 || age > 100)
                {
                    MessageBox.Show("Age must be between 16 and 100.");
                    return;
                }

                // Basic email validation
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    MessageBox.Show("Please enter a valid email address.");
                    return;
                }

                // Create student object
                Student student = new Student
                {
                    StudentId = txtStudentId.Text,
                    FullName = txtFullName.Text,
                    Email = txtEmail.Text,
                    Age = age,
                    Programme = cmbProgramme.Text
                };

                // Display output
                txtStudentOutput.Text =
                    "Student saved successfully!" + Environment.NewLine +
                    "Student ID: " + student.StudentId + Environment.NewLine +
                    "Full Name: " + student.FullName + Environment.NewLine +
                    "Email: " + student.Email + Environment.NewLine +
                    "Age: " + student.Age + Environment.NewLine +
                    "Programme: " + student.Programme;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnClearStudent_Click(object sender, EventArgs e)
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtAge.Clear();
            cmbProgramme.SelectedIndex = -1;
            txtStudentOutput.Clear();
            txtStudentId.Focus();
        }

        //Add Back button to return to dashboard
        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
