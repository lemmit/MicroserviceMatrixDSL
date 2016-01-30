namespace MicroserviceMatrixDSL.Descriptions
{
    public class MessageTypeDescription
    {
        public MessageTypeDescription(string declaredMessageType,
            string @namespace)
        {
            DeclaredMessageType = declaredMessageType;
            Namespace = @namespace;
        }

        public string DeclaredMessageType { get; }
        public string Namespace { get; }
    }
}