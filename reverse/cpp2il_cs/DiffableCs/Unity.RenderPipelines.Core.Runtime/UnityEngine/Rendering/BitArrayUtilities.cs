namespace UnityEngine.Rendering;

public static class BitArrayUtilities
{

	public static bool Get128(uint index, ulong data1, ulong data2) { }

	public static bool Get16(uint index, ushort data) { }

	public static bool Get256(uint index, ulong data1, ulong data2, ulong data3, ulong data4) { }

	public static bool Get32(uint index, uint data) { }

	public static bool Get64(uint index, ulong data) { }

	public static bool Get8(uint index, byte data) { }

	public static void Set128(uint index, ref ulong data1, ref ulong data2, bool value) { }

	public static void Set16(uint index, ref ushort data, bool value) { }

	public static void Set256(uint index, ref ulong data1, ref ulong data2, ref ulong data3, ref ulong data4, bool value) { }

	public static void Set32(uint index, ref uint data, bool value) { }

	public static void Set64(uint index, ref ulong data, bool value) { }

	public static void Set8(uint index, ref byte data, bool value) { }

}

