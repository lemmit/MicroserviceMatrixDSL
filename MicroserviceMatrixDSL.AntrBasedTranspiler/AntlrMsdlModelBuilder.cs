using System;
using Antlr4.Runtime;
using MicroserviceMatrixDSL.AntlrBasedTranspiler.Generated;
using MicroserviceMatrixDSL.Builder;
using MicroserviceMatrixDSL.Descriptions;
using MicroserviceMatrixDSL.Services;

namespace MicroserviceMatrixDSL.AntlrBasedTranspiler
{
    public class AntlrMsdlModelBuilder : IInterpreter
    {
        private readonly Lazy<MicroserviceInfrastructureDescription> _description;
        private readonly string _inputPath;

        public AntlrMsdlModelBuilder(string inputFilePath)
        {
            _description = new Lazy<MicroserviceInfrastructureDescription>(BuildDescription);
            _inputPath = inputFilePath;
        }

        public MicroserviceInfrastructureDescription InterpretedDescription => _description.Value;

        private MicroserviceInfrastructureDescription BuildDescription()
        {
            var l = new microservice_description_languageLexer(new AntlrFileStream(_inputPath));
            var p = new microservice_description_languageParser(new CommonTokenStream(l));
            var parseListener = new MsdlParseTreeListener(
                new InfrastructureDesciptionBuilder("Messages", "None", "Microservices"),
                new MicroserviceDescriptionBuilder("Microservice", "RabbitMq", "Microservices"),
                new MessageTypeDescriptionBuilder()
                );
            p.AddParseListener(parseListener);
            var msdl = p.microservice_description_language();
            return parseListener.Create();
        }
    }
}