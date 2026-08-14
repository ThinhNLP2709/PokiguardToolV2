namespace UnityEngine.Rendering;

public static class CameraCaptureBridge
{
	private class CameraEntry
	{
		internal HashSet<Action`2<RenderTargetIdentifier, CommandBuffer>> actions; //Field offset: 0x10
		internal IEnumerator<Action`2<RenderTargetIdentifier, CommandBuffer>> cachedEnumerator; //Field offset: 0x18

		public CameraEntry() { }

	}

	private static Dictionary<Camera, CameraEntry> actionDict; //Field offset: 0x0
	private static bool _enabled; //Field offset: 0x8

	public static bool enabled
	{
		 get { } //Length: 79
		 set { } //Length: 84
	}

	private static CameraCaptureBridge() { }

	public static void AddCaptureAction(Camera camera, Action<RenderTargetIdentifier, CommandBuffer> action) { }

	public static bool get_enabled() { }

	internal static IEnumerator<Action`2<RenderTargetIdentifier, CommandBuffer>> GetCachedCaptureActionsEnumerator(Camera camera) { }

	public static IEnumerator<Action`2<RenderTargetIdentifier, CommandBuffer>> GetCaptureActions(Camera camera) { }

	public static void RemoveCaptureAction(Camera camera, Action<RenderTargetIdentifier, CommandBuffer> action) { }

	public static void set_enabled(bool value) { }

}

