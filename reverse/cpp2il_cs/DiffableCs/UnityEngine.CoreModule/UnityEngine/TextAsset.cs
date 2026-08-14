namespace UnityEngine;

[NativeHeader("Runtime/Scripting/TextAsset.h")]
public class TextAsset : object
{
	private static class EncodingUtility
	{
		internal static readonly KeyValuePair<Byte[], Encoding>[] encodingLookup; //Field offset: 0x0
		internal static readonly Encoding targetEncoding; //Field offset: 0x8

		private static EncodingUtility() { }

	}


	public Byte[] bytes
	{
		 get { } //Length: 119
	}

	public string text
	{
		 get { } //Length: 169
	}

	internal static string DecodeString(Byte[] bytes) { }

	public Byte[] get_bytes() { }

	private static Byte[] get_bytes_Injected(IntPtr _unity_self) { }

	public string get_text() { }

	public NativeArray<T> GetData() { }

	private IntPtr GetDataPtr() { }

	private static IntPtr GetDataPtr_Injected(IntPtr _unity_self) { }

	private long GetDataSize() { }

	private static long GetDataSize_Injected(IntPtr _unity_self) { }

	public virtual string ToString() { }

}

