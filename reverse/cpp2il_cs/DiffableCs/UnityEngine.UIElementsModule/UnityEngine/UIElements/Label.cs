namespace UnityEngine.UIElements;

public class Label : TextElement
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<Label, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{

		public UxmlTraits() { }

	}

	public static readonly string ussClassName; //Field offset: 0x0

	private static Label() { }

	public Label(string text) { }

	public Label() { }

}

