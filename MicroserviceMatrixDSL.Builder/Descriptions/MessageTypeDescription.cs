
namespace MicroserviceMatrixDSL.Builder.Descriptions
{
    public class MessageTypeDescription
    {
        public string DeclaredMessageType { get; }
        public string MessagesDefaultNamespace { get; }

        public MessageTypeDescription(string declaredMessageType,
            string messagesDefaultNamespace)
        {
            DeclaredMessageType = declaredMessageType;
            MessagesDefaultNamespace = messagesDefaultNamespace;
        }
    }
}
