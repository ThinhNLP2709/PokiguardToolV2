namespace Unity.Mathematics;

[Il2CppEagerStaticClassConstruction]
public static class svd
{
	public const float k_EpsilonDeterminant = 1E-06; //Field offset: 0x0
	public const float k_EpsilonRCP = 1E-09; //Field offset: 0x0
	public const float k_EpsilonNormalSqrt = 1E-15; //Field offset: 0x0
	public const float k_EpsilonNormal = 1E-30; //Field offset: 0x0

	private static quaternion approxGivensQuat(float3 pq, float4 mask) { }

	private static void condNegSwap(bool c, ref float3 x, ref float3 y) { }

	private static quaternion condNegSwapQuat(bool c, quaternion q, float4 mask) { }

	private static void condSwap(bool c, ref float x, ref float y) { }

	private static quaternion givensQRFactorization(float3x3 b, out float3x3 r) { }

	private static quaternion jacobiIteration(ref float3x3 s, int iterations = 5) { }

	private static quaternion qrGivensQuat(float2 pq, float4 mask) { }

	private static float3 rcpsafe(float3 x, float epsilon = 1E-09) { }

	private static float3 singularValuesDecomposition(float3x3 a, out quaternion u, out quaternion v) { }

	private static void sortSingularValues(ref float3x3 b, ref quaternion v) { }

	public static float3x3 svdInverse(float3x3 a) { }

	public static quaternion svdRotation(float3x3 a) { }

}

