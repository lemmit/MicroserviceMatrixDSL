using System;
using MicroserviceMatrixDSL.Builder;
using MicroserviceMatrixDSL.Builder.Descriptions;
using MicroserviceMatrixDSL.Builder.Interfaces;

namespace MicroserviceMatrixDSL.DSL
{
    public class MicroserviceDescriptionBuilderDsl
    {
        public MicroserviceInfrastructureDsl GetInfrastructure() => _microserviceInfrastructureDsl;

        private readonly string _lastDeclaredMessageName = "";
        private readonly MicroserviceInfrastructureDsl _microserviceInfrastructureDsl;
        private readonly IMicroserviceDescriptionBuilder _microserviceDescriptionBuilder;

        public MicroserviceDescriptionBuilderDsl( 
            string microserviceName,
            string defaultCommunicationMean,
            string defaultMicroservieNamespace,
            MicroserviceInfrastructureDsl microserviceInfrastructureDsl
            )
        {
            _microserviceInfrastructureDsl = microserviceInfrastructureDsl;
            
            _microserviceDescriptionBuilder =
                new MicroserviceDescriptionBuilder(
                        microserviceName,
                        defaultCommunicationMean,
                        defaultMicroservieNamespace
                    );
        }

        private MicroserviceDescriptionBuilderDsl(
            MicroserviceInfrastructureDsl microserviceInfrastructureDsl,
            IMicroserviceDescriptionBuilder microserviceDescriptionBuilder,
            string lastAddedMessageTypeName
            )
        {
            _microserviceInfrastructureDsl = microserviceInfrastructureDsl;
            _microserviceDescriptionBuilder = microserviceDescriptionBuilder;
            _lastDeclaredMessageName = lastAddedMessageTypeName;
        }


        public MicroserviceDescriptionBuilderDsl Using(string communicationMean)
        {
            return new MicroserviceDescriptionBuilderDsl(
                    _microserviceInfrastructureDsl,
                    _microserviceDescriptionBuilder.WithCommunicationMean(communicationMean),
                    _lastDeclaredMessageName
                );
        }

        public MicroserviceDescriptionBuilderDsl Sends(string sendsMessageTypeName)
        {
            return new MicroserviceDescriptionBuilderDsl(
                    _microserviceInfrastructureDsl,
                    _microserviceDescriptionBuilder.Sends(sendsMessageTypeName),
                    _lastDeclaredMessageName
                );
        }

        public MicroserviceDescriptionBuilderDsl Receives(string receiveMessageTypeName)
        {
            return new MicroserviceDescriptionBuilderDsl(
                    _microserviceInfrastructureDsl,
                    _microserviceDescriptionBuilder.RespondsTo(receiveMessageTypeName),
                    receiveMessageTypeName
                );
        }

        public MicroserviceDescriptionBuilderDsl And()
        {
            return this;
        }

        public MicroserviceDescriptionBuilderDsl Responds(string respondMessageTypeName)
        {
            if (string.IsNullOrEmpty(_lastDeclaredMessageName))
                throw new InvalidOperationException("Microservice first has to receive something to respond!");

            return new MicroserviceDescriptionBuilderDsl(
                    _microserviceInfrastructureDsl,
                    _microserviceDescriptionBuilder.RespondsToWith(_lastDeclaredMessageName, respondMessageTypeName),
                    _lastDeclaredMessageName
                );
        }

        public MicroserviceDescriptionBuilderDsl Microservice(string microserviceName)
        {
            return _microserviceInfrastructureDsl
                    .WithMicroservice(Create())
                    .Microservice(microserviceName);
        }

        private MicroserviceDescription Create()
        {
            return _microserviceDescriptionBuilder.Create();
        }

        public MicroserviceDescriptionBuilderDsl Like(string microserviceMixin)
        {
            return new MicroserviceDescriptionBuilderDsl(
                    _microserviceInfrastructureDsl,
                    _microserviceDescriptionBuilder.Extends(microserviceMixin),
                    _lastDeclaredMessageName
                );
        }

        public MicroserviceDescriptionBuilderDsl With(string respondMessageTypeName)
        {
            return Responds(respondMessageTypeName);
        }

        public MicroserviceDescriptionBuilderDsl Responds()
        {
            if (string.IsNullOrEmpty(_lastDeclaredMessageName))
                throw new InvalidOperationException("Microservice first has to receive something to respond!");
            return this;
        }
    }
}
