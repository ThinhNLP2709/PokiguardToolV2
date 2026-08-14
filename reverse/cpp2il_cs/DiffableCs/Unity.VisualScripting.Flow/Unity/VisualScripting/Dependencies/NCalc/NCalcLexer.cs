namespace Unity.VisualScripting.Dependencies.NCalc;

public class NCalcLexer : Lexer
{
	internal class DFA14 : DFA
	{

		public virtual string Description
		{
			 get { } //Length: 44
		}

		public DFA14(BaseRecognizer recognizer) { }

		public virtual string get_Description() { }

	}

	internal class DFA7 : DFA
	{

		public virtual string Description
		{
			 get { } //Length: 44
		}

		public DFA7(BaseRecognizer recognizer) { }

		public virtual string get_Description() { }

	}

	public const int T__33 = 33; //Field offset: 0x0
	public const int TRUE = 8; //Field offset: 0x0
	public const int T__30 = 30; //Field offset: 0x0
	public const int T__31 = 31; //Field offset: 0x0
	public const int T__32 = 32; //Field offset: 0x0
	public const int T__34 = 34; //Field offset: 0x0
	public const int T__35 = 35; //Field offset: 0x0
	public const int T__36 = 36; //Field offset: 0x0
	public const int T__37 = 37; //Field offset: 0x0
	public const int T__38 = 38; //Field offset: 0x0
	public const int T__39 = 39; //Field offset: 0x0
	public const int UnicodeEscape = 16; //Field offset: 0x0
	public const int FALSE = 9; //Field offset: 0x0
	public const int EscapeSequence = 15; //Field offset: 0x0
	public const int STRING = 6; //Field offset: 0x0
	private const string DFA7_eotS = "￿"; //Field offset: 0x0
	private const string DFA7_eofS = "￿"; //Field offset: 0x0
	private const string DFA7_minS = ".￿"; //Field offset: 0x0
	private const string DFA7_maxS = "9e￿"; //Field offset: 0x0
	private const string DFA7_acceptS = "￿"; //Field offset: 0x0
	private const string DFA7_specialS = "￿}>"; //Field offset: 0x0
	private const string DFA14_eotS = "￿!$￿')-0￿￿6￿7￿￿￿￿<=￿@￿B￿"; //Field offset: 0x0
	private const string DFA14_eofS = "C￿"; //Field offset: 0x0
	private const string DFA14_minS = "	￿|r&n￿=<=￿o￿ra+.￿0￿d￿tul￿0￿0es￿0e￿0￿"; //Field offset: 0x0
	private const string DFA14_maxS = "~￿|r&n￿=>￿o￿ra9e￿z￿d￿tul￿9￿zes￿ze￿z￿"; //Field offset: 0x0
	private const string DFA14_acceptS = "￿￿￿￿￿#$%&!(￿	￿
￿'￿"￿￿￿ "; //Field offset: 0x0
	private const string DFA14_specialS = "C￿}>"; //Field offset: 0x0
	private static readonly String[] DFA7_transitionS; //Field offset: 0x0
	public const int DATETIME = 7; //Field offset: 0x0
	public const int T__48 = 48; //Field offset: 0x0
	public const int WS = 18; //Field offset: 0x0
	public const int T__44 = 44; //Field offset: 0x0
	public const int T__29 = 29; //Field offset: 0x0
	public const int T__28 = 28; //Field offset: 0x0
	public const int T__27 = 27; //Field offset: 0x0
	public const int T__26 = 26; //Field offset: 0x0
	public const int T__25 = 25; //Field offset: 0x0
	public const int T__24 = 24; //Field offset: 0x0
	public const int LETTER = 12; //Field offset: 0x0
	public const int T__23 = 23; //Field offset: 0x0
	public const int T__45 = 45; //Field offset: 0x0
	public const int T__21 = 21; //Field offset: 0x0
	public const int T__20 = 20; //Field offset: 0x0
	public const int FLOAT = 5; //Field offset: 0x0
	public const int ID = 10; //Field offset: 0x0
	public const int EOF = -1; //Field offset: 0x0
	public const int T__22 = 22; //Field offset: 0x0
	public const int T__19 = 19; //Field offset: 0x0
	public const int HexDigit = 17; //Field offset: 0x0
	public const int T__46 = 46; //Field offset: 0x0
	public const int T__41 = 41; //Field offset: 0x0
	public const int T__40 = 40; //Field offset: 0x0
	public const int T__43 = 43; //Field offset: 0x0
	public const int T__47 = 47; //Field offset: 0x0
	public const int INTEGER = 4; //Field offset: 0x0
	public const int T__42 = 42; //Field offset: 0x0
	public const int DIGIT = 13; //Field offset: 0x0
	public const int NAME = 11; //Field offset: 0x0
	public const int E = 14; //Field offset: 0x0
	private static readonly Int16[] DFA7_eot; //Field offset: 0x8
	private static readonly Int16[] DFA7_eof; //Field offset: 0x10
	private static readonly Char[] DFA7_min; //Field offset: 0x18
	private static readonly Char[] DFA7_max; //Field offset: 0x20
	private static readonly Int16[] DFA7_accept; //Field offset: 0x28
	private static readonly Int16[] DFA7_special; //Field offset: 0x30
	private static readonly Int16[][] DFA7_transition; //Field offset: 0x38
	private static readonly String[] DFA14_transitionS; //Field offset: 0x40
	private static readonly Int16[] DFA14_eot; //Field offset: 0x48
	private static readonly Int16[] DFA14_eof; //Field offset: 0x50
	private static readonly Char[] DFA14_min; //Field offset: 0x58
	private static readonly Char[] DFA14_max; //Field offset: 0x60
	private static readonly Int16[] DFA14_accept; //Field offset: 0x68
	private static readonly Int16[] DFA14_special; //Field offset: 0x70
	private static readonly Int16[][] DFA14_transition; //Field offset: 0x78
	protected DFA7 dfa7; //Field offset: 0x20
	protected DFA14 dfa14; //Field offset: 0x28

