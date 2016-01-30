using MicroserviceMatrixDSL.Descriptions;

namespace MicroserviceMatrixDSL.DescriptionPrinters
{
    public interface IMicroserviceInfrastructureDescriptionPrinter
    {
        string Print(MicroserviceInfrastructureDescription microserviceInfrastructureDescription);
    }
}