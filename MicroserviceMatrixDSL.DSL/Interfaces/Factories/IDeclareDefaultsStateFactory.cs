namespace MicroserviceMatrixDSL.DSL.Interfaces.Factories
{
    public interface IDeclareDefaultsStateFactory
    {
        IDeclareDefaultsState CreateDefaultsState(IBaseState baseState);
    }
}