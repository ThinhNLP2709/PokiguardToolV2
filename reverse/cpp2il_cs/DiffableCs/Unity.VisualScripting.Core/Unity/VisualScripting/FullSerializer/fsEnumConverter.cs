namespace Unity.VisualScripting.FullSerializer;

public class fsEnumConverter : fsConverter
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"x", "previousName"})]
		public static Func<Enum, IEnumerable`1<ValueTuple`2<Enum, String>>> <>9__5_0; //Field offset: 0x8
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"enumMember", "previousName"})]
		public static Func<ValueTuple`2<Enum, String>, String> <>9__5_1; //Field offset: 0x10
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"enumMember", "previousName"})]
		public static Func<ValueTuple`2<Enum, String>, Enum> <>9__5_2; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal IEnumerable<ValueTuple`2<Enum, String>> <TryDeserialize>b__5_0(Enum x) { }

		internal string <TryDeserialize>b__5_1(ValueTuple<Enum, String> x) { }

		internal Enum <TryDeserialize>b__5_2(ValueTuple<Enum, String> x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public Enum x; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal ValueTuple<Enum, String> <TryDeserialize>b__3(RenamedFromAttribute attr) { }

	}


	public fsEnumConverter() { }

	private static bool ArrayContains(T[] values, T value) { }

	public virtual bool CanProcess(Type type) { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	public virtual bool RequestCycleSupport(Type storageType) { }

	public virtual bool RequestInheritanceSupport(Type storageType) { }

	public virtual fsResult TryDeserialize(fsData data, ref object instance, Type storageType) { }

	public virtual fsResult TrySerialize(object instance, out fsData serialized, Type storageType) { }

}

