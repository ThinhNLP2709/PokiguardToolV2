namespace UnityEngine;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
[NativeClass("Vector4f")]
[NativeHeader("Runtime/Math/Vector4.h")]
[RequiredByNativeCode(Optional = True, GenerateProxy = True)]
public struct Vector4 : IEquatable<Vector4>, IFormattable
{
	public const float kEpsilon = 1E-05; //Field offset: 0x0
	private static readonly Vector4 zeroVector; //Field offset: 0x0
	private static readonly Vector4 oneVector; //Field offset: 0x10
	private static readonly Vector4 positiveInfinityVector; //Field offset: 0x20
	private static readonly Vector4 negativeInfinityVector; //Field offset: 0x30
	public float x; //Field offset: 0x0
	public float y; //Field offset: 0x4
	public float z; //Field offset: 0x8
	public float w; //Field offset: 0xC

	public float Item
	{
		 get { } //Length: 144
		 set { } //Length: 144
	}

	public float magnitude
	{
		 get { } //Length: 194
	}

	public Vector4 normalized
	{
		 get { } //Length: 196
	}

	public static Vector4 one
	{
		 get { } //Length: 67
	}

	public float sqrMagnitude
	{
		 get { } //Length: 77
	}

	public static Vector4 zero
	{
		 get { } //Length: 66
	}

	private static Vector4() { }

	public Vector4(float x, float y, float z, float w) { }

	public Vector4(float x, float y, float z) { }

	public Vector4(float x, float y) { }

	public static float Distance(Vector4 a, Vector4 b) { }

	public static float Dot(Vector4 a, Vector4 b) { }

	public override bool Equals(Vector4 other) { }

	public virtual bool Equals(object other) { }

	public float get_Item(int index) { }

	public float get_magnitude() { }

	public Vector4 get_normalized() { }

	public static Vector4 get_one() { }

	public float get_sqrMagnitude() { }

	public static Vector4 get_zero() { }

	public virtual int GetHashCode() { }

	public static Vector4 Lerp(Vector4 a, Vector4 b, float t) { }

	public static float Magnitude(Vector4 a) { }

	public static Vector4 Max(Vector4 lhs, Vector4 rhs) { }

	public static Vector4 Min(Vector4 lhs, Vector4 rhs) { }

	public static Vector4 MoveTowards(Vector4 current, Vector4 target, float maxDistanceDelta) { }

	public static Vector4 Normalize(Vector4 a) { }

	public static Vector4 op_Addition(Vector4 a, Vector4 b) { }

	public static Vector4 op_Division(Vector4 a, float d) { }

	public static bool op_Equality(Vector4 lhs, Vector4 rhs) { }

	public static Vector2 op_Implicit(Vector4 v) { }

	public static Vector4 op_Implicit(Vector2 v) { }

	public static Vector3 op_Implicit(Vector4 v) { }

	public static Vector4 op_Implicit(Vector3 v) { }

	public static bool op_Inequality(Vector4 lhs, Vector4 rhs) { }

	public static Vector4 op_Multiply(Vector4 a, float d) { }

	public static Vector4 op_Multiply(float d, Vector4 a) { }

	public static Vector4 op_Subtraction(Vector4 a, Vector4 b) { }

	public static Vector4 op_UnaryNegation(Vector4 a) { }

	public void Scale(Vector4 scale) { }

	public void Set(float newX, float newY, float newZ, float newW) { }

	public void set_Item(int index, float value) { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

	public virtual string ToString() { }

}

