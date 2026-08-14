namespace Unity.VisualScripting;

public abstract class SerializedPropertyProvider : ScriptableObject, ISerializedPropertyProvider
{
	[SerializeField]
	protected T item; //Field offset: 0x0

	private override object Unity.VisualScripting.ISerializedPropertyProvider.item
	{
		private get { } //Length: 169
		private set { } //Length: 195
	}

	protected SerializedPropertyProvider`1() { }

	private override object Unity.VisualScripting.ISerializedPropertyProvider.get_item() { }

	private override void Unity.VisualScripting.ISerializedPropertyProvider.set_item(object value) { }

}

