namespace Unity.Properties;

public abstract class Property : IProperty<TContainer>, IProperty, IPropertyAccept<TContainer>, IAttributes
{
	private List<Attribute> m_Attributes; //Field offset: 0x0

	public abstract bool IsReadOnly
	{
		 get { } //Length: 0
	}

	public abstract string Name
	{
		 get { } //Length: 0
	}

	private override List<Attribute> Unity.Properties.Internal.IAttributes.Attributes
	{
		private get { } //Length: 5
		private set { } //Length: 13
	}

	protected Property`2() { }

	public override void Accept(IPropertyVisitor visitor, ref TContainer container) { }

	protected void AddAttribute(Attribute attribute) { }

	protected void AddAttributes(IEnumerable<Attribute> attributes) { }

	public override Type DeclaredValueType() { }

	public abstract bool get_IsReadOnly() { }

	public abstract string get_Name() { }

	public override TAttribute GetAttribute() { }

	public abstract TValue GetValue(ref TContainer container) { }

	public override bool HasAttribute() { }

	public abstract void SetValue(ref TContainer container, TValue value) { }

	private override void Unity.Properties.Internal.IAttributes.AddAttribute(Attribute attribute) { }

	private override void Unity.Properties.Internal.IAttributes.AddAttributes(IEnumerable<Attribute> attributes) { }

	private override AttributesScope Unity.Properties.Internal.IAttributes.CreateAttributesScope(IAttributes attributes) { }

	private override List<Attribute> Unity.Properties.Internal.IAttributes.get_Attributes() { }

	private override void Unity.Properties.Internal.IAttributes.set_Attributes(List<Attribute> value) { }

}

