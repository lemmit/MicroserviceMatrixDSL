namespace MicroserviceMatrixDSL.DSL.Interfaces.Factories
{
    public interface IMessageTypeDescribingStateFactory
    {
        IMessageTypeDescribingState CreateMessageTypeDescribingState(IBaseState baseState);
    }
}