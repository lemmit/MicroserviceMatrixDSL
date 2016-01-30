using System.Collections.Generic;
using System.Linq;
using MicroserviceMatrixDSL.Builder.Interfaces;
using MicroserviceMatrixDSL.Descriptions;
using MicroserviceMatrixDSL.FunctionalToolkit.Extensions;

namespace MicroserviceMatrixDSL.Builder
{
    public class MicroserviceDescriptionBuilder : IMicroserviceDescriptionBuilder
    {
        private readonly string _communicationMean;
        private readonly string _microserviceName;

        private readonly IEnumerable<string> _mixins =
            new HashSet<string>();

        private readonly string _namespace;

        private readonly IReadOnlyDictionary<string, string> _receiveRespondMessages =
            new Dictionary<string, string>();

        private readonly IEnumerable<string> _sendsMessages =
            new List<string>();

        public MicroserviceDescriptionBuilder(
            string microserviceName,
            string communicationMean,
            string namespaceName
            )
        {
            _microserviceName = microserviceName;
            _communicationMean = communicationMean;
            _namespace = namespaceName;
        }

        public MicroserviceDescriptionBuilder(
            string microserviceName,
            string communicationMean,
            string namespaceName,
            IReadOnlyDictionary<string, string> receiveRespondMessagesPairs,
            IEnumerable<string> sendsMessagesTypeNames,
            IEnumerable<string> inheritedMixins
            )
        {
            _microserviceName = microserviceName;
            _communicationMean = communicationMean;
            _namespace = namespaceName;
            _receiveRespondMessages = receiveRespondMessagesPairs
                .ToDictionary();
            _sendsMessages = sendsMessagesTypeNames.ToList();
            _mixins = inheritedMixins.ToList();
        }

        public MicroserviceDescription Create()
        {
            return new MicroserviceDescription(
                _microserviceName,
                _communicationMean,
                _namespace,
                _receiveRespondMessages,
                _sendsMessages,
                _mixins
                );
        }

        public IMicroserviceDescriptionBuilder WithCommunicationMean(string communicationMean)
        {
            return new MicroserviceDescriptionBuilder(
                _microserviceName,
                communicationMean,
                _namespace,
                _receiveRespondMessages,
                _sendsMessages,
                _mixins
                );
        }

        public IMicroserviceDescriptionBuilder RespondsToWith(string requestMessageTypeName,
            string responseMessageTypeName)
        {
            var dict = _receiveRespondMessages
                .ToDictionary();
            dict[requestMessageTypeName] = responseMessageTypeName;
            return new MicroserviceDescriptionBuilder(
                _microserviceName,
                _communicationMean,
                _namespace,
                dict,
                _sendsMessages,
                _mixins
                );
        }

        public IMicroserviceDescriptionBuilder RespondsTo(string requestMessageTypeName)
        {
            var dict = _receiveRespondMessages
                .ToDictionary();
            dict[requestMessageTypeName] = string.Empty;

            return new MicroserviceDescriptionBuilder(
                _microserviceName,
                _communicationMean,
                _namespace,
                dict,
                _sendsMessages,
                _mixins
                );
        }

        public IMicroserviceDescriptionBuilder Extends(string microserviceMixinName)
        {
            return new MicroserviceDescriptionBuilder(
                _microserviceName,
                _communicationMean,
                _namespace,
                _receiveRespondMessages,
                _sendsMessages,
                _mixins.AndThen(microserviceMixinName)
                );
        }

        public IMicroserviceDescriptionBuilder Sends(string messageTypeName)
        {
            return new MicroserviceDescriptionBuilder(
                _microserviceName,
                _communicationMean,
                _namespace,
                _receiveRespondMessages,
                _sendsMessages.AndThen(messageTypeName),
                _mixins
                );
        }

        public IMicroserviceDescriptionBuilder WithinNamespace(string namespaceName)
        {
            return new MicroserviceDescriptionBuilder(
                _microserviceName,
                _communicationMean,
                _namespace,
                _receiveRespondMessages,
                _sendsMessages,
                _mixins
                );
        }
    }
}