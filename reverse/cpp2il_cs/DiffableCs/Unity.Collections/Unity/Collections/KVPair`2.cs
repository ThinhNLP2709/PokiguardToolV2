namespace Unity.Collections;

[DebuggerDisplay("Key = {Key}, Value = {Value}")]
[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
public struct KVPair
{
	internal HashMapHelper<TKey>* m_Data; //Field offset: 0x0
	internal int m_Index; //Field offset: 0x0
	internal int m_Next; //Field offset: 0x0

	public TKey Key
	{
		 get { } //Length: 46
	}

	public static KVPair<TKey, TValue> Null
	{
		 get { } //Length: 17
	}

	public TValue Value
	{
		 get { } //Length: 78
	}

	public TKey get_Key() { }

	public static KVPair<TKey, TValue> get_Null() { }

	public TValue get_Value() { }

	public bool GetKeyValue(out TKey key, out TValue value) { }

}

