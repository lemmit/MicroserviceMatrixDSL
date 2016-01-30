namespace MicroserviceMatrixDSL.DSL.Interfaces.Factories
{
    public interface IBaseStateFactory
    {
        IBaseState CreateBaseState(string defaultMessageNamespace,
                          string defaultCommunicationMean,
                          string defaultMicroservieNamespace);
    }
}