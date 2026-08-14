namespace UnityEngine.Rendering;

[NativeHeader("Runtime/Graphics/GPUFence.h")]
[UsedByNativeCode]
public struct GraphicsFence
{
	internal IntPtr m_Ptr; //Field offset: 0x0
	internal int m_Version; //Field offset: 0x8
	internal GraphicsFenceType m_FenceType; //Field offset: 0xC

	private int GetPlatformNotSupportedVersion() { }

	[FreeFunction("GPUFenceInternals::GetVersionNumber")]
	[NativeThrows]
	private static int GetVersionNumber(IntPtr fencePtr) { }

	internal void InitPostAllocation() { }

	internal bool IsFencePending() { }

	internal static SynchronisationStageFlags TranslateSynchronizationStageToFlags(SynchronisationStage s) { }

	internal void Validate() { }

}

