﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel1.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton3.Checked == true)
            {
                string sub = "";
                int points = 0;

                if (numericUpDown1.Value != 0)
                {
                    sub += "М*";
                    points += (int)numericUpDown1.Value;
                }
                if (numericUpDown2.Value != 0)
                {
                    sub += "О*";
                    points += (int)numericUpDown2.Value;
                }
                if (numericUpDown3.Value != 0)
                {
                    sub += "Б*";
                    points += (int)numericUpDown3.Value;
                }
                if (numericUpDown4.Value != 0)
                {
                    sub += "Ин*";
                    points += (int)numericUpDown4.Value;
                }
                if (numericUpDown5.Value != 0)
                {
                    sub += "Ф*";
                    points += (int)numericUpDown5.Value;
                }
                if (numericUpDown6.Value != 0)
                {
                    sub += "Ис";
                    points += (int)numericUpDown6.Value;
                }
                if (numericUpDown7.Value != 0)
                {
                    sub += "Ия*";
                    points += (int)numericUpDown7.Value;
                }
                if (numericUpDown8.Value != 0)
                {
                    sub += "Х*";
                    points += (int)numericUpDown8.Value;
                }
                if (numericUpDown9.Value != 0)
                {
                    sub += "Л*";
                    points += (int)numericUpDown9.Value;
                }
                if (numericUpDown10.Value != 0)
                {
                    sub += "Г*";
                    points += (int)numericUpDown10.Value;
                }
            }
            else if(radioButton1.Checked == true)
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
            }
            else if(radioButton2.Checked == true)
            {

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
        }
    }
}
