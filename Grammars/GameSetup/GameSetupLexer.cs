//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from GameSetup.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

#pragma warning disable 3021
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class GameSetupLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		INITIALISE=1, FINALISE=2, GAMETYPE=3, PC=4, NUM=5, DIFFICULTY=6, SKILLLEVEL=7, 
		SKILLSET=8, DUNGEON=9, PLATFORMER=10, MAP=11, SIZE=12, ENEMY=13, ATTACKSTYLE=14, 
		INT=15, NEWLINE=16, WS=17;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"INITIALISE", "FINALISE", "GAMETYPE", "PC", "NUM", "DIFFICULTY", "SKILLLEVEL", 
		"SKILLSET", "DUNGEON", "PLATFORMER", "MAP", "SIZE", "ENEMY", "ATTACKSTYLE", 
		"INT", "NEWLINE", "WS"
	};


		public GameCompiler Compiler = new GameCompiler(); //the specific compiler file in the Unity project


	public GameSetupLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public GameSetupLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'initialise'", "'finalise'", null, "'players'", null, "'difficulty'", 
		null, null, "'dungeon'", "'platformer'", "'map'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "INITIALISE", "FINALISE", "GAMETYPE", "PC", "NUM", "DIFFICULTY", 
		"SKILLLEVEL", "SKILLSET", "DUNGEON", "PLATFORMER", "MAP", "SIZE", "ENEMY", 
		"ATTACKSTYLE", "INT", "NEWLINE", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "GameSetup.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static GameSetupLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\x13', '\xDD', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x3', '\x2', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', 
		'\x4', '\x5', '\x4', '<', '\n', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', 
		'\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', 
		'\a', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', 
		'\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', 
		'\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', 
		'\x3', '\b', '\x5', '\b', '\x62', '\n', '\b', '\x3', '\t', '\x3', '\t', 
		'\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', 
		'\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', 
		'\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', 
		'\t', '\x3', '\t', '\x5', '\t', 'x', '\n', '\t', '\x3', '\n', '\x3', '\n', 
		'\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', 
		'\n', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', 
		'\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', 
		'\v', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\r', 
		'\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', 
		'\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', 
		'\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x5', '\r', '\xA1', 
		'\n', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xE', '\x5', '\xE', '\xAF', '\n', '\xE', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x5', '\xF', '\xC8', '\n', 
		'\xF', '\x3', '\x10', '\x5', '\x10', '\xCB', '\n', '\x10', '\x3', '\x10', 
		'\x6', '\x10', '\xCE', '\n', '\x10', '\r', '\x10', '\xE', '\x10', '\xCF', 
		'\x3', '\x11', '\x5', '\x11', '\xD3', '\n', '\x11', '\x3', '\x11', '\x3', 
		'\x11', '\x3', '\x12', '\x6', '\x12', '\xD8', '\n', '\x12', '\r', '\x12', 
		'\xE', '\x12', '\xD9', '\x3', '\x12', '\x3', '\x12', '\x2', '\x2', '\x13', 
		'\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', '\x6', '\v', '\a', '\r', 
		'\b', '\xF', '\t', '\x11', '\n', '\x13', '\v', '\x15', '\f', '\x17', '\r', 
		'\x19', '\xE', '\x1B', '\xF', '\x1D', '\x10', '\x1F', '\x11', '!', '\x12', 
		'#', '\x13', '\x3', '\x2', '\x3', '\x5', '\x2', '\v', '\f', '\xF', '\xF', 
		'\"', '\"', '\x2', '\xEB', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '\x13', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x17', '\x3', '\x2', '\x2', '\x2', '\x2', '\x19', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1D', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', '\x3', '\x2', '\x2', 
		'\x2', '\x3', '%', '\x3', '\x2', '\x2', '\x2', '\x5', '\x30', '\x3', '\x2', 
		'\x2', '\x2', '\a', ';', '\x3', '\x2', '\x2', '\x2', '\t', '=', '\x3', 
		'\x2', '\x2', '\x2', '\v', '\x45', '\x3', '\x2', '\x2', '\x2', '\r', 'G', 
		'\x3', '\x2', '\x2', '\x2', '\xF', '\x61', '\x3', '\x2', '\x2', '\x2', 
		'\x11', 'w', '\x3', '\x2', '\x2', '\x2', '\x13', 'y', '\x3', '\x2', '\x2', 
		'\x2', '\x15', '\x81', '\x3', '\x2', '\x2', '\x2', '\x17', '\x8C', '\x3', 
		'\x2', '\x2', '\x2', '\x19', '\xA0', '\x3', '\x2', '\x2', '\x2', '\x1B', 
		'\xAE', '\x3', '\x2', '\x2', '\x2', '\x1D', '\xC7', '\x3', '\x2', '\x2', 
		'\x2', '\x1F', '\xCA', '\x3', '\x2', '\x2', '\x2', '!', '\xD2', '\x3', 
		'\x2', '\x2', '\x2', '#', '\xD7', '\x3', '\x2', '\x2', '\x2', '%', '&', 
		'\a', 'k', '\x2', '\x2', '&', '\'', '\a', 'p', '\x2', '\x2', '\'', '(', 
		'\a', 'k', '\x2', '\x2', '(', ')', '\a', 'v', '\x2', '\x2', ')', '*', 
		'\a', 'k', '\x2', '\x2', '*', '+', '\a', '\x63', '\x2', '\x2', '+', ',', 
		'\a', 'n', '\x2', '\x2', ',', '-', '\a', 'k', '\x2', '\x2', '-', '.', 
		'\a', 'u', '\x2', '\x2', '.', '/', '\a', 'g', '\x2', '\x2', '/', '\x4', 
		'\x3', '\x2', '\x2', '\x2', '\x30', '\x31', '\a', 'h', '\x2', '\x2', '\x31', 
		'\x32', '\a', 'k', '\x2', '\x2', '\x32', '\x33', '\a', 'p', '\x2', '\x2', 
		'\x33', '\x34', '\a', '\x63', '\x2', '\x2', '\x34', '\x35', '\a', 'n', 
		'\x2', '\x2', '\x35', '\x36', '\a', 'k', '\x2', '\x2', '\x36', '\x37', 
		'\a', 'u', '\x2', '\x2', '\x37', '\x38', '\a', 'g', '\x2', '\x2', '\x38', 
		'\x6', '\x3', '\x2', '\x2', '\x2', '\x39', '<', '\x5', '\x13', '\n', '\x2', 
		':', '<', '\x5', '\x15', '\v', '\x2', ';', '\x39', '\x3', '\x2', '\x2', 
		'\x2', ';', ':', '\x3', '\x2', '\x2', '\x2', '<', '\b', '\x3', '\x2', 
		'\x2', '\x2', '=', '>', '\a', 'r', '\x2', '\x2', '>', '?', '\a', 'n', 
		'\x2', '\x2', '?', '@', '\a', '\x63', '\x2', '\x2', '@', '\x41', '\a', 
		'{', '\x2', '\x2', '\x41', '\x42', '\a', 'g', '\x2', '\x2', '\x42', '\x43', 
		'\a', 't', '\x2', '\x2', '\x43', '\x44', '\a', 'u', '\x2', '\x2', '\x44', 
		'\n', '\x3', '\x2', '\x2', '\x2', '\x45', '\x46', '\x5', '\x1F', '\x10', 
		'\x2', '\x46', '\f', '\x3', '\x2', '\x2', '\x2', 'G', 'H', '\a', '\x66', 
		'\x2', '\x2', 'H', 'I', '\a', 'k', '\x2', '\x2', 'I', 'J', '\a', 'h', 
		'\x2', '\x2', 'J', 'K', '\a', 'h', '\x2', '\x2', 'K', 'L', '\a', 'k', 
		'\x2', '\x2', 'L', 'M', '\a', '\x65', '\x2', '\x2', 'M', 'N', '\a', 'w', 
		'\x2', '\x2', 'N', 'O', '\a', 'n', '\x2', '\x2', 'O', 'P', '\a', 'v', 
		'\x2', '\x2', 'P', 'Q', '\a', '{', '\x2', '\x2', 'Q', '\xE', '\x3', '\x2', 
		'\x2', '\x2', 'R', 'S', '\a', 'g', '\x2', '\x2', 'S', 'T', '\a', '\x63', 
		'\x2', '\x2', 'T', 'U', '\a', 'u', '\x2', '\x2', 'U', '\x62', '\a', '{', 
		'\x2', '\x2', 'V', 'W', '\a', 't', '\x2', '\x2', 'W', 'X', '\a', 'g', 
		'\x2', '\x2', 'X', 'Y', '\a', 'i', '\x2', '\x2', 'Y', 'Z', '\a', 'w', 
		'\x2', '\x2', 'Z', '[', '\a', 'n', '\x2', '\x2', '[', '\\', '\a', '\x63', 
		'\x2', '\x2', '\\', '\x62', '\a', 't', '\x2', '\x2', ']', '^', '\a', 'j', 
		'\x2', '\x2', '^', '_', '\a', '\x63', '\x2', '\x2', '_', '`', '\a', 't', 
		'\x2', '\x2', '`', '\x62', '\a', '\x66', '\x2', '\x2', '\x61', 'R', '\x3', 
		'\x2', '\x2', '\x2', '\x61', 'V', '\x3', '\x2', '\x2', '\x2', '\x61', 
		']', '\x3', '\x2', '\x2', '\x2', '\x62', '\x10', '\x3', '\x2', '\x2', 
		'\x2', '\x63', '\x64', '\a', '\x64', '\x2', '\x2', '\x64', '\x65', '\a', 
		'\x63', '\x2', '\x2', '\x65', '\x66', '\a', 'u', '\x2', '\x2', '\x66', 
		'g', '\a', 'k', '\x2', '\x2', 'g', 'x', '\a', '\x65', '\x2', '\x2', 'h', 
		'i', '\a', '\x64', '\x2', '\x2', 'i', 'j', '\a', '\x63', '\x2', '\x2', 
		'j', 'k', '\a', 'n', '\x2', '\x2', 'k', 'l', '\a', '\x63', '\x2', '\x2', 
		'l', 'm', '\a', 'p', '\x2', '\x2', 'm', 'n', '\a', '\x65', '\x2', '\x2', 
		'n', 'o', '\a', 'g', '\x2', '\x2', 'o', 'x', '\a', '\x66', '\x2', '\x2', 
		'p', 'q', '\a', 'u', '\x2', '\x2', 'q', 'r', '\a', 'm', '\x2', '\x2', 
		'r', 's', '\a', 'k', '\x2', '\x2', 's', 't', '\a', 'n', '\x2', '\x2', 
		't', 'u', '\a', 'n', '\x2', '\x2', 'u', 'v', '\a', 'g', '\x2', '\x2', 
		'v', 'x', '\a', '\x66', '\x2', '\x2', 'w', '\x63', '\x3', '\x2', '\x2', 
		'\x2', 'w', 'h', '\x3', '\x2', '\x2', '\x2', 'w', 'p', '\x3', '\x2', '\x2', 
		'\x2', 'x', '\x12', '\x3', '\x2', '\x2', '\x2', 'y', 'z', '\a', '\x66', 
		'\x2', '\x2', 'z', '{', '\a', 'w', '\x2', '\x2', '{', '|', '\a', 'p', 
		'\x2', '\x2', '|', '}', '\a', 'i', '\x2', '\x2', '}', '~', '\a', 'g', 
		'\x2', '\x2', '~', '\x7F', '\a', 'q', '\x2', '\x2', '\x7F', '\x80', '\a', 
		'p', '\x2', '\x2', '\x80', '\x14', '\x3', '\x2', '\x2', '\x2', '\x81', 
		'\x82', '\a', 'r', '\x2', '\x2', '\x82', '\x83', '\a', 'n', '\x2', '\x2', 
		'\x83', '\x84', '\a', '\x63', '\x2', '\x2', '\x84', '\x85', '\a', 'v', 
		'\x2', '\x2', '\x85', '\x86', '\a', 'h', '\x2', '\x2', '\x86', '\x87', 
		'\a', 'q', '\x2', '\x2', '\x87', '\x88', '\a', 't', '\x2', '\x2', '\x88', 
		'\x89', '\a', 'o', '\x2', '\x2', '\x89', '\x8A', '\a', 'g', '\x2', '\x2', 
		'\x8A', '\x8B', '\a', 't', '\x2', '\x2', '\x8B', '\x16', '\x3', '\x2', 
		'\x2', '\x2', '\x8C', '\x8D', '\a', 'o', '\x2', '\x2', '\x8D', '\x8E', 
		'\a', '\x63', '\x2', '\x2', '\x8E', '\x8F', '\a', 'r', '\x2', '\x2', '\x8F', 
		'\x18', '\x3', '\x2', '\x2', '\x2', '\x90', '\x91', '\a', 'u', '\x2', 
		'\x2', '\x91', '\x92', '\a', 'o', '\x2', '\x2', '\x92', '\x93', '\a', 
		'\x63', '\x2', '\x2', '\x93', '\x94', '\a', 'n', '\x2', '\x2', '\x94', 
		'\xA1', '\a', 'n', '\x2', '\x2', '\x95', '\x96', '\a', 'o', '\x2', '\x2', 
		'\x96', '\x97', '\a', 'g', '\x2', '\x2', '\x97', '\x98', '\a', '\x66', 
		'\x2', '\x2', '\x98', '\x99', '\a', 'k', '\x2', '\x2', '\x99', '\x9A', 
		'\a', 'w', '\x2', '\x2', '\x9A', '\xA1', '\a', 'o', '\x2', '\x2', '\x9B', 
		'\x9C', '\a', 'n', '\x2', '\x2', '\x9C', '\x9D', '\a', '\x63', '\x2', 
		'\x2', '\x9D', '\x9E', '\a', 't', '\x2', '\x2', '\x9E', '\x9F', '\a', 
		'i', '\x2', '\x2', '\x9F', '\xA1', '\a', 'g', '\x2', '\x2', '\xA0', '\x90', 
		'\x3', '\x2', '\x2', '\x2', '\xA0', '\x95', '\x3', '\x2', '\x2', '\x2', 
		'\xA0', '\x9B', '\x3', '\x2', '\x2', '\x2', '\xA1', '\x1A', '\x3', '\x2', 
		'\x2', '\x2', '\xA2', '\xA3', '\a', 'g', '\x2', '\x2', '\xA3', '\xA4', 
		'\a', 'p', '\x2', '\x2', '\xA4', '\xA5', '\a', 'g', '\x2', '\x2', '\xA5', 
		'\xA6', '\a', 'o', '\x2', '\x2', '\xA6', '\xAF', '\a', '{', '\x2', '\x2', 
		'\xA7', '\xA8', '\a', 'g', '\x2', '\x2', '\xA8', '\xA9', '\a', 'p', '\x2', 
		'\x2', '\xA9', '\xAA', '\a', 'g', '\x2', '\x2', '\xAA', '\xAB', '\a', 
		'o', '\x2', '\x2', '\xAB', '\xAC', '\a', 'k', '\x2', '\x2', '\xAC', '\xAD', 
		'\a', 'g', '\x2', '\x2', '\xAD', '\xAF', '\a', 'u', '\x2', '\x2', '\xAE', 
		'\xA2', '\x3', '\x2', '\x2', '\x2', '\xAE', '\xA7', '\x3', '\x2', '\x2', 
		'\x2', '\xAF', '\x1C', '\x3', '\x2', '\x2', '\x2', '\xB0', '\xB1', '\a', 
		'o', '\x2', '\x2', '\xB1', '\xB2', '\a', 'q', '\x2', '\x2', '\xB2', '\xB3', 
		'\a', 'x', '\x2', '\x2', '\xB3', '\xB4', '\a', 'k', '\x2', '\x2', '\xB4', 
		'\xB5', '\a', 'p', '\x2', '\x2', '\xB5', '\xC8', '\a', 'i', '\x2', '\x2', 
		'\xB6', '\xB7', '\a', 'u', '\x2', '\x2', '\xB7', '\xB8', '\a', 'v', '\x2', 
		'\x2', '\xB8', '\xB9', '\a', '\x63', '\x2', '\x2', '\xB9', '\xBA', '\a', 
		'v', '\x2', '\x2', '\xBA', '\xBB', '\a', 'k', '\x2', '\x2', '\xBB', '\xC8', 
		'\a', '\x65', '\x2', '\x2', '\xBC', '\xBD', '\a', 'x', '\x2', '\x2', '\xBD', 
		'\xBE', '\a', '\x63', '\x2', '\x2', '\xBE', '\xBF', '\a', 't', '\x2', 
		'\x2', '\xBF', '\xC0', '\a', 'k', '\x2', '\x2', '\xC0', '\xC1', '\a', 
		'g', '\x2', '\x2', '\xC1', '\xC8', '\a', '\x66', '\x2', '\x2', '\xC2', 
		'\xC3', '\a', '\x65', '\x2', '\x2', '\xC3', '\xC4', '\a', 'q', '\x2', 
		'\x2', '\xC4', '\xC5', '\a', 'o', '\x2', '\x2', '\xC5', '\xC6', '\a', 
		'\x64', '\x2', '\x2', '\xC6', '\xC8', '\a', 'q', '\x2', '\x2', '\xC7', 
		'\xB0', '\x3', '\x2', '\x2', '\x2', '\xC7', '\xB6', '\x3', '\x2', '\x2', 
		'\x2', '\xC7', '\xBC', '\x3', '\x2', '\x2', '\x2', '\xC7', '\xC2', '\x3', 
		'\x2', '\x2', '\x2', '\xC8', '\x1E', '\x3', '\x2', '\x2', '\x2', '\xC9', 
		'\xCB', '\a', '/', '\x2', '\x2', '\xCA', '\xC9', '\x3', '\x2', '\x2', 
		'\x2', '\xCA', '\xCB', '\x3', '\x2', '\x2', '\x2', '\xCB', '\xCD', '\x3', 
		'\x2', '\x2', '\x2', '\xCC', '\xCE', '\x4', '\x32', ';', '\x2', '\xCD', 
		'\xCC', '\x3', '\x2', '\x2', '\x2', '\xCE', '\xCF', '\x3', '\x2', '\x2', 
		'\x2', '\xCF', '\xCD', '\x3', '\x2', '\x2', '\x2', '\xCF', '\xD0', '\x3', 
		'\x2', '\x2', '\x2', '\xD0', ' ', '\x3', '\x2', '\x2', '\x2', '\xD1', 
		'\xD3', '\a', '\xF', '\x2', '\x2', '\xD2', '\xD1', '\x3', '\x2', '\x2', 
		'\x2', '\xD2', '\xD3', '\x3', '\x2', '\x2', '\x2', '\xD3', '\xD4', '\x3', 
		'\x2', '\x2', '\x2', '\xD4', '\xD5', '\a', '\f', '\x2', '\x2', '\xD5', 
		'\"', '\x3', '\x2', '\x2', '\x2', '\xD6', '\xD8', '\t', '\x2', '\x2', 
		'\x2', '\xD7', '\xD6', '\x3', '\x2', '\x2', '\x2', '\xD8', '\xD9', '\x3', 
		'\x2', '\x2', '\x2', '\xD9', '\xD7', '\x3', '\x2', '\x2', '\x2', '\xD9', 
		'\xDA', '\x3', '\x2', '\x2', '\x2', '\xDA', '\xDB', '\x3', '\x2', '\x2', 
		'\x2', '\xDB', '\xDC', '\b', '\x12', '\x2', '\x2', '\xDC', '$', '\x3', 
		'\x2', '\x2', '\x2', '\r', '\x2', ';', '\x61', 'w', '\xA0', '\xAE', '\xC7', 
		'\xCA', '\xCF', '\xD2', '\xD9', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
