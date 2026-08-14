namespace UnityEngine;

public struct LazyLoadReference
{
	private const int kInstanceID_None = 0; //Field offset: 0x0
	[SerializeField]
	private int m_InstanceID; //Field offset: 0x0

	public T asset
	{
		 get { } //Length: 193
		 set { } //Length: 246
	}

	public bool isSet
	{
		 get { } //Length: 7
	}

	public T get_asset() { }

	public bool get_isSet() { }

	public static LazyLoadReference<T> op_Implicit(T asset) { }

	public void set_asset(T value) { }

}

