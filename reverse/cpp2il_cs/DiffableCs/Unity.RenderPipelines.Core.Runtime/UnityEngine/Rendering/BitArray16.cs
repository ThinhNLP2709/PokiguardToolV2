namespace UnityEngine.Rendering;

[DebuggerDisplay("{this.GetType().Name} {humanizedData}")]
[DefaultMember("Item")]
public struct BitArray16 : IBitArray
{
	[SerializeField]
	private ushort data; //Field offset: 0x0

	public override bool allFalse
	{
		 get { } //Length: 8
	}

	public override bool allTrue
	{
		 get { } //Length: 12
	}

	public override uint capacity
	{
		 get { } //Length: 6
	}

	public override string humanizedData
	{
		 get { } //Length: 315
	}

	public override bool Item
	{
		 get { } //Length: 25
		 set { } //Length: 25
	}

	public BitArray16(ushort initValue) { }

	public BitArray16(IEnumerable<UInt32> bitIndexTrue) { }

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

	public static BitArray16 op_BitwiseAnd(BitArray16 a, BitArray16 b) { }

	public static BitArray16 op_BitwiseOr(BitArray16 a, BitArray16 b) { }

	public static bool op_Equality(BitArray16 a, BitArray16 b) { }

	public static bool op_Inequality(BitArray16 a, BitArray16 b) { }

	public static BitArray16 op_OnesComplement(BitArray16 a) { }

	public override void set_Item(uint index, bool value) { }

}

