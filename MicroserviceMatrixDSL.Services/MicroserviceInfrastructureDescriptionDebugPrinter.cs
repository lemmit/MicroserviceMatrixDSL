using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MicroserviceMatrixDSL.Descriptions;
using MicroserviceMatrixDSL.FunctionalToolkit.Extensions;

namespace MicroserviceMatrixDSL.Services
{
    public class MicroserviceInfrastructureDescriptionDebugPrinter : IMicroserviceInfrastructureDescriptionPrinter
    {
        public string Print(MicroserviceInfrastructureDescription microserviceInfrastructureDescription)
        {
            var mms = microserviceInfrastructureDescription.MessageTypes.ToDictionary(
                elem => elem.DeclaredMessageType,
                elem => elem.Namespace
                ).ToVerboseDictionary();
            var sb = new StringBuilder();
            sb.AppendLine("Declared messages:");
            microserviceInfrastructureDescription.MessageTypes.ForEach(msgType =>
                sb.AppendLine($"{msgType.Namespace}." +
                              $"{msgType.DeclaredMessageType}")
                );

            sb.AppendLine("\nDeclared microservices:");
            microserviceInfrastructureDescription.Microservices.ForEach(mcsDescription =>
            {
                try
                {
                    Func<KeyValuePair<string, string>, string> stringifyDictPair =
                        pair =>
                            $"[{mms[pair.Key]}.{pair.Key}=>"
                            + $"{(!string.IsNullOrEmpty(pair.Value) ? mms[pair.Value] : "")}.{pair.Value}]";
                    sb.AppendLine(
                        $"****"
                        + $"\n{mcsDescription.Namespace}.{mcsDescription.MicroserviceName}"
                        + $"\nCommunication: {mcsDescription.CommunicationMean}"
                        + $"\nMixins: {mcsDescription.Mixins.Stringify()}"
                        +
                        $"\nSends messages: {mcsDescription.SendingMessages.Select(msg => $"{mms[msg]}.{msg}").Stringify()}"
                        + $"\nReq/Resp messages: {mcsDescription.ReceiveRespondMessages.Stringify(stringifyDictPair)}"
                        );
                }
                catch (Exception e)
                {
                    sb.AppendLine(e.ToString());
                }
            });
            return sb.ToString();
        }
    }
}