	public virtual string GrammarFileName
	{
		 get { } //Length: 44
	}

	private static NCalcLexer() { }

	public NCalcLexer(ICharStream input, RecognizerSharedState state) { }

	public NCalcLexer() { }

	public NCalcLexer(ICharStream input) { }

	public virtual string get_GrammarFileName() { }

	private void InitializeCyclicDFAs() { }

	public void mDATETIME() { }

	public void mDIGIT() { }

	public void mE() { }

	public void mEscapeSequence() { }

	public void mFALSE() { }

	public void mFLOAT() { }

	public void mHexDigit() { }

	public void mID() { }

	public void mINTEGER() { }

	public void mLETTER() { }

	public void mNAME() { }

	public void mSTRING() { }

	public void mT__19() { }

	public void mT__20() { }

	public void mT__21() { }

	public void mT__22() { }

	public void mT__23() { }

	public void mT__24() { }

	public void mT__25() { }

	public void mT__26() { }

	public void mT__27() { }

	public void mT__28() { }

	public void mT__29() { }

	public void mT__30() { }

	public void mT__31() { }

	public void mT__32() { }

	public void mT__33() { }

	public void mT__34() { }

	public void mT__35() { }

	public void mT__36() { }

	public void mT__37() { }

	public void mT__38() { }

	public void mT__39() { }

	public void mT__40() { }

	public void mT__41() { }

	public void mT__42() { }

	public void mT__43() { }

	public void mT__44() { }

	public void mT__45() { }

	public void mT__46() { }

	public void mT__47() { }

	public void mT__48() { }

	public virtual void mTokens() { }

	public void mTRUE() { }

	public void mUnicodeEscape() { }

	public void mWS() { }

}

