using System;
using System.IO;
using MicroserviceMatrixDSL.AntlrBasedTranspiler;
using MicroserviceMatrixDSL.CodeTranspiler;
using MicroserviceMatrixDSL.DescriptionPrinters;
using MicroserviceMatrixDSL.Generators;

namespace MicroserviceMatrixDSL
{
    internal class Program
    {
        private static void Main()
        {
            var inputFile = "../../input.msdl";
            var input = File.ReadAllLines(inputFile);

            var printer = new MicroserviceInfrastructureDescriptionToCSharpCodePrinter();
            //var printer = new MicroserviceInfrastructureDescriptionDebugPrinter();

            var transpiler = new CSharpToCsScriptTranspilerDecorator(
                new DslToCSharpTranspiler(
                    new Tokenizer(
                        input,
                        new KeywordsProvider()
                        )), "Messages", "None", "Microservices"
                );
            var cg = new CodeGenerator(printer, transpiler, input);
            File.WriteAllText("test.generated.cs", cg.GeneratedCode);

            var antrlb = new AntlrMsdlModelBuilder(inputFile);
            var desc = antrlb.Description;
            Console.WriteLine(printer.Print(desc));
            File.WriteAllText("test2.generated.cs", printer.Print(desc));

            Console.ReadLine();
        }
    }
}