using MicroserviceMatrixDSL.Descriptions;

namespace MicroserviceMatrixDSL.Services
{
    public interface IInterpreter
    {
        MicroserviceInfrastructureDescription InterpretedDescription { get; }
    }
}