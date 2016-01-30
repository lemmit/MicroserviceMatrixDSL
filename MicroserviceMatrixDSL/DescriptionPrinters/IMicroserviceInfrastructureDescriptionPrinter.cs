using MicroserviceMatrixDSL.Builder.Descriptions;

namespace MicroserviceMatrixDSL.DescriptionPrinters
{
    public interface IMicroserviceInfrastructureDescriptionPrinter
    {
        string Print(MicroserviceInfrastructureDescription microserviceInfrastructureDescription);
    }
}