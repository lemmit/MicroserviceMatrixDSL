using MicroserviceMatrixDSL.Builder.Descriptions;

namespace MicroserviceMatrixDSL.DSL.Interfaces
{
    public interface IMicroserviceInfrastructureDsl
    {
        string MessagesDefaultNamespace { get; }
        string MicroserviceDefaultNamespace { get; }
        string DefaultCommunicationMean { get; }
        MicroserviceInfrastructureDescription Create();

        IDeclareDefaultDsl Default();
        IMicroserviceInfrastructureDsl Using();
        IMessageTypeDescriptionBuilderDsl Message();
        IMicroserviceDescriptionBuilderDsl Microservice(string microserviceName);
        IMicroserviceInfrastructureDsl WithDefaultMessageNamespace(string messagesDefaultNamespace);
        IMicroserviceInfrastructureDsl WithDefaultCommunicationMean(string communicationMean);
        IMicroserviceInfrastructureDsl WithDefaultMicroserviceNamespace(string microserviceDefaultNamespace);
        IMicroserviceInfrastructureDsl WithDeclaredMessage(MessageTypeDescription messageTypeDescription);
        IMicroserviceInfrastructureDsl WithMicroservice(MicroserviceDescription microserviceDescription);
    }
}