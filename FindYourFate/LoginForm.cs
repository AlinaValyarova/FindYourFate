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
using NLog;

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
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                
                MessageBox.Show("Поля не могут быть пустыми", "Ошибка");
                logger.Info("Пользователь оставил поля пустыми");

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
                    logger.Info("Пользователь успешно вошел в аккаунт");
                    MainForm mainForm = new MainForm(textBox1.Text.ToString());
                    mainForm.Show();
                    this.Hide();


                }
                else
                {
                    logger.Info("Пользователь ввел логин или пароль, которых нет в базе данных");
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
            logger.Info("Пользователь перешел на окно регистрации");
            RegistrationForm rf = new RegistrationForm();
            rf.Show();
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
