namespace UnityEngine.Rendering;

[Extension]
[NativeHeader("Runtime/Export/Graphics/RenderingCommandBufferExtensions.bindings.h")]
[UsedByNativeCode]
public static class CommandBufferExtensions
{

	[FreeFunction("RenderingCommandBufferExtensions_Bindings::Internal_SwitchIntoFastMemory")]
	private static void Internal_SwitchIntoFastMemory(CommandBuffer cmd, ref RenderTargetIdentifier rt, FastMemoryFlags fastMemoryFlags, float residency, bool copyContents) { }

	private static void Internal_SwitchIntoFastMemory_Injected(IntPtr cmd, ref RenderTargetIdentifier rt, FastMemoryFlags fastMemoryFlags, float residency, bool copyContents) { }

	[FreeFunction("RenderingCommandBufferExtensions_Bindings::Internal_SwitchOutOfFastMemory")]
	private static void Internal_SwitchOutOfFastMemory(CommandBuffer cmd, ref RenderTargetIdentifier rt, bool copyContents) { }

	private static void Internal_SwitchOutOfFastMemory_Injected(IntPtr cmd, ref RenderTargetIdentifier rt, bool copyContents) { }

	[Extension]
	[NativeConditional("UNITY_XBOXONE || UNITY_GAMECORE_XBOXONE")]
	public static void SwitchIntoFastMemory(CommandBuffer cmd, RenderTargetIdentifier rid, FastMemoryFlags fastMemoryFlags, float residency, bool copyContents) { }

	[Extension]
	[NativeConditional("UNITY_XBOXONE || UNITY_GAMECORE_XBOXONE")]
	public static void SwitchOutOfFastMemory(CommandBuffer cmd, RenderTargetIdentifier rid, bool copyContents) { }

}

