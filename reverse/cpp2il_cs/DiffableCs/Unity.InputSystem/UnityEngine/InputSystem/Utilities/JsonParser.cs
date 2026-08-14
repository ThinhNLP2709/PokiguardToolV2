namespace UnityEngine.InputSystem.Utilities;

internal struct JsonParser
{
	internal struct JsonString : IEquatable<JsonString>
	{
		public Substring text; //Field offset: 0x0
		public bool hasEscapes; //Field offset: 0x10

		public override bool Equals(JsonString other) { }

		public virtual bool Equals(object obj) { }

		public virtual int GetHashCode() { }

		public static bool op_Equality(JsonString left, JsonString right) { }

		public static JsonString op_Implicit(string str) { }

		public static bool op_Inequality(JsonString left, JsonString right) { }

		public virtual string ToString() { }

	}

	internal struct JsonValue : IEquatable<JsonValue>
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Func<JsonValue, String> <>9__11_0; //Field offset: 0x8
			public static Func<KeyValuePair`2<String, JsonValue>, String> <>9__11_1; //Field offset: 0x10

			private static <>c() { }

			public <>c() { }

			internal string <ToString>b__11_0(JsonValue x) { }

			internal string <ToString>b__11_1(KeyValuePair<String, JsonValue> pair) { }

		}

		public JsonValueType type; //Field offset: 0x0
		public bool boolValue; //Field offset: 0x4
		public double realValue; //Field offset: 0x8
		public long integerValue; //Field offset: 0x10
		public JsonString stringValue; //Field offset: 0x18
		public List<JsonValue> arrayValue; //Field offset: 0x30
		public Dictionary<String, JsonValue> objectValue; //Field offset: 0x38
		public object anyValue; //Field offset: 0x40

		public virtual bool Equals(object obj) { }

		private static bool Equals(object obj, JsonValue value) { }

		public override bool Equals(JsonValue other) { }

		public virtual int GetHashCode() { }

		public static bool op_Equality(JsonValue left, JsonValue right) { }

		public static JsonValue op_Implicit(JsonString str) { }

		public static JsonValue op_Implicit(bool val) { }

		public static JsonValue op_Implicit(long val) { }

		public static JsonValue op_Implicit(double val) { }

		public static JsonValue op_Implicit(string str) { }

		public static JsonValue op_Implicit(List<JsonValue> array) { }

		public static JsonValue op_Implicit(Dictionary<String, JsonValue> obj) { }

		public static JsonValue op_Implicit(Enum val) { }

		public static bool op_Inequality(JsonValue left, JsonValue right) { }

		public bool ToBoolean() { }

		public double ToDouble() { }

		public long ToInteger() { }

		public virtual string ToString() { }

	}

	internal enum JsonValueType
	{
		None = 0,
		Bool = 1,
		Real = 2,
		Integer = 3,
		String = 4,
		Array = 5,
		Object = 6,
		Any = 7,
	}

	private readonly string m_Text; //Field offset: 0x0
	private readonly int m_Length; //Field offset: 0x8
	private int m_Position; //Field offset: 0xC
	private bool m_MatchAnyElementInArray; //Field offset: 0x10
	private bool m_DryRun; //Field offset: 0x11

	public bool isAtEnd
	{
		 get { } //Length: 10
	}

	public JsonParser(string json) { }

	public bool CurrentPropertyHasValueEqualTo(JsonValue expectedValue) { }

	public bool get_isAtEnd() { }

	public bool NavigateToProperty(string path) { }

	public bool ParseArrayValue(out JsonValue result) { }

	public bool ParseBooleanValue(out JsonValue result) { }

	public bool ParseNullValue(out JsonValue result) { }

	public bool ParseNumber(out JsonValue result) { }

	public bool ParseObjectValue(out JsonValue result) { }

	public bool ParseStringValue(out JsonValue result) { }

	public bool ParseToken(char token) { }

	public bool ParseValue() { }

	public bool ParseValue(out JsonValue result) { }

	public void Reset() { }

	private bool SkipString(string text) { }

	public bool SkipToValue() { }

	private void SkipWhitespace() { }

	public virtual string ToString() { }

}

