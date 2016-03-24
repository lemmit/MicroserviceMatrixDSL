using System.Collections.Generic;

namespace MicroserviceMatrixDSL.CSScriptInterpreter.Models
{
    public class Token
    {
        public Token(string value, bool isKeyword, IEnumerable<int> possibleNumbersOfParams)
        {
            Value = value;
            IsKeyword = isKeyword;
            PossibleNumbersOfParams = possibleNumbersOfParams;
        }

        public string Value { get; }
        public bool IsKeyword { get; }
        public IEnumerable<int> PossibleNumbersOfParams { get; }
    }
}