using System;

namespace Quantum.DAL.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    internal abstract class ProcedureParameter : Attribute
    {
    }
}
