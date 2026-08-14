namespace Unity.VisualScripting.Antlr3.Runtime;

public class BitSet
{
	protected private const int BITS = 64; //Field offset: 0x0
	protected private const int LOG_BITS = 6; //Field offset: 0x0
	protected private static readonly int MOD_MASK; //Field offset: 0x0
	protected private UInt64[] bits; //Field offset: 0x10

	public override int Count
	{
		 get { } //Length: 174
	}

	public override bool Nil
	{
		 get { } //Length: 89
	}

	private static BitSet() { }

	public BitSet(int nbits) { }

	public BitSet() { }

	public BitSet(UInt64[] bits_) { }

	public BitSet(IList items) { }

	public override void Add(int el) { }

	private static ulong BitMask(int bitNumber) { }

	public override object Clone() { }

	public virtual bool Equals(object other) { }

	public override int get_Count() { }

	public override bool get_Nil() { }

	public virtual int GetHashCode() { }

	public override void GrowToInclude(int bit) { }

	public override int LengthInLongWords() { }

	public override bool Member(int el) { }

	public override int NumBits() { }

	private int NumWordsToHold(int el) { }

	public static BitSet Of(int a, int b, int c, int d) { }

	public static BitSet Of(int a, int b, int c) { }

	public static BitSet Of(int el) { }

	public static BitSet Of(int a, int b) { }

	public override BitSet Or(BitSet a) { }

	public override void OrInPlace(BitSet a) { }

	public override void Remove(int el) { }

	private void SetSize(int nwords) { }

	public override Int32[] ToArray() { }

	public override UInt64[] ToPackedArray() { }

	public virtual string ToString() { }

	public override string ToString(String[] tokenNames) { }

	private static int WordNumber(int bit) { }

}

