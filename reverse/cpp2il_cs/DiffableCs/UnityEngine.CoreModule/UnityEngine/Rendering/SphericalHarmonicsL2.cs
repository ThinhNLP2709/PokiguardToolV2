namespace UnityEngine.Rendering;

[DefaultMember("Item")]
[NativeHeader("Runtime/Export/Math/SphericalHarmonicsL2.bindings.h")]
[UsedByNativeCode]
public struct SphericalHarmonicsL2 : IEquatable<SphericalHarmonicsL2>
{
	private float shr0; //Field offset: 0x0
	private float shr1; //Field offset: 0x4
	private float shr2; //Field offset: 0x8
	private float shr3; //Field offset: 0xC
	private float shr4; //Field offset: 0x10
	private float shr5; //Field offset: 0x14
	private float shr6; //Field offset: 0x18
	private float shr7; //Field offset: 0x1C
	private float shr8; //Field offset: 0x20
	private float shg0; //Field offset: 0x24
	private float shg1; //Field offset: 0x28
	private float shg2; //Field offset: 0x2C
	private float shg3; //Field offset: 0x30
	private float shg4; //Field offset: 0x34
	private float shg5; //Field offset: 0x38
	private float shg6; //Field offset: 0x3C
	private float shg7; //Field offset: 0x40
	private float shg8; //Field offset: 0x44
	private float shb0; //Field offset: 0x48
	private float shb1; //Field offset: 0x4C
	private float shb2; //Field offset: 0x50
	private float shb3; //Field offset: 0x54
	private float shb4; //Field offset: 0x58
	private float shb5; //Field offset: 0x5C
	private float shb6; //Field offset: 0x60
	private float shb7; //Field offset: 0x64
	private float shb8; //Field offset: 0x68

	public float Item
	{
		 get { } //Length: 432
		 set { } //Length: 432
	}

	public virtual bool Equals(object other) { }

	public override bool Equals(SphericalHarmonicsL2 other) { }

	public float get_Item(int rgb, int coefficient) { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(SphericalHarmonicsL2 lhs, SphericalHarmonicsL2 rhs) { }

	public static bool op_Inequality(SphericalHarmonicsL2 lhs, SphericalHarmonicsL2 rhs) { }

	public void set_Item(int rgb, int coefficient, float value) { }

}

