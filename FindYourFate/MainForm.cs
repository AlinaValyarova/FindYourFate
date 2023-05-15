﻿using System;
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
using AngleSharp;
using AngleSharp.Dom;

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

        List<Professions> professions = new List<Professions>();
        List<Users> users = new List<Users>();
        List<TempList> tl = new List<TempList>();
        private void MainForm_Load(object sender, EventArgs e)
        {

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

                        listBox1.Items.Add(pf);
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

            //for (int i = 0; i < professions.Count; i++)
            //{
            //    foreach (var u in users)
            //    {
            //        if (u.Email == label4.Text)
            //        {
            //            Professions pf = new Professions();
            //            pf = professions[i];
            //            if (pf.HollandResult == u.HollandResult)
            //            {
            //                if (pf.Subjects == u.Subjects)
            //                {
            //                    pf.temp += 1;
            //                    if (pf.Profile == u.Profile)
            //                    {
            //                        pf.temp += 1;
            //                        if (pf.Points <= u.Points)
            //                        {
            //                            pf.temp += 1;
            //                            if (pf.Higher_ed == u.Higher_ed)
            //                            {
            //                                listBox1.Items.Add(pf);
            //                                continue;
            //                            }
            //                        }
            //                    }
            //                }
            //            }


            //        }

            //    }
            //}

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
            ChangeForm cf = new ChangeForm();
            cf.Show();
        }

        private void узнатьРезультатыТестыНаТипЛичностиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

