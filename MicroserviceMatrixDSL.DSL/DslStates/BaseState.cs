using MicroserviceMatrixDSL.Builder;
using MicroserviceMatrixDSL.Builder.Interfaces;
using MicroserviceMatrixDSL.Descriptions;
using MicroserviceMatrixDSL.DSL.Interfaces;
using MicroserviceMatrixDSL.DSL.Interfaces.Factories;

namespace MicroserviceMatrixDSL.DSL.DslStates
{
    public class BaseState : IBaseState
    {
        private readonly IInfrastructureDesciptionBuilder _infrastractureDescriptionBuilder;
        private readonly IStatesFactory _statesFactory;

        public BaseState(
            IInfrastructureDesciptionBuilder infrastructureDesciptionBuilder,
            IStatesFactory statesFactory
            )
        {
            _infrastractureDescriptionBuilder = infrastructureDesciptionBuilder;
            _statesFactory = statesFactory;
        }

        public BaseState(
            string messageDefaultNamespace,
            string microserviceDefaultNamespace,
            string defaultCommunicationMean,
            IStatesFactory statesFactory
            )
        {
            _infrastractureDescriptionBuilder =
                new InfrastructureDesciptionBuilder(
                    messageDefaultNamespace,
                    microserviceDefaultNamespace,
                    defaultCommunicationMean
                    );
            _statesFactory = statesFactory;
        }

        public string MessagesDefaultNamespace
            => _infrastractureDescriptionBuilder.MessagesDefaultNamespace;

        public string MicroserviceDefaultNamespace
            => _infrastractureDescriptionBuilder.MicroserviceDefaultNamespace;

        public string DefaultCommunicationMean
            => _infrastractureDescriptionBuilder.DefaultCommunicationMean;

        public IDeclareDefaultsState Default()
        {
            return _statesFactory.CreateDefaultsState(this);
        }

        public IBaseState Using()
        {
            return this;
        }

        public IMessageTypeDescribingState Message()
        {
            return _statesFactory.CreateMessageTypeDescribingState(this);
        }

        public IMicroserviceDescribingState Microservice(string microserviceName)
        {
            return new MicroserviceDescribingState(
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

        public IBaseState WithDefaultMessageNamespace(string messagesDefaultNamespace)
        {
            return new BaseState(
                _infrastractureDescriptionBuilder
                    .WithDefaultMessageNamespace(messagesDefaultNamespace),
                _statesFactory
                );
        }

        public IBaseState WithDefaultCommunicationMean(string communicationMean)
        {
            return new BaseState(
                _infrastractureDescriptionBuilder
                    .WithDefaultCommunicationMean(communicationMean),
                _statesFactory
                );
        }

        public IBaseState WithDefaultMicroserviceNamespace(string microserviceDefaultNamespace)
        {
            return new BaseState(
                _infrastractureDescriptionBuilder
                    .WithDefaultMicroserviceNamespace(microserviceDefaultNamespace),
                _statesFactory
                );
        }

        public IBaseState WithDeclaredMessage(MessageTypeDescription messageTypeDescription)
        {
            return new BaseState(
                _infrastractureDescriptionBuilder
                    .WithDeclaredMessage(messageTypeDescription),
                _statesFactory
                );
        }

        public IBaseState WithMicroservice(MicroserviceDescription microserviceDescription)
        {
            return new BaseState(
                _infrastractureDescriptionBuilder
                    .WithMicroservice(microserviceDescription),
                _statesFactory
                );
        }
    }
}