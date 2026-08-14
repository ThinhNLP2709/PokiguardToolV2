//Type is in global namespace

public struct ObfuscatedInt
{
	private static readonly Random _rng; //Field offset: 0x0
	[SerializeField]
	private int _stored; //Field offset: 0x0
	[SerializeField]
	private int _keyA; //Field offset: 0x4
	[SerializeField]
	private int _keyB; //Field offset: 0x8
	[SerializeField]
	private int _noise; //Field offset: 0xC

	public int Value
	{
		 get { } //Length: 113
		 set { } //Length: 292
	}

	private static ObfuscatedInt() { }

	public ObfuscatedInt(int value) { }

	public virtual bool Equals(object obj) { }

	public int get_Value() { }

	public virtual int GetHashCode() { }

	public static int op_Implicit(ObfuscatedInt o) { }

	public static ObfuscatedInt op_Implicit(int v) { }

	private static int RotateLeft(int v, int n) { }

	private static int RotateRight(int v, int n) { }

	public void set_Value(int value) { }

	public virtual string ToString() { }

}

