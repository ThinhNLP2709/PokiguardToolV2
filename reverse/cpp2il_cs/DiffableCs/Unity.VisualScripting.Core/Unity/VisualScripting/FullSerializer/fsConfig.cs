namespace Unity.VisualScripting.FullSerializer;

public class fsConfig
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, MemberInfo, String> <>9__10_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <.ctor>b__10_0(string name, MemberInfo info) { }

	}

	public Type[] SerializeAttributes; //Field offset: 0x10
	public Type[] IgnoreSerializeAttributes; //Field offset: 0x18
	public fsMemberSerialization DefaultMemberSerialization; //Field offset: 0x20
	public Func<String, MemberInfo, String> GetJsonNameFromMemberName; //Field offset: 0x28
	public bool EnablePropertySerialization; //Field offset: 0x30
	public bool SerializeNonAutoProperties; //Field offset: 0x31
	public bool SerializeNonPublicSetProperties; //Field offset: 0x32
	public string CustomDateTimeFormatString; //Field offset: 0x38
	public bool Serialize64BitIntegerAsString; //Field offset: 0x40
	public bool SerializeEnumsAsInteger; //Field offset: 0x41

	public fsConfig() { }

}

