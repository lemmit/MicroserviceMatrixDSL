using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MicroserviceMatrixDSL.CodeTranspiler.Interfaces;
using MicroserviceMatrixDSL.FunctionalToolkit.Extensions;

namespace MicroserviceMatrixDSL.CodeTranspiler
{
    public class DslToCSharpScriptTranspiler : ITranspiler
    {
        public string GeneratedCode => _generatedCode.Value;

        private readonly ITokenizer _tokenizer;
        private readonly Lazy<string> _generatedCode;
        private Token[] _tokens;

        public DslToCSharpScriptTranspiler(ITokenizer tokenizer)
        {
            _tokenizer = tokenizer;
            _generatedCode = new Lazy<string>(GenerateCode);
        }

        public virtual string CodeBefore()
        {
            return @"
                    //css_reference MicroserviceMatrixDSL.DSL;
                    //css_reference MicroserviceMatrixDSL.Builder;
                    using MicroserviceMatrixDSL.DSL;
                    using MicroserviceMatrixDSL.Builder.Descriptions;

                    MicroserviceInfrastructureDescription GenerateInfrastructureDescription()
                    {
                        return new MicroserviceInfrastructureDsl()
                    ";
        }

        public virtual string CodeAfter()
        {
            return @".Flush().Create();
                }
            ";
        }

        private int _pointer = 0;
        private string GenerateCode()
        {
            var generatedCode = GenerateCodeFromDsl();
            var final = CodeBefore()
                        + generatedCode +
                        CodeAfter();
            return final;
        }

        private string GenerateCodeFromDsl()
        {
            _tokens = _tokenizer.Tokenized;
            Token token;
            var builder = new StringBuilder();
            while ((token = GetNextToken()) != null)
            {
                try
                {
                    if (Step(token, builder))
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    builder.Append($"Top code generation error. Token:{token.Value} at pos [{_pointer}] => {e}");
                }
            }

            return builder.ToString();
        }

        private bool Step(Token token, StringBuilder builder)
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
                Debug.WriteLine("Exception handled.", e);
                if (PeekNextToken() != null)
                {
                    builder.Append($"Code generation error. Token:{token.Value} at pos [{_pointer}] => {e}");
                }
                return true;
            }

            //rewrite with brackets
            var @params = Enumerable
                .Range(0, match)
                .Select(iter => $"\"{GetNextToken().Value}\"")
                .Stringify();
            var line = $".{token.Value.Capitalize()}({@params})";
            Debug.WriteLine(line);
            builder.Append(line);
            return false;
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
