using System;
using MicroserviceMatrixDSL.Builder;
using MicroserviceMatrixDSL.Builder.Interfaces;
using MicroserviceMatrixDSL.Descriptions;
using MicroserviceMatrixDSL.DSL.Interfaces;

namespace MicroserviceMatrixDSL.DSL.DslStates
{
    public class MicroserviceDescribingState : IMicroserviceDescribingState
    {
        private readonly IBaseState _baseState;
        private readonly string _lastDeclaredMessageName = "";
        private readonly IMicroserviceDescriptionBuilder _microserviceDescriptionBuilder;

        public MicroserviceDescribingState(
            string microserviceName,
            string defaultCommunicationMean,
            string defaultMicroserviceNamespace,
            IBaseState baseState
            )
        {
            _baseState = baseState;
            _microserviceDescriptionBuilder =
                new MicroserviceDescriptionBuilder(
                    microserviceName,
                    defaultCommunicationMean,
                    defaultMicroserviceNamespace
                    );
        }

        private MicroserviceDescribingState(
            IBaseState baseState,
            IMicroserviceDescriptionBuilder microserviceDescriptionBuilder,
            string lastAddedMessageTypeName
            )
        {
            _baseState = baseState;
            _microserviceDescriptionBuilder = microserviceDescriptionBuilder;
            _lastDeclaredMessageName = lastAddedMessageTypeName;
        }


        public IMicroserviceDescribingState Using(string communicationMean)
        {
            return new MicroserviceDescribingState(
                _baseState,
                _microserviceDescriptionBuilder.WithCommunicationMean(communicationMean),
                _lastDeclaredMessageName
                );
        }

        public IMicroserviceDescribingState Sends(string sendsMessageTypeName)
        {
            return new MicroserviceDescribingState(
                _baseState,
                _microserviceDescriptionBuilder.Sends(sendsMessageTypeName),
                _lastDeclaredMessageName
                );
        }

        public IMicroserviceDescribingState Receives(string receiveMessageTypeName)
        {
            return new MicroserviceDescribingState(
                _baseState,
                _microserviceDescriptionBuilder.RespondsTo(receiveMessageTypeName),
                receiveMessageTypeName
                );
        }

        public IMicroserviceDescribingState And()
        {
            return this;
        }

        public IMicroserviceDescribingState Responds(string respondMessageTypeName)
        {
            if (string.IsNullOrEmpty(_lastDeclaredMessageName))
                throw new InvalidOperationException("Microservice first has to receive something to respond!");

            return new MicroserviceDescribingState(
                _baseState,
                _microserviceDescriptionBuilder.RespondsToWith(_lastDeclaredMessageName, respondMessageTypeName),
                _lastDeclaredMessageName
                );
        }

        public IMicroserviceDescribingState Microservice(string microserviceName)
        {
            return _baseState
                .WithMicroservice(Create())
                .Microservice(microserviceName);
        }

        public IMicroserviceDescribingState Like(string microserviceMixin)
        {
            return new MicroserviceDescribingState(
                _baseState,
                _microserviceDescriptionBuilder.Extends(microserviceMixin),
                _lastDeclaredMessageName
                );
        }

        public IMicroserviceDescribingState With(string respondMessageTypeName)
        {
            return Responds(respondMessageTypeName);
        }

        public IMicroserviceDescribingState Responds()
        {
            if (string.IsNullOrEmpty(_lastDeclaredMessageName))
                throw new InvalidOperationException("Microservice first has to receive something to respond!");
            return this;
        }

        public IDeclareDefaultsState Default()
        {
            return Flush().Default();
        }

        public IBaseState Flush()
        {
            return _baseState
                .WithMicroservice(Create());
        }

        private MicroserviceDescription Create()
        {
            return _microserviceDescriptionBuilder.Create();
        }
    }
}