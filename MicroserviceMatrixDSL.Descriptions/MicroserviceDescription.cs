using System.Collections.Generic;

namespace MicroserviceMatrixDSL.Descriptions
{
    public class MicroserviceDescription
    {
        public MicroserviceDescription(
            string microserviceName,
            string communicationMean,
            string namespaceName,
            IReadOnlyDictionary<string, string> receiveRespondMessages,
            IEnumerable<string> sendingMessages,
            IEnumerable<string> mixins)
        {
            MicroserviceName = microserviceName;
            CommunicationMean = communicationMean;
            Namespace = namespaceName;
            ReceiveRespondMessages = receiveRespondMessages;
            SendingMessages = sendingMessages;
            Mixins = mixins;
        }

        public string CommunicationMean { get; }
        public string MicroserviceName { get; }
        public IEnumerable<string> Mixins { get; }
        public string Namespace { get; }
        public IReadOnlyDictionary<string, string> ReceiveRespondMessages { get; }
        public IEnumerable<string> SendingMessages { get; }
    }
}