namespace UnityEngine.Rendering;

[RequiredByNativeCode]
public class OnDemandRendering
{
	private static int m_RenderFrameInterval; //Field offset: 0x0

	public static int effectiveRenderFrameRate
	{
		 get { } //Length: 118
	}

	public static int renderFrameInterval
	{
		 get { } //Length: 77
	}

	public static bool willCurrentFrameRender
	{
		 get { } //Length: 143
	}

	private static OnDemandRendering() { }

	public static int get_effectiveRenderFrameRate() { }

	public static int get_renderFrameInterval() { }

	public static bool get_willCurrentFrameRender() { }

	[FreeFunction]
	internal static float GetEffectiveRenderFrameRate() { }

	[RequiredByNativeCode]
	internal static void GetRenderFrameInterval(out int frameInterval) { }

}

