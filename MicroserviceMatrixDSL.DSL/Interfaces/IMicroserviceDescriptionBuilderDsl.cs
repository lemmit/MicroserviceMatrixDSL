namespace MicroserviceMatrixDSL.DSL.Interfaces
{
    public interface IMicroserviceDescriptionBuilderDsl
    {
        IMicroserviceDescriptionBuilderDsl Using(string communicationMean);
        IMicroserviceDescriptionBuilderDsl Sends(string sendsMessageTypeName);
        IMicroserviceDescriptionBuilderDsl Receives(string receiveMessageTypeName);
        IMicroserviceDescriptionBuilderDsl And();
        IMicroserviceDescriptionBuilderDsl Responds(string respondMessageTypeName);
        IMicroserviceDescriptionBuilderDsl Microservice(string microserviceName);
        IMicroserviceDescriptionBuilderDsl Like(string microserviceMixin);
        IMicroserviceDescriptionBuilderDsl With(string respondMessageTypeName);
        IMicroserviceDescriptionBuilderDsl Responds();
        IDeclareDefaultDsl Default();
        IMicroserviceInfrastructureDsl Flush();
    }
}