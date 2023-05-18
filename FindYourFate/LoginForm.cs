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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FindYourFate
{
    public partial class LoginForm : Form
    {
        DataBase database = new DataBase();
        public LoginForm()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Поля не могут быть пустыми", "Ошибка");
            }
            else
            {
                string email = textBox1.Text;
                var password = textBox2.Text;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                DataTable dt = new DataTable();

                string querystring = $"select Id, Email, Password from dbo.Users where Email = '{email}' and Password = {password}";

                


                SqlCommand command = new SqlCommand(querystring, database.getConnection());

                sqlDataAdapter.SelectCommand = command;
                sqlDataAdapter.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Вход выполнен!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm mainForm = new MainForm(textBox1.Text.ToString());
                    mainForm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Такого аккаунта не существует!", "Не существует!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegistrationForm rf = new RegistrationForm();
            rf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeForm mf = new ChangeForm(textBox1.Text.ToString());
            mf.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
