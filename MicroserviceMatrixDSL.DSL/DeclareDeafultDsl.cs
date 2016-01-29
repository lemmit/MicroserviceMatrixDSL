namespace MicroserviceMatrixDSL.DSL
{
    public class DeclareDeafultDsl
    {
        private readonly MicroserviceInfrastructureDsl _microserviceInfrastructureDesciptionBuilder;

        public DeclareDeafultDsl(MicroserviceInfrastructureDsl microserviceInfrastructureDesciptionBuilder)
        {
            _microserviceInfrastructureDesciptionBuilder = microserviceInfrastructureDesciptionBuilder;
        }

        public MessageNamespaceDeclaringDsl Message()
        {
            return new MessageNamespaceDeclaringDsl(_microserviceInfrastructureDesciptionBuilder);
        }

        public MicroserviceInfrastructureDsl Namespace(string defaultNamespace)
        {
            return _microserviceInfrastructureDesciptionBuilder
                .WithDefaultMicroserviceNamespace(defaultNamespace);
        }

        public MicroserviceInfrastructureDsl Communication(string communicationMean)
        {
            return _microserviceInfrastructureDesciptionBuilder
                .WithDefaultCommunicationMean(communicationMean);
        }
    }
}