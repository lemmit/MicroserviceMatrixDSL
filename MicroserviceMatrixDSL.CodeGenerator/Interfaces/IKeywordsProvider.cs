using System.Collections.Generic;

namespace MicroserviceMatrixDSL.CodeTranspiler.Interfaces
{
    public interface IKeywordsProvider
    {
        IEnumerable<KeyValuePair<string, int>> GetKeywords();
    }
}