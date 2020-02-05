// Generated from c:\Users\rcmcg\Documents\University\Year4\Honours\PracticalWork\Grammars\Prototype101\proto101.g4 by ANTLR 4.7.1
#pragma warning disable 3021
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class proto101Parser extends Parser {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		GAMETYPE=1, PC=2, NUM=3, SKILL=4, DUNGEON=5, PLATFORMER=6, SIZE=7, ENEMY=8, 
		ENEMYTYPE=9, START=10, FLATPATH=11, LOWPLATFORM=12, HIGHPLATFORM=13, PATHGAP=14, 
		FINISHLINE=15, INT=16, NEWLINE=17, WS=18;
	public static final int
		RULE_prog = 0, RULE_elem = 1, RULE_createGame = 2, RULE_createPlayer = 3, 
		RULE_createDungeon = 4, RULE_createEnemies = 5, RULE_addStartSegment = 6, 
		RULE_addFlatPathSegment = 7, RULE_addLowPlatformSegment = 8, RULE_addHighPlatformSegment = 9, 
		RULE_addPathGapSegment = 10, RULE_addFinishLineSegment = 11;
	public static final String[] ruleNames = {
		"prog", "elem", "createGame", "createPlayer", "createDungeon", "createEnemies", 
		"addStartSegment", "addFlatPathSegment", "addLowPlatformSegment", "addHighPlatformSegment", 
		"addPathGapSegment", "addFinishLineSegment"
	};

	private static final String[] _LITERAL_NAMES = {
		null, null, "'player'", null, null, "'dungeon'", "'platformer'", null, 
		"'enemy'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "GAMETYPE", "PC", "NUM", "SKILL", "DUNGEON", "PLATFORMER", "SIZE", 
		"ENEMY", "ENEMYTYPE", "START", "FLATPATH", "LOWPLATFORM", "HIGHPLATFORM", 
		"PATHGAP", "FINISHLINE", "INT", "NEWLINE", "WS"
	};
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "proto101.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }


		public PrototypeCompiler Compiler = new PrototypeCompiler(); //this will be the compiler file in the Unity project

	public proto101Parser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}
	public static class ProgContext extends ParserRuleContext {
		public List<ElemContext> elem() {
			return getRuleContexts(ElemContext.class);
		}
		public ElemContext elem(int i) {
			return getRuleContext(ElemContext.class,i);
		}
		public ProgContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_prog; }
	}

	public final ProgContext prog() throws RecognitionException {
		ProgContext _localctx = new ProgContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_prog);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(25); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(24);
				elem();
				}
				}
				setState(27); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << GAMETYPE) | (1L << PC) | (1L << DUNGEON) | (1L << ENEMY) | (1L << START) | (1L << FLATPATH) | (1L << LOWPLATFORM) | (1L << HIGHPLATFORM) | (1L << PATHGAP) | (1L << FINISHLINE))) != 0) );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ElemContext extends ParserRuleContext {
		public TerminalNode NEWLINE() { return getToken(proto101Parser.NEWLINE, 0); }
		public CreateGameContext createGame() {
			return getRuleContext(CreateGameContext.class,0);
		}
		public CreatePlayerContext createPlayer() {
			return getRuleContext(CreatePlayerContext.class,0);
		}
		public CreateDungeonContext createDungeon() {
			return getRuleContext(CreateDungeonContext.class,0);
		}
		public CreateEnemiesContext createEnemies() {
			return getRuleContext(CreateEnemiesContext.class,0);
		}
		public AddStartSegmentContext addStartSegment() {
			return getRuleContext(AddStartSegmentContext.class,0);
		}
		public AddFlatPathSegmentContext addFlatPathSegment() {
			return getRuleContext(AddFlatPathSegmentContext.class,0);
		}
		public AddLowPlatformSegmentContext addLowPlatformSegment() {
			return getRuleContext(AddLowPlatformSegmentContext.class,0);
		}
		public AddHighPlatformSegmentContext addHighPlatformSegment() {
			return getRuleContext(AddHighPlatformSegmentContext.class,0);
		}
		public AddPathGapSegmentContext addPathGapSegment() {
			return getRuleContext(AddPathGapSegmentContext.class,0);
		}
		public AddFinishLineSegmentContext addFinishLineSegment() {
			return getRuleContext(AddFinishLineSegmentContext.class,0);
		}
		public ElemContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_elem; }
	}

	public final ElemContext elem() throws RecognitionException {
		ElemContext _localctx = new ElemContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_elem);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(39);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case GAMETYPE:
				{
				setState(29);
				createGame();
				}
				break;
			case PC:
				{
				setState(30);
				createPlayer();
				}
				break;
			case DUNGEON:
				{
				setState(31);
				createDungeon();
				}
				break;
			case ENEMY:
				{
				setState(32);
				createEnemies();
				}
				break;
			case START:
				{
				setState(33);
				addStartSegment();
				}
				break;
			case FLATPATH:
				{
				setState(34);
				addFlatPathSegment();
				}
				break;
			case LOWPLATFORM:
				{
				setState(35);
				addLowPlatformSegment();
				}
				break;
			case HIGHPLATFORM:
				{
				setState(36);
				addHighPlatformSegment();
				}
				break;
			case PATHGAP:
				{
				setState(37);
				addPathGapSegment();
				}
				break;
			case FINISHLINE:
				{
				setState(38);
				addFinishLineSegment();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(41);
			match(NEWLINE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CreateGameContext extends ParserRuleContext {
		public Token GAMETYPE;
		public TerminalNode GAMETYPE() { return getToken(proto101Parser.GAMETYPE, 0); }
		public CreateGameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_createGame; }
	}

	public final CreateGameContext createGame() throws RecognitionException {
		CreateGameContext _localctx = new CreateGameContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_createGame);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(43);
			((CreateGameContext)_localctx).GAMETYPE = match(GAMETYPE);
			Compiler.CreateGame((((CreateGameContext)_localctx).GAMETYPE!=null?((CreateGameContext)_localctx).GAMETYPE.getText():null));
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CreatePlayerContext extends ParserRuleContext {
		public Token NUM;
		public TerminalNode PC() { return getToken(proto101Parser.PC, 0); }
		public TerminalNode NUM() { return getToken(proto101Parser.NUM, 0); }
		public CreatePlayerContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_createPlayer; }
	}

	public final CreatePlayerContext createPlayer() throws RecognitionException {
		CreatePlayerContext _localctx = new CreatePlayerContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_createPlayer);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(46);
			match(PC);
			setState(47);
			((CreatePlayerContext)_localctx).NUM = match(NUM);
			 Compiler.CreatePlayer((((CreatePlayerContext)_localctx).NUM!=null?((CreatePlayerContext)_localctx).NUM.getText():null)); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CreateDungeonContext extends ParserRuleContext {
		public Token SIZE;
		public TerminalNode DUNGEON() { return getToken(proto101Parser.DUNGEON, 0); }
		public TerminalNode SIZE() { return getToken(proto101Parser.SIZE, 0); }
		public CreateDungeonContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_createDungeon; }
	}

	public final CreateDungeonContext createDungeon() throws RecognitionException {
		CreateDungeonContext _localctx = new CreateDungeonContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_createDungeon);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(50);
			match(DUNGEON);
			setState(51);
			((CreateDungeonContext)_localctx).SIZE = match(SIZE);
			 Compiler.CreateDungeon((((CreateDungeonContext)_localctx).SIZE!=null?((CreateDungeonContext)_localctx).SIZE.getText():null)); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CreateEnemiesContext extends ParserRuleContext {
		public Token ENEMYTYPE;
		public Token NUM;
		public Token SKILL;
		public TerminalNode ENEMY() { return getToken(proto101Parser.ENEMY, 0); }
		public TerminalNode ENEMYTYPE() { return getToken(proto101Parser.ENEMYTYPE, 0); }
		public TerminalNode NUM() { return getToken(proto101Parser.NUM, 0); }
		public TerminalNode SKILL() { return getToken(proto101Parser.SKILL, 0); }
		public CreateEnemiesContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_createEnemies; }
	}

	public final CreateEnemiesContext createEnemies() throws RecognitionException {
		CreateEnemiesContext _localctx = new CreateEnemiesContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_createEnemies);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(54);
			match(ENEMY);
			setState(55);
			((CreateEnemiesContext)_localctx).ENEMYTYPE = match(ENEMYTYPE);
			setState(56);
			((CreateEnemiesContext)_localctx).NUM = match(NUM);
			setState(57);
			((CreateEnemiesContext)_localctx).SKILL = match(SKILL);
			 Compiler.CreateEnemy((((CreateEnemiesContext)_localctx).ENEMYTYPE!=null?((CreateEnemiesContext)_localctx).ENEMYTYPE.getText():null), (((CreateEnemiesContext)_localctx).NUM!=null?((CreateEnemiesContext)_localctx).NUM.getText():null), (((CreateEnemiesContext)_localctx).SKILL!=null?((CreateEnemiesContext)_localctx).SKILL.getText():null)); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AddStartSegmentContext extends ParserRuleContext {
		public TerminalNode START() { return getToken(proto101Parser.START, 0); }
		public AddStartSegmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addStartSegment; }
	}

	public final AddStartSegmentContext addStartSegment() throws RecognitionException {
		AddStartSegmentContext _localctx = new AddStartSegmentContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_addStartSegment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(60);
			match(START);
			 Compiler.CreatePathStart(); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AddFlatPathSegmentContext extends ParserRuleContext {
		public TerminalNode FLATPATH() { return getToken(proto101Parser.FLATPATH, 0); }
		public AddFlatPathSegmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addFlatPathSegment; }
	}

	public final AddFlatPathSegmentContext addFlatPathSegment() throws RecognitionException {
		AddFlatPathSegmentContext _localctx = new AddFlatPathSegmentContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_addFlatPathSegment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(63);
			match(FLATPATH);
			 Compiler.CreateFlatPath(); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AddLowPlatformSegmentContext extends ParserRuleContext {
		public TerminalNode LOWPLATFORM() { return getToken(proto101Parser.LOWPLATFORM, 0); }
		public AddLowPlatformSegmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addLowPlatformSegment; }
	}

	public final AddLowPlatformSegmentContext addLowPlatformSegment() throws RecognitionException {
		AddLowPlatformSegmentContext _localctx = new AddLowPlatformSegmentContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_addLowPlatformSegment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(66);
			match(LOWPLATFORM);
			 Compiler.CreateLowPlatform(); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AddHighPlatformSegmentContext extends ParserRuleContext {
		public TerminalNode HIGHPLATFORM() { return getToken(proto101Parser.HIGHPLATFORM, 0); }
		public AddHighPlatformSegmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addHighPlatformSegment; }
	}

	public final AddHighPlatformSegmentContext addHighPlatformSegment() throws RecognitionException {
		AddHighPlatformSegmentContext _localctx = new AddHighPlatformSegmentContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_addHighPlatformSegment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(69);
			match(HIGHPLATFORM);
			 Compiler.CreateHighPlatform(); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AddPathGapSegmentContext extends ParserRuleContext {
		public TerminalNode PATHGAP() { return getToken(proto101Parser.PATHGAP, 0); }
		public AddPathGapSegmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addPathGapSegment; }
	}

	public final AddPathGapSegmentContext addPathGapSegment() throws RecognitionException {
		AddPathGapSegmentContext _localctx = new AddPathGapSegmentContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_addPathGapSegment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(72);
			match(PATHGAP);
			 Compiler.CreatePathGap(); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AddFinishLineSegmentContext extends ParserRuleContext {
		public TerminalNode FINISHLINE() { return getToken(proto101Parser.FINISHLINE, 0); }
		public AddFinishLineSegmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addFinishLineSegment; }
	}

	public final AddFinishLineSegmentContext addFinishLineSegment() throws RecognitionException {
		AddFinishLineSegmentContext _localctx = new AddFinishLineSegmentContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_addFinishLineSegment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(75);
			match(FINISHLINE);
			 Compiler.CreateFinishLine(); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\24Q\4\2\t\2\4\3\t"+
		"\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t\13\4"+
		"\f\t\f\4\r\t\r\3\2\6\2\34\n\2\r\2\16\2\35\3\3\3\3\3\3\3\3\3\3\3\3\3\3"+
		"\3\3\3\3\3\3\5\3*\n\3\3\3\3\3\3\4\3\4\3\4\3\5\3\5\3\5\3\5\3\6\3\6\3\6"+
		"\3\6\3\7\3\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\t\3\t\3\t\3\n\3\n\3\n\3\13"+
		"\3\13\3\13\3\f\3\f\3\f\3\r\3\r\3\r\3\r\2\2\16\2\4\6\b\n\f\16\20\22\24"+
		"\26\30\2\2\2N\2\33\3\2\2\2\4)\3\2\2\2\6-\3\2\2\2\b\60\3\2\2\2\n\64\3\2"+
		"\2\2\f8\3\2\2\2\16>\3\2\2\2\20A\3\2\2\2\22D\3\2\2\2\24G\3\2\2\2\26J\3"+
		"\2\2\2\30M\3\2\2\2\32\34\5\4\3\2\33\32\3\2\2\2\34\35\3\2\2\2\35\33\3\2"+
		"\2\2\35\36\3\2\2\2\36\3\3\2\2\2\37*\5\6\4\2 *\5\b\5\2!*\5\n\6\2\"*\5\f"+
		"\7\2#*\5\16\b\2$*\5\20\t\2%*\5\22\n\2&*\5\24\13\2\'*\5\26\f\2(*\5\30\r"+
		"\2)\37\3\2\2\2) \3\2\2\2)!\3\2\2\2)\"\3\2\2\2)#\3\2\2\2)$\3\2\2\2)%\3"+
		"\2\2\2)&\3\2\2\2)\'\3\2\2\2)(\3\2\2\2*+\3\2\2\2+,\7\23\2\2,\5\3\2\2\2"+
		"-.\7\3\2\2./\b\4\1\2/\7\3\2\2\2\60\61\7\4\2\2\61\62\7\5\2\2\62\63\b\5"+
		"\1\2\63\t\3\2\2\2\64\65\7\7\2\2\65\66\7\t\2\2\66\67\b\6\1\2\67\13\3\2"+
		"\2\289\7\n\2\29:\7\13\2\2:;\7\5\2\2;<\7\6\2\2<=\b\7\1\2=\r\3\2\2\2>?\7"+
		"\f\2\2?@\b\b\1\2@\17\3\2\2\2AB\7\r\2\2BC\b\t\1\2C\21\3\2\2\2DE\7\16\2"+
		"\2EF\b\n\1\2F\23\3\2\2\2GH\7\17\2\2HI\b\13\1\2I\25\3\2\2\2JK\7\20\2\2"+
		"KL\b\f\1\2L\27\3\2\2\2MN\7\21\2\2NO\b\r\1\2O\31\3\2\2\2\4\35)";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}