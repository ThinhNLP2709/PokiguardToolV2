namespace UnityEngine.UIElements.Internal;

internal class TypePathVisitor : ITypeVisitor, IPropertyBagVisitor, IPropertyVisitor
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private PropertyPath <Path>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Type <resolvedType>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private VisitReturnCode <ReturnCode>k__BackingField; //Field offset: 0xA8
	private Type m_LastType; //Field offset: 0xB0
	private int m_PathIndex; //Field offset: 0xB8

	public PropertyPath Path
	{
		[CompilerGenerated]
		 get { } //Length: 84
		[CompilerGenerated]
		 set { } //Length: 91
	}

	private Type resolvedType
	{
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public internal VisitReturnCode ReturnCode
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	public TypePathVisitor() { }

	[CompilerGenerated]
	public PropertyPath get_Path() { }

	[CompilerGenerated]
	public VisitReturnCode get_ReturnCode() { }

	private static Type GetElementType(Type type) { }

	private bool IsLastPartReached() { }

	public void Reset() { }

	[CompilerGenerated]
	public void set_Path(PropertyPath value) { }

	[CompilerGenerated]
	private void set_resolvedType(Type value) { }

	[CompilerGenerated]
	internal void set_ReturnCode(VisitReturnCode value) { }

	private override void Unity.Properties.IPropertyBagVisitor.Visit(IPropertyBag<TContainer> properties, ref TContainer container) { }

	private override void Unity.Properties.IPropertyVisitor.Visit(Property<TContainer, TValue> property, ref TContainer container) { }

	private override void Unity.Properties.ITypeVisitor.Visit() { }

}

