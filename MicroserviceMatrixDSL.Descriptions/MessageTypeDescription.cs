
namespace MicroserviceMatrixDSL.Descriptions
{
    public class MessageTypeDescription
    {
        public string DeclaredMessageType { get; }
        public string Namespace { get; }

        public MessageTypeDescription(string declaredMessageType,
            string @namespace)
        {
            DeclaredMessageType = declaredMessageType;
            Namespace = @namespace;
        }
    }
}
