using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MicroserviceMatrixDSL.FunctionalToolkit.Extensions;

namespace MicroserviceMatrixDSL.CodeGenerator
{
    public class CodeGenerator
    {
        public string GeneratedCode => _generatedCode.Value;

        private readonly ITokenizer _tokenizer;
        private readonly Lazy<string> _generatedCode;
        private Token[] _tokens;

        public CodeGenerator(ITokenizer tokenizer)
        {
            _tokenizer = tokenizer;
            _generatedCode = new Lazy<string>(GenerateCode);
        }

        private int _pointer = 0;
        private string GenerateCode()
        {
            var generatedCode = GenerateCodeFromDsl();
            var final = @"
                //css_reference MicroserviceMatrixDSL.DSL;
                //css_reference MicroserviceMatrixDSL.Builder;
                using MicroserviceMatrixDSL.DSL;
                using MicroserviceMatrixDSL.Builder.Descriptions;

                MicroserviceInfrastructureDescription GenerateInfrastructureDescription()
                {
                    return new MicroserviceInfrastructureDsl()"
                    + generatedCode +
                    @".Flush().Create();
                }
            ";
            return final;
        }

        private string GenerateCodeFromDsl()
        {
            _tokens = _tokenizer.Tokenized;
            Token token;
            var builder = new StringBuilder();
            while ((token = GetNextToken()) != null)
            {
                if (!token.IsKeyword)
                {
                    throw new InvalidOperationException(token.Value);
                }

                var possible = token.PossibleNumbersOfParams.OrderByDescending(k => k);
                var match = 0;
                try
                {
                    match = possible.First(nrOfParams =>
                        Enumerable
                            .Range(1, nrOfParams)
                            .All(tokenPosition => PeekNextToken(tokenPosition)?.IsKeyword ?? false)
                        );
                }
                catch (Exception e)
                {
                    //TODO - exception types!
                    Debug.WriteLine(e);
                    break;
                }

                //rewrite with brackets
                var @params = Enumerable
                    .Range(0, match)
                    .Select(iter => $"\"{GetNextToken().Value}\"")
                    .Stringify();
                var line = $".{token.Value.Capitalize()}({@params})";
                Debug.WriteLine(line);
                builder.Append(line);
            }

            return builder.ToString();
        }

        private Token GetNextToken()
        {
            return _pointer < _tokens.Length ? _tokens[_pointer++] : null;
        }

        private Token PeekNextToken(int depth = 1)
        {
            return _pointer + depth < _tokens.Length ? _tokens[_pointer + depth] : null;
        }
    }
}
