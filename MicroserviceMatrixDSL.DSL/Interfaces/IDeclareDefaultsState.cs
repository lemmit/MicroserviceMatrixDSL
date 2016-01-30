namespace MicroserviceMatrixDSL.DSL.Interfaces
{
    public interface IDeclareDefaultsState
    {
        IDeclareNamespaceState Message();
        IBaseState Namespace(string defaultNamespace);
        IBaseState Communication(string defaultCommunicationMean);
    }
}