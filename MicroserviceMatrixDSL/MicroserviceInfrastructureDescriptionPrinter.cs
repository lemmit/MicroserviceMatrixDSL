using System;
using System.Collections.Generic;
using System.Linq;
using MicroserviceMatrixDSL.Builder.Descriptions;
using MicroserviceMatrixDSL.FunctionalToolkit.Extensions;

namespace MicroserviceMatrixDSL
{
    public class MicroserviceInfrastructureDescriptionPrinter
    {
        public void Print(MicroserviceInfrastructureDescription microserviceInfrastructureDescription)
        {
            var mms = microserviceInfrastructureDescription.MessageTypes.ToDictionary(
                elem => elem.DeclaredMessageType,
                elem => elem.MessagesDefaultNamespace
                ).ToVerboseDictionary();

            Console.WriteLine("Declared messages:");
            microserviceInfrastructureDescription.MessageTypes.ForEach(msgType =>
                Console.WriteLine($"{msgType.MessagesDefaultNamespace}." +
                                  $"{msgType.DeclaredMessageType}")
                );

            Console.WriteLine("\nDeclared microservices:");
            microserviceInfrastructureDescription.Microservices.ForEach(mcsDescription =>
            {
                try
                {
                    Func<KeyValuePair<string, string>, string> stringifyDictPair =
                        pair =>
                            $"[{mms[pair.Key]}.{pair.Key}=>"
                            + $"{(!string.IsNullOrEmpty(pair.Value) ? mms[pair.Value] : "")}.{pair.Value}]";
                    Console.WriteLine(
                        $"****"
                        + $"\n{mcsDescription.Namespace}.{mcsDescription.MicroserviceName}"
                        + $"\nCommunication: {mcsDescription.CommunicationMean}"
                        + $"\nMixins: {mcsDescription.Mixins.Stringify()}"
                        + $"\nSends messages: {mcsDescription.SendingMessages.Select(msg => $"{mms[msg]}.{msg}").Stringify()}"
                        + $"\nReq/Resp messages: {mcsDescription.ReceiveRespondMessages.Stringify(stringifyDictPair)}"
                        );
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }
    }
}
