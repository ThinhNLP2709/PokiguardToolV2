namespace UnityEngine.UIElements;

public class HelpBox : VisualElement
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<HelpBox, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private UxmlStringAttributeDescription m_Text; //Field offset: 0x88
		private UxmlEnumAttributeDescription<HelpBoxMessageType> m_MessageType; //Field offset: 0x90

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	internal static readonly BindingId textProperty; //Field offset: 0x0
	internal static readonly BindingId messageTypeProperty; //Field offset: 0x98
	public static readonly string ussClassName; //Field offset: 0x130
	public static readonly string labelUssClassName; //Field offset: 0x138
	public static readonly string iconUssClassName; //Field offset: 0x140
	public static readonly string iconInfoUssClassName; //Field offset: 0x148
	public static readonly string iconwarningUssClassName; //Field offset: 0x150
	public static readonly string iconErrorUssClassName; //Field offset: 0x158
	private HelpBoxMessageType m_HelpBoxMessageType; //Field offset: 0x4A8
	private VisualElement m_Icon; //Field offset: 0x4B0
	private string m_IconClass; //Field offset: 0x4B8
	private Label m_Label; //Field offset: 0x4C0

	[CreateProperty]
	public HelpBoxMessageType messageType
	{
		 get { } //Length: 9
		 set { } //Length: 137
	}

	[CreateProperty]
	public string text
	{
		 get { } //Length: 45
		 set { } //Length: 245
	}

	private static HelpBox() { }

	public HelpBox() { }

	public HelpBox(string text, HelpBoxMessageType messageType) { }

	public HelpBoxMessageType get_messageType() { }

	public string get_text() { }

	private string GetIconClass(HelpBoxMessageType messageType) { }

	public void set_messageType(HelpBoxMessageType value) { }

	public void set_text(string value) { }

	private void UpdateIcon(HelpBoxMessageType messageType) { }

}

