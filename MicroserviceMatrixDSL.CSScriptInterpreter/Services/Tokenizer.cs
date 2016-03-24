using System;
using System.Collections.Generic;
using System.Linq;
using MicroserviceMatrixDSL.CSScriptInterpreter.Models;
using MicroserviceMatrixDSL.CSScriptInterpreter.Providers;
using MicroserviceMatrixDSL.FunctionalToolkit.Extensions;

namespace MicroserviceMatrixDSL.CSScriptInterpreter.Services
{
    internal class Tokenizer
    {
        private readonly KeywordsProvider _keywordsProvider;
        private readonly Lazy<Token[]> _tokenized;

        private readonly IEnumerable<string> _tokens;

        public Tokenizer(IEnumerable<string> tokens)
        {
            _tokens = tokens;
            _keywordsProvider = new KeywordsProvider();
            _tokenized = new Lazy<Token[]>(Tokenize);
        }

        public Token[] Tokenized => _tokenized.Value;

        private Token[] Tokenize()
        {
            var keywords = _keywordsProvider.GetKeywords().ToList();
            return _tokens
                .RemoveComments()
                .SplitLines()
                .FilterWhitespaces()
                .Trim()
                .Select(token =>
                    new Token(
                        token,
                        keywords.Any(keyword => keyword.Key.ToLower().Equals(token.ToLower())),
                        keywords.Where(keyword => keyword.Key.ToLower().Equals(token.ToLower()))
                            .Select(keyword => keyword.Value)
                        )
                )
                .ToArray();
        }
    }
}