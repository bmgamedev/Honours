// Generated from c:\Users\rcmcg\Documents\University\Year4\Honours\PracticalWork\Grammars\GameSetup\GameSetup.g4 by ANTLR 4.7.1
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
public class GameSetupParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		INITIALISE=1, FINALISE=2, GAMETYPE=3, PC=4, NUM=5, DIFFICULTY=6, SKILLLEVEL=7, 
		SKILLSET=8, DUNGEON=9, PLATFORMER=10, MAP=11, SIZE=12, ENEMY=13, ATTACKSTYLE=14, 
		INT=15, NEWLINE=16, WS=17;
	public static final int
		RULE_prog = 0, RULE_elem = 1, RULE_initialiseGame = 2, RULE_defineGame = 3, 
		RULE_createPlayer = 4, RULE_createEnemies = 5, RULE_finishGameSetup = 6;
	public static final String[] ruleNames = {
		"prog", "elem", "initialiseGame", "defineGame", "createPlayer", "createEnemies", 
		"finishGameSetup"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'initialise'", "'finalise'", null, "'players'", null, "'difficulty'", 
		null, null, "'dungeon'", "'platformer'", "'map'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "INITIALISE", "FINALISE", "GAMETYPE", "PC", "NUM", "DIFFICULTY", 
		"SKILLLEVEL", "SKILLSET", "DUNGEON", "PLATFORMER", "MAP", "SIZE", "ENEMY", 
		"ATTACKSTYLE", "INT", "NEWLINE", "WS"
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
	public String getGrammarFileName() { return "GameSetup.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }


		public GameCompiler Compiler = new GameCompiler(); //this will be the compiler file in the Unity project

	public GameSetupParser(TokenStream input) {
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
			setState(15); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(14);
				elem();
				}
				}
				setState(17); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INITIALISE) | (1L << FINALISE) | (1L << GAMETYPE) | (1L << PC) | (1L << ATTACKSTYLE))) != 0) );
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
		public TerminalNode NEWLINE() { return getToken(GameSetupParser.NEWLINE, 0); }
		public InitialiseGameContext initialiseGame() {
			return getRuleContext(InitialiseGameContext.class,0);
		}
		public DefineGameContext defineGame() {
			return getRuleContext(DefineGameContext.class,0);
		}
		public CreatePlayerContext createPlayer() {
			return getRuleContext(CreatePlayerContext.class,0);
		}
		public CreateEnemiesContext createEnemies() {
			return getRuleContext(CreateEnemiesContext.class,0);
		}
		public FinishGameSetupContext finishGameSetup() {
			return getRuleContext(FinishGameSetupContext.class,0);
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
			setState(24);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INITIALISE:
				{
				setState(19);
				initialiseGame();
				}
				break;
			case GAMETYPE:
				{
				setState(20);
				defineGame();
				}
				break;
			case PC:
				{
				setState(21);
				createPlayer();
				}
				break;
			case ATTACKSTYLE:
				{
				setState(22);
				createEnemies();
				}
				break;
			case FINALISE:
				{
				setState(23);
				finishGameSetup();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(26);
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

	public static class InitialiseGameContext extends ParserRuleContext {
		public TerminalNode INITIALISE() { return getToken(GameSetupParser.INITIALISE, 0); }
		public InitialiseGameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_initialiseGame; }
	}

	public final InitialiseGameContext initialiseGame() throws RecognitionException {
		InitialiseGameContext _localctx = new InitialiseGameContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_initialiseGame);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(28);
			match(INITIALISE);
			 Compiler.InitialiseGame(); 
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

	public static class DefineGameContext extends ParserRuleContext {
		public Token GAMETYPE;
		public Token SKILLLEVEL;
		public Token SIZE;
		public TerminalNode GAMETYPE() { return getToken(GameSetupParser.GAMETYPE, 0); }
		public TerminalNode SKILLLEVEL() { return getToken(GameSetupParser.SKILLLEVEL, 0); }
		public TerminalNode DIFFICULTY() { return getToken(GameSetupParser.DIFFICULTY, 0); }
		public TerminalNode SIZE() { return getToken(GameSetupParser.SIZE, 0); }
		public DefineGameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_defineGame; }
	}

	public final DefineGameContext defineGame() throws RecognitionException {
		DefineGameContext _localctx = new DefineGameContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_defineGame);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(31);
			((DefineGameContext)_localctx).GAMETYPE = match(GAMETYPE);
			setState(32);
			((DefineGameContext)_localctx).SKILLLEVEL = match(SKILLLEVEL);
			setState(33);
			match(DIFFICULTY);
			setState(34);
			((DefineGameContext)_localctx).SIZE = match(SIZE);
			 Compiler.DefineGame((((DefineGameContext)_localctx).GAMETYPE!=null?((DefineGameContext)_localctx).GAMETYPE.getText():null), (((DefineGameContext)_localctx).SKILLLEVEL!=null?((DefineGameContext)_localctx).SKILLLEVEL.getText():null), (((DefineGameContext)_localctx).SIZE!=null?((DefineGameContext)_localctx).SIZE.getText():null)); 
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
		public TerminalNode PC() { return getToken(GameSetupParser.PC, 0); }
		public TerminalNode NUM() { return getToken(GameSetupParser.NUM, 0); }
		public CreatePlayerContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_createPlayer; }
	}

	public final CreatePlayerContext createPlayer() throws RecognitionException {
		CreatePlayerContext _localctx = new CreatePlayerContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_createPlayer);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(37);
			match(PC);
			setState(38);
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

	public static class CreateEnemiesContext extends ParserRuleContext {
		public Token ATTACKSTYLE;
		public TerminalNode ATTACKSTYLE() { return getToken(GameSetupParser.ATTACKSTYLE, 0); }
		public TerminalNode ENEMY() { return getToken(GameSetupParser.ENEMY, 0); }
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
			setState(41);
			((CreateEnemiesContext)_localctx).ATTACKSTYLE = match(ATTACKSTYLE);
			setState(42);
			match(ENEMY);
			 Compiler.CreateEnemy((((CreateEnemiesContext)_localctx).ATTACKSTYLE!=null?((CreateEnemiesContext)_localctx).ATTACKSTYLE.getText():null)); 
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

	public static class FinishGameSetupContext extends ParserRuleContext {
		public TerminalNode FINALISE() { return getToken(GameSetupParser.FINALISE, 0); }
		public FinishGameSetupContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_finishGameSetup; }
	}

	public final FinishGameSetupContext finishGameSetup() throws RecognitionException {
		FinishGameSetupContext _localctx = new FinishGameSetupContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_finishGameSetup);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(45);
			match(FINALISE);
			 Compiler.FinishSetup(); 
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\23\63\4\2\t\2\4\3"+
		"\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\3\2\6\2\22\n\2\r\2\16\2\23"+
		"\3\3\3\3\3\3\3\3\3\3\5\3\33\n\3\3\3\3\3\3\4\3\4\3\4\3\5\3\5\3\5\3\5\3"+
		"\5\3\5\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\2\2\t\2\4\6\b\n"+
		"\f\16\2\2\2\60\2\21\3\2\2\2\4\32\3\2\2\2\6\36\3\2\2\2\b!\3\2\2\2\n\'\3"+
		"\2\2\2\f+\3\2\2\2\16/\3\2\2\2\20\22\5\4\3\2\21\20\3\2\2\2\22\23\3\2\2"+
		"\2\23\21\3\2\2\2\23\24\3\2\2\2\24\3\3\2\2\2\25\33\5\6\4\2\26\33\5\b\5"+
		"\2\27\33\5\n\6\2\30\33\5\f\7\2\31\33\5\16\b\2\32\25\3\2\2\2\32\26\3\2"+
		"\2\2\32\27\3\2\2\2\32\30\3\2\2\2\32\31\3\2\2\2\33\34\3\2\2\2\34\35\7\22"+
		"\2\2\35\5\3\2\2\2\36\37\7\3\2\2\37 \b\4\1\2 \7\3\2\2\2!\"\7\5\2\2\"#\7"+
		"\t\2\2#$\7\b\2\2$%\7\16\2\2%&\b\5\1\2&\t\3\2\2\2\'(\7\6\2\2()\7\7\2\2"+
		")*\b\6\1\2*\13\3\2\2\2+,\7\20\2\2,-\7\17\2\2-.\b\7\1\2.\r\3\2\2\2/\60"+
		"\7\4\2\2\60\61\b\b\1\2\61\17\3\2\2\2\4\23\32";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}