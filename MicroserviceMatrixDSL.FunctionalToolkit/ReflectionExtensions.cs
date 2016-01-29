using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MicroserviceMatrixDSL.FunctionalToolkit
{
    public static class ReflectionExtensions
    {
        public static IEnumerable<string> GetPublicMethods(this Type type)
        {
            var members = type
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => !m.IsSpecialName);
            return members.Select(member => member.Name);
        }

        private const BindingFlags Flags = BindingFlags.Public 
            | BindingFlags.Instance
            | BindingFlags.DeclaredOnly;
        private static readonly IList<MethodInfo> ObjectMembers
            = typeof(object).GetMethods(Flags).Where(m => !m.IsSpecialName).ToList();
        public static IEnumerable<KeyValuePair<string, int>> GetPublicMethodsWithNumberOfParams(this Type type)
        {
            return type
                .GetMethods(Flags)
                .Where(m => !m.IsSpecialName)
        //        .Except(ObjectMembers)
                .Select(member => new KeyValuePair<string, int>(member.Name, member.GetParameters().Length));
        }
    }
}
