using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Спортивный_клуб.Классы;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Спортивный_клуб
{
    public partial class Абонемент : Form
    {
        database db = new database();
        private DateTime _startDate;
        private DateTime _endDate;
        private decimal _pricePerDay;
        public Абонемент()
        {
            InitializeComponent();
            Random random = new Random();
            textBox5.Text = random.Next(10000000, 1999999999).ToString();
            _pricePerDay = 100;
        }

        public void S()
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Номер вашего абонимента, не потеряйте его!.txt")))
            {
                writer.WriteLine(textBox5.Text);
            }

            MessageBox.Show("Данные успешно сохранены в файл на рабочем столе.");
        }

        public void Saver()
        {
            string query = $"insert into Участник(НомерУчастника,Имя,Фамилия,Отчество, Телефон) values ('{textBox5.Text}','{textBox2.Text}','{textBox1.Text}','{textBox3.Text}', '{maskedTextBox1.Text}')";

            SqlCommand command = new SqlCommand(query, db.con);

            try
            {
                db.con.Open();
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Абонемент приобретен.\nWelcome to the club, buddy.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                db.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
                db.con.Close();
            }
        }


        public void Save()
        {
            string query = $"insert into Абонемент(Участник,Цена,ДатаС,ДатаПо) values ('{textBox5.Text}','{textBox4.Text}','{dateTimePicker1.Text}','{dateTimePicker2.Text}')";

            SqlCommand command = new SqlCommand(query, db.con);

            try
            {
                db.con.Open();
                int rowsAffected = command.ExecuteNonQuery();

                db.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
                db.con.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(maskedTextBox1.Text) || string.IsNullOrWhiteSpace(dateTimePicker1.Text) || string.IsNullOrWhiteSpace(dateTimePicker1.Text))
            {
                MessageBox.Show("Заполните данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Saver();
                Save();
                S();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            _startDate = dateTimePicker1.Value;
            _endDate = dateTimePicker2.Value;

            int days = (int)(_endDate - _startDate).TotalDays;

            decimal price = days * _pricePerDay;

            textBox4.Text = price.ToString();
        }

        private void Абонемент_Load(object sender, EventArgs e)
        {

        }
    }
}
