namespace UnityEngine.UIElements;

[NativeType(Header = "Modules/UIElements/Core/Native/Renderer/UIRenderer.h")]
public sealed class UIRenderer : Renderer
{
	internal List<CommandList>[] commandLists; //Field offset: 0x18
	internal bool skipRendering; //Field offset: 0x20

	[RequiredByNativeCode]
	private static void OnRenderNodeExecute(UIRenderer renderer, int safeFrameIndex, int cmdListIndex) { }

	internal void SetNativeData(int safeFrameIndex, int cmdListIndex, Material mat) { }

	private static void SetNativeData_Injected(IntPtr _unity_self, int safeFrameIndex, int cmdListIndex, IntPtr mat) { }

}

