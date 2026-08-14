namespace UnityEngine.UIElements;

public class DropdownField : PopupField<String>
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<DropdownField, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits<String>
	{
		private UxmlIntAttributeDescription m_Index; //Field offset: 0x98
		private UxmlStringAttributeDescription m_Choices; //Field offset: 0xA0

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}


	public DropdownField() { }

	public DropdownField(string label) { }

}

