using MicroserviceMatrixDSL.Builder;
using MicroserviceMatrixDSL.Builder.Descriptions;
using MicroserviceMatrixDSL.Builder.Interfaces;
using MicroserviceMatrixDSL.DSL.Interfaces;

namespace MicroserviceMatrixDSL.DSL
{
    public class MessageTypeDescriptionBuilderDsl : IMessageTypeDescriptionBuilderDsl
    {
        private readonly IMicroserviceInfrastructureDsl _microserviceInfrastructureBuilder;
        private readonly IMessageTypeDescriptionBuilder _messageTypeDescriptionBuilder;

        public MessageTypeDescriptionBuilderDsl(
            IMicroserviceInfrastructureDsl microserviceInfrastructureBuilder)
        {
            _microserviceInfrastructureBuilder = microserviceInfrastructureBuilder;
             _messageTypeDescriptionBuilder = new MessageTypeDescriptionBuilder()
                .WithNamespace(microserviceInfrastructureBuilder.MessagesDefaultNamespace);
        }

        public MessageTypeDescriptionBuilderDsl(
            IMicroserviceInfrastructureDsl microserviceInfrastructureBuilder, 
            IMessageTypeDescriptionBuilder messageTypeDescriptionBuilder
            )
        {
            _microserviceInfrastructureBuilder = microserviceInfrastructureBuilder;
            _messageTypeDescriptionBuilder = messageTypeDescriptionBuilder;
        }
        
        public IMessageTypeDescriptionBuilderDsl Namespace(string messageTypeNamespace)
        {
            return new MessageTypeDescriptionBuilderDsl(
                    _microserviceInfrastructureBuilder,
                    _messageTypeDescriptionBuilder
                        .WithNamespace(messageTypeNamespace)
                );
        }

        public IMessageTypeDescriptionBuilderDsl Class(string declaredMessageType)
        {
            return new MessageTypeDescriptionBuilderDsl(
                    _microserviceInfrastructureBuilder,
                    _messageTypeDescriptionBuilder
                        .WithTypeName(declaredMessageType)
                );
        }

        public IMessageTypeDescriptionBuilderDsl Message()
        {
            return _microserviceInfrastructureBuilder
                    .WithDeclaredMessage(Create())
                    .Message();
        }

        private MessageTypeDescription Create()
        {
            return _messageTypeDescriptionBuilder.Create();
        }

        public IMessageTypeDescriptionBuilderDsl Using()
        {
            return this;
        }

        public IDeclareDefaultDsl Default()
        {
            return _microserviceInfrastructureBuilder
                   .WithDeclaredMessage(Create())
                   .Default();
        }
    }
}
