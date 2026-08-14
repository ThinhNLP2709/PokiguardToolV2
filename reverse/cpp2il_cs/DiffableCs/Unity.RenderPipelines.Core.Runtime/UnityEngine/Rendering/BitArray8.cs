namespace UnityEngine.Rendering;

[DebuggerDisplay("{this.GetType().Name} {humanizedData}")]
[DefaultMember("Item")]
public struct BitArray8 : IBitArray
{
	[SerializeField]
	private byte data; //Field offset: 0x0

	public override bool allFalse
	{
		 get { } //Length: 7
	}

	public override bool allTrue
	{
		 get { } //Length: 7
	}

	public override uint capacity
	{
		 get { } //Length: 6
	}

	public override string humanizedData
	{
		 get { } //Length: 210
	}

	public override bool Item
	{
		 get { } //Length: 25
		 set { } //Length: 23
	}

	public BitArray8(byte initValue) { }

	public BitArray8(IEnumerable<UInt32> bitIndexTrue) { }

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

	public static BitArray8 op_BitwiseAnd(BitArray8 a, BitArray8 b) { }

	public static BitArray8 op_BitwiseOr(BitArray8 a, BitArray8 b) { }

	public static bool op_Equality(BitArray8 a, BitArray8 b) { }

	public static bool op_Inequality(BitArray8 a, BitArray8 b) { }

	public static BitArray8 op_OnesComplement(BitArray8 a) { }

	public override void set_Item(uint index, bool value) { }

}

