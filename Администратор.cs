using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Спортивный_клуб.Классы;

namespace Спортивный_клуб
{
    public partial class Администратор : Form
    {
        events events = new events();
        subscription subscription = new subscription();
        coach coach = new coach();
        person person = new person();
        appointments appointments = new appointments();
        public Администратор()
        {
            InitializeComponent();
            events.Event(listBox1);
            subscription.Subscription(listBox2);
            coach.CoachLoadListBox(listBox3);
            coach.CoachLoadComboBox(comboBox1);
            person.PersonLoadComboBox(comboBox2);
            appointments.Appointment(listBox4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(dateTimePicker1.Text))
            {
                MessageBox.Show("Заполните данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listBox1.Items.Clear();
                events.Event(listBox1);
                events.AddEvent(textBox1, dateTimePicker1, textBox2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            subscription.Subscription(listBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(maskedTextBox1.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Заполните данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listBox3.Items.Clear();
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                coach.CoachLoadListBox(listBox3);
                coach.CoachLoadComboBox(comboBox1);
                person.PersonLoadComboBox(comboBox2);
                coach.CoachAdd(textBox4, textBox5, textBox3, maskedTextBox1, textBox6);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ДомашняяСтраница form1 = new ДомашняяСтраница();
            form1.ShowDialog();
        }

        private void Администратор_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;

            string header = "Отчет";
            Font headerFont = new Font("Bahnschrift", 14, FontStyle.Bold);
            graphics.DrawString(header, headerFont, Brushes.Black, 100, 100);

            int y = 150;
            int x = 100;
            int lineHeight = 20;

            foreach (string item in listBox2.Items)
            {
                string[] words = item.Split(' ');

                foreach (string word in words)
                {
                    SizeF wordSize = graphics.MeasureString(word, new Font("Bahnschrift", 12));
                    if (x + wordSize.Width > e.PageBounds.Width - 100)
                    {
                        x = 100;
                        y += lineHeight;
                    }

                    graphics.DrawString(word, new Font("Bahnschrift", 12), Brushes.Black, x, y);

                    x += (int)wordSize.Width;
                }

                y += lineHeight;
                x = 100;
            }
        }

        public void print()
        {
            PrintDocument printDocument = new PrintDocument();

            printDocument.PrintPage += PrintDocument_PrintPage;

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            print();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Заполните данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listBox4.Items.Clear();
                appointments.Appointment(listBox4);
                appointments.AppointmentAdd(comboBox1, comboBox2);
            }
        }

        private void Администратор_Load(object sender, EventArgs e)
        {

        }
    }
}
