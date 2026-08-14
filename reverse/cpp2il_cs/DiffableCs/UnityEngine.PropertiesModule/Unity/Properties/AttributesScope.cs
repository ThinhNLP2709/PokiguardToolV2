namespace Unity.Properties;

[IsReadOnly]
public struct AttributesScope : IDisposable
{
	private readonly IAttributes m_Target; //Field offset: 0x0
	private readonly List<Attribute> m_Previous; //Field offset: 0x8

	public AttributesScope(IProperty target, IProperty source) { }

	internal AttributesScope(IAttributes target, List<Attribute> attributes) { }

	public override void Dispose() { }

}

