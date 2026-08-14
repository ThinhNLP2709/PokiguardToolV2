namespace UnityEngine.UIElements.Layout;

[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
internal sealed class InvokeMeasureFunctionDelegate : MulticastDelegate
{

	public InvokeMeasureFunctionDelegate(object object, IntPtr method) { }

	public override void Invoke(ref LayoutNode node, float width, LayoutMeasureMode widthMode, float height, LayoutMeasureMode heightMode, ref IntPtr exception, out LayoutSize result) { }

}

