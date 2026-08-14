namespace UnityEngine.Rendering;

[NativeHeader("Modules/Terrain/Public/SpeedTreeWindManager.h")]
[StaticAccessor("GetSpeedTreeWindManager()", StaticAccessorType::Dot (0))]
internal static class SpeedTreeWindManager
{

	public static void UpdateWindAndWriteBufferWindParams(ReadOnlySpan<Int32> renderersID, SpeedTreeWindParamsBufferIterator windParams, bool history) { }

	private static void UpdateWindAndWriteBufferWindParams_Injected(ref ManagedSpanWrapper renderersID, in SpeedTreeWindParamsBufferIterator windParams, bool history) { }

}

