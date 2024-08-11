using System.Data;

namespace DateManagementMySQL.Infrastructure.Extensions
{
    public static class MapToListHelper
    {
        // mapea la informacion de la base de datos y la guarda en una lista del tipo de objeto que se provea
        public static List<T> MapToList<T>(IDataReader dataReader)
        {
            var list = new List<T>();
            var obj2 = Activator.CreateInstance<T>();
            var properties = obj2.GetType().GetProperties();
            while (dataReader.Read())
            {
                var obj = Activator.CreateInstance<T>();
                foreach (var prop in properties)
                {
                    if (object.Equals(dataReader[prop.Name], DBNull.Value)) continue;
                    var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    var safeValue = Convert.ChangeType(dataReader[prop.Name], type);
                    prop.SetValue(obj, safeValue, null);
                }
                list.Add(obj);
            }
            return list;
        }
    }

}
