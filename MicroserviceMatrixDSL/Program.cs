using System;
using System.IO;
using MicroserviceMatrixDSL.CodeTranspiler;
using MicroserviceMatrixDSL.DescriptionPrinters;
using MicroserviceMatrixDSL.Generators;

namespace MicroserviceMatrixDSL
{

    class Program
    {
        static void Main()
        {
            var input = File.ReadAllLines("../../input.msdl");

            var printer = new MicroserviceInfrastructureDescriptionToCSharpCodePrinter();
            //var printer = new MicroserviceInfrastructureDescriptionDebugPrinter();

            var transpiler = new CSharpToCsScriptTranspilerDecorator(
                new DslToCSharpTranspiler(
                    new Tokenizer(
                        input,
                        new KeywordsProvider()
                        )),
                    defaultMessagesNamespace: "Messages",
                    defaultCommunicationMean: "None",
                    defaultMicroservicesNamespace: "Microservices"
                );
            var cg = new CodeGenerator(printer, transpiler, input);
            File.WriteAllText("test.generated.cs", cg.GeneratedCode);

            Console.ReadLine();
        }
    }
}
