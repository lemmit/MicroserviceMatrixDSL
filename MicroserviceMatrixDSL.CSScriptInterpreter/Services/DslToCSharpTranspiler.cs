﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MicroserviceMatrixDSL.CSScriptInterpreter.Models;
using MicroserviceMatrixDSL.CSScriptInterpreter.Services.Interfaces;
using MicroserviceMatrixDSL.FunctionalToolkit.Extensions;

namespace MicroserviceMatrixDSL.CSScriptInterpreter.Services
{
    internal class DslToCSharpTranspiler : ITranspiler
    {
        private readonly Lazy<string> _generatedCode;

        private readonly Tokenizer _tokenizer;
        private int _pointer;
        private Token[] _tokens;

        public DslToCSharpTranspiler(
            Tokenizer tokenizer
            )
        {
            _tokenizer = tokenizer;
            _generatedCode = new Lazy<string>(GenerateCode);
        }

        public string GeneratedCode => _generatedCode.Value;

        private string GenerateCode()
        {
            var generatedCode = GenerateCodeFromDsl();
            return generatedCode;
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