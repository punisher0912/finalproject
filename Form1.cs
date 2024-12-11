using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_Project
{
    public partial class Login: Form
    {
        string Connstring;
        public Login()
        {
            InitializeComponent();
        }

        private string connectionString = "Server=localhost;Database=users;Uid=root;Pwd=123;";

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        connection.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Open the new form
                            frmBarangayinfo mainForm = new frmBarangayinfo();
                            mainForm.Show();

                            // Hide the login form
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

