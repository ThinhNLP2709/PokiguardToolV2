namespace UnityEngine.UIElements;

public class GroupBox : BindableElement, IGroupBox
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<GroupBox, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private UxmlStringAttributeDescription m_Text; //Field offset: 0x90

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	internal static readonly BindingId textProperty; //Field offset: 0x0
	public static readonly string ussClassName; //Field offset: 0x98
	public static readonly string labelUssClassName; //Field offset: 0xA0
	private Label m_TitleLabel; //Field offset: 0x4B8

	[CreateProperty]
	public string text
	{
		 get { } //Length: 35
		 set { } //Length: 504
	}

	private static GroupBox() { }

	public GroupBox() { }

	public GroupBox(string text) { }

	public string get_text() { }

	public void set_text(string value) { }

	private override void UnityEngine.UIElements.IGroupBox.OnOptionAdded(IGroupBoxOption option) { }

	private override void UnityEngine.UIElements.IGroupBox.OnOptionRemoved(IGroupBoxOption option) { }

}

