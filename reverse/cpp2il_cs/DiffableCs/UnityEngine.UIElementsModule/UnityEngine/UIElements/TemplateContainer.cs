namespace UnityEngine.UIElements;

[HideInInspector]
[UxmlElement("Instance")]
public class TemplateContainer : BindableElement
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<TemplateContainer, UxmlTraits>
	{

		public virtual string uxmlName
		{
			 get { } //Length: 44
		}

		public virtual string uxmlQualifiedName
		{
			 get { } //Length: 120
		}

		public UxmlFactory() { }

		public virtual string get_uxmlName() { }

		public virtual string get_uxmlQualifiedName() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private UxmlStringAttributeDescription m_Template; //Field offset: 0x90

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	internal static readonly BindingId templateIdProperty; //Field offset: 0x0
	internal static readonly BindingId templateSourceProperty; //Field offset: 0x98
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <templateId>k__BackingField; //Field offset: 0x4B8
	private VisualElement m_ContentContainer; //Field offset: 0x4C0
	private VisualTreeAsset m_TemplateSource; //Field offset: 0x4C8

	public virtual VisualElement contentContainer
	{
		 get { } //Length: 10
	}

	[CreateProperty(ReadOnly = True)]
	public private string templateId
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[CreateProperty(ReadOnly = True)]
	public internal VisualTreeAsset templateSource
	{
		 get { } //Length: 8
		internal set { } //Length: 19
	}

	private static TemplateContainer() { }

	public TemplateContainer() { }

	public TemplateContainer(string templateId) { }

	internal TemplateContainer(string templateId, VisualTreeAsset templateSource) { }

	public virtual VisualElement get_contentContainer() { }

	[CompilerGenerated]
	public string get_templateId() { }

	public VisualTreeAsset get_templateSource() { }

	[CompilerGenerated]
	private void set_templateId(string value) { }

	internal void set_templateSource(VisualTreeAsset value) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal void SetContentContainer(VisualElement content) { }

}

