namespace UnityEngine.UIElements;

[IsReadOnly]
public struct BindablePropertyChangedEventArgs
{
	private readonly BindingId m_PropertyName; //Field offset: 0x0

	public BindingId propertyName
	{
		 get { } //Length: 96
	}

	public BindablePropertyChangedEventArgs(in BindingId propertyName) { }

	public BindingId get_propertyName() { }

}

