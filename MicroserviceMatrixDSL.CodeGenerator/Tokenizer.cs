using System;
using System.Collections.Generic;
using System.Linq;
using MicroserviceMatrixDSL.FunctionalToolkit.Extensions;

namespace MicroserviceMatrixDSL.CodeGenerator
{
    public class Tokenizer : ITokenizer
    {
        public Token[] Tokenized => _tokenized.Value;

        private readonly IEnumerable<string> _tokens;
        private readonly IKeywordsProvider _keywordsProvider;
        private readonly Lazy<Token[]> _tokenized;

        public Tokenizer(IEnumerable<string> tokens, IKeywordsProvider keywordsProvider)
        {
            _tokens = tokens;
            _keywordsProvider = keywordsProvider;
            _tokenized = new Lazy<Token[]>(Tokenize);
        }

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
