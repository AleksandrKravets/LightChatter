using Quantum.DAL.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Quantum.DAL.Infrastructure
{
    internal abstract class StoredProcedure
    {
        public void SetFieldValue(string fieldName, object value)
        {
            GetType().GetField(fieldName).SetValue(this, value);
        }

        public string GetProcedureName()
        {
            var nameAttribute = (ProcedureName)GetType().GetCustomAttributes(typeof(ProcedureName)).FirstOrDefault();

            if (nameAttribute == null)
                return GetType().Name;

            return nameAttribute.Name;
        }

        private ParameterDirection GetParameterDirection(IEnumerable<CustomAttributeData> attributes)
        {
            var attribute = attributes
                .Select(a => a.AttributeType)
                .FirstOrDefault();

            return attribute.Name switch
            {
                nameof(InParameter) => ParameterDirection.Input,
                nameof(OutParameter) => ParameterDirection.Output,
                nameof(ReturnValue) => ParameterDirection.ReturnValue,
                _ => throw new Exception()
            };
        }

        public StoredProcedureParameter[] GetStoredProcedureParameters()
        {
            var procedureParameters = Reflector.GetFieldsWithProcedureParameterAttribute(this);

            var result = procedureParameters
                .Select(f => new StoredProcedureParameter(f.Name, f.GetValue(this), GetParameterDirection(f.CustomAttributes)))
                .ToArray();

            return result;
        }
    }
}
