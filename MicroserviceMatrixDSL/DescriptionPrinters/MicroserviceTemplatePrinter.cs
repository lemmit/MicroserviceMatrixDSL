using System;
using System.Text;
using MicroserviceMatrixDSL.Builder.Descriptions;
using MicroserviceMatrixDSL.Template;

namespace MicroserviceMatrixDSL.DescriptionPrinters
{
    public class MicroserviceTemplatePrinter : IMicroserviceInfrastructureDescriptionPrinter
    {
        public string Print(MicroserviceInfrastructureDescription microserviceInfrastructureDescription)
        {
            var str = new MicroservicesGenerator(microserviceInfrastructureDescription).TransformText();
            var sb = new StringBuilder();
            sb.AppendLine(
                             $"/*" 
                        +  $"\nGENERATED CODE {DateTime.UtcNow}"
                        +   "\nby MicroserviceMatrixDSL tool"
                        +   "\n(https://github.com/lemmit/MicroserviceMatrixDSL)"
                        +   "\n*/"
                        );
            sb.AppendLine(str);
            sb.AppendLine("//END OF GENERATED CODE");
            return sb.ToString();
        }
    }
}