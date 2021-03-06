// Generated from c:\Users\rcmcg\Documents\University\Year4\Honours\PracticalWork\Grammars\GameSetup\GameSetup.g4 by ANTLR 4.7.1
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
public class GameSetupLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		INITIALISE=1, FINALISE=2, GAMETYPE=3, PC=4, NUM=5, DIFFICULTY=6, SKILLLEVEL=7, 
		SKILLSET=8, DUNGEON=9, PLATFORMER=10, MAP=11, SIZE=12, ENEMY=13, ATTACKSTYLE=14, 
		INT=15, NEWLINE=16, WS=17;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	public static final String[] ruleNames = {
		"INITIALISE", "FINALISE", "GAMETYPE", "PC", "NUM", "DIFFICULTY", "SKILLLEVEL", 
		"SKILLSET", "DUNGEON", "PLATFORMER", "MAP", "SIZE", "ENEMY", "ATTACKSTYLE", 
		"INT", "NEWLINE", "WS"
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


		public GameCompiler Compiler = new GameCompiler(); //the specific compiler file in the Unity project


	public GameSetupLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "GameSetup.g4"; }

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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\23\u00dd\b\1\4\2"+
		"\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4"+
		"\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22"+
		"\t\22\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\3\3\3\3\3\3\3\3\3"+
		"\3\3\3\3\3\3\3\3\3\4\3\4\5\4<\n\4\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\5\3\6"+
		"\3\6\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3"+
		"\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\5\bb\n\b\3\t\3\t\3\t\3\t\3\t\3"+
		"\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\5\tx\n\t\3"+
		"\n\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13"+
		"\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3"+
		"\r\3\r\3\r\3\r\3\r\3\r\3\r\5\r\u00a1\n\r\3\16\3\16\3\16\3\16\3\16\3\16"+
		"\3\16\3\16\3\16\3\16\3\16\3\16\5\16\u00af\n\16\3\17\3\17\3\17\3\17\3\17"+
		"\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17"+
		"\3\17\3\17\3\17\3\17\5\17\u00c8\n\17\3\20\5\20\u00cb\n\20\3\20\6\20\u00ce"+
		"\n\20\r\20\16\20\u00cf\3\21\5\21\u00d3\n\21\3\21\3\21\3\22\6\22\u00d8"+
		"\n\22\r\22\16\22\u00d9\3\22\3\22\2\2\23\3\3\5\4\7\5\t\6\13\7\r\b\17\t"+
		"\21\n\23\13\25\f\27\r\31\16\33\17\35\20\37\21!\22#\23\3\2\3\5\2\13\f\17"+
		"\17\"\"\2\u00eb\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3"+
		"\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2"+
		"\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3"+
		"\2\2\2\2#\3\2\2\2\3%\3\2\2\2\5\60\3\2\2\2\7;\3\2\2\2\t=\3\2\2\2\13E\3"+
		"\2\2\2\rG\3\2\2\2\17a\3\2\2\2\21w\3\2\2\2\23y\3\2\2\2\25\u0081\3\2\2\2"+
		"\27\u008c\3\2\2\2\31\u00a0\3\2\2\2\33\u00ae\3\2\2\2\35\u00c7\3\2\2\2\37"+
		"\u00ca\3\2\2\2!\u00d2\3\2\2\2#\u00d7\3\2\2\2%&\7k\2\2&\'\7p\2\2\'(\7k"+
		"\2\2()\7v\2\2)*\7k\2\2*+\7c\2\2+,\7n\2\2,-\7k\2\2-.\7u\2\2./\7g\2\2/\4"+
		"\3\2\2\2\60\61\7h\2\2\61\62\7k\2\2\62\63\7p\2\2\63\64\7c\2\2\64\65\7n"+
		"\2\2\65\66\7k\2\2\66\67\7u\2\2\678\7g\2\28\6\3\2\2\29<\5\23\n\2:<\5\25"+
		"\13\2;9\3\2\2\2;:\3\2\2\2<\b\3\2\2\2=>\7r\2\2>?\7n\2\2?@\7c\2\2@A\7{\2"+
		"\2AB\7g\2\2BC\7t\2\2CD\7u\2\2D\n\3\2\2\2EF\5\37\20\2F\f\3\2\2\2GH\7f\2"+
		"\2HI\7k\2\2IJ\7h\2\2JK\7h\2\2KL\7k\2\2LM\7e\2\2MN\7w\2\2NO\7n\2\2OP\7"+
		"v\2\2PQ\7{\2\2Q\16\3\2\2\2RS\7g\2\2ST\7c\2\2TU\7u\2\2Ub\7{\2\2VW\7t\2"+
		"\2WX\7g\2\2XY\7i\2\2YZ\7w\2\2Z[\7n\2\2[\\\7c\2\2\\b\7t\2\2]^\7j\2\2^_"+
		"\7c\2\2_`\7t\2\2`b\7f\2\2aR\3\2\2\2aV\3\2\2\2a]\3\2\2\2b\20\3\2\2\2cd"+
		"\7d\2\2de\7c\2\2ef\7u\2\2fg\7k\2\2gx\7e\2\2hi\7d\2\2ij\7c\2\2jk\7n\2\2"+
		"kl\7c\2\2lm\7p\2\2mn\7e\2\2no\7g\2\2ox\7f\2\2pq\7u\2\2qr\7m\2\2rs\7k\2"+
		"\2st\7n\2\2tu\7n\2\2uv\7g\2\2vx\7f\2\2wc\3\2\2\2wh\3\2\2\2wp\3\2\2\2x"+
		"\22\3\2\2\2yz\7f\2\2z{\7w\2\2{|\7p\2\2|}\7i\2\2}~\7g\2\2~\177\7q\2\2\177"+
		"\u0080\7p\2\2\u0080\24\3\2\2\2\u0081\u0082\7r\2\2\u0082\u0083\7n\2\2\u0083"+
		"\u0084\7c\2\2\u0084\u0085\7v\2\2\u0085\u0086\7h\2\2\u0086\u0087\7q\2\2"+
		"\u0087\u0088\7t\2\2\u0088\u0089\7o\2\2\u0089\u008a\7g\2\2\u008a\u008b"+
		"\7t\2\2\u008b\26\3\2\2\2\u008c\u008d\7o\2\2\u008d\u008e\7c\2\2\u008e\u008f"+
		"\7r\2\2\u008f\30\3\2\2\2\u0090\u0091\7u\2\2\u0091\u0092\7o\2\2\u0092\u0093"+
		"\7c\2\2\u0093\u0094\7n\2\2\u0094\u00a1\7n\2\2\u0095\u0096\7o\2\2\u0096"+
		"\u0097\7g\2\2\u0097\u0098\7f\2\2\u0098\u0099\7k\2\2\u0099\u009a\7w\2\2"+
		"\u009a\u00a1\7o\2\2\u009b\u009c\7n\2\2\u009c\u009d\7c\2\2\u009d\u009e"+
		"\7t\2\2\u009e\u009f\7i\2\2\u009f\u00a1\7g\2\2\u00a0\u0090\3\2\2\2\u00a0"+
		"\u0095\3\2\2\2\u00a0\u009b\3\2\2\2\u00a1\32\3\2\2\2\u00a2\u00a3\7g\2\2"+
		"\u00a3\u00a4\7p\2\2\u00a4\u00a5\7g\2\2\u00a5\u00a6\7o\2\2\u00a6\u00af"+
		"\7{\2\2\u00a7\u00a8\7g\2\2\u00a8\u00a9\7p\2\2\u00a9\u00aa\7g\2\2\u00aa"+
		"\u00ab\7o\2\2\u00ab\u00ac\7k\2\2\u00ac\u00ad\7g\2\2\u00ad\u00af\7u\2\2"+
		"\u00ae\u00a2\3\2\2\2\u00ae\u00a7\3\2\2\2\u00af\34\3\2\2\2\u00b0\u00b1"+
		"\7o\2\2\u00b1\u00b2\7q\2\2\u00b2\u00b3\7x\2\2\u00b3\u00b4\7k\2\2\u00b4"+
		"\u00b5\7p\2\2\u00b5\u00c8\7i\2\2\u00b6\u00b7\7u\2\2\u00b7\u00b8\7v\2\2"+
		"\u00b8\u00b9\7c\2\2\u00b9\u00ba\7v\2\2\u00ba\u00bb\7k\2\2\u00bb\u00c8"+
		"\7e\2\2\u00bc\u00bd\7x\2\2\u00bd\u00be\7c\2\2\u00be\u00bf\7t\2\2\u00bf"+
		"\u00c0\7k\2\2\u00c0\u00c1\7g\2\2\u00c1\u00c8\7f\2\2\u00c2\u00c3\7e\2\2"+
		"\u00c3\u00c4\7q\2\2\u00c4\u00c5\7o\2\2\u00c5\u00c6\7d\2\2\u00c6\u00c8"+
		"\7q\2\2\u00c7\u00b0\3\2\2\2\u00c7\u00b6\3\2\2\2\u00c7\u00bc\3\2\2\2\u00c7"+
		"\u00c2\3\2\2\2\u00c8\36\3\2\2\2\u00c9\u00cb\7/\2\2\u00ca\u00c9\3\2\2\2"+
		"\u00ca\u00cb\3\2\2\2\u00cb\u00cd\3\2\2\2\u00cc\u00ce\4\62;\2\u00cd\u00cc"+
		"\3\2\2\2\u00ce\u00cf\3\2\2\2\u00cf\u00cd\3\2\2\2\u00cf\u00d0\3\2\2\2\u00d0"+
		" \3\2\2\2\u00d1\u00d3\7\17\2\2\u00d2\u00d1\3\2\2\2\u00d2\u00d3\3\2\2\2"+
		"\u00d3\u00d4\3\2\2\2\u00d4\u00d5\7\f\2\2\u00d5\"\3\2\2\2\u00d6\u00d8\t"+
		"\2\2\2\u00d7\u00d6\3\2\2\2\u00d8\u00d9\3\2\2\2\u00d9\u00d7\3\2\2\2\u00d9"+
		"\u00da\3\2\2\2\u00da\u00db\3\2\2\2\u00db\u00dc\b\22\2\2\u00dc$\3\2\2\2"+
		"\r\2;aw\u00a0\u00ae\u00c7\u00ca\u00cf\u00d2\u00d9\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}