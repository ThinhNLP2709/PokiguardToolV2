namespace UnityEngine.UIElements;

public class BindableElement : VisualElement, IBindable
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<BindableElement, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private UxmlStringAttributeDescription m_PropertyPath; //Field offset: 0x88

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	internal const string k_BindingPathTooltip = "Default method to define a path to a serialized property. Most often used for Editor extensions and inspectors."; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private IBinding <binding>k__BackingField; //Field offset: 0x4A8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <bindingPath>k__BackingField; //Field offset: 0x4B0

	public override IBinding binding
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public override string bindingPath
	{
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public BindableElement() { }

	[CompilerGenerated]
	public override IBinding get_binding() { }

	[CompilerGenerated]
	public override void set_bindingPath(string value) { }

}

