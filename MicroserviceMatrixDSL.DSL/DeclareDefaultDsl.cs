namespace MicroserviceMatrixDSL.DSL
{
    public class DeclareDefaultDsl
    {
        private readonly MicroserviceInfrastructureDsl _microserviceInfrastructureDesciptionBuilder;

        public DeclareDefaultDsl(MicroserviceInfrastructureDsl microserviceInfrastructureDesciptionBuilder)
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

        public MicroserviceInfrastructureDsl Communication(string defaultCommunicationMean)
        {
            return _microserviceInfrastructureDesciptionBuilder
                .WithDefaultCommunicationMean(defaultCommunicationMean);
        }
    }
}