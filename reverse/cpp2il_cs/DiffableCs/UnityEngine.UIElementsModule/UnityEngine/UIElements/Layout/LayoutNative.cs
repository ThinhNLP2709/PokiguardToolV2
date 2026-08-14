namespace UnityEngine.UIElements.Layout;

[NativeHeader("Modules/UIElements/Core/Layout/Native/LayoutNative.h")]
internal static class LayoutNative
{
	public class LayoutLogData
	{
		public LayoutNode node; //Field offset: 0x10
		public LayoutLogEventType eventType; //Field offset: 0x40
		public string message; //Field offset: 0x48

		public LayoutLogData() { }

	}

	public enum LayoutLogEventType
	{
		None = 0,
		Error = 1,
		Measure = 2,
		Layout = 3,
		CacheUsage = 4,
		BeginLayout = 5,
		EndLayout = 6,
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action<LayoutLogData> onLayoutLog; //Field offset: 0x0

	[NativeMethod(IsThreadSafe = False)]
	internal static void CalculateLayout(IntPtr node, float parentWidth, float parentHeight, int parentDirection, IntPtr state, IntPtr exceptionGCHandle) { }

	[RequiredByNativeCode]
	private static void LayoutLog_Internal(IntPtr nodePtr, LayoutLogEventType type, string message) { }

}

