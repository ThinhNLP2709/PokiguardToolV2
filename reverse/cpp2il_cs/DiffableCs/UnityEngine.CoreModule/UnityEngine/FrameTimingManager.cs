namespace UnityEngine;

[StaticAccessor("GetUncheckedRealGfxDevice().GetFrameTimingManager()", StaticAccessorType::Dot (0))]
public static class FrameTimingManager
{

	public static void CaptureFrameTimings() { }

	public static uint GetLatestTimings(uint numFrames, FrameTiming[] timings) { }

	private static uint GetLatestTimings_Injected(uint numFrames, ref ManagedSpanWrapper timings) { }

}

