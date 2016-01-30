using MicroserviceMatrixDSL.Builder;
using MicroserviceMatrixDSL.Builder.Interfaces;
using MicroserviceMatrixDSL.Descriptions;
using MicroserviceMatrixDSL.DSL.Interfaces;

namespace MicroserviceMatrixDSL.DSL.DslStates
{
    public class MessageTypeDescribingState : IMessageTypeDescribingState
    {
        private readonly IBaseState _baseState;
        private readonly IMessageTypeDescriptionBuilder _messageTypeDescriptionBuilder;

        public MessageTypeDescribingState(
            IBaseState baseState)
        {
            _baseState = baseState;
            _messageTypeDescriptionBuilder = new MessageTypeDescriptionBuilder()
                .WithNamespace(baseState.MessagesDefaultNamespace);
        }

        public MessageTypeDescribingState(
            IBaseState baseState,
            IMessageTypeDescriptionBuilder messageTypeDescriptionBuilder
            )
        {
            _baseState = baseState;
            _messageTypeDescriptionBuilder = messageTypeDescriptionBuilder;
        }

        public IMessageTypeDescribingState Namespace(string messageTypeNamespace)
        {
            return new MessageTypeDescribingState(
                _baseState,
                _messageTypeDescriptionBuilder
                    .WithNamespace(messageTypeNamespace)
                );
        }

        public IMessageTypeDescribingState Class(string declaredMessageType)
        {
            return new MessageTypeDescribingState(
                _baseState,
                _messageTypeDescriptionBuilder
                    .WithTypeName(declaredMessageType)
                );
        }

        public IMessageTypeDescribingState Message()
        {
            return _baseState
                .WithDeclaredMessage(Create())
                .Message();
        }

        public IMessageTypeDescribingState Using()
        {
            return this;
        }

        public IDeclareDefaultsState Default()
        {
            return _baseState
                .WithDeclaredMessage(Create())
                .Default();
        }

        private MessageTypeDescription Create()
        {
            return _messageTypeDescriptionBuilder.Create();
        }
    }
}