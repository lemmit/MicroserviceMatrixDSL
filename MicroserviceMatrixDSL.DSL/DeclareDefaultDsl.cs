using MicroserviceMatrixDSL.DSL.Interfaces;

namespace MicroserviceMatrixDSL.DSL
{
    public class DeclareDefaultDsl : IDeclareDefaultDsl
    {
        private readonly IMicroserviceInfrastructureDsl _microserviceInfrastructureDesciptionBuilder;

        public DeclareDefaultDsl(IMicroserviceInfrastructureDsl microserviceInfrastructureDesciptionBuilder)
        {
            _microserviceInfrastructureDesciptionBuilder = microserviceInfrastructureDesciptionBuilder;
        }

        public IMessageNamespaceDeclaringDsl Message()
        {
            return new MessageNamespaceDeclaringDsl(_microserviceInfrastructureDesciptionBuilder);
        }

        public IMicroserviceInfrastructureDsl Namespace(string defaultNamespace)
        {
            return _microserviceInfrastructureDesciptionBuilder
                .WithDefaultMicroserviceNamespace(defaultNamespace);
        }

        public IMicroserviceInfrastructureDsl Communication(string defaultCommunicationMean)
        {
            return _microserviceInfrastructureDesciptionBuilder
                .WithDefaultCommunicationMean(defaultCommunicationMean);
        }
    }
}