using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Спортивный_клуб.Классы
{
    public class events
    {
        database db = new database();

        public void Event(ListBox listBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Мероприятия";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox.Items.Add($"{reader["Информация"].ToString()}, дата проведения события {reader["ДатаПроведения"].ToString()} по адресу {reader["Местоположение"].ToString()}");
                    }
                }
            }
            db.con.Close();
        }

        public void AddEvent(System.Windows.Forms.TextBox textBox, DateTimePicker dateTimePicker, System.Windows.Forms.TextBox textBox1)
        {
            string query = $"insert into Мероприятия(Информация,ДатаПроведения,Местоположение) values ('{textBox.Text}','{dateTimePicker.Text}','{textBox1.Text}')";
            SqlCommand command = new SqlCommand(query, db.con);
            try
            {
                db.con.Open();
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Данные занесены.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                db.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
                db.con.Close();
            }
        }
    }
}
