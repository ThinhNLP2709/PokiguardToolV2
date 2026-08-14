namespace UnityEngine.Rendering.Universal;

[DefaultMember("Item")]
internal struct Fixed2
{
	public T item1; //Field offset: 0x0
	public T item2; //Field offset: 0x0

	public T Item
	{
		 get { } //Length: 9
		 set { } //Length: 9
	}

	public Fixed2`1(T item1) { }

	public Fixed2`1(T item1, T item2) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckRange(int index) { }

	public T get_Item(int index) { }

	public void set_Item(int index, T value) { }

}

