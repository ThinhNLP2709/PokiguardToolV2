namespace Unity.VisualScripting.Antlr3.Runtime;

public abstract class DFA
{
	internal sealed class SpecialStateTransitionHandler : MulticastDelegate
	{

		public SpecialStateTransitionHandler(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(DFA dfa, int s, IIntStream input, AsyncCallback callback, object object) { }

		public override int EndInvoke(IAsyncResult result) { }

		public override int Invoke(DFA dfa, int s, IIntStream input) { }

	}

	public const bool debug = False; //Field offset: 0x0
	protected Int16[] eot; //Field offset: 0x10
	protected Int16[] eof; //Field offset: 0x18
	protected Char[] min; //Field offset: 0x20
	protected Char[] max; //Field offset: 0x28
	protected Int16[] accept; //Field offset: 0x30
	protected Int16[] special; //Field offset: 0x38
	protected Int16[][] transition; //Field offset: 0x40
	protected int decisionNumber; //Field offset: 0x48
	public SpecialStateTransitionHandler specialStateTransitionHandler; //Field offset: 0x50
	protected BaseRecognizer recognizer; //Field offset: 0x58

	public override string Description
	{
		 get { } //Length: 44
	}

	protected DFA() { }

	public override void Error(NoViableAltException nvae) { }

	public override string get_Description() { }

	protected void NoViableAlt(int s, IIntStream input) { }

	public int Predict(IIntStream input) { }

	public override int SpecialStateTransition(int s, IIntStream input) { }

	public int SpecialTransition(int state, int symbol) { }

	public static Int16[] UnpackEncodedString(string encodedString) { }

	public static Int16[][] UnpackEncodedStringArray(String[] encodedStrings) { }

	public static Char[] UnpackEncodedStringToUnsignedChars(string encodedString) { }

}

