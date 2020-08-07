using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeksamen.Scripts.SQLiteFrameWork
{
    public class Mapper<T> where T : new()
    {
        private Dictionary<string,string> _mapping { get; set; }

        public Mapper()
        {
            _mapping = CreateMapper();
        }

        public T Map(IDataRecord record)
        {
            var item = Activator.CreateInstance<T>();
            var itemType = item.GetType();

            foreach (var map in _mapping)
            {
                var prop = itemType.GetProperty(map.Key);

                if (record[map.Value] != DBNull.Value) //records the date if its not empty ~DBNULL
                {
                    if (prop.GetValue(item) is bool) //if the prop is a Bool
                    {
                        prop.SetValue(item, Convert.ToBoolean(record[map.Value]), null); //Bool
                    }
                    else if (record[map.Value] is long) //if the prop's value is a long
                    {
                        prop.SetValue(item, Convert.ToInt32(record[map.Value]), null); //Int
                    }
                    else if (record[map.Value] is Double) //if the prop's value is a double
                    {
                        prop.SetValue(item, Convert.ToSingle(record[map.Value]), null); //Float
                    }
                    else //if its something else set it to default
                    {
                        prop.SetValue(item, record[map.Value], null); 
                    }
                }
            }

            return item;
        }

        public List<T> MapList(IDataReader reader)
        {
            var list = new List<T>();

            while(reader.Read())
            {
                list.Add(Map(reader));
            }

            reader.Close();
            return list;
        }

        public Dictionary<string,string> CreateMapper()
        {
            var mappings = new Dictionary<string, string>();
            var props = typeof(T).GetProperties().Where(p => p.CanWrite);

            foreach (var prop in props)
            {
                mappings.Add(prop.Name, prop.Name);
            }

            return mappings;
        }
    }
}
