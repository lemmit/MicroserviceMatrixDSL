using MicroserviceMatrixDSL.Builder.Descriptions;

namespace MicroserviceMatrixDSL.Builder.Interfaces
{
    public interface IMessageTypeDescriptionBuilder
    {
        MessageTypeDescription Create();
        IMessageTypeDescriptionBuilder WithTypeName(string declaredMessageType);
        IMessageTypeDescriptionBuilder WithNamespace(string messageTypeNamespace);
    }
}