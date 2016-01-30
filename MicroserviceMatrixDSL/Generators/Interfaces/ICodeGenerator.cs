using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceMatrixDSL.Generators.Interfaces
{
    public interface ICodeGenerator
    {
        string GeneratedCode { get; }
    }
}
