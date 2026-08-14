namespace UnityEngine;

[NativeHeader("Runtime/Utilities/Hash128.h")]
[NativeHeader("Runtime/Export/Hashing/Hash128.bindings.h")]
[UsedByNativeCode]
public struct Hash128 : IComparable, IComparable<Hash128>, IEquatable<Hash128>
{
	private const ulong kConst = 16045690984833335023; //Field offset: 0x0
	internal ulong u64_0; //Field offset: 0x0
	internal ulong u64_1; //Field offset: 0x8

	public bool isValid
	{
		 get { } //Length: 22
	}

	public Hash128(uint u32_0, uint u32_1, uint u32_2, uint u32_3) { }

	public Hash128(ulong u64_0, ulong u64_1) { }

	public void Append(int val) { }

	public void Append(ref T val) { }

	public override int CompareTo(object obj) { }

	public override int CompareTo(Hash128 rhs) { }

	public static Hash128 Compute(ref T val) { }

	public static Hash128 Compute(int val) { }

	[FreeFunction("ComputeHash128FromScriptPointer", IsThreadSafe = True)]
	private static void ComputeFromPtr(IntPtr data, int start, int count, int elemSize, ref Hash128 hash) { }

	public override bool Equals(Hash128 obj) { }

	public virtual bool Equals(object obj) { }

	public bool get_isValid() { }

	public virtual int GetHashCode() { }

	[FreeFunction("Hash128ToString", IsThreadSafe = True)]
	private static string Hash128ToStringImpl(Hash128 hash) { }

	private static void Hash128ToStringImpl_Injected(in Hash128 hash, out ManagedSpanWrapper ret) { }

	public static bool op_Equality(Hash128 hash1, Hash128 hash2) { }

	public static bool op_GreaterThan(Hash128 x, Hash128 y) { }

	public static bool op_Inequality(Hash128 hash1, Hash128 hash2) { }

	public static bool op_LessThan(Hash128 x, Hash128 y) { }

	[FreeFunction("StringToHash128", IsThreadSafe = True)]
	public static Hash128 Parse(string hashString) { }

	private static void Parse_Injected(ref ManagedSpanWrapper hashString, out Hash128 ret) { }

	private static void Rot64(ref ulong x, int k) { }

	private static void ShortEnd(ref ulong h0, ref ulong h1, ref ulong h2, ref ulong h3) { }

	private void ShortHash4(uint data) { }

	public virtual string ToString() { }

}

