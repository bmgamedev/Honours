// Generated from c:\Users\rcmcg\Documents\University\Year4\Honours\PracticalWork\Grammars\PlatformerMap\PlatformerMap.g4 by ANTLR 4.7.1
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
public class PlatformerMapParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		START=1, FLATPATH=2, LOWPLATFORM=3, HIGHPLATFORM=4, PATHGAP=5, FINISHLINE=6, 
		INT=7, NEWLINE=8, WS=9;
	public static final int
		RULE_prog = 0, RULE_elem = 1, RULE_addStartSegment = 2, RULE_addFlatPathSegment = 3, 
		RULE_addLowPlatformSegment = 4, RULE_addHighPlatformSegment = 5, RULE_addPathGapSegment = 6, 
		RULE_addFinishLineSegment = 7;
	public static final String[] ruleNames = {
		"prog", "elem", "addStartSegment", "addFlatPathSegment", "addLowPlatformSegment", 
		"addHighPlatformSegment", "addPathGapSegment", "addFinishLineSegment"
	};

	private static final String[] _LITERAL_NAMES = {
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "START", "FLATPATH", "LOWPLATFORM", "HIGHPLATFORM", "PATHGAP", "FINISHLINE", 
		"INT", "NEWLINE", "WS"
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
	public String getGrammarFileName() { return "PlatformerMap.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }


		public PlatformerCompiler Compiler = new PlatformerCompiler(); //this will be the compiler file in the Unity project

	public PlatformerMapParser(TokenStream input) {
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
			setState(17); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(16);
				elem();
				}
				}
				setState(19); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << START) | (1L << FLATPATH) | (1L << LOWPLATFORM) | (1L << HIGHPLATFORM) | (1L << PATHGAP) | (1L << FINISHLINE))) != 0) );
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
		public TerminalNode NEWLINE() { return getToken(PlatformerMapParser.NEWLINE, 0); }
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
			setState(27);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case START:
				{
				setState(21);
				addStartSegment();
				}
				break;
			case FLATPATH:
				{
				setState(22);
				addFlatPathSegment();
				}
				break;
			case LOWPLATFORM:
				{
				setState(23);
				addLowPlatformSegment();
				}
				break;
			case HIGHPLATFORM:
				{
				setState(24);
				addHighPlatformSegment();
				}
				break;
			case PATHGAP:
				{
				setState(25);
				addPathGapSegment();
				}
				break;
			case FINISHLINE:
				{
				setState(26);
				addFinishLineSegment();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(29);
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

	public static class AddStartSegmentContext extends ParserRuleContext {
		public TerminalNode START() { return getToken(PlatformerMapParser.START, 0); }
		public AddStartSegmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addStartSegment; }
	}

	public final AddStartSegmentContext addStartSegment() throws RecognitionException {
		AddStartSegmentContext _localctx = new AddStartSegmentContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_addStartSegment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(31);
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
		public TerminalNode FLATPATH() { return getToken(PlatformerMapParser.FLATPATH, 0); }
		public AddFlatPathSegmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addFlatPathSegment; }
	}

	public final AddFlatPathSegmentContext addFlatPathSegment() throws RecognitionException {
		AddFlatPathSegmentContext _localctx = new AddFlatPathSegmentContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_addFlatPathSegment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(34);
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
		public TerminalNode LOWPLATFORM() { return getToken(PlatformerMapParser.LOWPLATFORM, 0); }
		public AddLowPlatformSegmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addLowPlatformSegment; }
	}

	public final AddLowPlatformSegmentContext addLowPlatformSegment() throws RecognitionException {
		AddLowPlatformSegmentContext _localctx = new AddLowPlatformSegmentContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_addLowPlatformSegment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(37);
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
		public TerminalNode HIGHPLATFORM() { return getToken(PlatformerMapParser.HIGHPLATFORM, 0); }
		public AddHighPlatformSegmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addHighPlatformSegment; }
	}

	public final AddHighPlatformSegmentContext addHighPlatformSegment() throws RecognitionException {
		AddHighPlatformSegmentContext _localctx = new AddHighPlatformSegmentContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_addHighPlatformSegment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(40);
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
		public TerminalNode PATHGAP() { return getToken(PlatformerMapParser.PATHGAP, 0); }
		public AddPathGapSegmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addPathGapSegment; }
	}

	public final AddPathGapSegmentContext addPathGapSegment() throws RecognitionException {
		AddPathGapSegmentContext _localctx = new AddPathGapSegmentContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_addPathGapSegment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(43);
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
		public TerminalNode FINISHLINE() { return getToken(PlatformerMapParser.FINISHLINE, 0); }
		public AddFinishLineSegmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addFinishLineSegment; }
	}

	public final AddFinishLineSegmentContext addFinishLineSegment() throws RecognitionException {
		AddFinishLineSegmentContext _localctx = new AddFinishLineSegmentContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_addFinishLineSegment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(46);
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\13\64\4\2\t\2\4\3"+
		"\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\3\2\6\2\24\n\2\r"+
		"\2\16\2\25\3\3\3\3\3\3\3\3\3\3\3\3\5\3\36\n\3\3\3\3\3\3\4\3\4\3\4\3\5"+
		"\3\5\3\5\3\6\3\6\3\6\3\7\3\7\3\7\3\b\3\b\3\b\3\t\3\t\3\t\3\t\2\2\n\2\4"+
		"\6\b\n\f\16\20\2\2\2\61\2\23\3\2\2\2\4\35\3\2\2\2\6!\3\2\2\2\b$\3\2\2"+
		"\2\n\'\3\2\2\2\f*\3\2\2\2\16-\3\2\2\2\20\60\3\2\2\2\22\24\5\4\3\2\23\22"+
		"\3\2\2\2\24\25\3\2\2\2\25\23\3\2\2\2\25\26\3\2\2\2\26\3\3\2\2\2\27\36"+
		"\5\6\4\2\30\36\5\b\5\2\31\36\5\n\6\2\32\36\5\f\7\2\33\36\5\16\b\2\34\36"+
		"\5\20\t\2\35\27\3\2\2\2\35\30\3\2\2\2\35\31\3\2\2\2\35\32\3\2\2\2\35\33"+
		"\3\2\2\2\35\34\3\2\2\2\36\37\3\2\2\2\37 \7\n\2\2 \5\3\2\2\2!\"\7\3\2\2"+
		"\"#\b\4\1\2#\7\3\2\2\2$%\7\4\2\2%&\b\5\1\2&\t\3\2\2\2\'(\7\5\2\2()\b\6"+
		"\1\2)\13\3\2\2\2*+\7\6\2\2+,\b\7\1\2,\r\3\2\2\2-.\7\7\2\2./\b\b\1\2/\17"+
		"\3\2\2\2\60\61\7\b\2\2\61\62\b\t\1\2\62\21\3\2\2\2\4\25\35";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}