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

namespace Спортивный_клуб
{
    public partial class АккаунтАдминистратора : Form
    {
        database db = new database();
        public АккаунтАдминистратора()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ДомашняяСтраница form = new ДомашняяСтраница();
            form.ShowDialog();
        }

        private void logins()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();

            string query = $"select * from Администратор where Логин='{textBox1.Text}' and Пароль='{textBox2.Text}'";

            SqlCommand command = new SqlCommand(query, db.con);

            adapter.SelectCommand = command;

            adapter.Fill(Table);

            if (Table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли как админ!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Администратор администратор = new Администратор();
                администратор.ShowDialog();


                db.con.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                db.con.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин/пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Поля не заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                logins();
            }
        }

        private void АккаунтАдминистратора_Load(object sender, EventArgs e)
        {

        }
    }
}
