//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.3
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:\users\michal\documents\visual studio 2013\Projects\MSDL\MSDL\microservice_description_language.g4 by ANTLR 4.3

// Unreachable code detected


#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace MicroserviceMatrixDSL.AntlrBasedTranspiler.Generated {
    /// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="microservice_description_languageParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.3")]
[System.CLSCompliant(false)]
public interface Imicroservice_description_languageVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="microservice_description_languageParser.microservice_description_language"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMicroservice_description_language([NotNull] microservice_description_languageParser.Microservice_description_languageContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="microservice_description_languageParser.used_communication"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUsed_communication([NotNull] microservice_description_languageParser.Used_communicationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="microservice_description_languageParser.sended_message_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSended_message_declaration([NotNull] microservice_description_languageParser.Sended_message_declarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="microservice_description_languageParser.message_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMessage_declaration([NotNull] microservice_description_languageParser.Message_declarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="microservice_description_languageParser.message_description"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMessage_description([NotNull] microservice_description_languageParser.Message_descriptionContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="microservice_description_languageParser.default_message_namespace_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefault_message_namespace_declaration([NotNull] microservice_description_languageParser.Default_message_namespace_declarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="microservice_description_languageParser.default_communication_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefault_communication_declaration([NotNull] microservice_description_languageParser.Default_communication_declarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="microservice_description_languageParser.mixin_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMixin_declaration([NotNull] microservice_description_languageParser.Mixin_declarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="microservice_description_languageParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] microservice_description_languageParser.StatementContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="microservice_description_languageParser.microservice_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMicroservice_declaration([NotNull] microservice_description_languageParser.Microservice_declarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="microservice_description_languageParser.received_message_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReceived_message_declaration([NotNull] microservice_description_languageParser.Received_message_declarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="microservice_description_languageParser.microservice_description"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMicroservice_description([NotNull] microservice_description_languageParser.Microservice_descriptionContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="microservice_description_languageParser.default_microservice_namespace_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefault_microservice_namespace_declaration([NotNull] microservice_description_languageParser.Default_microservice_namespace_declarationContext context);
}
} // namespace MSDL
