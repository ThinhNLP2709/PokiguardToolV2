namespace UnityEngine.Rendering;

public struct Observable
{
	[CompilerGenerated]
	private Action<T> onValueChanged; //Field offset: 0x0
	private T m_Value; //Field offset: 0x0

	public event Action<T> onValueChanged
	{
		[CompilerGenerated]
		 add { } //Length: 308
		[CompilerGenerated]
		 remove { } //Length: 308
	}

	public T value
	{
		 get { } //Length: 209
		 set { } //Length: 885
	}

	public Observable`1(T newValue) { }

	[CompilerGenerated]
	public void add_onValueChanged(Action<T> value) { }

	public T get_value() { }

	[CompilerGenerated]
	public void remove_onValueChanged(Action<T> value) { }

	public void set_value(T value) { }

}

