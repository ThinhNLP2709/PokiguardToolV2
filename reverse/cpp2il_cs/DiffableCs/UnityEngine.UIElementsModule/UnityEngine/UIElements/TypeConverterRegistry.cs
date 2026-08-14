namespace UnityEngine.UIElements;

[IsReadOnly]
internal struct TypeConverterRegistry : IEqualityComparer<TypeConverterRegistry>
{
	[IsReadOnly]
	private struct ConverterKey
	{
		public readonly Type SourceType; //Field offset: 0x0
		public readonly Type DestinationType; //Field offset: 0x8

		public ConverterKey(Type source, Type destination) { }

	}

	private class ConverterKeyComparer : IEqualityComparer<ConverterKey>
	{

		public ConverterKeyComparer() { }

		public override bool Equals(ConverterKey x, ConverterKey y) { }

		public override int GetHashCode(ConverterKey obj) { }

	}

	private static readonly ConverterKeyComparer k_Comparer; //Field offset: 0x0
	private readonly Dictionary<ConverterKey, Delegate> m_Converters; //Field offset: 0x0

	private static TypeConverterRegistry() { }

	private TypeConverterRegistry(Dictionary<ConverterKey, Delegate> storage) { }

	internal void Apply(TypeConverterRegistry registry) { }

	public static TypeConverterRegistry Create() { }

	public override bool Equals(TypeConverterRegistry x, TypeConverterRegistry y) { }

	public Delegate GetConverter(Type source, Type destination) { }

	public override int GetHashCode(TypeConverterRegistry obj) { }

	public void Register(Type source, Type destination, Delegate converter) { }

	public bool TryGetConverter(Type source, Type destination, out Delegate converter) { }

}

