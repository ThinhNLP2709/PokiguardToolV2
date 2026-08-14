namespace UnityEngine.InputSystem.Utilities;

public struct FourCC : IEquatable<FourCC>
{
	private int m_Code; //Field offset: 0x0

	public FourCC(int code) { }

	public FourCC(char a, char b =  , char c =  , char d =  ) { }

	public FourCC(string str) { }

	public override bool Equals(FourCC other) { }

	public virtual bool Equals(object obj) { }

	public static FourCC FromInt32(int i) { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(FourCC left, FourCC right) { }

	public static int op_Implicit(FourCC fourCC) { }

	public static FourCC op_Implicit(int i) { }

	public static bool op_Inequality(FourCC left, FourCC right) { }

	public static int ToInt32(FourCC fourCC) { }

	public virtual string ToString() { }

}

