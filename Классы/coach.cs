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
    public class coach
    {
        database db = new database();
        public void CoachLoadListBox(ListBox listBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Тренер";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string row = "";

                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            string value = reader[i].ToString();

                            row += $"{value} | ";
                        }
                        listBox.Items.Add(row);
                    }
                }
            }
            db.con.Close();
        }

        public void CoachLoadComboBox(System.Windows.Forms.ComboBox comboBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Тренер";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader["id"].ToString());
                    }
                }
            }
            db.con.Close();
        }
        public void CoachAdd(System.Windows.Forms.TextBox name,System.Windows.Forms.TextBox firstname, System.Windows.Forms.TextBox lastname, MaskedTextBox number, System.Windows.Forms.TextBox experience)
        {
            string query = $"insert into Тренер(Имя,Фамилия,Отчество, Телефон, Опыт) values ('{name.Text}','{firstname.Text}','{lastname.Text}','{number.Text}', '{experience.Text}')";
            SqlCommand command = new SqlCommand(query, db.con);

            try
            {
                db.con.Open();
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Тренер успешно добавлен!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
