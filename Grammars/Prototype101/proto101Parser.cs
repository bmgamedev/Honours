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
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class proto101Parser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		GAMETYPE=1, PC=2, NUM=3, SKILL=4, DUNGEON=5, PLATFORMER=6, SIZE=7, ENEMY=8, 
		ENEMYTYPE=9, START=10, FLATPATH=11, LOWPLATFORM=12, HIGHPLATFORM=13, PATHGAP=14, 
		FINISHLINE=15, INT=16, NEWLINE=17, WS=18;
	public const int
		RULE_prog = 0, RULE_elem = 1, RULE_createGame = 2, RULE_createPlayer = 3, 
		RULE_createDungeon = 4, RULE_createEnemies = 5, RULE_addStartSegment = 6, 
		RULE_addFlatPathSegment = 7, RULE_addLowPlatformSegment = 8, RULE_addHighPlatformSegment = 9, 
		RULE_addPathGapSegment = 10, RULE_addFinishLineSegment = 11;
	public static readonly string[] ruleNames = {
		"prog", "elem", "createGame", "createPlayer", "createDungeon", "createEnemies", 
		"addStartSegment", "addFlatPathSegment", "addLowPlatformSegment", "addHighPlatformSegment", 
		"addPathGapSegment", "addFinishLineSegment"
	};

	private static readonly string[] _LiteralNames = {
		null, null, "'player'", null, null, "'dungeon'", "'platformer'", null, 
		"'enemy'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "GAMETYPE", "PC", "NUM", "SKILL", "DUNGEON", "PLATFORMER", "SIZE", 
		"ENEMY", "ENEMYTYPE", "START", "FLATPATH", "LOWPLATFORM", "HIGHPLATFORM", 
		"PATHGAP", "FINISHLINE", "INT", "NEWLINE", "WS"
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

	public override string GrammarFileName { get { return "proto101.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static proto101Parser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}


		public PrototypeCompiler Compiler = new PrototypeCompiler(); //this will be the compiler file in the Unity project

		public proto101Parser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public proto101Parser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class ProgContext : ParserRuleContext {
		public ElemContext[] elem() {
			return GetRuleContexts<ElemContext>();
		}
		public ElemContext elem(int i) {
			return GetRuleContext<ElemContext>(i);
		}
		public ProgContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_prog; } }
		public override void EnterRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.EnterProg(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.ExitProg(this);
		}
	}

	[RuleVersion(0)]
	public ProgContext prog() {
		ProgContext _localctx = new ProgContext(Context, State);
		EnterRule(_localctx, 0, RULE_prog);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 25;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 24; elem();
				}
				}
				State = 27;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << GAMETYPE) | (1L << PC) | (1L << DUNGEON) | (1L << ENEMY) | (1L << START) | (1L << FLATPATH) | (1L << LOWPLATFORM) | (1L << HIGHPLATFORM) | (1L << PATHGAP) | (1L << FINISHLINE))) != 0) );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ElemContext : ParserRuleContext {
		public ITerminalNode NEWLINE() { return GetToken(proto101Parser.NEWLINE, 0); }
		public CreateGameContext createGame() {
			return GetRuleContext<CreateGameContext>(0);
		}
		public CreatePlayerContext createPlayer() {
			return GetRuleContext<CreatePlayerContext>(0);
		}
		public CreateDungeonContext createDungeon() {
			return GetRuleContext<CreateDungeonContext>(0);
		}
		public CreateEnemiesContext createEnemies() {
			return GetRuleContext<CreateEnemiesContext>(0);
		}
		public AddStartSegmentContext addStartSegment() {
			return GetRuleContext<AddStartSegmentContext>(0);
		}
		public AddFlatPathSegmentContext addFlatPathSegment() {
			return GetRuleContext<AddFlatPathSegmentContext>(0);
		}
		public AddLowPlatformSegmentContext addLowPlatformSegment() {
			return GetRuleContext<AddLowPlatformSegmentContext>(0);
		}
		public AddHighPlatformSegmentContext addHighPlatformSegment() {
			return GetRuleContext<AddHighPlatformSegmentContext>(0);
		}
		public AddPathGapSegmentContext addPathGapSegment() {
			return GetRuleContext<AddPathGapSegmentContext>(0);
		}
		public AddFinishLineSegmentContext addFinishLineSegment() {
			return GetRuleContext<AddFinishLineSegmentContext>(0);
		}
		public ElemContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_elem; } }
		public override void EnterRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.EnterElem(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.ExitElem(this);
		}
	}

	[RuleVersion(0)]
	public ElemContext elem() {
		ElemContext _localctx = new ElemContext(Context, State);
		EnterRule(_localctx, 2, RULE_elem);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 39;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case GAMETYPE:
				{
				State = 29; createGame();
				}
				break;
			case PC:
				{
				State = 30; createPlayer();
				}
				break;
			case DUNGEON:
				{
				State = 31; createDungeon();
				}
				break;
			case ENEMY:
				{
				State = 32; createEnemies();
				}
				break;
			case START:
				{
				State = 33; addStartSegment();
				}
				break;
			case FLATPATH:
				{
				State = 34; addFlatPathSegment();
				}
				break;
			case LOWPLATFORM:
				{
				State = 35; addLowPlatformSegment();
				}
				break;
			case HIGHPLATFORM:
				{
				State = 36; addHighPlatformSegment();
				}
				break;
			case PATHGAP:
				{
				State = 37; addPathGapSegment();
				}
				break;
			case FINISHLINE:
				{
				State = 38; addFinishLineSegment();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			State = 41; Match(NEWLINE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class CreateGameContext : ParserRuleContext {
		public IToken _GAMETYPE;
		public ITerminalNode GAMETYPE() { return GetToken(proto101Parser.GAMETYPE, 0); }
		public CreateGameContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_createGame; } }
		public override void EnterRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.EnterCreateGame(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.ExitCreateGame(this);
		}
	}

	[RuleVersion(0)]
	public CreateGameContext createGame() {
		CreateGameContext _localctx = new CreateGameContext(Context, State);
		EnterRule(_localctx, 4, RULE_createGame);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 43; _localctx._GAMETYPE = Match(GAMETYPE);
			Compiler.CreateGame((_localctx._GAMETYPE!=null?_localctx._GAMETYPE.Text:null));
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class CreatePlayerContext : ParserRuleContext {
		public IToken _NUM;
		public ITerminalNode PC() { return GetToken(proto101Parser.PC, 0); }
		public ITerminalNode NUM() { return GetToken(proto101Parser.NUM, 0); }
		public CreatePlayerContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_createPlayer; } }
		public override void EnterRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.EnterCreatePlayer(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.ExitCreatePlayer(this);
		}
	}

	[RuleVersion(0)]
	public CreatePlayerContext createPlayer() {
		CreatePlayerContext _localctx = new CreatePlayerContext(Context, State);
		EnterRule(_localctx, 6, RULE_createPlayer);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 46; Match(PC);
			State = 47; _localctx._NUM = Match(NUM);
			 Compiler.CreatePlayer((_localctx._NUM!=null?_localctx._NUM.Text:null)); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class CreateDungeonContext : ParserRuleContext {
		public IToken _SIZE;
		public ITerminalNode DUNGEON() { return GetToken(proto101Parser.DUNGEON, 0); }
		public ITerminalNode SIZE() { return GetToken(proto101Parser.SIZE, 0); }
		public CreateDungeonContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_createDungeon; } }
		public override void EnterRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.EnterCreateDungeon(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.ExitCreateDungeon(this);
		}
	}

	[RuleVersion(0)]
	public CreateDungeonContext createDungeon() {
		CreateDungeonContext _localctx = new CreateDungeonContext(Context, State);
		EnterRule(_localctx, 8, RULE_createDungeon);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 50; Match(DUNGEON);
			State = 51; _localctx._SIZE = Match(SIZE);
			 Compiler.CreateDungeon((_localctx._SIZE!=null?_localctx._SIZE.Text:null)); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class CreateEnemiesContext : ParserRuleContext {
		public IToken _ENEMYTYPE;
		public IToken _NUM;
		public IToken _SKILL;
		public ITerminalNode ENEMY() { return GetToken(proto101Parser.ENEMY, 0); }
		public ITerminalNode ENEMYTYPE() { return GetToken(proto101Parser.ENEMYTYPE, 0); }
		public ITerminalNode NUM() { return GetToken(proto101Parser.NUM, 0); }
		public ITerminalNode SKILL() { return GetToken(proto101Parser.SKILL, 0); }
		public CreateEnemiesContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_createEnemies; } }
		public override void EnterRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.EnterCreateEnemies(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.ExitCreateEnemies(this);
		}
	}

	[RuleVersion(0)]
	public CreateEnemiesContext createEnemies() {
		CreateEnemiesContext _localctx = new CreateEnemiesContext(Context, State);
		EnterRule(_localctx, 10, RULE_createEnemies);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 54; Match(ENEMY);
			State = 55; _localctx._ENEMYTYPE = Match(ENEMYTYPE);
			State = 56; _localctx._NUM = Match(NUM);
			State = 57; _localctx._SKILL = Match(SKILL);
			 Compiler.CreateEnemy((_localctx._ENEMYTYPE!=null?_localctx._ENEMYTYPE.Text:null), (_localctx._NUM!=null?_localctx._NUM.Text:null), (_localctx._SKILL!=null?_localctx._SKILL.Text:null)); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AddStartSegmentContext : ParserRuleContext {
		public ITerminalNode START() { return GetToken(proto101Parser.START, 0); }
		public AddStartSegmentContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_addStartSegment; } }
		public override void EnterRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.EnterAddStartSegment(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.ExitAddStartSegment(this);
		}
	}

	[RuleVersion(0)]
	public AddStartSegmentContext addStartSegment() {
		AddStartSegmentContext _localctx = new AddStartSegmentContext(Context, State);
		EnterRule(_localctx, 12, RULE_addStartSegment);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 60; Match(START);
			 Compiler.CreatePathStart(); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AddFlatPathSegmentContext : ParserRuleContext {
		public ITerminalNode FLATPATH() { return GetToken(proto101Parser.FLATPATH, 0); }
		public AddFlatPathSegmentContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_addFlatPathSegment; } }
		public override void EnterRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.EnterAddFlatPathSegment(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.ExitAddFlatPathSegment(this);
		}
	}

	[RuleVersion(0)]
	public AddFlatPathSegmentContext addFlatPathSegment() {
		AddFlatPathSegmentContext _localctx = new AddFlatPathSegmentContext(Context, State);
		EnterRule(_localctx, 14, RULE_addFlatPathSegment);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 63; Match(FLATPATH);
			 Compiler.CreateFlatPath(); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AddLowPlatformSegmentContext : ParserRuleContext {
		public ITerminalNode LOWPLATFORM() { return GetToken(proto101Parser.LOWPLATFORM, 0); }
		public AddLowPlatformSegmentContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_addLowPlatformSegment; } }
		public override void EnterRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.EnterAddLowPlatformSegment(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.ExitAddLowPlatformSegment(this);
		}
	}

	[RuleVersion(0)]
	public AddLowPlatformSegmentContext addLowPlatformSegment() {
		AddLowPlatformSegmentContext _localctx = new AddLowPlatformSegmentContext(Context, State);
		EnterRule(_localctx, 16, RULE_addLowPlatformSegment);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 66; Match(LOWPLATFORM);
			 Compiler.CreateLowPlatform(); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AddHighPlatformSegmentContext : ParserRuleContext {
		public ITerminalNode HIGHPLATFORM() { return GetToken(proto101Parser.HIGHPLATFORM, 0); }
		public AddHighPlatformSegmentContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_addHighPlatformSegment; } }
		public override void EnterRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.EnterAddHighPlatformSegment(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.ExitAddHighPlatformSegment(this);
		}
	}

	[RuleVersion(0)]
	public AddHighPlatformSegmentContext addHighPlatformSegment() {
		AddHighPlatformSegmentContext _localctx = new AddHighPlatformSegmentContext(Context, State);
		EnterRule(_localctx, 18, RULE_addHighPlatformSegment);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 69; Match(HIGHPLATFORM);
			 Compiler.CreateHighPlatform(); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AddPathGapSegmentContext : ParserRuleContext {
		public ITerminalNode PATHGAP() { return GetToken(proto101Parser.PATHGAP, 0); }
		public AddPathGapSegmentContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_addPathGapSegment; } }
		public override void EnterRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.EnterAddPathGapSegment(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.ExitAddPathGapSegment(this);
		}
	}

	[RuleVersion(0)]
	public AddPathGapSegmentContext addPathGapSegment() {
		AddPathGapSegmentContext _localctx = new AddPathGapSegmentContext(Context, State);
		EnterRule(_localctx, 20, RULE_addPathGapSegment);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 72; Match(PATHGAP);
			 Compiler.CreatePathGap(); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AddFinishLineSegmentContext : ParserRuleContext {
		public ITerminalNode FINISHLINE() { return GetToken(proto101Parser.FINISHLINE, 0); }
		public AddFinishLineSegmentContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_addFinishLineSegment; } }
		public override void EnterRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.EnterAddFinishLineSegment(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			Iproto101Listener typedListener = listener as Iproto101Listener;
			if (typedListener != null) typedListener.ExitAddFinishLineSegment(this);
		}
	}

	[RuleVersion(0)]
	public AddFinishLineSegmentContext addFinishLineSegment() {
		AddFinishLineSegmentContext _localctx = new AddFinishLineSegmentContext(Context, State);
		EnterRule(_localctx, 22, RULE_addFinishLineSegment);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 75; Match(FINISHLINE);
			 Compiler.CreateFinishLine(); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\x14', 'Q', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', '\b', 
		'\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', '\t', '\v', 
		'\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x3', '\x2', '\x6', 
		'\x2', '\x1C', '\n', '\x2', '\r', '\x2', '\xE', '\x2', '\x1D', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x5', 
		'\x3', '*', '\n', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', 
		'\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', 
		'\t', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', 
		'\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', 
		'\r', '\x3', '\r', '\x3', '\r', '\x2', '\x2', '\xE', '\x2', '\x4', '\x6', 
		'\b', '\n', '\f', '\xE', '\x10', '\x12', '\x14', '\x16', '\x18', '\x2', 
		'\x2', '\x2', 'N', '\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x4', ')', 
		'\x3', '\x2', '\x2', '\x2', '\x6', '-', '\x3', '\x2', '\x2', '\x2', '\b', 
		'\x30', '\x3', '\x2', '\x2', '\x2', '\n', '\x34', '\x3', '\x2', '\x2', 
		'\x2', '\f', '\x38', '\x3', '\x2', '\x2', '\x2', '\xE', '>', '\x3', '\x2', 
		'\x2', '\x2', '\x10', '\x41', '\x3', '\x2', '\x2', '\x2', '\x12', '\x44', 
		'\x3', '\x2', '\x2', '\x2', '\x14', 'G', '\x3', '\x2', '\x2', '\x2', '\x16', 
		'J', '\x3', '\x2', '\x2', '\x2', '\x18', 'M', '\x3', '\x2', '\x2', '\x2', 
		'\x1A', '\x1C', '\x5', '\x4', '\x3', '\x2', '\x1B', '\x1A', '\x3', '\x2', 
		'\x2', '\x2', '\x1C', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x1D', '\x1B', 
		'\x3', '\x2', '\x2', '\x2', '\x1D', '\x1E', '\x3', '\x2', '\x2', '\x2', 
		'\x1E', '\x3', '\x3', '\x2', '\x2', '\x2', '\x1F', '*', '\x5', '\x6', 
		'\x4', '\x2', ' ', '*', '\x5', '\b', '\x5', '\x2', '!', '*', '\x5', '\n', 
		'\x6', '\x2', '\"', '*', '\x5', '\f', '\a', '\x2', '#', '*', '\x5', '\xE', 
		'\b', '\x2', '$', '*', '\x5', '\x10', '\t', '\x2', '%', '*', '\x5', '\x12', 
		'\n', '\x2', '&', '*', '\x5', '\x14', '\v', '\x2', '\'', '*', '\x5', '\x16', 
		'\f', '\x2', '(', '*', '\x5', '\x18', '\r', '\x2', ')', '\x1F', '\x3', 
		'\x2', '\x2', '\x2', ')', ' ', '\x3', '\x2', '\x2', '\x2', ')', '!', '\x3', 
		'\x2', '\x2', '\x2', ')', '\"', '\x3', '\x2', '\x2', '\x2', ')', '#', 
		'\x3', '\x2', '\x2', '\x2', ')', '$', '\x3', '\x2', '\x2', '\x2', ')', 
		'%', '\x3', '\x2', '\x2', '\x2', ')', '&', '\x3', '\x2', '\x2', '\x2', 
		')', '\'', '\x3', '\x2', '\x2', '\x2', ')', '(', '\x3', '\x2', '\x2', 
		'\x2', '*', '+', '\x3', '\x2', '\x2', '\x2', '+', ',', '\a', '\x13', '\x2', 
		'\x2', ',', '\x5', '\x3', '\x2', '\x2', '\x2', '-', '.', '\a', '\x3', 
		'\x2', '\x2', '.', '/', '\b', '\x4', '\x1', '\x2', '/', '\a', '\x3', '\x2', 
		'\x2', '\x2', '\x30', '\x31', '\a', '\x4', '\x2', '\x2', '\x31', '\x32', 
		'\a', '\x5', '\x2', '\x2', '\x32', '\x33', '\b', '\x5', '\x1', '\x2', 
		'\x33', '\t', '\x3', '\x2', '\x2', '\x2', '\x34', '\x35', '\a', '\a', 
		'\x2', '\x2', '\x35', '\x36', '\a', '\t', '\x2', '\x2', '\x36', '\x37', 
		'\b', '\x6', '\x1', '\x2', '\x37', '\v', '\x3', '\x2', '\x2', '\x2', '\x38', 
		'\x39', '\a', '\n', '\x2', '\x2', '\x39', ':', '\a', '\v', '\x2', '\x2', 
		':', ';', '\a', '\x5', '\x2', '\x2', ';', '<', '\a', '\x6', '\x2', '\x2', 
		'<', '=', '\b', '\a', '\x1', '\x2', '=', '\r', '\x3', '\x2', '\x2', '\x2', 
		'>', '?', '\a', '\f', '\x2', '\x2', '?', '@', '\b', '\b', '\x1', '\x2', 
		'@', '\xF', '\x3', '\x2', '\x2', '\x2', '\x41', '\x42', '\a', '\r', '\x2', 
		'\x2', '\x42', '\x43', '\b', '\t', '\x1', '\x2', '\x43', '\x11', '\x3', 
		'\x2', '\x2', '\x2', '\x44', '\x45', '\a', '\xE', '\x2', '\x2', '\x45', 
		'\x46', '\b', '\n', '\x1', '\x2', '\x46', '\x13', '\x3', '\x2', '\x2', 
		'\x2', 'G', 'H', '\a', '\xF', '\x2', '\x2', 'H', 'I', '\b', '\v', '\x1', 
		'\x2', 'I', '\x15', '\x3', '\x2', '\x2', '\x2', 'J', 'K', '\a', '\x10', 
		'\x2', '\x2', 'K', 'L', '\b', '\f', '\x1', '\x2', 'L', '\x17', '\x3', 
		'\x2', '\x2', '\x2', 'M', 'N', '\a', '\x11', '\x2', '\x2', 'N', 'O', '\b', 
		'\r', '\x1', '\x2', 'O', '\x19', '\x3', '\x2', '\x2', '\x2', '\x4', '\x1D', 
		')',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
