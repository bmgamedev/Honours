// Generated from c:\Users\rcmcg\Documents\University\Year4\Honours\PracticalWork\Grammars\Prototype101\proto101.g4 by ANTLR 4.7.1
#pragma warning disable 3021
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class proto101Lexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		GAMETYPE=1, PC=2, NUM=3, SKILL=4, DUNGEON=5, PLATFORMER=6, SIZE=7, ENEMY=8, 
		ENEMYTYPE=9, START=10, FLATPATH=11, LOWPLATFORM=12, HIGHPLATFORM=13, PATHGAP=14, 
		FINISHLINE=15, INT=16, NEWLINE=17, WS=18;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	public static final String[] ruleNames = {
		"GAMETYPE", "PC", "NUM", "SKILL", "DUNGEON", "PLATFORMER", "SIZE", "ENEMY", 
		"ENEMYTYPE", "START", "FLATPATH", "LOWPLATFORM", "HIGHPLATFORM", "PATHGAP", 
		"FINISHLINE", "INT", "NEWLINE", "WS"
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


		public PrototypeCompiler Compiler = new PrototypeCompiler(); //this will be the compiler file in the Unity project


	public proto101Lexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "proto101.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\24\u009e\b\1\4\2"+
		"\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4"+
		"\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22"+
		"\t\22\4\23\t\23\3\2\3\2\5\2*\n\2\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\4\3\4\3"+
		"\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5"+
		"\3\5\3\5\5\5I\n\5\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7"+
		"\3\7\3\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3"+
		"\b\3\b\5\bk\n\b\3\t\3\t\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3"+
		"\n\3\n\3\n\5\n}\n\n\3\13\3\13\3\f\3\f\3\r\3\r\3\16\3\16\3\17\3\17\3\20"+
		"\3\20\3\21\5\21\u008c\n\21\3\21\6\21\u008f\n\21\r\21\16\21\u0090\3\22"+
		"\5\22\u0094\n\22\3\22\3\22\3\23\6\23\u0099\n\23\r\23\16\23\u009a\3\23"+
		"\3\23\2\2\24\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27\r\31\16"+
		"\33\17\35\20\37\21!\22#\23%\24\3\2\t\4\2UUuu\4\2HHhh\4\2RRrr\4\2JJjj\4"+
		"\2IIii\4\2GGgg\5\2\13\f\17\17\"\"\2\u00a7\2\3\3\2\2\2\2\5\3\2\2\2\2\7"+
		"\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2"+
		"\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2"+
		"\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\3)\3\2\2\2\5"+
		"+\3\2\2\2\7\62\3\2\2\2\tH\3\2\2\2\13J\3\2\2\2\rR\3\2\2\2\17j\3\2\2\2\21"+
		"l\3\2\2\2\23|\3\2\2\2\25~\3\2\2\2\27\u0080\3\2\2\2\31\u0082\3\2\2\2\33"+
		"\u0084\3\2\2\2\35\u0086\3\2\2\2\37\u0088\3\2\2\2!\u008b\3\2\2\2#\u0093"+
		"\3\2\2\2%\u0098\3\2\2\2\'*\5\13\6\2(*\5\r\7\2)\'\3\2\2\2)(\3\2\2\2*\4"+
		"\3\2\2\2+,\7r\2\2,-\7n\2\2-.\7c\2\2./\7{\2\2/\60\7g\2\2\60\61\7t\2\2\61"+
		"\6\3\2\2\2\62\63\5!\21\2\63\b\3\2\2\2\64\65\7d\2\2\65\66\7c\2\2\66\67"+
		"\7u\2\2\678\7k\2\28I\7e\2\29:\7d\2\2:;\7c\2\2;<\7n\2\2<=\7c\2\2=>\7p\2"+
		"\2>?\7e\2\2?@\7g\2\2@I\7f\2\2AB\7u\2\2BC\7m\2\2CD\7k\2\2DE\7n\2\2EF\7"+
		"n\2\2FG\7g\2\2GI\7f\2\2H\64\3\2\2\2H9\3\2\2\2HA\3\2\2\2I\n\3\2\2\2JK\7"+
		"f\2\2KL\7w\2\2LM\7p\2\2MN\7i\2\2NO\7g\2\2OP\7q\2\2PQ\7p\2\2Q\f\3\2\2\2"+
		"RS\7r\2\2ST\7n\2\2TU\7c\2\2UV\7v\2\2VW\7h\2\2WX\7q\2\2XY\7t\2\2YZ\7o\2"+
		"\2Z[\7g\2\2[\\\7t\2\2\\\16\3\2\2\2]^\7u\2\2^_\7o\2\2_`\7c\2\2`a\7n\2\2"+
		"ak\7n\2\2bc\7o\2\2cd\7g\2\2dk\7f\2\2ef\7n\2\2fg\7c\2\2gh\7t\2\2hi\7i\2"+
		"\2ik\7g\2\2j]\3\2\2\2jb\3\2\2\2je\3\2\2\2k\20\3\2\2\2lm\7g\2\2mn\7p\2"+
		"\2no\7g\2\2op\7o\2\2pq\7{\2\2q\22\3\2\2\2rs\7v\2\2st\7{\2\2tu\7r\2\2u"+
		"v\7g\2\2v}\7C\2\2wx\7v\2\2xy\7{\2\2yz\7r\2\2z{\7g\2\2{}\7D\2\2|r\3\2\2"+
		"\2|w\3\2\2\2}\24\3\2\2\2~\177\t\2\2\2\177\26\3\2\2\2\u0080\u0081\t\3\2"+
		"\2\u0081\30\3\2\2\2\u0082\u0083\t\4\2\2\u0083\32\3\2\2\2\u0084\u0085\t"+
		"\5\2\2\u0085\34\3\2\2\2\u0086\u0087\t\6\2\2\u0087\36\3\2\2\2\u0088\u0089"+
		"\t\7\2\2\u0089 \3\2\2\2\u008a\u008c\7/\2\2\u008b\u008a\3\2\2\2\u008b\u008c"+
		"\3\2\2\2\u008c\u008e\3\2\2\2\u008d\u008f\4\62;\2\u008e\u008d\3\2\2\2\u008f"+
		"\u0090\3\2\2\2\u0090\u008e\3\2\2\2\u0090\u0091\3\2\2\2\u0091\"\3\2\2\2"+
		"\u0092\u0094\7\17\2\2\u0093\u0092\3\2\2\2\u0093\u0094\3\2\2\2\u0094\u0095"+
		"\3\2\2\2\u0095\u0096\7\f\2\2\u0096$\3\2\2\2\u0097\u0099\t\b\2\2\u0098"+
		"\u0097\3\2\2\2\u0099\u009a\3\2\2\2\u009a\u0098\3\2\2\2\u009a\u009b\3\2"+
		"\2\2\u009b\u009c\3\2\2\2\u009c\u009d\b\23\2\2\u009d&\3\2\2\2\13\2)Hj|"+
		"\u008b\u0090\u0093\u009a\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}