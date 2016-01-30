using MicroserviceMatrixDSL.Builder;
using MicroserviceMatrixDSL.Builder.Descriptions;
using MicroserviceMatrixDSL.Builder.Interfaces;
using MicroserviceMatrixDSL.DSL.Interfaces;

namespace MicroserviceMatrixDSL.DSL
{
    public class MicroserviceInfrastructureDsl : IMicroserviceInfrastructureDsl
    {
        private readonly IInfrastructureDesciptionBuilder _infrastractureDescriptionBuilder;

        public string MessagesDefaultNamespace 
            => _infrastractureDescriptionBuilder.MessagesDefaultNamespace;
        public string MicroserviceDefaultNamespace
            => _infrastractureDescriptionBuilder.MicroserviceDefaultNamespace;
        public string DefaultCommunicationMean
            => _infrastractureDescriptionBuilder.DefaultCommunicationMean;

        public MicroserviceInfrastructureDsl()
        {
            _infrastractureDescriptionBuilder =
                new InfrastructureDesciptionBuilder(
                    string.Empty,
                    string.Empty,
                    string.Empty
                );
        }

        public MicroserviceInfrastructureDsl(
            IInfrastructureDesciptionBuilder infrastructureDesciptionBuilder
            )
        {
            _infrastractureDescriptionBuilder = infrastructureDesciptionBuilder;
        }

        public MicroserviceInfrastructureDsl(
            string messageDefaultNamespace,
            string microserviceDefaultNamespace,
            string defaultCommunicationMean
            )
        {
            _infrastractureDescriptionBuilder = 
                new InfrastructureDesciptionBuilder(
                    messageDefaultNamespace,
                    microserviceDefaultNamespace,
                    defaultCommunicationMean
                );
        }

        public IDeclareDefaultDsl Default()
        {
            return new DeclareDefaultDsl(this);
        }

        public IMicroserviceInfrastructureDsl Using()
        {
            return this;
        }

        public IMessageTypeDescriptionBuilderDsl Message()
        {
            return new MessageTypeDescriptionBuilderDsl(this);
        }

        public IMicroserviceDescriptionBuilderDsl Microservice(string microserviceName)
        {
            return new MicroserviceDescriptionBuilderDsl(
                    microserviceName,
                    _infrastractureDescriptionBuilder.DefaultCommunicationMean,
                    _infrastractureDescriptionBuilder.MicroserviceDefaultNamespace,
                    this
                );
        }

        public MicroserviceInfrastructureDescription Create()
        {
            return _infrastractureDescriptionBuilder.Create();
        }

        public IMicroserviceInfrastructureDsl WithDefaultMessageNamespace(string messagesDefaultNamespace)
        {
            return new MicroserviceInfrastructureDsl(
                    _infrastractureDescriptionBuilder
                        .WithDefaultMessageNamespace(messagesDefaultNamespace)
                );
        }

        public IMicroserviceInfrastructureDsl WithDefaultCommunicationMean(string communicationMean)
        {
            return new MicroserviceInfrastructureDsl(
                   _infrastractureDescriptionBuilder
                        .WithDefaultCommunicationMean(communicationMean)
               );
        }

        public IMicroserviceInfrastructureDsl WithDefaultMicroserviceNamespace(string microserviceDefaultNamespace)
        {
            return new MicroserviceInfrastructureDsl(
                    _infrastractureDescriptionBuilder
                        .WithDefaultMicroserviceNamespace(microserviceDefaultNamespace)
                );
        }

        public IMicroserviceInfrastructureDsl WithDeclaredMessage(MessageTypeDescription messageTypeDescription)
        {
            return new MicroserviceInfrastructureDsl(
                _infrastractureDescriptionBuilder
                    .WithDeclaredMessage(messageTypeDescription)
                );
        }

        public IMicroserviceInfrastructureDsl WithMicroservice(MicroserviceDescription microserviceDescription)
        {
            return new MicroserviceInfrastructureDsl(
                    _infrastractureDescriptionBuilder
                        .WithMicroservice(microserviceDescription)
                );
        }
    }
}
