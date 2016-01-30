namespace MicroserviceMatrixDSL.DSL.Interfaces
{
    public interface IMicroserviceDescribingState
    {
        IMicroserviceDescribingState Using(string communicationMean);
        IMicroserviceDescribingState Sends(string sendsMessageTypeName);
        IMicroserviceDescribingState Receives(string receiveMessageTypeName);
        IMicroserviceDescribingState And();
        IMicroserviceDescribingState Responds(string respondMessageTypeName);
        IMicroserviceDescribingState Microservice(string microserviceName);
        IMicroserviceDescribingState Like(string microserviceMixin);
        IMicroserviceDescribingState With(string respondMessageTypeName);
        IMicroserviceDescribingState Responds();
        IDeclareDefaultsState Default();
        IBaseState Flush();
    }
}