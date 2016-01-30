namespace MicroserviceMatrixDSL.DSL.Interfaces
{
    public interface IDeclareDefaultDsl
    {
        IMessageNamespaceDeclaringDsl Message();
        IMicroserviceInfrastructureDsl Namespace(string defaultNamespace);
        IMicroserviceInfrastructureDsl Communication(string defaultCommunicationMean);
    }
}