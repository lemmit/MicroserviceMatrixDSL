using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MicroserviceMatrixDSL.Builder.Descriptions;
using MicroserviceMatrixDSL.FunctionalToolkit.Extensions;

namespace MicroserviceMatrixDSL.Template
{
    public partial class MicroservicesGenerator
    {
        private readonly MicroserviceInfrastructureDescription _infrastructureDescription;
        private readonly string _inheritedFrom;
        public MicroservicesGenerator(
            MicroserviceInfrastructureDescription infrastructureDescription,
            string inhertitedFrom = "BaseMicroservice")
        {
            _inheritedFrom = inhertitedFrom;
            _infrastructureDescription = infrastructureDescription;
        }

        public IDictionary<string, string> ReqResponseMessages(string microserviceName)
        {
            var msvc = Microservices.Single(ms => ms.MicroserviceName == microserviceName);
            return msvc.ReceiveRespondMessages.ToDefaultableDictionary("object");
        }

        public IDictionary<string, string> ReqResponseMessagesWithMixins(string microserviceName)
        {
            var msvc = Microservices.Single(ms => ms.MicroserviceName == microserviceName);
            var mixins = Microservices.Where(ms => msvc.Mixins.Contains(ms.MicroserviceName))
                        .SelectMany(ms => ReqResponseMessages(ms.MicroserviceName));
            var allmsgs = mixins
                    .AndThen(msvc.ReceiveRespondMessages)
                    .Distinct()
                    .ToDictionary()
                    .ToDefaultableDictionary("object");
            return allmsgs;
        }

        public IEnumerable<string> MessagesSendedByMicroserviceWithMixins(string microserviceName)
        {
            var msvc = Microservices.Single(ms => ms.MicroserviceName == microserviceName);
            return Microservices.Where(ms => msvc.Mixins.Contains(ms.MicroserviceName))
                        .SelectMany(ms => ms.SendingMessages).Distinct();
        }

        public IDictionary<string, string> NamespaceByMessageTypeName =>
                _infrastructureDescription.MessageTypes.ToDictionary(
                    elem => elem.DeclaredMessageType,
                    elem => elem.Namespace
                ).ToVerboseDictionary();

        public IEnumerable<MicroserviceDescription> Microservices
            => _infrastructureDescription.Microservices;

        public IEnumerable<IGrouping<string, MicroserviceDescription>> MicroservicesByNamespace 
            => Microservices.GroupBy(microservice => microservice.Namespace);

        
        public string MessageTypeNameWithNamespace(string messageTypeName)
        {
            string @namespace;
            var gotit = _infrastructureDescription.MessageTypes.ToDictionary(
                elem => elem.DeclaredMessageType,
                elem => elem.Namespace
                ).TryGetValue(messageTypeName, out @namespace);

            return gotit ? $"{@namespace}.{messageTypeName}" : messageTypeName;
        }
    }
}
