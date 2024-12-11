using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Final_Project
{
    public partial class frmBarangayinfo : Form
    {
        String connString;
        String Gender;

        public frmBarangayinfo()
        {
            InitializeComponent();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {


                string connString = "server=localhost; database=yourdb; Uid=root; pwd = 123";
                string query = "insert into brgybungca(IdNumber,lastName,firstName,Age,Gender,middleName,birthDate,occupation,phone) values('" + txtIdNumber.Text + "','" + txtlastName.Text + "','" + txtfirstName.Text + "','" + txtAge.Text + "','" + Gender + "','" + txtmiddleName.Text + "','" + this.dateTimePicker1.Text + "','" + txtoccupation.Text + "','" + txtphone.Text + "')";

                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader myReader;
                conn.Open();
                myReader = cmd.ExecuteReader();

                MessageBox.Show("Record Insert to the database successfully");


                txtIdNumber.Clear();
                txtlastName.Clear();
                txtfirstName.Clear();
                txtAge.Clear();
                txtmiddleName.Clear();
                txtoccupation.Clear();
                this.dateTimePicker1.Text = null;
                txtphone.Clear();

                ClearGender();


                myReader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string connString = "server=localhost; database = yourdb;Uid=root; pwd = 123";

                string query = "select * from brgybungca where IdNumber='" + txtIdNumber.Text + "'";

                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader myReader;
                conn.Open();
                myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {
                    MessageBox.Show("Record Found!" + "Welcome " + myReader.GetString("firstName") + ", " + myReader.GetString("lastName"));

                    
                    txtfirstName.Text = myReader.GetString("firstName");
                    txtlastName.Text = myReader.GetString("lastName");
                    txtmiddleName.Text = myReader.GetString("middleName");
                    txtAge.Text = myReader.GetString("Age");
                    txtoccupation.Text = myReader.GetString("occupation");
                    this.dateTimePicker1.Text = myReader.GetString("birthDate");
                    txtphone.Text = myReader.GetString("phone");
                    string gender = myReader.GetString("Gender");
                    if (gender == "Male")
                    {
                        radioButton1.Checked = true;
                    }
                    else if (gender == "Female")
                    {
                        radioButton2.Checked = true;
                    }
                }
                else
                {
                    MessageBox.Show("No Record Found.");
                }

                myReader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            try
            {
                string connString = "server=localhost; database = yourdb;Uid=root; pwd = 123";

                string query = "update brgybungca set firstname='" + txtfirstName.Text + "', lastname='" + txtlastName.Text + "' where IdNumber='" + txtIdNumber.Text + "'";



                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader myReader;
                conn.Open();
                myReader = cmd.ExecuteReader();
                myReader.Close();
                conn.Close();

                txtIdNumber.Clear();
                txtlastName.Clear();
                txtfirstName.Clear();
                txtAge.Clear();
                txtmiddleName.Clear();
                txtoccupation.Clear();
                ClearGender();
                this.dateTimePicker1.Text = null;
                txtphone.Clear();


                MessageBox.Show("Update Record Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            try
            {
                string connString = "server=localhost; database = yourdb;Uid=root; pwd = 123";

                string query = "delete from brgybungca where IdNumber='" + txtIdNumber.Text + "'";

                MySqlConnection conn = new MySqlConnection(connString);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader myReader;
                conn.Open();
                myReader = cmd.ExecuteReader();
                myReader.Close();
                conn.Close();

                txtIdNumber.Clear();
                txtlastName.Clear();
                txtfirstName.Clear();
                txtAge.Clear();
                txtmiddleName.Clear();
                txtoccupation.Clear();
                ClearGender();
                this.dateTimePicker1.Text = null;
                txtphone.Clear();

                MessageBox.Show("Delete Record Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            Gender = "Male";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            Gender = "Female";
        }
        private void ClearGender()
        {
            Gender = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

    }



}


