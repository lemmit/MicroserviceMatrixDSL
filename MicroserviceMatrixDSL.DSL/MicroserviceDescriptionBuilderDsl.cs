using System;
using MicroserviceMatrixDSL.Builder;
using MicroserviceMatrixDSL.Builder.Descriptions;
using MicroserviceMatrixDSL.Builder.Interfaces;
using MicroserviceMatrixDSL.DSL.Interfaces;

namespace MicroserviceMatrixDSL.DSL
{
    public class MicroserviceDescriptionBuilderDsl : IMicroserviceDescriptionBuilderDsl
    {
        private readonly string _lastDeclaredMessageName = "";
        private readonly IMicroserviceInfrastructureDsl _microserviceInfrastructureDsl;
        private readonly IMicroserviceDescriptionBuilder _microserviceDescriptionBuilder;

        public MicroserviceDescriptionBuilderDsl( 
            string microserviceName,
            string defaultCommunicationMean,
            string defaultMicroservieNamespace,
            IMicroserviceInfrastructureDsl microserviceInfrastructureDsl
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
            IMicroserviceInfrastructureDsl microserviceInfrastructureDsl,
            IMicroserviceDescriptionBuilder microserviceDescriptionBuilder,
            string lastAddedMessageTypeName
            )
        {
            _microserviceInfrastructureDsl = microserviceInfrastructureDsl;
            _microserviceDescriptionBuilder = microserviceDescriptionBuilder;
            _lastDeclaredMessageName = lastAddedMessageTypeName;
        }


        public IMicroserviceDescriptionBuilderDsl Using(string communicationMean)
        {
            return new MicroserviceDescriptionBuilderDsl(
                    _microserviceInfrastructureDsl,
                    _microserviceDescriptionBuilder.WithCommunicationMean(communicationMean),
                    _lastDeclaredMessageName
                );
        }

        public IMicroserviceDescriptionBuilderDsl Sends(string sendsMessageTypeName)
        {
            return new MicroserviceDescriptionBuilderDsl(
                    _microserviceInfrastructureDsl,
                    _microserviceDescriptionBuilder.Sends(sendsMessageTypeName),
                    _lastDeclaredMessageName
                );
        }

        public IMicroserviceDescriptionBuilderDsl Receives(string receiveMessageTypeName)
        {
            return new MicroserviceDescriptionBuilderDsl(
                    _microserviceInfrastructureDsl,
                    _microserviceDescriptionBuilder.RespondsTo(receiveMessageTypeName),
                    receiveMessageTypeName
                );
        }

        public IMicroserviceDescriptionBuilderDsl And()
        {
            return this;
        }

        public IMicroserviceDescriptionBuilderDsl Responds(string respondMessageTypeName)
        {
            if (string.IsNullOrEmpty(_lastDeclaredMessageName))
                throw new InvalidOperationException("Microservice first has to receive something to respond!");

            return new MicroserviceDescriptionBuilderDsl(
                    _microserviceInfrastructureDsl,
                    _microserviceDescriptionBuilder.RespondsToWith(_lastDeclaredMessageName, respondMessageTypeName),
                    _lastDeclaredMessageName
                );
        }

        public IMicroserviceDescriptionBuilderDsl Microservice(string microserviceName)
        {
            return _microserviceInfrastructureDsl
                    .WithMicroservice(Create())
                    .Microservice(microserviceName);
        }

        private MicroserviceDescription Create()
        {
            return _microserviceDescriptionBuilder.Create();
        }

        public IMicroserviceDescriptionBuilderDsl Like(string microserviceMixin)
        {
            return new MicroserviceDescriptionBuilderDsl(
                    _microserviceInfrastructureDsl,
                    _microserviceDescriptionBuilder.Extends(microserviceMixin),
                    _lastDeclaredMessageName
                );
        }

        public IMicroserviceDescriptionBuilderDsl With(string respondMessageTypeName)
        {
            return Responds(respondMessageTypeName);
        }

        public IMicroserviceDescriptionBuilderDsl Responds()
        {
            if (string.IsNullOrEmpty(_lastDeclaredMessageName))
                throw new InvalidOperationException("Microservice first has to receive something to respond!");
            return this;
        }

        public IDeclareDefaultDsl Default()
        {
            return Flush().Default();
        }

        public IMicroserviceInfrastructureDsl Flush()
        {
            return _microserviceInfrastructureDsl
                    .WithMicroservice(Create());
        }
    }
}
