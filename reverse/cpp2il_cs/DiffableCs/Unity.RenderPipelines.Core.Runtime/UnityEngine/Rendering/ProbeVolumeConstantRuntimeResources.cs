namespace UnityEngine.Rendering;

internal static class ProbeVolumeConstantRuntimeResources
{
	private static ComputeBuffer m_SkySamplingDirectionsBuffer; //Field offset: 0x0
	private const int NB_SKY_PRECOMPUTED_DIRECTIONS = 255; //Field offset: 0x0
	private static ComputeBuffer m_AntiLeakDataBuffer; //Field offset: 0x8
	private static Vector3[] k_SkyDirections; //Field offset: 0x10
	private static UInt32[] k_AntiLeakData; //Field offset: 0x18

	private static ProbeVolumeConstantRuntimeResources() { }

	internal static void Cleanup() { }

	private static Vector3[] GenerateSkyDirections() { }

	internal static void GetRuntimeResources(ref RuntimeResources rr) { }

	public static Vector3[] GetSkySamplingDirections() { }

	internal static void Initialize() { }

}

