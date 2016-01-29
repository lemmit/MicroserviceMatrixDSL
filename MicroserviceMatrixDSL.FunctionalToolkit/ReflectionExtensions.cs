using System;
using System.Linq;
using System.Reflection;

namespace MicroserviceMatrixDSL.FunctionalToolkit
{
    public static class ReflectionExtensions
    {
        public static bool HasPublicMethodMember(this Type type, string methodName)
        {
            return type.GetMembers(BindingFlags.Public | BindingFlags.Instance)
                .Any(member => member.Name.ToLower().Equals(methodName.ToLower()));
        }
    }
}
