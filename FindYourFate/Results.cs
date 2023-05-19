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

namespace FindYourFate
{
    public partial class Results : Form
    {
        public Results(string str)
        {
            InitializeComponent();
            label2.Text = str;
        }

        private void Results_Load(object sender, EventArgs e)
        {
            int result = 0;
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

            foreach(Users u in users)
            {
                if (u.Email == label2.Text)
                {
                    result = u.HollandResult;
                }
            }

            switch(result)
            {
                case 0:
                    pictureBox1.Image = Properties.Resources.realistic;
                    label3.Text = "Ваш тип: реалистичный";
                    label1.Text = "Люди, относящиеся к этому типу, предпочитают выполнять работу, требующую силы, ловкости, подвижности, хорошей координации движений, " +
                        "навыков практической работы. Результаты труда профессионалов этого типа ощутимы и реальны – их руками создан весь" +
                        "окружающий нас предметный мир. Люди реалистического типа охотнее делают, чем говорят, они настойчивы и уверены в себе," +
                        " в работе предпочитают четкие и конкретные указания.Придерживаются традиционных ценностей, поэтому критически относятся к новым идеям. ";
                    return;
                case 1:
                    pictureBox1.Image = Properties.Resources.intellectual;
                    label3.Text = "Ваш тип: интеллектуальный";
                    label1.Text = "Людей, относящихся к этому типу, отличают аналитические способности, рационализм, независимость и оригинальность мышления, умение точно" +
                        " формулировать и излагать свои мысли, решать логические задачи, генерировать новые идеи. Они часто выбирают научную и исследовательскую работу.Им нужна свобода для творчества." +
                        "Работа способна увлечь их настолько, что стирается грань между рабочим временем и досугом. Мир идей для них может быть важнее, чем общение " +
                        "с людьми. Материальное благополучие для них обычно не на первом месте. ";
                    return;
                case 2:
                    pictureBox1.Image = Properties.Resources.social;
                    label3.Text = "Ваш тип: социальный";
                    label1.Text = "Люди, относящиеся к этому типу, предпочитают профессиональную деятельность, связанную с обучением, воспитанием, лечением, " +
                        "консультированием, обслуживанием.Люди этого типа гуманны, чувствительны, активны, ориентированы на социальные нормы, " +
                        "способны понять эмоциональное состояние другого человека. Для них характерно хорошее речевое развитие, живая мимика, интерес к людям, " +
                        "готовность прийти на помощь. Материальное благополучие для них обычно не на первом месте.";
                    return;
                case 3:
                    pictureBox1.Image = Properties.Resources.office;
                    label3.Text = "Ваш тип: офисный";
                    label1.Text = "Люди этого типа обычно проявляют склонность к работе, связанной с обработкой и систематизацией информации, предоставленной в виде" +
                        " условных знаков, цифр, формул, текстов (ведение документации, " +
                        "установление количественных соотношений между числами и условными " +
                        "знаками). Они отличаются аккуратностью, пунктуальностью, " +
                        "практичностью, ориентированы на социальные нормы, предпочитают " +
                        "четко регламентированную работу.Материальное благополучие для них " +
                        "более значимо, чем для других типов.Склонны к работе, не связанной с " +
                        "широкими контактами и принятием ответственных решений. ";
                    return;
                case 4:
                    pictureBox1.Image = Properties.Resources.business;
                    label3.Text = "Ваш тип: предпринимательский";
                    label1.Text = "Люди этого типа находчивы, практичны, быстро ориентируются в " +
                        "сложной обстановке, склонны к самостоятельному принятию решений, " +
                        "социально активны, готовы рисковать, ищут острые ощущения. Любят и " +
                        "умеют общаться. Имеют высокий уровень притязаний. Избегают занятий, " +
                        "требующих усидчивости, большой и длительной концентрации внимания. " +
                        "Для них значимо материальное благополучие.Предпочитают " +
                        "деятельность, требующую энергии, организаторских способностей, " +
                        "связанную с руководством, управлением и влиянием на людей.";
                    return;
                case 5:
                    pictureBox1.Image = Properties.Resources.artist;
                    label3.Text = "Ваш тип: артистичный";
                    label1.Text = "Люди этого типа оригинальны, независимы в принятии решений, редко " +
                        "ориентируются на социальные нормы и одобрение, обладают необычным " +
                        "взглядом на жизнь, гибкостью мышления, эмоциональной " +
                        "чувствительностью.Отношения с людьми строят, опираясь на свои " +
                        "ощущения, эмоции, воображение, интуицию.Они не выносят жесткой " +
                        "регламентации, предпочитая свободный график работы. Часто выбирают " +
                        "профессии, связанные с литературой, театром, кино, музыкой, " +
                        "изобразительным искусством.";
                    return;


            }
        }
    }
}
