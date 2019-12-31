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
		PC=1, NUM=2, SKILL=3, MAP=4, SIZE=5, ENEMY=6, TYPE=7, INT=8, NEWLINE=9, 
		WS=10;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	public static final String[] ruleNames = {
		"PC", "NUM", "SKILL", "MAP", "SIZE", "ENEMY", "TYPE", "INT", "NEWLINE", 
		"WS"
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\fo\b\1\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\3\3\3\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3"+
		"\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\5\4\65\n\4\3\5\3\5"+
		"\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\5\6H\n\6"+
		"\3\7\3\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\5\bZ"+
		"\n\b\3\t\5\t]\n\t\3\t\6\t`\n\t\r\t\16\ta\3\n\5\ne\n\n\3\n\3\n\3\13\6\13"+
		"j\n\13\r\13\16\13k\3\13\3\13\2\2\f\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n"+
		"\23\13\25\f\3\2\3\5\2\13\f\17\17\"\"\2w\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3"+
		"\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2"+
		"\2\23\3\2\2\2\2\25\3\2\2\2\3\27\3\2\2\2\5\36\3\2\2\2\7\64\3\2\2\2\t\66"+
		"\3\2\2\2\13G\3\2\2\2\rI\3\2\2\2\17Y\3\2\2\2\21\\\3\2\2\2\23d\3\2\2\2\25"+
		"i\3\2\2\2\27\30\7r\2\2\30\31\7n\2\2\31\32\7c\2\2\32\33\7{\2\2\33\34\7"+
		"g\2\2\34\35\7t\2\2\35\4\3\2\2\2\36\37\5\21\t\2\37\6\3\2\2\2 !\7d\2\2!"+
		"\"\7c\2\2\"#\7u\2\2#$\7k\2\2$\65\7e\2\2%&\7d\2\2&\'\7c\2\2\'(\7n\2\2("+
		")\7c\2\2)*\7p\2\2*+\7e\2\2+,\7g\2\2,\65\7f\2\2-.\7u\2\2./\7m\2\2/\60\7"+
		"k\2\2\60\61\7n\2\2\61\62\7n\2\2\62\63\7g\2\2\63\65\7f\2\2\64 \3\2\2\2"+
		"\64%\3\2\2\2\64-\3\2\2\2\65\b\3\2\2\2\66\67\7o\2\2\678\7c\2\289\7r\2\2"+
		"9\n\3\2\2\2:;\7u\2\2;<\7o\2\2<=\7c\2\2=>\7n\2\2>H\7n\2\2?@\7o\2\2@A\7"+
		"g\2\2AH\7f\2\2BC\7n\2\2CD\7c\2\2DE\7t\2\2EF\7i\2\2FH\7g\2\2G:\3\2\2\2"+
		"G?\3\2\2\2GB\3\2\2\2H\f\3\2\2\2IJ\7g\2\2JK\7p\2\2KL\7g\2\2LM\7o\2\2MN"+
		"\7{\2\2N\16\3\2\2\2OP\7v\2\2PQ\7{\2\2QR\7r\2\2RS\7g\2\2SZ\7C\2\2TU\7v"+
		"\2\2UV\7{\2\2VW\7r\2\2WX\7g\2\2XZ\7D\2\2YO\3\2\2\2YT\3\2\2\2Z\20\3\2\2"+
		"\2[]\7/\2\2\\[\3\2\2\2\\]\3\2\2\2]_\3\2\2\2^`\4\62;\2_^\3\2\2\2`a\3\2"+
		"\2\2a_\3\2\2\2ab\3\2\2\2b\22\3\2\2\2ce\7\17\2\2dc\3\2\2\2de\3\2\2\2ef"+
		"\3\2\2\2fg\7\f\2\2g\24\3\2\2\2hj\t\2\2\2ih\3\2\2\2jk\3\2\2\2ki\3\2\2\2"+
		"kl\3\2\2\2lm\3\2\2\2mn\b\13\2\2n\26\3\2\2\2\n\2\64GY\\adk\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}