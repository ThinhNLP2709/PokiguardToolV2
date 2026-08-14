namespace Unity.Properties;

[IsReadOnly]
[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
internal struct ConversionRegistry : IEqualityComparer<ConversionRegistry>
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

	private static readonly ConverterKeyComparer Comparer; //Field offset: 0x0
	private readonly Dictionary<ConverterKey, Delegate> m_Converters; //Field offset: 0x0

	private static ConversionRegistry() { }

	private ConversionRegistry(Dictionary<ConverterKey, Delegate> storage) { }

	public static ConversionRegistry Create() { }

	public override bool Equals(ConversionRegistry x, ConversionRegistry y) { }

	public Delegate GetConverter(Type source, Type destination) { }

	public override int GetHashCode(ConversionRegistry obj) { }

	public void Register(Type source, Type destination, Delegate converter) { }

	public bool TryGetConverter(Type source, Type destination, out Delegate converter) { }

}

