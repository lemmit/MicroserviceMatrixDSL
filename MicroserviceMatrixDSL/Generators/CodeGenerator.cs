﻿using System;
using CSScriptLibrary;
using MicroserviceMatrixDSL.CodeTranspiler.Interfaces;
using MicroserviceMatrixDSL.DescriptionPrinters;
using MicroserviceMatrixDSL.Descriptions;
using MicroserviceMatrixDSL.FunctionalToolkit.Extensions;
using MicroserviceMatrixDSL.Generators.Interfaces;

namespace MicroserviceMatrixDSL.Generators
{
    public class CodeGenerator : ICodeGenerator
    {
        private readonly Lazy<string> _generatedCode;
        private readonly string[] _input;
        private readonly IMicroserviceInfrastructureDescriptionPrinter _printer;
        private readonly ITranspiler _transpiler;

        public CodeGenerator(
            IMicroserviceInfrastructureDescriptionPrinter printer,
            ITranspiler transpiler,
            string[] input
            )
        {
            _printer = printer;
            _input = input;
            _transpiler = transpiler;
            _generatedCode = new Lazy<string>(GenerateCode);
        }

        public string GeneratedCode => _generatedCode.Value;

        private string GenerateCode()
        {
            var genCode = _transpiler.GeneratedCode;
            try
            {
                CSScript.EvaluatorConfig.Engine = EvaluatorEngine.CodeDom;
                var generate = CSScript.Evaluator
                    .CreateDelegate(genCode);
                var description = (MicroserviceInfrastructureDescription) generate();
                return _printer.Print(description);
            }
            catch (Exception e)
            {
                return $"/*CODE GENERATION ERROR:\n" +
                       $"Input: {_input.Stringify(t => t, "\n")}\n" +
                       $"Generated code: {genCode}\n" +
                       $"Exception: {e}\n" +
                       $"*/";
            }
        }
    }
}