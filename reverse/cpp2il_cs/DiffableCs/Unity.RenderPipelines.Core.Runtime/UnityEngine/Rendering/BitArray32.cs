namespace UnityEngine.Rendering;

[DebuggerDisplay("{this.GetType().Name} {humanizedData}")]
[DefaultMember("Item")]
public struct BitArray32 : IBitArray
{
	[SerializeField]
	private uint data; //Field offset: 0x0

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
		 get { } //Length: 315
	}

	private string humanizedVersion
	{
		private get { } //Length: 81
	}

	public override bool Item
	{
		 get { } //Length: 23
		 set { } //Length: 22
	}

	public BitArray32(IEnumerable<UInt32> bitIndexTrue) { }

	public BitArray32(uint initValue) { }

	public override IBitArray BitAnd(IBitArray other) { }

	public override IBitArray BitNot() { }

	public override IBitArray BitOr(IBitArray other) { }

	public virtual bool Equals(object obj) { }

	public override bool get_allFalse() { }

	public override bool get_allTrue() { }

	public override uint get_capacity() { }

	public override string get_humanizedData() { }

	private string get_humanizedVersion() { }

	public override bool get_Item(uint index) { }

	public virtual int GetHashCode() { }

	public static BitArray32 op_BitwiseAnd(BitArray32 a, BitArray32 b) { }

	public static BitArray32 op_BitwiseOr(BitArray32 a, BitArray32 b) { }

	public static bool op_Equality(BitArray32 a, BitArray32 b) { }

	public static bool op_Inequality(BitArray32 a, BitArray32 b) { }

	public static BitArray32 op_OnesComplement(BitArray32 a) { }

	public override void set_Item(uint index, bool value) { }

}

