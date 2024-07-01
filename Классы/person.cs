using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Спортивный_клуб.Классы
{
    public class person
    {
        database db = new database();
        public void PersonLoadComboBox(System.Windows.Forms.ComboBox comboBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Участник";

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
    }
}
