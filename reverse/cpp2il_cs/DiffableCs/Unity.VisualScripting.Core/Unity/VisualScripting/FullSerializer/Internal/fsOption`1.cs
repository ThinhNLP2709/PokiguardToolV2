namespace Unity.VisualScripting.FullSerializer.Internal;

public struct fsOption
{
	public static fsOption<T> Empty; //Field offset: 0x0
	private T _value; //Field offset: 0x0
	private bool _hasValue; //Field offset: 0x0

	public bool HasValue
	{
		 get { } //Length: 64
	}

	public bool IsEmpty
	{
		 get { } //Length: 67
	}

	public T Value
	{
		 get { } //Length: 353
	}

	public fsOption`1(T value) { }

	public bool get_HasValue() { }

	public bool get_IsEmpty() { }

	public T get_Value() { }

}

