using System;
using MicroserviceMatrixDSL.DSL.DslStates;
using MicroserviceMatrixDSL.DSL.Interfaces;
using MicroserviceMatrixDSL.DSL.Interfaces.Factories;

namespace MicroserviceMatrixDSL.DSL
{
    public class DslStatesFactory : IStatesFactory
    {
        public IBaseState CreateBaseState(string defaultMessageNamespace, 
            string defaultCommunicationMean, 
            string defaultMicroservieNamespace)
        {
            return new BaseState(defaultMessageNamespace,
                                 defaultCommunicationMean,
                                 defaultMicroservieNamespace, 
                                 this);
        }

        public IDeclareDefaultsState CreateDefaultsState(IBaseState baseState)
        {
            return new DeclareDefaultsState(baseState, this);
        }

        public IDeclareNamespaceState CreateDeclareNamespaceState(IBaseState baseState)
        {
            return new DeclareNamespaceState(baseState);
        }

        public IMicroserviceDescribingState CreateMicroserviceDescribingState(string microserviceName, string defaultCommunicationMean, string defaultMicroserviceNamespace, IBaseState baseState)
        {
            return new MicroserviceDescribingState(microserviceName,
                defaultCommunicationMean,
                defaultMicroserviceNamespace,
                baseState);
        }

        public IMessageTypeDescribingState CreateMessageTypeDescribingState(IBaseState baseState)
        {
            return new MessageTypeDescribingState(baseState);
        }
    }
}
