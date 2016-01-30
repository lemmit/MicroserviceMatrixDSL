using System.Collections.Generic;

namespace MicroserviceMatrixDSL.Descriptions
{
    public class MicroserviceDescription
    {
        public string CommunicationMean { get; }
        public string MicroserviceName { get; }
        public IEnumerable<string> Mixins { get; }
        public string Namespace { get; }
        public IReadOnlyDictionary<string, string> ReceiveRespondMessages { get; }
        public IEnumerable<string> SendingMessages { get; }

        public MicroserviceDescription(
            string microserviceName,
            string communicationMean,
            string namespaceName,
            IReadOnlyDictionary<string, string> receiveRespondMessages, 
            IEnumerable<string> sendingMessages,
            IEnumerable<string> mixins)
        {
            this.MicroserviceName = microserviceName;
            this.CommunicationMean = communicationMean;
            this.Namespace = namespaceName;
            this.ReceiveRespondMessages = receiveRespondMessages;
            this.SendingMessages = sendingMessages;
            this.Mixins = mixins;
        }
    }
}