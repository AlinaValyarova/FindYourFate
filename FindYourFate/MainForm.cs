using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindYourFate
{

    public partial class MainForm : LoginForm
    {
        public MainForm(string str)
        {
            InitializeComponent();

            label4.Text = str;
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            listBox1.ItemHeight = 70;
            listBox1.DrawItem += listBox1_DrawItem;
            label1.Focus();
            toolStripTextBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            toolStripTextBox1.Items.Add("По умолчанию");
            toolStripTextBox1.Items.Add("По возрастанию баллов");
            toolStripTextBox1.Items.Add("По убыванию баллов");
            toolStripTextBox1.Items.Add("По алфавиту");
            toolStripTextBox1.Text = "По умолчанию";



        }



        public class TempList
        {
            public string Name;
            public int Points;
        }

        public static string ToUpperFirstLetter(string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            char[] letters = source.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new string(letters);
        }

        public List<Professions> professions = new List<Professions>();
        List<Users> users = new List<Users>();
        private void MainForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string connectionString = @"Data Source = Project3DataBase.mssql.somee.com;" + "Initial Catalog=Project3DataBase;" + "User id=	cargoesbrr_SQLLogin_1;" + "Password=nchbzqmryy;";
            string sqlExpression = "SELECT * FROM Professions";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Professions pf = new Professions();
                        pf.Id = Convert.ToInt32(reader.GetValue(0));
                        pf.Name = ToUpperFirstLetter(reader.GetString(1));
                        pf.HollandResult = Convert.ToInt32(reader.GetValue(2));
                        pf.Subjects = reader.GetValue(3).ToString();
                        pf.Profile = Convert.ToInt32(reader.GetValue(4));
                        pf.Points = Convert.ToInt32(reader.GetValue(5));
                        pf.Higher_ed = Convert.ToInt32(reader.GetValue(6));
                        pf.Speciality = ToUpperFirstLetter(reader.GetString(7));

                        //listBox1.Items.Add(pf);
                        professions.Add(pf);
                        continue;

                    }
                }
                reader.Close();
            }

            sqlExpression = "SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) 
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


                foreach (var u in users)
            { 

                    if (u.Email == label4.Text)
                    {
                    for (int i = 0; i < professions.Count; i++)
                    {
                        Professions pf = new Professions();
                        pf = professions[i];
                        if (pf.HollandResult == u.HollandResult)
                        {
                            if (u.Subjects == pf.Subjects && u.Points <= pf.Points)
                            {
                                pf.temp += 30;
                                
                            }
                            if (u.Profile == pf.Profile)
                            {
                                pf.temp += 20;
                            }
                            if(u.Higher_ed == 0)
                            {
                                if (u.Higher_ed == pf.Higher_ed)
                                {
                                    pf.temp += 100;
                                }
                            }
                            continue;
                        }
                        continue;
                    }
                    var sortedList = professions.OrderByDescending(si => si.temp).ToList();
                    for (int j = 0; j < 5; j++)
                    {
                        Professions p = new Professions();
                        p = sortedList[j];
                        listBox1.Items.Add(p);
                    }
                }
            }




        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {


        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {

            Brush roomsBrush;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds,
                    e.Index, e.State ^ DrawItemState.Selected, e.ForeColor, Color.White);

                roomsBrush = Brushes.Black;
            }
            else
            {
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Default, e.ForeColor, Color.White);
                roomsBrush = Brushes.Black;
            }

            var linePen = new Pen(SystemBrushes.Control);
            var lineStartPoint = new Point(e.Bounds.Left, e.Bounds.Height + e.Bounds.Top);
            var lineEndPoint = new Point(e.Bounds.Width, e.Bounds.Height + e.Bounds.Top);
            e.DrawBackground();
            if(listBox1.Items.Count > 0)
            {
                Professions dataItem = listBox1.Items[e.Index] as Professions;

                var timeFont = new Font("Microsoft Sans Serif", 10.25f, FontStyle.Bold);

                e.Graphics.DrawString(dataItem.Name, timeFont, Brushes.Black, e.Bounds.Left + 3, e.Bounds.Top + 20);


                var roomsFont = new Font("Microsoft Sans Serif", 10.25f, FontStyle.Regular);
                var priceFont = new Font("Microsoft Sans Serif", 10.25f, FontStyle.Regular);

                // And, finally, we draw that text.

                e.Graphics.DrawString(dataItem.Speciality, roomsFont, Brushes.Gray, e.Bounds.Left + 3, e.Bounds.Top + 40);
                e.Graphics.DrawString(dataItem.Subjects, priceFont, Brushes.Black, e.Bounds.Left + 700, e.Bounds.Top + 30);
                e.Graphics.DrawString(dataItem.Points.ToString(), priceFont, Brushes.Black, e.Bounds.Left + 600, e.Bounds.Top + 30);
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void изменитьАккаунтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeForm cf = new ChangeForm(label4.Text);
            cf.Show();
        }

        private void узнатьРезультатыТестыНаТипЛичностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Results res = new Results();
            res.Show();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void показатьБольшеПрофессийToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var sortedList = professions.OrderByDescending(si => si.temp).ToList();
            for (int j = 5; j < 10; j++)
            {
                Professions p = new Professions();
                p = sortedList[j];
                listBox1.Items.Add(p);
            }

        }

        private void поУмолчаниюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Focus();
            if (toolStripTextBox1.SelectedItem.ToString() == "По возрастанию баллов")
            {
                var myOtherList = listBox1.Items.Cast<Professions>().ToList();
                var sortedList = myOtherList.OrderBy(si => si.Points).ToList();
                listBox1.Items.Clear();
                for (int j = 0; j < sortedList.Count; j++)
                {
                    Professions p = new Professions();
                    p = sortedList[j];
                    listBox1.Items.Add(p);
                }
            }
            else if (toolStripTextBox1.SelectedItem.ToString() == "По убыванию баллов")
            {
                var myOtherList = listBox1.Items.Cast<Professions>().ToList();
                var sortedList = myOtherList.OrderByDescending(si => si.Points).ToList();
                listBox1.Items.Clear();
                for (int j = 0; j < sortedList.Count; j++)
                {
                    Professions p = new Professions();
                    p = sortedList[j];
                    listBox1.Items.Add(p);
                }


            }
            else if (toolStripTextBox1.SelectedItem.ToString() == "По алфавиту")
            {
                var myOtherList = listBox1.Items.Cast<Professions>().ToList();
                var sortedList = myOtherList.OrderBy(si => si.Name).ToList();
                listBox1.Items.Clear();
                for (int j = 0; j < sortedList.Count; j++)
                {
                    Professions p = new Professions();
                    p = sortedList[j];
                    listBox1.Items.Add(p);
                }


            }

            else if(toolStripTextBox1.SelectedItem.ToString() == "По умолчанию")
            {
                listBox1.Items.Clear();
                foreach (var u in users)
                {

                    if (u.Email == label4.Text)
                    {
                        for (int i = 0; i < professions.Count; i++)
                        {
                            Professions pf = new Professions();
                            pf = professions[i];
                            if (pf.HollandResult == u.HollandResult)
                            {
                                if (u.Subjects == pf.Subjects && u.Points <= pf.Points)
                                {
                                    pf.temp += 30;

                                }
                                if (u.Profile == pf.Profile)
                                {
                                    pf.temp += 20;
                                }
                                if (u.Higher_ed == 0)
                                {
                                    if (u.Higher_ed == pf.Higher_ed)
                                    {
                                        pf.temp += 100;
                                    }
                                }
                                continue;
                            }
                            continue;
                        }
                        var sortedList = professions.OrderByDescending(si => si.temp).ToList();
                        for (int j = 0; j < 5; j++)
                        {
                            Professions p = new Professions();
                            p = sortedList[j];
                            listBox1.Items.Add(p);
                        }
                    }
                }
            }
        }
    }
}

