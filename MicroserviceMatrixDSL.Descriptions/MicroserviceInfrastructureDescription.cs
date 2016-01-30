using System.Collections.Generic;
using System.Linq;

namespace MicroserviceMatrixDSL.Descriptions
{
    public class MicroserviceInfrastructureDescription
    {
        public MicroserviceInfrastructureDescription(
            IEnumerable<MessageTypeDescription> messageTypesDescriptions,
            IEnumerable<MicroserviceDescription> microservicesDescriptions
            )
        {
            MessageTypes = messageTypesDescriptions.ToList();
            Microservices = microservicesDescriptions.ToList();
        }

        public IEnumerable<MessageTypeDescription> MessageTypes { get; }
        public IEnumerable<MicroserviceDescription> Microservices { get; }
    }
}