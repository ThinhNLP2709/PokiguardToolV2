namespace Unity.Mathematics;

[Il2CppEagerStaticClassConstruction]
public struct AffineTransform : IEquatable<AffineTransform>, IFormattable
{
	public static readonly AffineTransform identity; //Field offset: 0x0
	public static readonly AffineTransform zero; //Field offset: 0x30
	public float3x3 rs; //Field offset: 0x0
	public float3 t; //Field offset: 0x24

	private static AffineTransform() { }

	public AffineTransform(float3 translation, quaternion rotation) { }

	public AffineTransform(float3 translation, quaternion rotation, float3 scale) { }

	public AffineTransform(float3 translation, float3x3 rotationScale) { }

	public AffineTransform(float3x3 rotationScale) { }

	public AffineTransform(RigidTransform rigid) { }

	public AffineTransform(float3x4 m) { }

	public AffineTransform(float4x4 m) { }

	public override bool Equals(AffineTransform rhs) { }

	public virtual bool Equals(object o) { }

	public virtual int GetHashCode() { }

	public static float3x4 op_Implicit(AffineTransform m) { }

	public static float4x4 op_Implicit(AffineTransform m) { }

	public virtual string ToString() { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

}

