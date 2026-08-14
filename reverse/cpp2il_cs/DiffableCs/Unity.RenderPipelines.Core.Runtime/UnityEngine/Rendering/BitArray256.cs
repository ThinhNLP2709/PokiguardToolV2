namespace UnityEngine.Rendering;

[DebuggerDisplay("{this.GetType().Name} {humanizedData}")]
[DefaultMember("Item")]
public struct BitArray256 : IBitArray
{
	[SerializeField]
	private ulong data1; //Field offset: 0x0
	[SerializeField]
	private ulong data2; //Field offset: 0x8
	[SerializeField]
	private ulong data3; //Field offset: 0x10
	[SerializeField]
	private ulong data4; //Field offset: 0x18

	public override bool allFalse
	{
		 get { } //Length: 32
	}

	public override bool allTrue
	{
		 get { } //Length: 32
	}

	public override uint capacity
	{
		 get { } //Length: 6
	}

	public override string humanizedData
	{
		 get { } //Length: 771
	}

	public override bool Item
	{
		 get { } //Length: 65
		 set { } //Length: 131
	}

	public BitArray256(ulong initValue1, ulong initValue2, ulong initValue3, ulong initValue4) { }

	public BitArray256(IEnumerable<UInt32> bitIndexTrue) { }

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

	public static BitArray256 op_BitwiseAnd(BitArray256 a, BitArray256 b) { }

	public static BitArray256 op_BitwiseOr(BitArray256 a, BitArray256 b) { }

	public static bool op_Equality(BitArray256 a, BitArray256 b) { }

	public static bool op_Inequality(BitArray256 a, BitArray256 b) { }

	public static BitArray256 op_OnesComplement(BitArray256 a) { }

	public override void set_Item(uint index, bool value) { }

}

