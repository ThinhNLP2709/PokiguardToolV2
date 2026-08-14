namespace UnityEngine.UIElements;

[IsReadOnly]
public struct BindingInfo
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly VisualElement <targetElement>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly BindingId <bindingId>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly Binding <binding>k__BackingField; //Field offset: 0xA0

	public Binding binding
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	private BindingInfo(VisualElement targetElement, in BindingId bindingId, Binding binding) { }

	internal static BindingInfo FromBindingData(in BindingData bindingData) { }

	internal static BindingInfo FromRequest(VisualElement target, in PropertyPath targetPath, Binding binding) { }

	[CompilerGenerated]
	public Binding get_binding() { }

}

