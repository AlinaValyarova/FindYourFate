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
using AngleSharp;
using AngleSharp.Dom;

namespace FindYourFate
{

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            listBox1.ItemHeight = 70;
            listBox1.DrawItem += listBox1_DrawItem;
        }

        public static string ToUpperFirstLetter(string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            // convert to char array of the string
            char[] letters = source.ToCharArray();
            // upper case the first char
            letters[0] = char.ToUpper(letters[0]);
            // return the array made of the new char array
            return new string(letters);
        }

        List<Professions> professions = new List<Professions>();
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm lg = new LoginForm();
            string email = lg.ImportantValue;

            string connectionString = @"Data Source = Project3DataBase.mssql.somee.com;" + "Initial Catalog=Project3DataBase;" + "User id=	cargoesbrr_SQLLogin_1;" + "Password=nchbzqmryy;";
            string sqlExpression = "SELECT * FROM Professions";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        Professions pf = new Professions();
                        pf.Id = Convert.ToInt32(reader.GetValue(0));
                        pf.Name = ToUpperFirstLetter(reader.GetString(1));
                        pf.HollandResult = Convert.ToInt32(reader.GetValue(2));
                        pf.Subjects = reader.GetValue(3).ToString();
                        pf.Profile = Convert.ToInt32(reader.GetValue(4));
                        pf.Points = Convert.ToInt32(reader.GetValue(5));
                        pf.Higher_ed = Convert.ToInt32(reader.GetValue(6));
                        pf.Speciality = reader.GetString(7);

                        professions.Add(pf);
                        continue;

                    }
                }
                reader.Close();
            }

            for (int i = 0; i < professions.Count; i++)
            {
                Professions pf = new Professions();
                pf = professions[i];
                listBox1.Items.Add(pf);
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
}

