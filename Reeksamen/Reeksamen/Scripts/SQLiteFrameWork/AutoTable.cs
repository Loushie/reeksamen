using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.SQLiteFrameWork
{
    class AutoTable<T> where T : new ()
    {
        private Dictionary<string,string> _mapper { get; set; }

        public AutoTable()
        {
            _mapper = CreateTableDictionary();
        }

        public void MakeTable()
        {
            string sql = "";

            foreach (var map in _mapper)
            {
                sql += map.Key + " ";

                if (map.Value == "Int16" || map.Value == "Int32" || map.Value == "Int64")
                {
                    sql += "INTEGER ";
                }
                else if (map.Value == "Single")
                {
                    sql += "REAL";
                }
                else if (map.Value == "Boolean")
                {
                    sql += "INTEGER";
                }
                else if (map.Value == "String")
                {
                    sql += "VARCHAR";
                }
                else
                {
                    sql += map.Value + " ";
                }

                if (map.Key == "ID")
                {
                    sql += " PRIMARY KEY AUTOINCREMENT ";  
                }
                sql += ", ";
            }

            sql = sql.Substring(0, sql.Length - 2);

            using (var cmd = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS {typeof(T).Name} ({sql})", Connector.CreateConnection()))
            {
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        private Dictionary<string,string> CreateTableDictionary()
        {
            var mappings = new Dictionary<string, string>();
            var props = typeof(T).GetProperties().Where(p => p.CanWrite);

            foreach (var prop in props)
            {
                mappings.Add(prop.Name, prop.PropertyType.Name);
            }

            return mappings;
        }
    }
}
