using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace FindYourFate
{
    public partial class ChangeForm : LoginForm
    {
        public ChangeForm(string str)
        {
            InitializeComponent();
            label22.Text = str;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private void ChangeForm_Load(object sender, EventArgs e)
        {
            List<Users> users = new List<Users>();  
            string connectionString = @"Data Source = Project3DataBase.mssql.somee.com;" + "Initial Catalog=Project3DataBase;" + "User id=	cargoesbrr_SQLLogin_1;" + "Password=nchbzqmryy;";
            string sqlExpression = "SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        Users u = new Users();
                        Professions pf = new Professions();
                        u.Id = Convert.ToInt32(reader.GetValue(0));
                        u.FirstName = reader.GetString(1);
                        u.LastName = reader.GetString(2);
                        u.Email = reader.GetString(3);  
                        u.Password = reader.GetString(4); 
                        u.HollandResult = Convert.ToInt32(reader.GetValue(5));
                        u.Subjects = reader.GetString(6);
                        u.Points = Convert.ToInt32(reader.GetValue(7));
                        u.Higher_ed = Convert.ToInt32(reader.GetValue(8));


                        users.Add(u);
                        continue;

                    }
                }
                reader.Close();
            }

            foreach (var a in users)
            {
                if (a.Email == label22.Text.ToString())
                {
                    textBox11.Text = a.Email;
                    textBox3.Text = a.Password; 
                    textBox22.Text = a.FirstName;
                    textBox4.Text = a.LastName;


                }
            }
        }

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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Test t = new Test(label22.Text);
            t.Show();
        }
        DataBase database = new DataBase();
        private void button3_Click(object sender, EventArgs e)
        {
            List<Users> users = new List<Users>();
            string connectionString = @"Data Source = Project3DataBase.mssql.somee.com;" + "Initial Catalog=Project3DataBase;" + "User id=	cargoesbrr_SQLLogin_1;" + "Password=nchbzqmryy;";
            string sqlExpression = "SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        Users u = new Users();
                        Professions pf = new Professions();
                        u.Id = Convert.ToInt32(reader.GetValue(0));
                        u.FirstName = reader.GetString(1);
                        u.LastName = reader.GetString(2);
                        u.Email = reader.GetString(3);
                        u.Password = reader.GetString(4);
                        u.HollandResult = Convert.ToInt32(reader.GetValue(5));
                        u.Subjects = reader.GetString(6);
                        u.Points = Convert.ToInt32(reader.GetValue(7));
                        u.Higher_ed = Convert.ToInt32(reader.GetValue(8));


                        users.Add(u);
                        continue;

                    }
                }
                reader.Close();
            }
            int id = 0;
            foreach (var a in users)
            {
                if (a.Email == label22.Text.ToString())
                {
                    id = a.Id;
                    textBox11.Text = a.Email;
                    textBox3.Text = a.Password; //поменять на звездочки
                    textBox22.Text = a.FirstName;
                    textBox4.Text = a.LastName;


                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            DataTable table = new DataTable();
            DataBase dataBase = new DataBase();
            SqlDataAdapter adapter = new SqlDataAdapter();

            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                string insertResult = $" Update Users set FirstName = N'{textBox22.Text}' , LastName = N'{textBox4.Text}', Email = N'{textBox11.Text}' , Password = N'{textBox3.Text}' where Id = {id}";
                SqlCommand command = new SqlCommand(insertResult, dataBase.getConnection());

                dataBase.openConnetion();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Данные введены успешно!", "Успех!");
                    this.Hide();
                    MainForm rg = new MainForm(label22.Text);
                    rg.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Данные не введены");
                }
                dataBase.closeConnetion();
            }
            else
            {
                if (radioButton3.Checked == true)
                {
                    string sub = "";
                    int points = 0;
                    int amount = 0;
                    if (numericUpDown11.Value != 0)
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
                    string insertResult = $" update Users set FirstName = n'{textBox22.Text}' , LastName = n'{textBox4.Text}', Email = n'{textBox11.Text}' , Password = n'{textBox3.Text}'," +
                        $" Subjects = N'{sub}', Points = {points / amount}, Profile = {3}, Higher_ed = {0} where Id = {id}";
                    SqlCommand command = new SqlCommand(insertResult, dataBase.getConnection());

                    dataBase.openConnetion();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        logger.Info("Данные с окна изменения формы введены успешно");
                        MessageBox.Show("Данные введены успешно!", "Успех!");
                        this.Hide();
                        MainForm rg = new MainForm(label22.Text);
                        rg.ShowDialog();
                    }
                    else
                    {
                        logger.Info("Данные с окна изменения формы не введены");
                        MessageBox.Show("Данные не введены");
                    }
                    dataBase.closeConnetion();
                }
                if (radioButton1.Checked == true)
                {
                    int profile = 0;

                    if (radioButton4.Checked == true)
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
                    string insertResult = $" update Users set FirstName = n'{textBox22.Text}' , LastName = n'{textBox4.Text}', Email = n'{textBox11.Text}' , Password = n'{textBox3.Text}'," +
    $" Subjects = N'', Points = {0}, Profile = {profile}, Higher_ed = {1} where Id = {id}";
                    SqlCommand command = new SqlCommand(insertResult, dataBase.getConnection());

                    dataBase.openConnetion();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Данные введены успешно!", "Успех!");
                        this.Hide();
                        MainForm rg = new MainForm(label22.Text);
                        rg.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Данные не введены");
                    }
                    dataBase.closeConnetion();
                }
                if (radioButton2.Checked == true)
                {
                    int education = 0;
                    int profile = 0;
                    if (radioButton7.Checked == true)
                    {
                        label15.Text = "В какой сфере у вас образование?";
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
                        string insertResult = $" update Users set FirstName = n'{textBox22.Text}' , LastName = n'{textBox4.Text}', Email = n'{textBox11.Text}' , Password = n'{textBox3.Text}'," +
$" Subjects = N'', Points = {0}, Profile = {profile}, Higher_ed = {education} where Id = {id}";
                        SqlCommand command = new SqlCommand(insertResult, dataBase.getConnection());

                        dataBase.openConnetion();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            logger.Info("Данные с окна изменения формы введены успешно");
                            MessageBox.Show("Данные введены успешно!", "Успех!");
                            this.Hide();
                            MainForm rg = new MainForm(label22.Text);
                            rg.ShowDialog();
                        }
                        else
                        {
                            logger.Info("Данные с окна изменения формы не введены");
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
                        string insertResult = $" update Users set FirstName = n'{textBox22.Text}' , LastName = n'{textBox4.Text}', Email = n'{textBox11.Text}' , Password = n'{textBox3.Text}'," +
$" Subjects = N'', Points = {0}, Profile = {profile}, Higher_ed = {education} where Id = {id}";
                        SqlCommand command = new SqlCommand(insertResult, dataBase.getConnection());

                        dataBase.openConnetion();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            logger.Info("Данные с окна изменения формы введены успешно");
                            MessageBox.Show("Данные введены успешно!", "Успех!");
                            this.Hide();
                            MainForm rg = new MainForm(label22.Text);
                            rg.ShowDialog();
                        }
                        else
                        {
                            logger.Info("Данные с окна изменения формы не введены");
                            MessageBox.Show("Данные не введены");
                        }
                        dataBase.closeConnetion();
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Test t = new Test(label22.Text);
            t.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Test t = new Test(label22.Text);
            t.Show();
            this.Hide();
        }
    }
}
