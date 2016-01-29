using System.Collections.Generic;
using System.Linq;

namespace MicroserviceMatrixDSL.Builder.Descriptions
{
    public class MicroserviceInfrastructureDescription
    {
        public IEnumerable<MessageTypeDescription> MessageTypes { get; }
        public IEnumerable<MicroserviceDescription> Microservices { get; }

        public MicroserviceInfrastructureDescription(
            IEnumerable<MessageTypeDescription> messageTypesDescriptions,
            IEnumerable<MicroserviceDescription> microservicesDescriptions
            )
        {
            MessageTypes = messageTypesDescriptions.ToList();
            Microservices = microservicesDescriptions.ToList();
        }
    }
}
