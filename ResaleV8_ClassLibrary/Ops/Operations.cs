using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ResaleV8_ClassLibrary.Ops
{
    public static class Operations
    {
        public static List<string> getModelPtoperties<T>(T model)
        {
            List<string> properties = new List<string>();
            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                properties.Add(prop.Name);
            }            

            return properties;
        }
    }
}
