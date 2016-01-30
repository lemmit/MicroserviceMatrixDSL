namespace MicroserviceMatrixDSL.DSL.Interfaces.Factories
{
    public interface IStatesFactory
        : IBaseStateFactory,
            IDeclareDefaultsStateFactory,
            IDeclareNamespaceStateFactory,
            IMessageTypeDescribingStateFactory,
            IMicroserviceDescribingStateFactory
    {
    }
}