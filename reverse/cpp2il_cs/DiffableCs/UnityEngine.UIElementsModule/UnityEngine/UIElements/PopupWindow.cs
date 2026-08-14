namespace UnityEngine.UIElements;

public class PopupWindow : TextElement
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<PopupWindow, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{

		public UxmlTraits() { }

	}

	public static readonly string ussClassName; //Field offset: 0x0
	public static readonly string contentUssClassName; //Field offset: 0x8
	private VisualElement m_ContentContainer; //Field offset: 0x5A8

	public virtual VisualElement contentContainer
	{
		 get { } //Length: 10
	}

	private static PopupWindow() { }

	public PopupWindow() { }

	public virtual VisualElement get_contentContainer() { }

}

