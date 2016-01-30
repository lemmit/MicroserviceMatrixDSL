using System.Collections.Generic;
using System.Linq;
using MicroserviceMatrixDSL.CodeTranspiler.Interfaces;
using MicroserviceMatrixDSL.DSL.DslStates;
using MicroserviceMatrixDSL.FunctionalToolkit;

namespace MicroserviceMatrixDSL
{
    public class KeywordsProvider : IKeywordsProvider
    {
        public IEnumerable<KeyValuePair<string, int>> GetKeywords()
        {
            var lists = new[]
            {
                typeof (DeclareNamespaceState).GetPublicMethodsWithNumberOfParams(),
                typeof (MessageTypeDescribingState).GetPublicMethodsWithNumberOfParams(),
                typeof (MicroserviceDescribingState).GetPublicMethodsWithNumberOfParams(),
                typeof (BaseState).GetPublicMethodsWithNumberOfParams(),
                typeof (DeclareDefaultsState).GetPublicMethodsWithNumberOfParams()
            };

            var keywordList = lists
                .SelectMany(list => list)
                .Distinct();
            return keywordList;
        }
    }
}