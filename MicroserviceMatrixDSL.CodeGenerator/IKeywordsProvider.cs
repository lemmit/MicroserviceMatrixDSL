using System.Collections.Generic;

namespace MicroserviceMatrixDSL.CodeGenerator
{
    public interface IKeywordsProvider
    {
        IEnumerable<KeyValuePair<string, int>> GetKeywords();
    }
}