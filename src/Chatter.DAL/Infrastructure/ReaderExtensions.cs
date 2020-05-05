using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Quantum.DAL.Infrastructure
{
    internal static class ReaderExtensions
    {
        public static T ReadObject<T>(this SqlDataReader reader)
        {
            var instance = (T)Activator.CreateInstance(typeof(T));

            foreach (var instanceProperty in instance.GetType().GetProperties())
            {
                if (instanceProperty.PropertyType.IsEnum)
                {
                    instanceProperty.SetValue(
                        instance,
                        Enum.Parse(
                            instanceProperty.PropertyType,
                            Enum.GetName(instanceProperty.PropertyType, reader[instanceProperty.Name])
                        )
                    );

                    continue;
                }

                instanceProperty.SetValue(instance, Convert.ChangeType(reader[instanceProperty.Name], instanceProperty.PropertyType));
            }

            return instance;
        }

        public static List<T> ReadList<T>(this SqlDataReader reader)
        {
            var result = new List<T>();

            while (reader.Read())
            {
                var instance = reader.ReadObject<T>();
                result.Add(instance);
            }

            return result;
        }
    }
}
