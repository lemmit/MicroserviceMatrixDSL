using System.Collections.Generic;
using System.Linq;
using MicroserviceMatrixDSL.DSL;
using MicroserviceMatrixDSL.FunctionalToolkit;

namespace MicroserviceMatrixDSL.CodeGenerator
{
    public class KeywordsProvider : IKeywordsProvider
    {
        public IEnumerable<KeyValuePair<string, int>> GetKeywords()
        {
            var lists = new[]
            {
                typeof (MessageNamespaceDeclaringDsl).GetPublicMethodsWithNumberOfParams(),
                typeof (MessageTypeDescriptionBuilderDsl).GetPublicMethodsWithNumberOfParams(),
                typeof (MicroserviceDescriptionBuilderDsl).GetPublicMethodsWithNumberOfParams(),
                typeof (MicroserviceInfrastructureDsl).GetPublicMethodsWithNumberOfParams(),
                typeof (DeclareDefaultDsl).GetPublicMethodsWithNumberOfParams(),
            };

            var keywordList = lists
                .SelectMany(list => list)
                .Distinct();
            return keywordList;
        }
    }
}
