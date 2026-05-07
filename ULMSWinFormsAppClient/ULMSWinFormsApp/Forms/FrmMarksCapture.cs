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
    public partial class FrmMarksCapture : Form
    {
        public FrmMarksCapture()
        {
            InitializeComponent();
        }

        private void btnCalculateResults_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for empty fields
                if (string.IsNullOrWhiteSpace(txtMarkStudentId.Text) ||
                    string.IsNullOrWhiteSpace(txtMarkStudentName.Text) ||
                    string.IsNullOrWhiteSpace(txtSubject1.Text) ||
                    string.IsNullOrWhiteSpace(txtSubject2.Text) ||
                    string.IsNullOrWhiteSpace(txtSubject3.Text))
                {
                    MessageBox.Show("Please complete all fields.");
                    return;
                }

                // Validate numeric input
                double subject1, subject2, subject3;

                bool validSubject1 = double.TryParse(txtSubject1.Text, out subject1);
                bool validSubject2 = double.TryParse(txtSubject2.Text, out subject2);
                bool validSubject3 = double.TryParse(txtSubject3.Text, out subject3);

                if (!validSubject1 || !validSubject2 || !validSubject3)
                {
                    MessageBox.Show("Marks must be numeric values.");
                    return;
                }

                // Validate marks range
                if (subject1 < 0 || subject1 > 100 ||
                    subject2 < 0 || subject2 > 100 ||
                    subject3 < 0 || subject3 > 100)
                {
                    MessageBox.Show("Marks must be between 0 and 100.");
                    return;
                }

                // Create record
                MarkRecord record = new MarkRecord();

                record.StudentId = txtMarkStudentId.Text;
                record.StudentName = txtMarkStudentName.Text;

                record.Subject1 = subject1;
                record.Subject2 = subject2;
                record.Subject3 = subject3;

                // Correct average calculation
                record.Average = (record.Subject1 + record.Subject2 + record.Subject3) / 3;

                // Determine result
                if (record.Average >= 50)
                {
                    record.ResultStatus = "PASS";
                }
                else
                {
                    record.ResultStatus = "FAIL";
                }

                // Display results
                txtMarksOutput.Text =
                    "Marks processed successfully!" + Environment.NewLine +
                    "Student ID: " + record.StudentId + Environment.NewLine +
                    "Student Name: " + record.StudentName + Environment.NewLine +
                    "Subject 1: " + record.Subject1 + Environment.NewLine +
                    "Subject 2: " + record.Subject2 + Environment.NewLine +
                    "Subject 3: " + record.Subject3 + Environment.NewLine +
                    "Average: " + record.Average + Environment.NewLine +
                    "Final Result: " + record.ResultStatus;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnClearMarks_Click(object sender, EventArgs e)
        {
            txtMarkStudentId.Clear();
            txtMarkStudentName.Clear();
            txtSubject1.Clear();
            txtSubject2.Clear();
            txtSubject3.Clear();
            txtMarksOutput.Clear();
            txtMarkStudentId.Focus();
        }

        private void btnBackMarks_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
