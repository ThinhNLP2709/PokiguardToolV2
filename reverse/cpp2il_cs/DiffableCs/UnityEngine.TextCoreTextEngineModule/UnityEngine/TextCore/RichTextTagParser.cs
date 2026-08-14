namespace UnityEngine.TextCore;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
internal static class RichTextTagParser
{
	[Nullable(0)]
	[NullableContext(1)]
	public class ParseError : IEquatable<ParseError>
	{
		public readonly int position; //Field offset: 0x10
		public readonly string message; //Field offset: 0x18

		[CompilerGenerated]
		protected override Type EqualityContract
		{
			[CompilerGenerated]
			 get { } //Length: 77
		}

		internal ParseError(string message, int position) { }

		[CompilerGenerated]
		[NullableContext(2)]
		public virtual bool Equals(object obj) { }

		[CompilerGenerated]
		[NullableContext(2)]
		public override bool Equals(ParseError other) { }

		[CompilerGenerated]
		protected override Type get_EqualityContract() { }

		[CompilerGenerated]
		public virtual int GetHashCode() { }

		[CompilerGenerated]
		protected override bool PrintMembers(StringBuilder builder) { }

		[CompilerGenerated]
		public virtual string ToString() { }

	}

	internal struct Segment
	{
		[Nullable(2)]
		public List<Tag> tags; //Field offset: 0x0
		public int start; //Field offset: 0x8
		public int end; //Field offset: 0xC

	}

	public struct Tag
	{
		public TagType tagType; //Field offset: 0x0
		public bool isClosing; //Field offset: 0x4
		public int start; //Field offset: 0x8
		public int end; //Field offset: 0xC
		[Nullable(2)]
		public TagValue value; //Field offset: 0x10

	}

	internal enum TagType
	{
		Hyperlink = 0,
		Align = 1,
		AllCaps = 2,
		Alpha = 3,
		Bold = 4,
		Br = 5,
		Color = 6,
		CSpace = 7,
		Font = 8,
		FontWeight = 9,
		Italic = 10,
		Indent = 11,
		LineHeight = 12,
		LineIndent = 13,
		Link = 14,
		Lowercase = 15,
		Mark = 16,
		Mspace = 17,
		NoBr = 18,
		NoParse = 19,
		Strikethrough = 20,
		Size = 21,
		SmallCaps = 22,
		Space = 23,
		Sprite = 24,
		Style = 25,
		Subscript = 26,
		Superscript = 27,
		Underline = 28,
		Uppercase = 29,
		Unknown = 30,
	}

	[Nullable(0)]
	[NullableContext(1)]
	public class TagTypeInfo : IEquatable<TagTypeInfo>
	{
		public TagType TagType; //Field offset: 0x10
		public string name; //Field offset: 0x18
		public TagValueType valueType; //Field offset: 0x20
		public TagUnitType unitType; //Field offset: 0x24

		[CompilerGenerated]
		protected override Type EqualityContract
		{
			[CompilerGenerated]
			 get { } //Length: 77
		}

		internal TagTypeInfo(TagType tagType, string name, TagValueType valueType = 0, TagUnitType unitType = 0) { }

		[CompilerGenerated]
		[NullableContext(2)]
		public virtual bool Equals(object obj) { }

		[CompilerGenerated]
		[NullableContext(2)]
		public override bool Equals(TagTypeInfo other) { }

		[CompilerGenerated]
		protected override Type get_EqualityContract() { }

		[CompilerGenerated]
		public virtual int GetHashCode() { }

		[CompilerGenerated]
		protected override bool PrintMembers(StringBuilder builder) { }

		[CompilerGenerated]
		public virtual string ToString() { }

	}

	public enum TagUnitType
	{
		Pixels = 0,
		FontUnits = 1,
		Percentage = 2,
	}

	[Nullable(0)]
	[NullableContext(2)]
	public class TagValue : IEquatable<TagValue>
	{
		internal TagValueType type; //Field offset: 0x10
		private string m_stringValue; //Field offset: 0x18
		private float m_numericalValue; //Field offset: 0x20
		private Color m_colorValue; //Field offset: 0x24

		internal Color ColorValue
		{
			internal get { } //Length: 113
		}

		[CompilerGenerated]
		[Nullable(1)]
		protected override Type EqualityContract
		{
			[CompilerGenerated]
			[NullableContext(1)]
			 get { } //Length: 77
		}

		internal float NumericalValue
		{
			internal get { } //Length: 102
		}

		internal string StringValue
		{
			internal get { } //Length: 101
		}

		internal TagValue(Color value) { }

		[NullableContext(1)]
		internal TagValue(string value) { }

		[CompilerGenerated]
		public virtual bool Equals(object obj) { }

		[CompilerGenerated]
		public override bool Equals(TagValue other) { }

		internal Color get_ColorValue() { }

		[CompilerGenerated]
		[NullableContext(1)]
		protected override Type get_EqualityContract() { }

		internal float get_NumericalValue() { }

		internal string get_StringValue() { }

		[CompilerGenerated]
		public virtual int GetHashCode() { }

		[CompilerGenerated]
		[NullableContext(1)]
		protected override bool PrintMembers(StringBuilder builder) { }

		[CompilerGenerated]
		[NullableContext(1)]
		public virtual string ToString() { }

	}

	public enum TagValueType
	{
		None = 0,
		NumericalValue = 1,
		StringValue = 2,
		ColorValue = 4,
	}

	[Nullable(1)]
	internal static readonly TagTypeInfo[] TagsInfo; //Field offset: 0x0

	private static RichTextTagParser() { }

	[NullableContext(1)]
	private static int AddLink(TagType type, string value, List<ValueTuple`3<Int32, TagType, String>> links) { }

	[NullableContext(1)]
	internal static void ApplyStateToSegment(string input, List<Tag> tags, Segment[] segments) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static void CreateTextGenerationSettingsArray(ref NativeTextGenerationSettings tgs, List<ValueTuple`3<Int32, TagType, String>> links, Color hyperlinkColor) { }

	private static TextSpan CreateTextSpan(Segment segment, ref NativeTextGenerationSettings tgs, List<ValueTuple`3<Int32, TagType, String>> links, Color hyperlinkColor) { }

	[NullableContext(1)]
	internal static List<Tag> FindTags(string inputStr, List<ParseError> errors = null) { }

	[NullableContext(1)]
	internal static Segment[] GenerateSegments(string input, List<Tag> tags) { }

	[NullableContext(1)]
	internal static List<Tag> PickResultingTags(List<Tag> allTags, string input, int atPosition, List<Tag> applicableTags = null) { }

	private static bool SpanToEnum(ReadOnlySpan<Char> tagCandidate, out TagType tagType, out string error, out ReadOnlySpan<Char>& attribute) { }

	private static bool tagMatch(ReadOnlySpan<Char> tagCandidate, string tagName) { }

}

