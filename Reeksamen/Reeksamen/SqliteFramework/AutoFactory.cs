using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.SqliteFramework
{
    public class AutoFactory<T> where T : new ()
    {
        private string table;
        private Mapper<T> mapper = new Mapper<T>();

        public AutoFactory()
        {
            table = "[" + typeof(T).Name + "]";
        }

        public int Insert(T pro)
        {
            string parameters = "";
            string columns = "";

            var mappings = mapper.CreateMap();

            foreach (var map in mappings)
            {
                  if (map.Key.ToLower() != "id" && pro.GetType().GetProperty(map.Key).GetValue(pro, null) != null)
                {
                    columns += map.Value + ", ";
                    parameters += "@" + map.Key + ", ";
                }
            }

            columns = columns.Substring(0, columns.Length - 2);
            columns = parameters.Substring(0, columns.Length - 2);

            using(var cmd = new SQLiteCommand($"INSERT INTO{table} ({columns}) VALUES ({parameters}); SELECT LAST_INSERT_ROWID() as curID; ", Conn.CreateConnection()))
            {
                foreach (var prop in mappings)
                {
                    if(prop.Key.ToLower() != "id" && pro.GetType().GetProperty(prop.Key).GetValue(pro, null) != null)
                    {
                        cmd.Parameters.AddWithValue(prop.Key, pro.GetType().GetProperty(prop.Key).GetValue(pro, null));
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
            using(var cmd = new SQLiteCommand($"SELECT * FROM {table} WHERE ID=@ID ", Conn.CreateConnection()))
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
            using(var cmd = new SQLiteCommand($"SELECT * FROM {table}", Conn.CreateConnection()))
            {
                List<T> list = mapper.MapList(cmd.ExecuteReader());
                cmd.Connection.Close();
                return list;
            }
        }

        public void Delete(int ID)
        {
            using(var cmd = new SQLiteCommand($"DELETE FROM {table} WHERE ID=@ID", Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public void DeleteBy(string column, object value)
        {
            using (var cmd = new SQLiteCommand($"DELETE FROM {table} WHERE {column}=@value", Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@value", value);
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public List<T> GetBy(string column, object value)
        {
            using(var cmd = new SQLiteCommand($"SELECT * FROM {table} WHERE {column}=@value", Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@value", value);

                List<T> list = mapper.MapList(cmd.ExecuteReader());
                cmd.Connection.Close();
                return list;
            }
        }

        public void update(T pro)
        {
            string fAndP = "";
            var mappings = mapper.CreateMap();

            foreach (var map in mappings)
            {
                if(map.Key.ToLower() != "id")
                {
                    if (pro.GetType().GetProperty(map.Key).GetValue(pro,null) != null)
                    {
                        fAndP += map.Value + "=@" + map.Key + ", ";
                    }
                }
                fAndP = fAndP.Substring(0, fAndP.Length - 2);

                using (var cmd = new SQLiteCommand($"UPDATE {table} SET {fAndP} WHERE ID=@id", Conn.CreateConnection()))
                {
                    foreach (var prop in mappings)
                    {
                        if (pro.GetType().GetProperty(prop.Key).GetValue(pro, null) != null)
                        {
                            cmd.Parameters.AddWithValue(prop.Key, pro.GetType().GetProperty(prop.Key).GetValue(pro, null));
                        }
                    }

                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }
    }
}
