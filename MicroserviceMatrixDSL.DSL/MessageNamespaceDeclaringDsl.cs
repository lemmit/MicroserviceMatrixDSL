using System;
using MicroserviceMatrixDSL.DSL.Interfaces;

namespace MicroserviceMatrixDSL.DSL
{
    public class MessageNamespaceDeclaringDsl : IMessageNamespaceDeclaringDsl
    {
        private readonly IMicroserviceInfrastructureDsl _microserviceInfrastructureDesciptionBuilder;

        public MessageNamespaceDeclaringDsl(IMicroserviceInfrastructureDsl microserviceInfrastructureDesciptionBuilder)
        {
            _microserviceInfrastructureDesciptionBuilder = microserviceInfrastructureDesciptionBuilder;
        }

        public IMicroserviceInfrastructureDsl Namespace(string defaultMessageNamespace)
        {
            return _microserviceInfrastructureDesciptionBuilder.WithDefaultMessageNamespace(defaultMessageNamespace);
        }
    }
}