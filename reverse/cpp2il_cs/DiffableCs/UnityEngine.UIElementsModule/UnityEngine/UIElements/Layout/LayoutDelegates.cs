namespace UnityEngine.UIElements.Layout;

internal static class LayoutDelegates
{
	private static readonly ProfilerMarker s_InvokeMeasureFunctionMarker; //Field offset: 0x0
	private static readonly ProfilerMarker s_InvokeBaselineFunctionMarker; //Field offset: 0x8
	private static readonly InvokeMeasureFunctionDelegate s_InvokeMeasureDelegate; //Field offset: 0x10
	private static readonly InvokeBaselineFunctionDelegate s_InvokeBaselineDelegate; //Field offset: 0x18
	internal static readonly IntPtr s_InvokeMeasureFunction; //Field offset: 0x20
	internal static readonly IntPtr s_InvokeBaselineFunction; //Field offset: 0x28

	private static LayoutDelegates() { }

	[MonoPInvokeCallback(typeof(InvokeBaselineFunctionDelegate))]
	private static float InvokeBaselineFunction(ref LayoutNode node, float width, float height) { }

	[MonoPInvokeCallback(typeof(InvokeMeasureFunctionDelegate))]
	private static void InvokeMeasureFunction(ref LayoutNode node, float width, LayoutMeasureMode widthMode, float height, LayoutMeasureMode heightMode, ref IntPtr exception, out LayoutSize result) { }

}

