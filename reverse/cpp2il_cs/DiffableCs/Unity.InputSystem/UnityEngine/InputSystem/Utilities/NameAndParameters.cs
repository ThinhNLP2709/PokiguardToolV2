namespace UnityEngine.InputSystem.Utilities;

public struct NameAndParameters
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<NamedValue, String> <>9__8_0; //Field offset: 0x8
		public static Func<NameAndParameters, String> <>9__9_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal string <ToSerializableString>b__9_0(NameAndParameters x) { }

		internal string <ToString>b__8_0(NamedValue x) { }

	}

	[CompilerGenerated]
	private string <name>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ReadOnlyArray<NamedValue> <parameters>k__BackingField; //Field offset: 0x8

	public string name
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public ReadOnlyArray<NamedValue> parameters
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 11
		[CompilerGenerated]
		 set { } //Length: 18
	}

	internal static NameAndParameters Create(string name, IList<NamedValue> parameters) { }

	[CompilerGenerated]
	[IsReadOnly]
	public string get_name() { }

	[CompilerGenerated]
	[IsReadOnly]
	public ReadOnlyArray<NamedValue> get_parameters() { }

	public static NameAndParameters Parse(string text) { }

	public static IEnumerable<NameAndParameters> ParseMultiple(string text) { }

	internal static bool ParseMultiple(string text, ref List<NameAndParameters>& list) { }

	internal static string ParseName(string text) { }

	private static NameAndParameters ParseNameAndParameters(string text, ref int index, bool nameOnly = false) { }

	[CompilerGenerated]
	public void set_name(string value) { }

	[CompilerGenerated]
	public void set_parameters(ReadOnlyArray<NamedValue> value) { }

	internal static string ToSerializableString(IEnumerable<NameAndParameters> list) { }

	public virtual string ToString() { }

}

