using MicroserviceMatrixDSL.CSScriptInterpreter.Services.Interfaces;

namespace MicroserviceMatrixDSL.CSScriptInterpreter.Services
{
    internal class CSharpToCsScriptTranspilerDecorator : ITranspiler
    {
        private readonly string _defaultCommuniationMean;


        private readonly string _defaultMessagesNamespace;
        private readonly string _defaultMicroservicesNamespace;
        private readonly ITranspiler _transpiler;

        public CSharpToCsScriptTranspilerDecorator(ITranspiler transpiler,
            string defaultMessagesNamespace,
            string defaultCommunicationMean,
            string defaultMicroservicesNamespace
            )
        {
            _defaultMessagesNamespace = defaultMessagesNamespace;
            _defaultCommuniationMean = defaultCommunicationMean;
            _defaultMicroservicesNamespace = defaultMicroservicesNamespace;

            _transpiler = transpiler;
        }

        public string GeneratedCode => CodeBefore()
                                       + _transpiler.GeneratedCode
                                       + CodeAfter();

        private string GetParams()
        {
            return
                $"\"{_defaultMessagesNamespace}\", \"{_defaultCommuniationMean}\", \"{_defaultMicroservicesNamespace}\" ";
        }

        public virtual string CodeBefore()
        {
            return @"
                    //css_reference MicroserviceMatrixDSL.DSL;
                    //css_reference MicroserviceMatrixDSL.Descriptions;
                    using MicroserviceMatrixDSL.DSL;
                    using MicroserviceMatrixDSL.Descriptions;

                    MicroserviceInfrastructureDescription GenerateInfrastructureDescription()
                    {
                        return  new DslStatesFactory()
                                .CreateBaseState(" + GetParams() + ")";
        }

        public virtual string CodeAfter()
        {
            return @".Flush().Create();
                }
            ";
        }
    }
}