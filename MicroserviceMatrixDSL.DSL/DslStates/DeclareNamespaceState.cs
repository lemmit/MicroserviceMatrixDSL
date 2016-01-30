using MicroserviceMatrixDSL.DSL.Interfaces;

namespace MicroserviceMatrixDSL.DSL.DslStates
{
    public class DeclareNamespaceState : IDeclareNamespaceState
    {
        private readonly IBaseState _baseState;

        public DeclareNamespaceState(IBaseState baseState)
        {
            _baseState = baseState;
        }

        public IBaseState Namespace(string defaultMessageNamespace)
        {
            return _baseState.WithDefaultMessageNamespace(defaultMessageNamespace);
        }
    }
}