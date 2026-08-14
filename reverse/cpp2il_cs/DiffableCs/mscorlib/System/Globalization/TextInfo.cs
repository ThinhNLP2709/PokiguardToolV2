namespace System.Globalization;

[ComVisible(True)]
public class TextInfo : ICloneable, IDeserializationCallback
{
	internal static TextInfo s_Invariant; //Field offset: 0x0
	[OptionalField(VersionAdded = 2)]
	private bool m_isReadOnly; //Field offset: 0x10
	[OptionalField(VersionAdded = 3)]
	private string m_cultureName; //Field offset: 0x18
	private CultureData m_cultureData; //Field offset: 0x20
	private string m_textInfoName; //Field offset: 0x28
	private Nullable<Boolean> m_IsAsciiCasingSameAsInvariant; //Field offset: 0x30
	[OptionalField(VersionAdded = 2)]
	private string customCultureName; //Field offset: 0x38
	[OptionalField(VersionAdded = 1)]
	internal bool m_useUserOverride; //Field offset: 0x40
	[OptionalField(VersionAdded = 1)]
	internal int m_win32LangID; //Field offset: 0x44

	[ComVisible(False)]
	public string CultureName
	{
		 get { } //Length: 5
	}

	internal static TextInfo Invariant
	{
		internal get { } //Length: 258
	}

	private bool IsAsciiCasingSameAsInvariant
	{
		private get { } //Length: 219
	}

	internal TextInfo() { }

	internal TextInfo(CultureData cultureData) { }

	private static int AddNonLetter(ref StringBuilder result, ref string input, int inputIndex, int charLen) { }

	private int AddTitlecaseLetter(ref StringBuilder result, ref string input, int inputIndex, int charLen) { }

	internal void ChangeCase(ReadOnlySpan<Char> source, Span<Char> destination, bool toUpper) { }

	[ComVisible(False)]
	public override object Clone() { }

	public virtual bool Equals(object obj) { }

	public string get_CultureName() { }

	internal static TextInfo get_Invariant() { }

	private bool get_IsAsciiCasingSameAsInvariant() { }

	public virtual int GetHashCode() { }

	private static bool IsAscii(char c) { }

	private static bool IsLetterCategory(UnicodeCategory uc) { }

	private static bool IsWordSeparator(UnicodeCategory category) { }

	private void OnDeserialized() { }

	[OnDeserialized]
	private void OnDeserialized(StreamingContext ctx) { }

	[OnDeserializing]
	private void OnDeserializing(StreamingContext ctx) { }

	[OnSerializing]
	private void OnSerializing(StreamingContext ctx) { }

	internal void SetReadOnlyState(bool readOnly) { }

	private override void System.Runtime.Serialization.IDeserializationCallback.OnDeserialization(object sender) { }

	public override char ToLower(char c) { }

	public override string ToLower(string str) { }

	private static char ToLowerAsciiInvariant(char c) { }

	private string ToLowerInternal(string str) { }

	private char ToLowerInternal(char c) { }

	public virtual string ToString() { }

	public string ToTitleCase(string str) { }

	public override string ToUpper(string str) { }

	public override char ToUpper(char c) { }

	internal static char ToUpperAsciiInvariant(char c) { }

	internal void ToUpperAsciiInvariant(ReadOnlySpan<Char> source, Span<Char> destination) { }

	private string ToUpperInternal(string str) { }

	private char ToUpperInternal(char c) { }

}

