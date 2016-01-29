using System.Collections.Generic;

namespace MicroserviceMatrixDSL.Builder.Descriptions
{
    public class MicroserviceDescription
    {
        public string CommunicationMean { get; }
        public string MicroserviceName { get; }
        public IEnumerable<string> Mixins { get; }
        public string Namespace { get; }
        public IReadOnlyDictionary<string, string> ReceiveRespondMessages { get; }
        public IEnumerable<string> SendingMessages { get; }

        public MicroserviceDescription(string microserviceName, string communicationMean, string namespaceName,
            IReadOnlyDictionary<string, string> _receiveRespondMessages, IEnumerable<string> sendingMessages,
            IEnumerable<string> _mixins)
        {
            this.MicroserviceName = microserviceName;
            this.CommunicationMean = communicationMean;
            this.Namespace = namespaceName;
            this.ReceiveRespondMessages = _receiveRespondMessages;
            this.SendingMessages = sendingMessages;
            this.Mixins = _mixins;
        }
    }
}