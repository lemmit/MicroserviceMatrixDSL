using System.Collections.Generic;
using System.Linq;
using MicroserviceMatrixDSL.Descriptions;

namespace MicroserviceMatrixDSL.Template
{
    public partial class MicroservicesGenerator
    {
        private readonly MicroserviceInfrastructureDescriptionExtender _infrastructureDescriptionExtender;
        private readonly string _inheritedFrom;

        public MicroservicesGenerator(
            MicroserviceInfrastructureDescriptionExtender infrastructureDescriptionExtender,
            string inhertitedFrom = "BaseMicroservice")
        {
            _inheritedFrom = inhertitedFrom;
            _infrastructureDescriptionExtender = infrastructureDescriptionExtender;
        }

        public IDictionary<string, string> NamespaceByMessageTypeName =>
            _infrastructureDescriptionExtender.NamespaceByMessageTypeName;

        public IEnumerable<MicroserviceDescription> Microservices
            => _infrastructureDescriptionExtender.Microservices;

        public IEnumerable<IGrouping<string, MicroserviceDescription>> MicroservicesByNamespace
            => _infrastructureDescriptionExtender.MicroservicesByNamespace;

        public IDictionary<string, string> ReqResponseMessages(string microserviceName)
        {
            return _infrastructureDescriptionExtender.ReqResponseMessages(microserviceName);
        }

        public IDictionary<string, string> ReqResponseMessagesWithMixins(string microserviceName)
        {
            return _infrastructureDescriptionExtender.ReqResponseMessagesWithMixins(microserviceName);
        }

        public IEnumerable<string> MessagesSendedByMicroserviceWithMixins(string microserviceName)
        {
            return _infrastructureDescriptionExtender.MessagesSendedByMicroserviceWithMixins(microserviceName);
        }


        public string MessageTypeNameWithNamespace(string messageTypeName)
        {
            return _infrastructureDescriptionExtender.MessageTypeNameWithNamespace(messageTypeName);
        }
    }
}