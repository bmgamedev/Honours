// Generated from c:\Users\rcmcg\Documents\University\Year4\Honours\PracticalWork\Grammars\DungeonMap\DungeonMap.g4 by ANTLR 4.7.1
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
public class DungeonMapParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		INITROOM=1, ENTRY=2, EXIT=3, DIRECTION=4, ROOM=5, INT=6, NEWLINE=7, WS=8;
	public static final int
		RULE_prog = 0, RULE_elem = 1, RULE_createInitialRoom = 2, RULE_createFirstCorrSect = 3, 
		RULE_createSecondCorrSect = 4, RULE_createRoom = 5;
	public static final String[] ruleNames = {
		"prog", "elem", "createInitialRoom", "createFirstCorrSect", "createSecondCorrSect", 
		"createRoom"
	};

	private static final String[] _LITERAL_NAMES = {
		null, null, null, null, null, "'r'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "INITROOM", "ENTRY", "EXIT", "DIRECTION", "ROOM", "INT", "NEWLINE", 
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
	public String getGrammarFileName() { return "DungeonMap.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }


		public DungeonCompiler Compiler = new DungeonCompiler(); //this will be the compiler file in the Unity project

	public DungeonMapParser(TokenStream input) {
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
			setState(13); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(12);
				elem();
				}
				}
				setState(15); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << INITROOM) | (1L << ENTRY) | (1L << EXIT) | (1L << DIRECTION))) != 0) );
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
		public TerminalNode NEWLINE() { return getToken(DungeonMapParser.NEWLINE, 0); }
		public CreateInitialRoomContext createInitialRoom() {
			return getRuleContext(CreateInitialRoomContext.class,0);
		}
		public CreateFirstCorrSectContext createFirstCorrSect() {
			return getRuleContext(CreateFirstCorrSectContext.class,0);
		}
		public CreateSecondCorrSectContext createSecondCorrSect() {
			return getRuleContext(CreateSecondCorrSectContext.class,0);
		}
		public CreateRoomContext createRoom() {
			return getRuleContext(CreateRoomContext.class,0);
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
			setState(21);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INITROOM:
				{
				setState(17);
				createInitialRoom();
				}
				break;
			case ENTRY:
				{
				setState(18);
				createFirstCorrSect();
				}
				break;
			case DIRECTION:
				{
				setState(19);
				createSecondCorrSect();
				}
				break;
			case EXIT:
				{
				setState(20);
				createRoom();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(23);
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

	public static class CreateInitialRoomContext extends ParserRuleContext {
		public TerminalNode INITROOM() { return getToken(DungeonMapParser.INITROOM, 0); }
		public TerminalNode EXIT() { return getToken(DungeonMapParser.EXIT, 0); }
		public CreateInitialRoomContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_createInitialRoom; }
	}

	public final CreateInitialRoomContext createInitialRoom() throws RecognitionException {
		CreateInitialRoomContext _localctx = new CreateInitialRoomContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_createInitialRoom);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(25);
			match(INITROOM);
			setState(26);
			match(EXIT);
			 Compiler.CreateInitialRoom(); 
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

	public static class CreateFirstCorrSectContext extends ParserRuleContext {
		public TerminalNode ENTRY() { return getToken(DungeonMapParser.ENTRY, 0); }
		public TerminalNode DIRECTION() { return getToken(DungeonMapParser.DIRECTION, 0); }
		public CreateFirstCorrSectContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_createFirstCorrSect; }
	}

	public final CreateFirstCorrSectContext createFirstCorrSect() throws RecognitionException {
		CreateFirstCorrSectContext _localctx = new CreateFirstCorrSectContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_createFirstCorrSect);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(29);
			match(ENTRY);
			setState(30);
			match(DIRECTION);
			 Compiler.CreateFirstPiece(); 
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

	public static class CreateSecondCorrSectContext extends ParserRuleContext {
		public TerminalNode DIRECTION() { return getToken(DungeonMapParser.DIRECTION, 0); }
		public TerminalNode EXIT() { return getToken(DungeonMapParser.EXIT, 0); }
		public CreateSecondCorrSectContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_createSecondCorrSect; }
	}

	public final CreateSecondCorrSectContext createSecondCorrSect() throws RecognitionException {
		CreateSecondCorrSectContext _localctx = new CreateSecondCorrSectContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_createSecondCorrSect);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(33);
			match(DIRECTION);
			setState(34);
			match(EXIT);
			 Compiler.CreateSecondPiece(); 
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

	public static class CreateRoomContext extends ParserRuleContext {
		public TerminalNode EXIT() { return getToken(DungeonMapParser.EXIT, 0); }
		public TerminalNode ROOM() { return getToken(DungeonMapParser.ROOM, 0); }
		public TerminalNode ENTRY() { return getToken(DungeonMapParser.ENTRY, 0); }
		public CreateRoomContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_createRoom; }
	}

	public final CreateRoomContext createRoom() throws RecognitionException {
		CreateRoomContext _localctx = new CreateRoomContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_createRoom);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(37);
			match(EXIT);
			setState(38);
			match(ROOM);
			setState(39);
			match(ENTRY);
			 Compiler.CreateRoom(); 
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\n-\4\2\t\2\4\3\t"+
		"\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\3\2\6\2\20\n\2\r\2\16\2\21\3\3\3\3"+
		"\3\3\3\3\5\3\30\n\3\3\3\3\3\3\4\3\4\3\4\3\4\3\5\3\5\3\5\3\5\3\6\3\6\3"+
		"\6\3\6\3\7\3\7\3\7\3\7\3\7\3\7\2\2\b\2\4\6\b\n\f\2\2\2*\2\17\3\2\2\2\4"+
		"\27\3\2\2\2\6\33\3\2\2\2\b\37\3\2\2\2\n#\3\2\2\2\f\'\3\2\2\2\16\20\5\4"+
		"\3\2\17\16\3\2\2\2\20\21\3\2\2\2\21\17\3\2\2\2\21\22\3\2\2\2\22\3\3\2"+
		"\2\2\23\30\5\6\4\2\24\30\5\b\5\2\25\30\5\n\6\2\26\30\5\f\7\2\27\23\3\2"+
		"\2\2\27\24\3\2\2\2\27\25\3\2\2\2\27\26\3\2\2\2\30\31\3\2\2\2\31\32\7\t"+
		"\2\2\32\5\3\2\2\2\33\34\7\3\2\2\34\35\7\5\2\2\35\36\b\4\1\2\36\7\3\2\2"+
		"\2\37 \7\4\2\2 !\7\6\2\2!\"\b\5\1\2\"\t\3\2\2\2#$\7\6\2\2$%\7\5\2\2%&"+
		"\b\6\1\2&\13\3\2\2\2\'(\7\5\2\2()\7\7\2\2)*\7\4\2\2*+\b\7\1\2+\r\3\2\2"+
		"\2\4\21\27";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}