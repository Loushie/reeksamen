using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.SQLiteFrameWork
{
    class AutoFactory<T> where T : new ()
    {
        private sting table;
        private Mapper<T> mapper = new Mapper<T>();

        public AutoFactory()
        {
            table = "[" + typeof(T).Name + "]";
        }

        public int Insert(T pro)
        {
            string parms = "";
            string columns = "";

            var mapping = mapper.CreateMapper();

            foreach (var map in mapping)
            {
                if (map.Key.ToLower() != "id" && pro.GetType().GetProperty(map.Key).GetValue(pro, null) != null)
                {

                    columns += map.Value + ", ";
                    parms += "@" + map.Key + ", ";

                }
            }

            columns = columns.Substring(0, columns.Length - 2);
            parms = parms.Substring(0, parms.Length - 2);

            using(var cmd = new SQLiteCommand($"INSERT INTO {table} ({columns}) VALUES ({parms}); SELECT LAST_INSERT_ROWID() as currentID;", Connector.CreateConnection()))
            {
                foreach (var prop in mapping)
                {
                    if (prop.Key.ToLower() != "id" && pro.GetType().GetProperty(prop.Key).GetValue(pro, null) != null)
                    {
                        cmd.Parameters.AddWithValue(prop.Key, pro.GetType().GetProperty(prop.Key).GetValue(pro, null)); //Some SQL security so that SQL commands dosent get entered by accident
                    }
                }

                var r = cmd.ExecuteReader();
                int curID = 0;

                if (r.Read())
                {
                    curID = int.Parse(r["curID"].ToString());
                }

                r.Close();
                cmd.Connection.Close();

                return curID;
            }
        }

        public T Get(int ID)
        {
            using (var cmd = new SQLiteCommand($"SELECT * FROM {table} WHERE ID=@ID ", Connector.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@ID", ID);

                var r = cmd.ExecuteReader();
                T type = new T();

                if (r.Read())
                {
                    type = mapper.Map(r);
                }

                r.Close();
                cmd.Connection.Close();
                return type;
            }
        }

        public List<T> GetAll()
        {
            using (var cmd = new SQLiteCommand($"SELECT * FROM {table}", Connector.CreateConnection()))
            {
                List<T> list = mapper.MapList(cmd.ExecuteReader());
                cmd.Connection.Close();
                return list;
            }
        }
    }
}
