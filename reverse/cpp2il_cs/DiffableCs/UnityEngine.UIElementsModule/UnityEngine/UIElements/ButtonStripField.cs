namespace UnityEngine.UIElements;

internal class ButtonStripField : BaseField<Int32>
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<ButtonStripField, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits<Int32>
	{

		public UxmlTraits() { }

	}

	private readonly List<Button> m_Buttons; //Field offset: 0x528

	public ButtonStripField() { }

	private void RefreshButtonsState() { }

	public virtual void SetValueWithoutNotify(int newValue) { }

}

