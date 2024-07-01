using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Спортивный_клуб.Классы
{
    public class search
    {
        database db = new database();
        public void SearchAb(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Абонемент where Участник = '{textBox1.Text}'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox2.Text = "Дата с: " + reader["ДатаС"].ToString();
                        textBox3.Text = "Дата по: " + reader["ДатаПо"].ToString();
                        textBox4.Text = reader["Цена"].ToString() + " ₽";
                    }
                }
            }
            db.con.Close();
        }
    }
}
