using System;

namespace Quantum.DAL.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    internal class ProcedureName : Attribute
    {
        public string Name { get; set; }

        public ProcedureName(string name)
        {
            Name = name;
        }
    }
}
