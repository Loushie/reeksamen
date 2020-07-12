using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.SqliteFramework.Models
{
    class AutoTable2
    {
        private Dictionary<string, string> _mappings { get; set; }

        public AutoTable2()
        {
            
        }

        public void MakeTable<T>()
        {
            _mappings = CreateTableDictionary<T>();

            string sql = "";
            foreach (var map in _mappings)
            {
                sql += map.Key + " ";

                if (map.Value == "int32" || map.Value == "int64" || map.Value == "int16")
                {
                    sql += "INTEGER ";
                }
                else if (map.Value == "Single")
                {
                    sql += "REAL";
                }
                else if (map.Value == "Boolean")
                {
                    sql += "INTEGER ";
                }
                else if (map.Value == "String")
                {
                    sql += "VARCHAR ";
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

            using (var cmd = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS {typeof(T).Name} ({sql}) ", Conn.CreateConnection()))
            {
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        private Dictionary<string, string> CreateTableDictionary<T>()
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
