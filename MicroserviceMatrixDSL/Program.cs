using System;
using System.IO;
using System.Linq;
using CSScriptLibrary;
using MicroserviceMatrixDSL.Builder.Descriptions;
using MicroserviceMatrixDSL.DSL;
using MicroserviceMatrixDSL.FunctionalToolkit.Extensions;

namespace MicroserviceMatrixDSL
{

    class Program
    {
        static void Main()
        {
            //TestCSharpScriptEngine();
            var descr = Test();
            var mms = descr.MessageTypes.ToDictionary(
                        elem => elem.DeclaredMessageType, 
                        elem => elem.MessagesDefaultNamespace
                    );
            descr.Microservices.ForEach(elem =>
            {
                Console.WriteLine(
                      $"\n****"
                    + $"\n{elem.Namespace}.{elem.MicroserviceName}"
                    + $"\nCommunication: {elem.CommunicationMean}"
                    + $"\nMixins: {elem.Mixins.Stringify()}"
                    + $"\nSends messages: {elem.SendingMessages/*.Select(msg => $"{mms[msg]}.{msg}")*/.Stringify()}"
                    + $"\nReq/Resp messages: {elem.ReceiveRespondMessages.Stringify(/*pair => $"[{mms[pair.Key]}.{pair.Key}=>{mms[pair.Key]}.{pair.Value}]"*/)}"
                    + $"\n****"
                    );
            });
            Console.ReadLine();
        }

        private static void TestCSharpScriptEngine()
        {
            CSScript.EvaluatorConfig.Engine = EvaluatorEngine.CodeDom;
            var input = File.ReadAllLines("../../input.mdl");
            var dslString = input
                .Where(line => string.IsNullOrEmpty(line))
                // .Select(line => new Tokenizer().Tokenize(line))
                .ToList();

            var DSLstring = "return \"hehe\"";
            var generate = CSScript.Evaluator
                .CreateDelegate(@"
                                    //css_reference MicroserviceMatrixDSL.Generator;
                                    using MicroserviceMatrixDSL.Generator;
                                    string Sqr()
                                    {
                                        " + DSLstring + @"
                                    }");

            var r = generate();
            Console.WriteLine(r);
        }

        private static MicroserviceInfrastructureDescription Test()
        {
            return new MicroserviceInfrastructureDsl()

                .Default().Message().Namespace("DefaultMessageNamespace.Messages")

                .Message().Class("TestMessage")
                .Message().Class("PingMessage").Using().Namespace("HeheLolMessages")
                .Message().Class("PongMessage").Using().Namespace("HeheLolMessages")
                .Message().Class("EchoMessage").Using().Namespace("HeheLolMessages")
                .Message().Class("LogMessage").Using().Namespace("Common")

                .Default().Namespace("AwesomeMicroservicesCreatedUsingDSL")
                .Microservice("Pinger").Using("RabbitMq").Receives("PingMessage").And().Responds("PongMessage")
                .Microservice("Echo").Using("RabbingMq").Receives("EchoMessage").And().Responds().With("EchoMessage")
                .Microservice("Logging").Using("RabbitMq").Sends("LogMessage")
                .Microservice("Email").Like("Logging").Using("RabbitMq").Receives("EmailMessage")
                .GetInfrastructure()
                .Create();
        }
    }
}
