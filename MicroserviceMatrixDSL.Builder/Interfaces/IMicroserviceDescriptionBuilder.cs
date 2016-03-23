using MicroserviceMatrixDSL.Descriptions;

namespace MicroserviceMatrixDSL.Builder.Interfaces
{
    public interface IMicroserviceDescriptionBuilder
    {
        MicroserviceDescription Create();
        IMicroserviceDescriptionBuilder WithCommunicationMean(string communicationMean);
        IMicroserviceDescriptionBuilder WithinNamespace(string namespaceName);
        IMicroserviceDescriptionBuilder RespondsToWith(string requestMessageTypeName, string responseMessageTypeName);
        IMicroserviceDescriptionBuilder RespondsTo(string requestMessageTypeName);
        IMicroserviceDescriptionBuilder Extends(string microserviceMixinName);
        IMicroserviceDescriptionBuilder Sends(string messageTypeName);
        IMicroserviceDescriptionBuilder WithName(string name);
    }
}