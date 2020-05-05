using Quantum.DAL.Infrastructure.Attributes;
using Quantum.DAL.Infrastructure.Exceptions;
using System;
using System.Linq;
using System.Reflection;

namespace Quantum.DAL.Infrastructure
{
    internal static class Reflector
    {
        public static FieldInfo[] GetStoredProcedureOutFields(StoredProcedure storedProcedure)
        {
            var result = GetFieldsWithParameterAttribute(storedProcedure, typeof(OutParameter));
            return result;
        }

        public static FieldInfo GetStoredProcedureReturnField(StoredProcedure storedProcedure)
        {
            var result = GetFieldsWithParameterAttribute(storedProcedure, typeof(ReturnValue));

            if (result.Length > 1)
            {
                throw new MoreThanOneReturnParameterException("More than one return parameter in stored procedure entity.");
            }

            return result.FirstOrDefault();
        }

        public static FieldInfo[] GetFieldsWithProcedureParameterAttribute(StoredProcedure storedProcedure)
        {
            var result =
                GetFieldsByAttribute(storedProcedure, a => a.AttributeType.BaseType == typeof(ProcedureParameter))
                .ToArray();

            return result;
        }

        public static FieldInfo[] GetFields(StoredProcedure storedProcedure)
        {
            return storedProcedure
                .GetType()
                .GetFields(
                    BindingFlags.Public |
                    BindingFlags.DeclaredOnly |
                    BindingFlags.SetField |
                    BindingFlags.GetField |
                    BindingFlags.Instance);
        }

        public static FieldInfo[] GetFieldsWithParameterAttribute(StoredProcedure storedProcedure, Type parameterAttributeType)
        {
            var result = GetFieldsByAttribute(storedProcedure, a => a.AttributeType == parameterAttributeType)
                .ToArray();

            return result;
        }

        public static FieldInfo[] GetFieldsByAttribute(StoredProcedure storedProcedure, Func<CustomAttributeData, bool> fieldSelector)
        {
            var result = GetFields(storedProcedure)
                .Where(p => p.CustomAttributes.Any(fieldSelector))
                .ToArray();

            return result;
        }
    }
}
