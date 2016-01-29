using System.Collections.Generic;

namespace MicroserviceMatrixDSL.CodeGenerator
{
    public class Token
    {
        public string Value { get; }
        public bool IsKeyword { get; }
        public IEnumerable<int> PossibleNumbersOfParams { get; } 
        public Token(string value, bool isKeyword, IEnumerable<int> possibleNumbersOfParams)
        {
            Value = value;
            IsKeyword = isKeyword;
            PossibleNumbersOfParams = possibleNumbersOfParams;
        }
    }
}