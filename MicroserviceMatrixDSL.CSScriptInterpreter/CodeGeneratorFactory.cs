using System.Collections.Generic;
using MicroserviceMatrixDSL.CSScriptInterpreter.Services;
using MicroserviceMatrixDSL.Services;

namespace MicroserviceMatrixDSL.CSScriptInterpreter
{
    public class CodeGeneratorFactory
    {
        public IInterpreter Create(IEnumerable<string> inputLines)
        {
            var decoratedCsharpTranspiler = new CSharpToCsScriptTranspilerDecorator(
                new DslToCSharpTranspiler(
                    new Tokenizer(
                        inputLines
                        )), "Messages", "None", "Microservices"
                );
            return new CSharpScriptBasedInterpreter(decoratedCsharpTranspiler);
        }
    }
}