namespace MicroserviceMatrixDSL.DSL.Interfaces.Factories
{
    public interface IDeclareNamespaceStateFactory
    {
        IDeclareNamespaceState CreateDeclareNamespaceState(IBaseState baseState);
    }
}