namespace MicroserviceMatrixDSL.DSL.Interfaces
{
    public interface IMessageNamespaceDeclaringDsl
    {
        IMicroserviceInfrastructureDsl Namespace(string defaultMessageNamespace);
    }
}