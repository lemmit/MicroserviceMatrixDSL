using System.Collections.Generic;
using System.Linq;
using MicroserviceMatrixDSL.DSL.DslStates;
using MicroserviceMatrixDSL.FunctionalToolkit;

namespace MicroserviceMatrixDSL.CSScriptInterpreter.Providers
{
    public class KeywordsProvider
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