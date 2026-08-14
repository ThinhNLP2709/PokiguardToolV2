namespace UnityEngine.Rendering;

public struct SHCoefficients : IEquatable<SHCoefficients>
{
	public Vector4 SHAr; //Field offset: 0x0
	public Vector4 SHAg; //Field offset: 0x10
	public Vector4 SHAb; //Field offset: 0x20
	public Vector4 SHBr; //Field offset: 0x30
	public Vector4 SHBg; //Field offset: 0x40
	public Vector4 SHBb; //Field offset: 0x50
	public Vector4 SHC; //Field offset: 0x60
	public Vector4 ProbesOcclusion; //Field offset: 0x70

	public SHCoefficients(SphericalHarmonicsL2 sh) { }

	public SHCoefficients(SphericalHarmonicsL2 sh, Vector4 probesOcclusion) { }

	public override bool Equals(SHCoefficients other) { }

	public virtual bool Equals(object obj) { }

	public virtual int GetHashCode() { }

	private static Vector4 GetSHA(SphericalHarmonicsL2 sh, int i) { }

	private static Vector4 GetSHB(SphericalHarmonicsL2 sh, int i) { }

	private static Vector4 GetSHC(SphericalHarmonicsL2 sh) { }

	public static bool op_Equality(SHCoefficients left, SHCoefficients right) { }

	public static bool op_Inequality(SHCoefficients left, SHCoefficients right) { }

}

