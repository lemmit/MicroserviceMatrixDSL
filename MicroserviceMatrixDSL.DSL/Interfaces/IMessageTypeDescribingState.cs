namespace MicroserviceMatrixDSL.DSL.Interfaces
{
    public interface IMessageTypeDescribingState
    {
        IMessageTypeDescribingState Namespace(string messageTypeNamespace);
        IMessageTypeDescribingState Class(string declaredMessageType);
        IMessageTypeDescribingState Message();
        IMessageTypeDescribingState Using();
        IDeclareDefaultsState Default();
    }
}