using System.Collections.Generic;
using System.Linq;
using MicroserviceMatrixDSL.Builder.Descriptions;
using MicroserviceMatrixDSL.Builder.Interfaces;
using MicroserviceMatrixDSL.FunctionalToolkit.Extensions;


namespace MicroserviceMatrixDSL.Builder
{
    public class InfrastructureDesciptionBuilder : IInfrastructureDesciptionBuilder
    {
        public string MessagesDefaultNamespace { get; }
        public string MicroserviceDefaultNamespace { get; }
        public string DefaultCommunicationMean { get; }

        private readonly IReadOnlyCollection<MessageTypeDescription> _messages = new List<MessageTypeDescription>();
        private readonly IReadOnlyCollection<MicroserviceDescription> _microservices = 
            new List<MicroserviceDescription>();

        public InfrastructureDesciptionBuilder(
                string messagesDefaultNamespace,
                string microserviceDefaultNamespace,
                string defaultCommunicationMean
            )
        {
            MessagesDefaultNamespace = messagesDefaultNamespace;
            MicroserviceDefaultNamespace = microserviceDefaultNamespace;
            DefaultCommunicationMean = defaultCommunicationMean;
        }

        public InfrastructureDesciptionBuilder(
            string messagesDefaultNamespace,
            string microserviceDefaultNamespace,
            string defaultCommunicationMean,
            IEnumerable<MessageTypeDescription> messageTypesDescriptions,
            IEnumerable<MicroserviceDescription> microservicesDescriptions
            )
        {
            MessagesDefaultNamespace = messagesDefaultNamespace;
            MicroserviceDefaultNamespace = microserviceDefaultNamespace;
            DefaultCommunicationMean = defaultCommunicationMean;
            _messages = messageTypesDescriptions.ToList();
            _microservices = microservicesDescriptions.ToList();
        }

        public MicroserviceInfrastructureDescription Create()
        {
            return new MicroserviceInfrastructureDescription(
                _messages,
                _microservices
            );
        }

        public IInfrastructureDesciptionBuilder WithDefaultMessageNamespace(string messagesDefaultNamespace)
        {
            return new InfrastructureDesciptionBuilder(
                messagesDefaultNamespace,
                MicroserviceDefaultNamespace,
                DefaultCommunicationMean,
                _messages,
                _microservices);
        }

        public IInfrastructureDesciptionBuilder WithDefaultCommunicationMean(string communicationMean)
        {
            return new InfrastructureDesciptionBuilder(
                MessagesDefaultNamespace,
                MicroserviceDefaultNamespace,
                communicationMean,
                _messages,
                _microservices);
        }

        public IInfrastructureDesciptionBuilder WithDefaultMicroserviceNamespace(string microserviceDefaultNamespace)
        {
            return new InfrastructureDesciptionBuilder(
                MessagesDefaultNamespace,
                microserviceDefaultNamespace,
                DefaultCommunicationMean,
                _messages,
                _microservices);
        }

        public IInfrastructureDesciptionBuilder WithDeclaredMessage(MessageTypeDescription messageTypeDescription)
        {
            return new InfrastructureDesciptionBuilder(
                MessagesDefaultNamespace,
                MicroserviceDefaultNamespace,
                DefaultCommunicationMean,
                _messages.AndThen(messageTypeDescription),
                _microservices);
        }

        public IInfrastructureDesciptionBuilder WithMicroservice(MicroserviceDescription microserviceDescription)
        {
            return new InfrastructureDesciptionBuilder(
                MessagesDefaultNamespace,
                MicroserviceDefaultNamespace,
                DefaultCommunicationMean,
                _messages,
                _microservices.AndThen(microserviceDescription));
        }
    }
}
