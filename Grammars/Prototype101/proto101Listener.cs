//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from proto101.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

#pragma warning disable 3021
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="proto101Parser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public interface Iproto101Listener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="proto101Parser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProg([NotNull] proto101Parser.ProgContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="proto101Parser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProg([NotNull] proto101Parser.ProgContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="proto101Parser.elem"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElem([NotNull] proto101Parser.ElemContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="proto101Parser.elem"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElem([NotNull] proto101Parser.ElemContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="proto101Parser.createPlayer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCreatePlayer([NotNull] proto101Parser.CreatePlayerContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="proto101Parser.createPlayer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCreatePlayer([NotNull] proto101Parser.CreatePlayerContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="proto101Parser.createMap"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCreateMap([NotNull] proto101Parser.CreateMapContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="proto101Parser.createMap"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCreateMap([NotNull] proto101Parser.CreateMapContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="proto101Parser.createEnemies"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCreateEnemies([NotNull] proto101Parser.CreateEnemiesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="proto101Parser.createEnemies"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCreateEnemies([NotNull] proto101Parser.CreateEnemiesContext context);
}