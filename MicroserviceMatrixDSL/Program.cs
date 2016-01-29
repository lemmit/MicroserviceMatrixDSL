using System;
using System.IO;
using CSScriptLibrary;
using MicroserviceMatrixDSL.Builder.Descriptions;
using MicroserviceMatrixDSL.CodeGenerator;
using MicroserviceMatrixDSL.DSL;
using MicroserviceMatrixDSL.FunctionalToolkit.Extensions;

namespace MicroserviceMatrixDSL
{

    class Program
    {
        static void Main()
        { 
            //TestCSharpScriptEngine();
            //new MicroserviceInfrastructureDescriptionPrinter().Print(Test());
            //PrintKeywordsTest();
            GeneratorTest();
            Console.ReadLine();
        }
        
        private static void PrintKeywordsTest()
        {
            var input = File.ReadAllLines("../../input.mdl");
            var tokenizer = new Tokenizer(input, new KeywordsProvider());
            Console.WriteLine($"{"Token Value".PadRight(25)}| Is Keyword?");
            Console.WriteLine(tokenizer.Tokenized.Stringify(
                    elem => $"{elem.Value.PadRight(25)}| {elem.IsKeyword}",
                    "\n"
                ));
        }

        private static void GeneratorTest()
        {
            var input = File.ReadAllLines("../../input.mdl");
            var tokenizer = new Tokenizer(input, new KeywordsProvider());
            var codeGenerator = new CodeGenerator.CodeGenerator(tokenizer);
            var genCode = codeGenerator.GeneratedCode;
            Console.WriteLine(genCode);
            CSScript.EvaluatorConfig.Engine = EvaluatorEngine.CodeDom;
            var generate = CSScript.Evaluator
                                .CreateDelegate(genCode);
            var description = (MicroserviceInfrastructureDescription)generate();
            new MicroserviceInfrastructureDescriptionPrinter().Print(description);
        }

        private static MicroserviceInfrastructureDescription Test()
        {
            return new MicroserviceInfrastructureDsl()

                .Default().Message().Namespace("DefaultMessageNamespace.Messages")
                .Message().Class("TestMessage")
                .Message().Class("PingMessage").Using().Namespace("HeheLolMessages")
                .Message().Class("PongMessage").Using().Namespace("HeheLolMessages")
                .Message().Class("EchoMessage").Using().Namespace("HeheLolMessages")
                .Message().Class("LogMessage")
                .Message().Class("EmailMessage").Using().Namespace("Common")

                .Default().Namespace("AwesomeMicroservicesCreatedUsingDSL")
                .Microservice("Pinger").Using("RabbitMq").Receives("PingMessage").And().Responds("PongMessage")
                .Microservice("Echo").Using("RabbingMq").Receives("EchoMessage").And().Responds().With("EchoMessage")
                .Default().Communication("REST")
                .Microservice("Logging").Using("RabbitMq").Sends("LogMessage")
                .Microservice("Email").Like("Logging").Using("RabbitMq").Receives("EmailMessage")
                .Flush()
                .Create();
        }
    }
}
