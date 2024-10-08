﻿using System.Data;

namespace DateManagementMySQL.Infrastructure.Extensions
{
    public static class MapToObjHelper
    {
        // mapea la informacion de la base de datos y la guarda en un objeto del tipo de objeto que se provea
        public static T MapToObj<T>(IDataReader dataReader)
        {
            var obj = Activator.CreateInstance<T>();
            var properties = obj.GetType().GetProperties();
            while (dataReader.Read())
            {
                foreach (var prop in properties)
                {
                    if (object.Equals(dataReader[prop.Name], DBNull.Value)) continue;
                    var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    var safeValue = Convert.ChangeType(dataReader[prop.Name], type);
                    prop.SetValue(obj, safeValue, null);
                }
            }
            return obj;
        }
    }
}
