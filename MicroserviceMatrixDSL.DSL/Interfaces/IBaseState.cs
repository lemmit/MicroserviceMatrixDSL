using MicroserviceMatrixDSL.Descriptions;

namespace MicroserviceMatrixDSL.DSL.Interfaces
{
    public interface IBaseState
    {
        string MessagesDefaultNamespace { get; }
        string MicroserviceDefaultNamespace { get; }
        string DefaultCommunicationMean { get; }
        MicroserviceInfrastructureDescription Create();

        IDeclareDefaultsState Default();
        IBaseState Using();
        IMessageTypeDescribingState Message();
        IMicroserviceDescribingState Microservice(string microserviceName);
        IBaseState WithDefaultMessageNamespace(string messagesDefaultNamespace);
        IBaseState WithDefaultCommunicationMean(string communicationMean);
        IBaseState WithDefaultMicroserviceNamespace(string microserviceDefaultNamespace);
        IBaseState WithDeclaredMessage(MessageTypeDescription messageTypeDescription);
        IBaseState WithMicroservice(MicroserviceDescription microserviceDescription);
    }
}