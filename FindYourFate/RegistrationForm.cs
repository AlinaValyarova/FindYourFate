using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace FindYourFate
{
    public partial class RegistrationForm : Form
    {
        DataBase database = new DataBase();
        public RegistrationForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private Boolean CheckingUser()
        {
            var email = textBox1.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querychecking = $"select Id, FirstName, Email, Password from dbo.Users where Email = '{email}'";

            SqlCommand command = new SqlCommand(querychecking, database.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Этот E-mail уже закреплен за другим пользователем!");
                return true;
            }
            else
            {
                return false;
            }


        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox3.Text == "")
            {

                MessageBox.Show("Поля не могут быть пустыми", "Ошибка");
            }
            else
            {
                DataTable table = new DataTable();
                DataBase dataBase = new DataBase();
                if (CheckingUser())

                {
                    return;
                }
                var username = textBox2.Text;
                var lastname = textBox4.Text;
                var email = textBox1.Text;
                var password = textBox3.Text;

                SqlDataAdapter adapter = new SqlDataAdapter();

                string querychecking = $"select count(*) from Users";

                SqlCommand command1 = new SqlCommand(querychecking, database.getConnection());
                adapter.SelectCommand = command1;
                adapter.Fill(table);
                int id = table.Rows.Count;
                label7.Text = id.ToString();

                string queryregistration = $" insert into Users(FirstName, LastName, Email, Password) values ( N'{username}', N'{lastname}', N'{email}', N'{password}')";

                SqlCommand command = new SqlCommand(queryregistration, dataBase.getConnection());

                dataBase.openConnetion();

                if (command.ExecuteNonQuery() == 1)
                {
                    panel1.Visible = true;
                    MessageBox.Show("Данные введены успешно!", "Успех!");
                }
                else
                {
                    MessageBox.Show("Данные не введены");
                }
                dataBase.closeConnetion();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm lg = new LoginForm();
            lg.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Test test = new Test(label7.Text);
            test.ShowDialog();
        }
    }
}
