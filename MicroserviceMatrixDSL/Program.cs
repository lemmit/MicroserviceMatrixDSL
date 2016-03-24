using System;
using System.IO;
using MicroserviceMatrixDSL.AntlrBasedTranspiler;
using MicroserviceMatrixDSL.CSScriptInterpreter;
using MicroserviceMatrixDSL.Services;
using MicroserviceMatrixDSL.TemplateGenerator;

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

            var cg = new CodeGeneratorFactory().Create(input);
            GenerateCodeFromDslUsing(cg, printer, "test1.generated.cs");

            var antrlb = new AntlrMsdlModelBuilder(inputFile);
            GenerateCodeFromDslUsing(antrlb, printer, "test2.generated.cs");

            Console.ReadLine();
        }

        private static void GenerateCodeFromDslUsing(IInterpreter cg,
            IMicroserviceInfrastructureDescriptionPrinter printer,
            string outputFile
            )
        {
            var desc = cg.InterpretedDescription;
            File.WriteAllText(outputFile, printer.Print(desc));
        }
    }
}