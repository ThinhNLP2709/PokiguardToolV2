namespace UnityEngine.Rendering;

[DebuggerDisplay("{this.GetType().Name} {humanizedData}")]
[DefaultMember("Item")]
public struct BitArray128 : IBitArray
{
	[SerializeField]
	private ulong data1; //Field offset: 0x0
	[SerializeField]
	private ulong data2; //Field offset: 0x8

	public override bool allFalse
	{
		 get { } //Length: 18
	}

	public override bool allTrue
	{
		 get { } //Length: 18
	}

	public override uint capacity
	{
		 get { } //Length: 6
	}

	public override string humanizedData
	{
		 get { } //Length: 478
	}

	public override bool Item
	{
		 get { } //Length: 33
		 set { } //Length: 63
	}

	public BitArray128(ulong initValue1, ulong initValue2) { }

	public BitArray128(IEnumerable<UInt32> bitIndexTrue) { }

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

	public static BitArray128 op_BitwiseAnd(BitArray128 a, BitArray128 b) { }

	public static BitArray128 op_BitwiseOr(BitArray128 a, BitArray128 b) { }

	public static bool op_Equality(BitArray128 a, BitArray128 b) { }

	public static bool op_Inequality(BitArray128 a, BitArray128 b) { }

	public static BitArray128 op_OnesComplement(BitArray128 a) { }

	public override void set_Item(uint index, bool value) { }

}

