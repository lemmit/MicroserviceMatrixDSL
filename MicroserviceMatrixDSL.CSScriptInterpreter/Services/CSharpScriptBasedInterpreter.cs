using System;
using System.Linq;
using CSScriptLibrary;
using MicroserviceMatrixDSL.CSScriptInterpreter.Services.Interfaces;
using MicroserviceMatrixDSL.Descriptions;
using MicroserviceMatrixDSL.Services;

namespace MicroserviceMatrixDSL.CSScriptInterpreter.Services
{
    internal class CSharpScriptBasedInterpreter : IInterpreter
    {
        private readonly Lazy<MicroserviceInfrastructureDescription> _interpretedDescription;
        private readonly ITranspiler _transpiler;

        public CSharpScriptBasedInterpreter(
            ITranspiler transpiler
            )
        {
            _transpiler = transpiler;
            _interpretedDescription = new Lazy<MicroserviceInfrastructureDescription>(InterpretDescription);
        }

        public MicroserviceInfrastructureDescription InterpretedDescription => _interpretedDescription.Value;

        private MicroserviceInfrastructureDescription InterpretDescription()
        {
            var genCode = _transpiler.GeneratedCode;
            try
            {
                CSScript.EvaluatorConfig.Engine = EvaluatorEngine.CodeDom;
                var generate = CSScript.Evaluator
                    .CreateDelegate(genCode);
                var description = (MicroserviceInfrastructureDescription) generate();
                return description;
            }
            catch (Exception e)
            {
                Console.Write($"/*CODE GENERATION ERROR:\n" +
                              $"Generated code: {genCode}\n" +
                              $"Exception: {e}\n" +
                              $"*/");
            }

            return new MicroserviceInfrastructureDescription(
                Enumerable.Empty<MessageTypeDescription>(),
                Enumerable.Empty<MicroserviceDescription>()
                );
        }
    }
}