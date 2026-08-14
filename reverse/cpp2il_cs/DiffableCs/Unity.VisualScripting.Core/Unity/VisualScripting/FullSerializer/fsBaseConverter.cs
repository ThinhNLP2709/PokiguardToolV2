namespace Unity.VisualScripting.FullSerializer;

public abstract class fsBaseConverter
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<fsDataType, String> <>9__6_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <FailExpectedType>b__6_0(fsDataType t) { }

	}

	public fsSerializer Serializer; //Field offset: 0x10

	protected fsBaseConverter() { }

	protected fsResult CheckKey(fsData data, string key, out fsData subitem) { }

	protected fsResult CheckKey(Dictionary<String, fsData> data, string key, out fsData subitem) { }

	protected fsResult CheckType(fsData data, fsDataType type) { }

	public override object CreateInstance(fsData data, Type storageType) { }

	protected fsResult DeserializeMember(Dictionary<String, fsData> data, Type overrideConverterType, string name, out T value) { }

	protected fsResult FailExpectedType(fsData data, fsDataType[] types) { }

	public override bool RequestCycleSupport(Type storageType) { }

	public override bool RequestInheritanceSupport(Type storageType) { }

	protected fsResult SerializeMember(Dictionary<String, fsData> data, Type overrideConverterType, string name, T value) { }

	public abstract fsResult TryDeserialize(fsData data, ref object instance, Type storageType) { }

	public abstract fsResult TrySerialize(object instance, out fsData serialized, Type storageType) { }

}

