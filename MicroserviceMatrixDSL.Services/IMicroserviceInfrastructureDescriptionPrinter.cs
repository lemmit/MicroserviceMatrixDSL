using MicroserviceMatrixDSL.Descriptions;

namespace MicroserviceMatrixDSL.Services
{
    public interface IMicroserviceInfrastructureDescriptionPrinter
    {
        string Print(MicroserviceInfrastructureDescription microserviceInfrastructureDescription);
    }
}