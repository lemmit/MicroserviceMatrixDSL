﻿using MicroserviceMatrixDSL.Builder;
using MicroserviceMatrixDSL.Builder.Descriptions;
using MicroserviceMatrixDSL.Builder.Interfaces;

namespace MicroserviceMatrixDSL.DSL
{
    public class MicroserviceInfrastructureDsl
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

        public MicroserviceInfrastructureDsl(IInfrastructureDesciptionBuilder infrastructureDesciptionBuilder)
        {
            _infrastractureDescriptionBuilder = infrastructureDesciptionBuilder;
        }

        public DeclareDeafultDsl Default()
        {
            return new DeclareDeafultDsl(this);
        }

        public MicroserviceInfrastructureDsl Using()
        {
            return this;
        }

        public MessageTypeDescriptionBuilderDsl Message()
        {
            return new MessageTypeDescriptionBuilderDsl(this);
        }

        public MicroserviceDescriptionBuilderDsl Microservice(string microserviceName)
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

        public MicroserviceInfrastructureDsl WithDefaultMessageNamespace(string messagesDefaultNamespace)
        {
            return new MicroserviceInfrastructureDsl(
                    _infrastractureDescriptionBuilder
                        .WithDefaultMessageNamespace(messagesDefaultNamespace)
                );
        }

        public MicroserviceInfrastructureDsl WithDefaultCommunicationMean(string communicationMean)
        {
            return new MicroserviceInfrastructureDsl(
                   _infrastractureDescriptionBuilder
                        .WithDefaultCommunicationMean(communicationMean)
               );
        }

        public MicroserviceInfrastructureDsl WithDefaultMicroserviceNamespace(string microserviceDefaultNamespace)
        {
            return new MicroserviceInfrastructureDsl(
                    _infrastractureDescriptionBuilder
                        .WithDefaultMicroserviceNamespace(microserviceDefaultNamespace)
                );
        }

        public MicroserviceInfrastructureDsl WithDeclaredMessage(MessageTypeDescription messageTypeDescription)
        {
            return new MicroserviceInfrastructureDsl(
                _infrastractureDescriptionBuilder
                    .WithDeclaredMessage(messageTypeDescription)
                );
        }

        public MicroserviceInfrastructureDsl WithMicroservice(MicroserviceDescription microserviceDescription)
        {
            return new MicroserviceInfrastructureDsl(
                    _infrastractureDescriptionBuilder
                        .WithMicroservice(microserviceDescription)
                );
        }
    }
}