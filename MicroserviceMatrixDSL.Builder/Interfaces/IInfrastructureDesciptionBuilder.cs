using MicroserviceMatrixDSL.Builder.Descriptions;

namespace MicroserviceMatrixDSL.Builder.Interfaces
{
    public interface IInfrastructureDesciptionBuilder
    {
        string MessagesDefaultNamespace { get; }
        string MicroserviceDefaultNamespace { get; }
        string DefaultCommunicationMean { get; }

        MicroserviceInfrastructureDescription Create();
        IInfrastructureDesciptionBuilder WithDefaultMessageNamespace(string messagesDefaultNamespace);
        IInfrastructureDesciptionBuilder WithDefaultCommunicationMean(string communicationMean);
        IInfrastructureDesciptionBuilder WithDefaultMicroserviceNamespace(string microserviceDefaultNamespace);
        IInfrastructureDesciptionBuilder WithDeclaredMessage(MessageTypeDescription messageTypeDescription);
        IInfrastructureDesciptionBuilder WithMicroservice(MicroserviceDescription microserviceDescription);
    }
}