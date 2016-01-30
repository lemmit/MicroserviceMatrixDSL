using MicroserviceMatrixDSL.DSL.Interfaces;
using MicroserviceMatrixDSL.DSL.Interfaces.Factories;

namespace MicroserviceMatrixDSL.DSL.DslStates
{
    public class DeclareDefaultsState : IDeclareDefaultsState
    {
        private readonly IBaseState _baseState;
        private readonly IDeclareNamespaceStateFactory _declareNamespaceStateFactory;

        public DeclareDefaultsState(IBaseState baseState, IDeclareNamespaceStateFactory declareNamespaceStateFactory)
        {
            _baseState = baseState;
            _declareNamespaceStateFactory = declareNamespaceStateFactory;
        }

        public IDeclareNamespaceState Message()
        {
            return _declareNamespaceStateFactory
                .CreateDeclareNamespaceState(_baseState);
        }

        public IBaseState Namespace(string defaultNamespace)
        {
            return _baseState
                .WithDefaultMicroserviceNamespace(defaultNamespace);
        }

        public IBaseState Communication(string defaultCommunicationMean)
        {
            return _baseState
                .WithDefaultCommunicationMean(defaultCommunicationMean);
        }
    }
}