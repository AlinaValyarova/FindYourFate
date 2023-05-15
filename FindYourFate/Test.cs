using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FindYourFate;

namespace FindYourFate
{
    public partial class Test : Form
    {
        public int R;
        public int I;
        public int S;
        public int O;
        public int P;
        public int A;
        public Test()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            radioButton42.Text = "Музыкант";

        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton57_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton51_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton39_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //первый вопрос
            if(radioButton1.Checked ==  false && radioButton2.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton1.Checked == true)
            {
                R += 1;
                panel1.Visible = true;

            }
            if(radioButton2.Checked == true)
            {
                S += 1;
                panel1.Visible = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //первый вопрос
            this.Hide();
            RegistrationForm rg = new RegistrationForm();
            rg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //второй вопрос
            if (radioButton3.Checked == false && radioButton4.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton3.Checked == true)
            {
                I += 1;
                panel2.Visible = true;

            }
            if (radioButton4.Checked == true)
            {
                P += 1;
                panel2.Visible = true;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //второй вопрос
            panel1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //пятый вопрос
            if (radioButton9.Checked == false && radioButton10.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton9.Checked == true)
            {
                I += 1;
                panel5.Visible = true;

            }
            if (radioButton10.Checked == true)
            {
                P += 1;
                panel5.Visible = true;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //третий вопрос
            if (radioButton5.Checked == false && radioButton6.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton5.Checked == true)
            {
                O += 1;
                panel3.Visible = true;

            }
            if (radioButton6.Checked == true)
            {
                A += 1;
                panel3.Visible = true;
            }
        }

        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel2.Visible = false;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //четвертый вопрос
            if (radioButton7.Checked == false && radioButton8.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton7.Checked == true)
            {
                R += 1;
                panel4.Visible = true;

            }
            if (radioButton8.Checked == true)
            {
                S += 1;
                panel4.Visible = true;
            }
        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Visible = false;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel4.Visible = false;
        }

        private void Test_Load(object sender, EventArgs e)
        {
            pictureBox60.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox59.SizeMode = PictureBoxSizeMode.StretchImage;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel16.Visible = false;
            panel17.Visible = false;
            panel18.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;
            panel23.Visible = false;
            panel24.Visible = false;
            panel25.Visible = false;
            panel26.Visible = false;
            panel27.Visible = false;
            panel28.Visible = false;
            panel29.Visible = false;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            //шестой вопрос
            if (radioButton11.Checked == false && radioButton12.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton11.Checked == true)
            {
                O += 1;
                panel6.Visible = true;

            }
            if (radioButton12.Checked == true)
            {
                A += 1;
                panel6.Visible = true;
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel5.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //седьмой вопрос
            if (radioButton13.Checked == false && radioButton14.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton13.Checked == true)
            {
                R += 1;
                panel7.Visible = true;

            }
            if (radioButton14.Checked == true)
            {
                S += 1;
                panel7.Visible = true;
            }
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel6.Visible = false;
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //восьмой вопрос
            if (radioButton15.Checked == false && radioButton16.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton15.Checked == true)
            {
                I += 1;
                panel8.Visible = true;

            }
            if (radioButton16.Checked == true)
            {
                P += 1;
                panel8.Visible = true;
            }
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel7.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //девятый вопрос
            if (radioButton17.Checked == false && radioButton18.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton17.Checked == true)
            {
                O += 1;
                panel9.Visible = true;

            }
            if (radioButton18.Checked == true)
            {
                A += 1;
                panel9.Visible = true;
            }
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel8.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //десятый вопрос
            if (radioButton19.Checked == false && radioButton20.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton19.Checked == true)
            {
                R += 1;
                panel10.Visible = true;

            }
            if (radioButton20.Checked == true)
            {
                S += 1;
                panel10.Visible = true;
            }
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel9.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //11 вопрос
            if (radioButton21.Checked == false && radioButton22.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton21.Checked == true)
            {
                O += 1;
                panel11.Visible = true;

            }
            if (radioButton22.Checked == true)
            {
                A += 1;
                panel11.Visible = true;
            }
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel10.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //12 вопрос
            if (radioButton23.Checked == false && radioButton24.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton23.Checked == true)
            {
                O += 1;
                panel12.Visible = true;

            }
            if (radioButton24.Checked == true)
            {
                A += 1;
                panel12.Visible = true;
            }
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel11.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //13 вопрос
            if (radioButton25.Checked == false && radioButton26.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton25.Checked == true)
            {
                R += 1;
                panel13.Visible = true;

            }
            if (radioButton26.Checked == true)
            {
                S += 1;
                panel13.Visible = true;
            }
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel12.Visible = false;
        }

        private void radioButton27_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            //14 вопрос
            if (radioButton27.Checked == false && radioButton28.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton27.Checked == true)
            {
                I += 1;
                panel14.Visible = true;

            }
            if (radioButton28.Checked == true)
            {
                P += 1;
                panel14.Visible = true;
            }
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel13.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //15 вопрос
            if (radioButton29.Checked == false && radioButton30.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton29.Checked == true)
            {
                O += 1;
                panel15.Visible = true;

            }
            if (radioButton30.Checked == true)
            {
                A += 1;
                panel15.Visible = true;
            }
        }

        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel14.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //16 вопрос
            if (radioButton31.Checked == false && radioButton32.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton31.Checked == true)
            {
                R += 1;
                panel16.Visible = true;

            }
            if (radioButton32.Checked == true)
            {
                S += 1;
                panel16.Visible = true;
            }
        }

        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel15.Visible = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //17 вопрос
            if (radioButton33.Checked == false && radioButton34.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton33.Checked == true)
            {
                I += 1;
                panel17.Visible = true;

            }
            if (radioButton34.Checked == true)
            {
                P += 1;
                panel17.Visible = true;
            }
        }

        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel16.Visible = false;
        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            //18 вопрос
            if (radioButton35.Checked == false && radioButton36.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton35.Checked == true)
            {
                O += 1;
                panel18.Visible = true;

            }
            if (radioButton36.Checked == true)
            {
                A += 1;
                panel18.Visible = true;
            }
        }

        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel17.Visible = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //19 вопрос
            if (radioButton37.Checked == false && radioButton38.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton37.Checked == true)
            {
                R += 1;
                panel19.Visible = true;

            }
            if (radioButton38.Checked == true)
            {
                S += 1;
                panel19.Visible = true;
            }
        }

        private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel18.Visible = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //20 вопрос
            if (radioButton39.Checked == false && radioButton40.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton39.Checked == true)
            {
                I += 1;
                panel20.Visible = true;

            }
            if (radioButton40.Checked == true)
            {
                P += 1;
                panel20.Visible = true;
            }
        }

        private void linkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel19.Visible = false;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //21 вопрос

            if (radioButton41.Checked == false && radioButton42.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton41.Checked == true)
            {
                O += 1;
                panel21.Visible = true;

            }
            if (radioButton42.Checked == true)
            {
                A += 1;
                panel21.Visible = true;
            }
        }

        private void linkLabel21_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel20.Visible = false;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //22 вопрос
            if (radioButton43.Checked == false && radioButton44.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton43.Checked == true)
            {
                R += 1;
                panel22.Visible = true;

            }
            if (radioButton44.Checked == true)
            {
                S += 1;
                panel22.Visible = true;
            }
        }

        private void linkLabel22_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel21.Visible = false;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            //23 вопрос
            if (radioButton45.Checked == false && radioButton46.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton45.Checked == true)
            {
                I += 1;
                panel23.Visible = true;

            }
            if (radioButton46.Checked == true)
            {
                P += 1;
                panel23.Visible = true;
            }
        }

        private void linkLabel23_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel22.Visible = false;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            //24 вопрос
            if (radioButton47.Checked == false && radioButton48.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton47.Checked == true)
            {
                O += 1;
                panel24.Visible = true;

            }
            if (radioButton48.Checked == true)
            {
                A += 1;
                panel24.Visible = true;
            }
        }

        private void linkLabel24_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel23.Visible = false;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //25 вопрос
            if (radioButton49.Checked == false && radioButton50.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton49.Checked == true)
            {
                R += 1;
                panel25.Visible = true;

            }
            if (radioButton50.Checked == true)
            {
                S += 1;
                panel25.Visible = true;
            }
        }

        private void linkLabel25_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel24.Visible = false;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            //26 вопрос
            if (radioButton51.Checked == false && radioButton52.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton51.Checked == true)
            {
                I += 1;
                panel26.Visible = true;

            }
            if (radioButton52.Checked == true)
            {
                P += 1;
                panel26.Visible = true;
            }
        }

        private void linkLabel26_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel25.Visible = false;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            //27 вопрос
            if (radioButton53.Checked == false && radioButton54.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton53.Checked == true)
            {
                O += 1;
                panel27.Visible = true;

            }
            if (radioButton54.Checked == true)
            {
                A += 1;
                panel27.Visible = true;
            }
        }

        private void linkLabel27_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel26.Visible = false;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            //28 вопрос
            if (radioButton55.Checked == false && radioButton56.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton55.Checked == true)
            {
                R += 1;
                panel28.Visible = true;

            }
            if (radioButton56.Checked == true)
            {
                S += 1;
                panel28.Visible = true;
            }
        }

        private void linkLabel28_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel27.Visible = false;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            //29 вопрос
            if (radioButton57.Checked == false && radioButton58.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton57.Checked == true)
            {
                I += 1;
                panel29.Visible = true;

            }
            if (radioButton58.Checked == true)
            {
                P += 1;
                panel29.Visible = true;
            }
        }

        private void linkLabel29_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel28.Visible = false;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            //30 вопрос
            if (radioButton59.Checked == false && radioButton60.Checked == false)
            {
                MessageBox.Show("Нужно выбрать одну из профессий!", "Упс!");
            }
            if (radioButton59.Checked == true)
            {
                O += 1;
                int[] arr = { R, I, S, O, P, A };
                int max = arr.Max();
                int maxlet = arr.ToList().IndexOf(max);
                label31.Text = maxlet.ToString();
                this.Hide();
                RegistrationForm2 rg = new RegistrationForm2();
                rg.ShowDialog();

            }
            if (radioButton60.Checked == true)
            {
                A += 1;
                int[] arr = { R, I, S, O, P, A };
                int max = arr.Max();
                int maxlet = arr.ToList().IndexOf(max);
                label31.Text = maxlet.ToString();
                this.Hide();
                RegistrationForm2 rg = new RegistrationForm2();
                rg.ShowDialog();
            }
        }

        private void linkLabel30_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel29.Visible = false;
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }
    }
}
