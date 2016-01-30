using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceMatrixDSL.DSL.Interfaces.Factories
{
    public interface IMessageTypeDescribingStateFactory
    {
        IMessageTypeDescribingState CreateMessageTypeDescribingState(IBaseState baseState);
    }
}
