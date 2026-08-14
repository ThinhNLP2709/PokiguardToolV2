namespace Unity.VisualScripting;

public sealed class FakeSerializationCloner : ReflectedCloner
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<fsMetaProperty, MemberInfo> <>9__6_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal MemberInfo <GetMembers>b__6_0(fsMetaProperty p) { }

	}

	[CompilerGenerated]
	private fsConfig <config>k__BackingField; //Field offset: 0x20

	public fsConfig config
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public FakeSerializationCloner() { }

	public virtual void AfterClone(Type type, object clone) { }

	public virtual void BeforeClone(Type type, object original) { }

	[CompilerGenerated]
	public fsConfig get_config() { }

	protected virtual IEnumerable<MemberInfo> GetMembers(Type type) { }

	[CompilerGenerated]
	public void set_config(fsConfig value) { }

}

