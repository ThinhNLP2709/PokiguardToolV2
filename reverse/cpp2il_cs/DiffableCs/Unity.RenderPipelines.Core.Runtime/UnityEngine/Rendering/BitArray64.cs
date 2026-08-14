namespace UnityEngine.Rendering;

[DebuggerDisplay("{this.GetType().Name} {humanizedData}")]
[DefaultMember("Item")]
public struct BitArray64 : IBitArray
{
	[SerializeField]
	private ulong data; //Field offset: 0x0

	public override bool allFalse
	{
		 get { } //Length: 8
	}

	public override bool allTrue
	{
		 get { } //Length: 8
	}

	public override uint capacity
	{
		 get { } //Length: 6
	}

	public override string humanizedData
	{
		 get { } //Length: 316
	}

	public override bool Item
	{
		 get { } //Length: 24
		 set { } //Length: 27
	}

	public BitArray64(ulong initValue) { }

	public BitArray64(IEnumerable<UInt32> bitIndexTrue) { }

	public override IBitArray BitAnd(IBitArray other) { }

	public override IBitArray BitNot() { }

	public override IBitArray BitOr(IBitArray other) { }

	public virtual bool Equals(object obj) { }

	public override bool get_allFalse() { }

	public override bool get_allTrue() { }

	public override uint get_capacity() { }

	public override string get_humanizedData() { }

	public override bool get_Item(uint index) { }

	public virtual int GetHashCode() { }

	public static BitArray64 op_BitwiseAnd(BitArray64 a, BitArray64 b) { }

	public static BitArray64 op_BitwiseOr(BitArray64 a, BitArray64 b) { }

	public static bool op_Equality(BitArray64 a, BitArray64 b) { }

	public static bool op_Inequality(BitArray64 a, BitArray64 b) { }

	public static BitArray64 op_OnesComplement(BitArray64 a) { }

	public override void set_Item(uint index, bool value) { }

}

