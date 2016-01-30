namespace MicroserviceMatrixDSL.DSL.Interfaces
{
    public interface IMessageTypeDescriptionBuilderDsl
    {
        IMessageTypeDescriptionBuilderDsl Namespace(string messageTypeNamespace);
        IMessageTypeDescriptionBuilderDsl Class(string declaredMessageType);
        IMessageTypeDescriptionBuilderDsl Message();
        IMessageTypeDescriptionBuilderDsl Using();
        IDeclareDefaultDsl Default();
    }
}