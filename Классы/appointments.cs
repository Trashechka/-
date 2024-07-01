using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Спортивный_клуб.Классы
{
    public class appointments
    {
        database db = new database();

        public void Appointment(ListBox listBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Назначения";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox.Items.Add($"Выбранный тренер: {reader["idТренер"].ToString()}, Выбранный участник: {reader["idУчастник"].ToString()}");
                    }
                }
            }
            db.con.Close();
        }

        public void AppointmentAdd(ComboBox comboBox,ComboBox comboBox1)
        {
            string query = $"insert into Назначения(idУчастник,idТренер) values ('{comboBox1.Text}','{comboBox.Text}')";

            SqlCommand command = new SqlCommand(query, db.con);

            try
            {
                db.con.Open();
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Успешно добавлено!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
