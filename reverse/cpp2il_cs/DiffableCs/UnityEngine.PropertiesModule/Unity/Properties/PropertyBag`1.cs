namespace Unity.Properties;

public abstract class PropertyBag : IPropertyBag<TContainer>, IPropertyBag, IPropertyBagRegister, IConstructor<TContainer>, IConstructor
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly InstantiationKind <InstantiationKind>k__BackingField; //Field offset: 0x0

	protected override InstantiationKind InstantiationKind
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	private override InstantiationKind Unity.Properties.IConstructor.InstantiationKind
	{
		private get { } //Length: 20
	}

	private static PropertyBag`1() { }

	protected PropertyBag`1() { }

	public override void Accept(ITypeVisitor visitor) { }

	[CompilerGenerated]
	protected override InstantiationKind get_InstantiationKind() { }

	public abstract PropertyCollection<TContainer> GetProperties() { }

	public abstract PropertyCollection<TContainer> GetProperties(ref TContainer container) { }

	protected override TContainer Instantiate() { }

	private override InstantiationKind Unity.Properties.IConstructor.get_InstantiationKind() { }

	private override TContainer Unity.Properties.IConstructor<TContainer>.Instantiate() { }

	private override void Unity.Properties.Internal.IPropertyBagRegister.Register() { }

	private override void Unity.Properties.IPropertyBag.Accept(IPropertyBagVisitor visitor, ref object container) { }

	private override void Unity.Properties.IPropertyBag<TContainer>.Accept(IPropertyBagVisitor visitor, ref TContainer container) { }

	private override PropertyCollection<TContainer> Unity.Properties.IPropertyBag<TContainer>.GetProperties() { }

	private override PropertyCollection<TContainer> Unity.Properties.IPropertyBag<TContainer>.GetProperties(ref TContainer container) { }

}

