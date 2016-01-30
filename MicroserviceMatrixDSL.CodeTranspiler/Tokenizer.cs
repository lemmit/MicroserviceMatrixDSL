using System;
using System.Collections.Generic;
using System.Linq;
using MicroserviceMatrixDSL.CodeTranspiler.Interfaces;
using MicroserviceMatrixDSL.FunctionalToolkit.Extensions;

namespace MicroserviceMatrixDSL.CodeTranspiler
{
    public class Tokenizer : ITokenizer
    {
        private readonly IKeywordsProvider _keywordsProvider;
        private readonly Lazy<Token[]> _tokenized;

        private readonly IEnumerable<string> _tokens;

        public Tokenizer(IEnumerable<string> tokens, IKeywordsProvider keywordsProvider)
        {
            _tokens = tokens;
            _keywordsProvider = keywordsProvider;
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