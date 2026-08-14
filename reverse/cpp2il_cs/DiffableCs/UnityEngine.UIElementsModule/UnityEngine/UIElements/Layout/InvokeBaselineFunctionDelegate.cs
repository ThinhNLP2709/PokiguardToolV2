namespace UnityEngine.UIElements.Layout;

[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
internal sealed class InvokeBaselineFunctionDelegate : MulticastDelegate
{

	public InvokeBaselineFunctionDelegate(object object, IntPtr method) { }

	public override float Invoke(ref LayoutNode node, float width, float height) { }

}

