namespace UnityEngine.Rendering;

public struct SphericalHarmonicsL1
{
	public static readonly SphericalHarmonicsL1 zero; //Field offset: 0x0
	public Vector4 shAr; //Field offset: 0x0
	public Vector4 shAg; //Field offset: 0x10
	public Vector4 shAb; //Field offset: 0x20

	private static SphericalHarmonicsL1() { }

	public virtual bool Equals(object other) { }

	public virtual int GetHashCode() { }

	public static SphericalHarmonicsL1 op_Addition(SphericalHarmonicsL1 lhs, SphericalHarmonicsL1 rhs) { }

	public static SphericalHarmonicsL1 op_Division(SphericalHarmonicsL1 lhs, float rhs) { }

	public static bool op_Equality(SphericalHarmonicsL1 lhs, SphericalHarmonicsL1 rhs) { }

	public static bool op_Inequality(SphericalHarmonicsL1 lhs, SphericalHarmonicsL1 rhs) { }

	public static SphericalHarmonicsL1 op_Multiply(SphericalHarmonicsL1 lhs, float rhs) { }

	public static SphericalHarmonicsL1 op_Subtraction(SphericalHarmonicsL1 lhs, SphericalHarmonicsL1 rhs) { }

}

