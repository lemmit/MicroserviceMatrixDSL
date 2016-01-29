using MicroserviceMatrixDSL.Builder;
using MicroserviceMatrixDSL.Builder.Descriptions;
using MicroserviceMatrixDSL.Builder.Interfaces;

namespace MicroserviceMatrixDSL.DSL
{
    public class MessageTypeDescriptionBuilderDsl
    {
        private readonly MicroserviceInfrastructureDsl _microserviceInfrastructureBuilder;
        private readonly IMessageTypeDescriptionBuilder _messageTypeDescriptionBuilder;

        public MessageTypeDescriptionBuilderDsl(
            MicroserviceInfrastructureDsl microserviceInfrastructureBuilder)
        {
            _microserviceInfrastructureBuilder = microserviceInfrastructureBuilder;
             _messageTypeDescriptionBuilder = new MessageTypeDescriptionBuilder()
                .WithNamespace(microserviceInfrastructureBuilder.MessagesDefaultNamespace);
        }

        public MessageTypeDescriptionBuilderDsl(
            MicroserviceInfrastructureDsl microserviceInfrastructureBuilder, 
            IMessageTypeDescriptionBuilder messageTypeDescriptionBuilder
            )
        {
            _microserviceInfrastructureBuilder = microserviceInfrastructureBuilder;
            _messageTypeDescriptionBuilder = messageTypeDescriptionBuilder;
        }
        
        public MessageTypeDescriptionBuilderDsl Namespace(string messageTypeNamespace)
        {
            return new MessageTypeDescriptionBuilderDsl(
                    _microserviceInfrastructureBuilder,
                    _messageTypeDescriptionBuilder
                        .WithNamespace(messageTypeNamespace)
                );
        }

        public MessageTypeDescriptionBuilderDsl Class(string declaredMessageType)
        {
            return new MessageTypeDescriptionBuilderDsl(
                    _microserviceInfrastructureBuilder,
                    _messageTypeDescriptionBuilder
                        .WithTypeName(declaredMessageType)
                );
        }

        public MessageTypeDescriptionBuilderDsl Message()
        {
            return _microserviceInfrastructureBuilder
                    .WithDeclaredMessage(Create())
                    .Message();
        }

        private MessageTypeDescription Create()
        {
            return _messageTypeDescriptionBuilder.Create();
        }

        public MessageTypeDescriptionBuilderDsl Using()
        {
            return this;
        }

        public DeclareDefaultDsl Default()
        {
            return _microserviceInfrastructureBuilder
                   .WithDeclaredMessage(Create())
                   .Default();
        }
    }
}
