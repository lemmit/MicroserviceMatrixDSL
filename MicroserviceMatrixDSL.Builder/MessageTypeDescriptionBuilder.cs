using MicroserviceMatrixDSL.Builder.Descriptions;
using MicroserviceMatrixDSL.Builder.Interfaces;

namespace MicroserviceMatrixDSL.Builder
{
    public class MessageTypeDescriptionBuilder : IMessageTypeDescriptionBuilder
    {
        private readonly string _declaredMessageTypeName;
        private readonly string _declaredMessageTypeNamespace;

        public MessageTypeDescriptionBuilder()
        {
        }

        public MessageTypeDescriptionBuilder(
            string messageTypeName,
            string messageTypeNamespace
            )
        {
            _declaredMessageTypeName = messageTypeName;
            _declaredMessageTypeNamespace = messageTypeNamespace;
        }

        public MessageTypeDescription Create()
        {
            return new MessageTypeDescription(
                _declaredMessageTypeName,
                _declaredMessageTypeNamespace);
        }

        public IMessageTypeDescriptionBuilder WithTypeName(string declaredMessageType)
        {
            return new MessageTypeDescriptionBuilder(
                    declaredMessageType,
                    _declaredMessageTypeNamespace
                );
        }

        public IMessageTypeDescriptionBuilder WithNamespace(string messageTypeNamespace)
        {
            return new MessageTypeDescriptionBuilder(
                    _declaredMessageTypeName,
                    messageTypeNamespace
                );
        } 
    }
}