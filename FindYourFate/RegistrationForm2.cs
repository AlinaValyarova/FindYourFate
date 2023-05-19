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
using NLog;

namespace FindYourFate
{
    public partial class RegistrationForm2 : Form
    {
        public RegistrationForm2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
            panel4.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel1.Visible = true;
            panel4.Visible = false;

        }

        DataBase database = new DataBase();
        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton3.Checked == true)
            {
                string sub = "";
                int points = 0;
                int amount = 0;
                if(numericUpDown11.Value !=0)
                {
                    sub += "P*";
                    points += (int)numericUpDown1.Value;
                    amount += 1;
                }
                if (numericUpDown1.Value != 0)
                {
                    sub += "М*";
                    points += (int)numericUpDown1.Value;
                    amount += 1;
                }
                if (numericUpDown2.Value != 0)
                {
                    sub += "О*";
                    points += (int)numericUpDown2.Value;
                    amount += 1;
                }
                if (numericUpDown3.Value != 0)
                {
                    sub += "Б*";
                    points += (int)numericUpDown3.Value;
                    amount += 1;
                }
                if (numericUpDown4.Value != 0)
                {
                    sub += "Ин*";
                    points += (int)numericUpDown4.Value;
                    amount += 1;
                }
                if (numericUpDown5.Value != 0)
                {
                    sub += "Ф*";
                    points += (int)numericUpDown5.Value;
                    amount += 1;
                }
                if (numericUpDown6.Value != 0)
                {
                    sub += "Ис*";
                    points += (int)numericUpDown6.Value;
                    amount += 1;
                }
                if (numericUpDown7.Value != 0)
                {
                    sub += "Ия*";
                    points += (int)numericUpDown7.Value;
                    amount += 1;
                }
                if (numericUpDown8.Value != 0)
                {
                    sub += "Х*";
                    points += (int)numericUpDown8.Value;
                    amount += 1;
                }
                if (numericUpDown9.Value != 0)
                {
                    sub += "Л*";
                    points += (int)numericUpDown9.Value;
                    amount += 1;
                }
                if (numericUpDown10.Value != 0)
                {
                    sub += "Г*";
                    points += (int)numericUpDown10.Value;
                    amount += 1;
                }

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///
                DataTable table = new DataTable();
                DataBase dataBase = new DataBase();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string querychecking = $"select count(*) from Users";

                SqlCommand command1 = new SqlCommand(querychecking, database.getConnection());
                adapter.SelectCommand = command1;
                adapter.Fill(table);
                int id = table.Rows.Count;

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                string insertResult = $" update Users set Subjects = N'{sub}', Points = {points/amount}, Profile = {3}, Higher_ed = {0} where Id = {id}";
                SqlCommand command = new SqlCommand(insertResult, dataBase.getConnection());

                dataBase.openConnetion();

                if (command.ExecuteNonQuery() == 1)
                {
                    logger.Info("Данные с формы регистрации2 отправлены в базу данных");
                    MessageBox.Show("Данные введены успешно!", "Успех!");
                    this.Hide();
                    LoginForm rg = new LoginForm();
                    rg.ShowDialog();
                }
                else
                {
                    logger.Info("Данные с формы регистрации2 не отправлены в базу данных");
                    MessageBox.Show("Данные не введены");
                }
                dataBase.closeConnetion();
               

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            }
            if(radioButton1.Checked == true)
            {
                int profile = 0;

                if(radioButton4.Checked == true)
                {
                    profile = 1;
                }
                if (radioButton5.Checked == true)
                {
                    profile = 2;
                }
                if (radioButton6.Checked == true)
                {
                    profile = 3;
                }

                DataTable table = new DataTable();
                DataBase dataBase = new DataBase();
                SqlDataAdapter adapter = new SqlDataAdapter();

                string querychecking = $"select count(*) from Users";

                SqlCommand command1 = new SqlCommand(querychecking, database.getConnection());
                adapter.SelectCommand = command1;
                adapter.Fill(table);
                int id = table.Rows.Count;

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                string insertResult = $" update Users set Subjects = N'', Points = {0}, Profile = {profile}, Higher_ed = {1} where Id = {id}";
                SqlCommand command = new SqlCommand(insertResult, dataBase.getConnection());

                dataBase.openConnetion();

                if (command.ExecuteNonQuery() == 1)
                {
                    logger.Info("Данные с формы регистрации2 отправлены в базу данных");
                    MessageBox.Show("Данные введены успешно!", "Успех!");
                    this.Hide();
                    LoginForm rg = new LoginForm();
                    rg.ShowDialog();
                }
                else
                {
                    logger.Info("Данные с формы регистрации2 не отправлены в базу данных");
                    MessageBox.Show("Данные не введены");
                }
                dataBase.closeConnetion();
            }
            if(radioButton2.Checked == true)
            {
                int education = 0;
                int profile = 0;
                if(radioButton7.Checked == true)
                {
                    label15.Text = "В какой сфере?";
                    panel4.Visible = true;
                    education = 1;
                    if (radioButton9.Checked == true)
                    {
                        profile = 1;
                    }
                    if (radioButton10.Checked == true)
                    {
                        profile = 2;
                    }
                    if (radioButton11.Checked == true)
                    {
                        profile = 3;
                    }

                    DataTable table = new DataTable();
                    DataBase dataBase = new DataBase();
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string querychecking = $"select count(*) from Users";

                    SqlCommand command1 = new SqlCommand(querychecking, database.getConnection());
                    adapter.SelectCommand = command1;
                    adapter.Fill(table);
                    int id = table.Rows.Count;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    string insertResult = $" update Users set Subjects = N'', Points = {0}, Profile = {profile}, Higher_ed = {education} where Id = {id}";
                    SqlCommand command = new SqlCommand(insertResult, dataBase.getConnection());

                    dataBase.openConnetion();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        logger.Info("Данные с формы регистрации2 отправлены в базу данных");
                        MessageBox.Show("Данные введены успешно!", "Успех!");
                        this.Hide();
                        LoginForm rg = new LoginForm();
                        rg.ShowDialog();
                    }
                    else
                    {
                        logger.Info("Данные с формы регистрации2 не отправлены в базу данных");
                        MessageBox.Show("Данные не введены");
                    }
                    dataBase.closeConnetion();
                }

                if (radioButton8.Checked == true)
                {
                    education = 1;
                    if (radioButton9.Checked == true)
                    {
                        profile = 1;
                    }
                    if (radioButton10.Checked == true)
                    {
                        profile = 2;
                    }
                    if (radioButton11.Checked == true)
                    {
                        profile = 3;
                    }
                    DataTable table = new DataTable();
                    DataBase dataBase = new DataBase();
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string querychecking = $"select count(*) from Users";

                    SqlCommand command1 = new SqlCommand(querychecking, database.getConnection());
                    adapter.SelectCommand = command1;
                    adapter.Fill(table);
                    int id = table.Rows.Count;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    string insertResult = $" update Users set Subjects = N'', Points = {0}, Profile = {profile}, Higher_ed = {education} where Id = {id}";
                    SqlCommand command = new SqlCommand(insertResult, dataBase.getConnection());

                    dataBase.openConnetion();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        logger.Info("Данные с формы регистрации2 отправлены в базу данных");
                        MessageBox.Show("Данные введены успешно!", "Успех!");
                        this.Hide();
                        LoginForm rg = new LoginForm();
                        rg.ShowDialog();
                    }
                    else
                    {
                        logger.Info("Данные с формы регистрации2 не отправлены  в базу данных");
                        MessageBox.Show("Данные не введены");
                    }
                    dataBase.closeConnetion();
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            radioButton12.Visible = false;
            panel4.Visible = true;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            radioButton12.Visible = true;
            panel4.Visible = true;
        }
    }
}
