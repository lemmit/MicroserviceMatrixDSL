namespace MicroserviceMatrixDSL.DSL.Interfaces.Factories
{
    public interface IMicroserviceDescribingStateFactory
    {
        IMicroserviceDescribingState CreateMicroserviceDescribingState(string microserviceName,
                                            string defaultCommunicationMean,
                                            string defaultMicroserviceNamespace,
                                            IBaseState baseState);
    }
}