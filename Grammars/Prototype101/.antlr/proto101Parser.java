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
		PC=1, NUM=2, SKILL=3, MAP=4, SIZE=5, ENEMY=6, TYPE=7, INT=8, NEWLINE=9, 
		WS=10;
	public static final int
		RULE_prog = 0, RULE_elem = 1, RULE_createPlayer = 2, RULE_createMap = 3, 
		RULE_createEnemies = 4;
	public static final String[] ruleNames = {
		"prog", "elem", "createPlayer", "createMap", "createEnemies"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'player'", null, null, "'map'", null, "'enemy'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "PC", "NUM", "SKILL", "MAP", "SIZE", "ENEMY", "TYPE", "INT", "NEWLINE", 
		"WS"
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
			setState(11); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(10);
				elem();
				}
				}
				setState(13); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << PC) | (1L << MAP) | (1L << ENEMY))) != 0) );
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
		public CreatePlayerContext createPlayer() {
			return getRuleContext(CreatePlayerContext.class,0);
		}
		public CreateMapContext createMap() {
			return getRuleContext(CreateMapContext.class,0);
		}
		public CreateEnemiesContext createEnemies() {
			return getRuleContext(CreateEnemiesContext.class,0);
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
			setState(18);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case PC:
				{
				setState(15);
				createPlayer();
				}
				break;
			case MAP:
				{
				setState(16);
				createMap();
				}
				break;
			case ENEMY:
				{
				setState(17);
				createEnemies();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(20);
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
		enterRule(_localctx, 4, RULE_createPlayer);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(22);
			match(PC);
			setState(23);
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

	public static class CreateMapContext extends ParserRuleContext {
		public Token SIZE;
		public TerminalNode MAP() { return getToken(proto101Parser.MAP, 0); }
		public TerminalNode SIZE() { return getToken(proto101Parser.SIZE, 0); }
		public CreateMapContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_createMap; }
	}

	public final CreateMapContext createMap() throws RecognitionException {
		CreateMapContext _localctx = new CreateMapContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_createMap);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(26);
			match(MAP);
			setState(27);
			((CreateMapContext)_localctx).SIZE = match(SIZE);
			 Compiler.CreateMap((((CreateMapContext)_localctx).SIZE!=null?((CreateMapContext)_localctx).SIZE.getText():null)); 
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
		public Token TYPE;
		public Token NUM;
		public Token SKILL;
		public TerminalNode ENEMY() { return getToken(proto101Parser.ENEMY, 0); }
		public TerminalNode TYPE() { return getToken(proto101Parser.TYPE, 0); }
		public TerminalNode NUM() { return getToken(proto101Parser.NUM, 0); }
		public TerminalNode SKILL() { return getToken(proto101Parser.SKILL, 0); }
		public CreateEnemiesContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_createEnemies; }
	}

	public final CreateEnemiesContext createEnemies() throws RecognitionException {
		CreateEnemiesContext _localctx = new CreateEnemiesContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_createEnemies);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(30);
			match(ENEMY);
			setState(31);
			((CreateEnemiesContext)_localctx).TYPE = match(TYPE);
			setState(32);
			((CreateEnemiesContext)_localctx).NUM = match(NUM);
			setState(33);
			((CreateEnemiesContext)_localctx).SKILL = match(SKILL);
			 Compiler.CreateEnemy((((CreateEnemiesContext)_localctx).TYPE!=null?((CreateEnemiesContext)_localctx).TYPE.getText():null), (((CreateEnemiesContext)_localctx).NUM!=null?((CreateEnemiesContext)_localctx).NUM.getText():null), (((CreateEnemiesContext)_localctx).SKILL!=null?((CreateEnemiesContext)_localctx).SKILL.getText():null)); 
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\f\'\4\2\t\2\4\3\t"+
		"\3\4\4\t\4\4\5\t\5\4\6\t\6\3\2\6\2\16\n\2\r\2\16\2\17\3\3\3\3\3\3\5\3"+
		"\25\n\3\3\3\3\3\3\4\3\4\3\4\3\4\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3"+
		"\6\3\6\2\2\7\2\4\6\b\n\2\2\2$\2\r\3\2\2\2\4\24\3\2\2\2\6\30\3\2\2\2\b"+
		"\34\3\2\2\2\n \3\2\2\2\f\16\5\4\3\2\r\f\3\2\2\2\16\17\3\2\2\2\17\r\3\2"+
		"\2\2\17\20\3\2\2\2\20\3\3\2\2\2\21\25\5\6\4\2\22\25\5\b\5\2\23\25\5\n"+
		"\6\2\24\21\3\2\2\2\24\22\3\2\2\2\24\23\3\2\2\2\25\26\3\2\2\2\26\27\7\13"+
		"\2\2\27\5\3\2\2\2\30\31\7\3\2\2\31\32\7\4\2\2\32\33\b\4\1\2\33\7\3\2\2"+
		"\2\34\35\7\6\2\2\35\36\7\7\2\2\36\37\b\5\1\2\37\t\3\2\2\2 !\7\b\2\2!\""+
		"\7\t\2\2\"#\7\4\2\2#$\7\5\2\2$%\b\6\1\2%\13\3\2\2\2\4\17\24";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}