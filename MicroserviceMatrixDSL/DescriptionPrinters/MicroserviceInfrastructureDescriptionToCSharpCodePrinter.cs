using System;
using System.Text;
using MicroserviceMatrixDSL.Descriptions;
using MicroserviceMatrixDSL.Template;

namespace MicroserviceMatrixDSL.DescriptionPrinters
{
    public class MicroserviceInfrastructureDescriptionToCSharpCodePrinter :
        IMicroserviceInfrastructureDescriptionPrinter
    {
        public string Print(MicroserviceInfrastructureDescription microserviceInfrastructureDescription)
        {
            var str = new MicroservicesGenerator(
                new MicroserviceInfrastructureDescriptionExtender(
                    microserviceInfrastructureDescription
                    )
                ).TransformText();
            var sb = new StringBuilder();
            sb.AppendLine(
                $"/*"
                + $"\nGENERATED CODE {DateTime.UtcNow}"
                + "\nby MicroserviceMatrixDSL tool"
                + "\n(https://github.com/lemmit/MicroserviceMatrixDSL)"
                + "\n*/"
                );
            sb.AppendLine(str);
            sb.AppendLine("//END OF GENERATED CODE");
            return sb.ToString();
        }
    }
}