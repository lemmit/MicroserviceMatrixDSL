namespace MicroserviceMatrixDSL.DSL
{
    public class MessageNamespaceDeclaringDsl
    {
        private readonly MicroserviceInfrastructureDsl _microserviceInfrastructureDesciptionBuilder;

        public MessageNamespaceDeclaringDsl(MicroserviceInfrastructureDsl microserviceInfrastructureDesciptionBuilder)
        {
            _microserviceInfrastructureDesciptionBuilder = microserviceInfrastructureDesciptionBuilder;
        }

        public MicroserviceInfrastructureDsl Namespace(string defaultMessageNamespace)
        {
            return _microserviceInfrastructureDesciptionBuilder.WithDefaultMessageNamespace(defaultMessageNamespace);
        }

    }
}