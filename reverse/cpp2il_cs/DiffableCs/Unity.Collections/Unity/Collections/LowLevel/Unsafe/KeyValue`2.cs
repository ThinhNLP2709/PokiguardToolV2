namespace Unity.Collections.LowLevel.Unsafe;

[DebuggerDisplay("Key = {Key}, Value = {Value}")]
[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
public struct KeyValue
{
	internal UnsafeParallelHashMapData* m_Buffer; //Field offset: 0x0
	internal int m_Index; //Field offset: 0x0
	internal int m_Next; //Field offset: 0x0

	public TKey Key
	{
		 get { } //Length: 164
	}

	public static KeyValue<TKey, TValue> Null
	{
		 get { } //Length: 17
	}

	public TValue Value
	{
		 get { } //Length: 104
	}

	public TKey get_Key() { }

	public static KeyValue<TKey, TValue> get_Null() { }

	public TValue get_Value() { }

	public bool GetKeyValue(out TKey key, out TValue value) { }

}

