namespace UnityEngine.UIElements;

public class RepeatButton : TextElement
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<RepeatButton, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private UxmlLongAttributeDescription m_Delay; //Field offset: 0xD0
		private UxmlLongAttributeDescription m_Interval; //Field offset: 0xD8

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	public static readonly string ussClassName; //Field offset: 0x0
	private Clickable m_Clickable; //Field offset: 0x5A8

	private static RepeatButton() { }

	public RepeatButton() { }

	public RepeatButton(Action clickEvent, long delay, long interval) { }

	internal void AddAction(Action clickEvent) { }

	public void SetAction(Action clickEvent, long delay, long interval) { }

}

