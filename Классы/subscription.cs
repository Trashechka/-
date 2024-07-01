using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Спортивный_клуб.Классы
{
    public class subscription
    {
        database db = new database();
        public void Subscription(ListBox listBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Абонемент";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox.Items.Add($"Номер участника абонемента: {reader["Участник"].ToString()}, {reader["Цена"].ToString()} ₽, Дата с: {reader["ДатаС"].ToString()}, Дата по: {reader["ДатаПо"].ToString()}");
                    }
                }
            }
            db.con.Close();
        }
    }
}
