using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dita_Base
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string grade = textBox2.Text;
                string connectionStering = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
C:\Users\LOQ\source\repos\Dita_Base\Dita_Base\SchoolDB.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionStering);
                connection.Open();
                string quary = "INSERT INTO students(Name,Grade)" +
                    " VALUES('" + name + "','" + grade + "')";
                SqlCommand command = new SqlCommand(quary, connection);
                command.ExecuteNonQuery();

                MessageBox.Show("finish");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                int id = int.Parse(textBox3.Text);
                string name = textBox1.Text;
                string grade = textBox2.Text;
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
C:\Users\LOQ\source\repos\Dita_Base\Dita_Base\SchoolDB.mdf;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE students SET Name = '" + name + "', Grade = '" + grade + "' "
                        ;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Grade", grade);
                        command.Parameters.AddWithValue("@ID", id);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Update completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox3.Text);
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
C:\Users\LOQ\source\repos\Dita_Base\Dita_Base\SchoolDB.mdf;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Students WHERE ID = '" + id + "'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Delete completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LOQ\source\repos\Dita_Base\Dita_Base\SchoolDB.mdf;Integrated Security=True"; using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open(); string query = "SELECT * FROM Students"; using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            SqlDataReader reader = command.ExecuteReader(); listBox1.Items.Clear();
                            while (reader.Read())
                            {
                                string studentInfo = "ID: " + reader["ID"].ToString() + ", Name: " + reader["Name"].ToString() + ", Grade: " + reader["Grade"].ToString();
                                listBox1.Items.Add(studentInfo);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
