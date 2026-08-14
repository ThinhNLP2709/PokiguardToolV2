namespace UnityEngine.VFX;

[NativeHeader("Modules/VFX/Public/VFXManager.h")]
[NativeHeader("Modules/VFX/Public/ScriptBindings/VFXManagerBindings.h")]
[RequiredByNativeCode]
[StaticAccessor("GetVFXManager()", StaticAccessorType::Dot (0))]
public static class VFXManager
{
	private static readonly VFXCameraXRSettings kDefaultCameraXRSettings; //Field offset: 0x0

	private static VFXManager() { }

	private static void Internal_ProcessCameraCommand(Camera cam, CommandBuffer cmd, VFXCameraXRSettings camXRSettings, IntPtr cullResults) { }

	private static void Internal_ProcessCameraCommand_Injected(IntPtr cam, IntPtr cmd, in VFXCameraXRSettings camXRSettings, IntPtr cullResults) { }

	public static VFXCameraBufferTypes IsCameraBufferNeeded(Camera cam) { }

	private static VFXCameraBufferTypes IsCameraBufferNeeded_Injected(IntPtr cam) { }

	public static void ProcessCameraCommand(Camera cam, CommandBuffer cmd, VFXCameraXRSettings camXRSettings, CullingResults results) { }

	public static void SetCameraBuffer(Camera cam, VFXCameraBufferTypes type, Texture buffer, int x, int y, int width, int height) { }

	private static void SetCameraBuffer_Injected(IntPtr cam, VFXCameraBufferTypes type, IntPtr buffer, int x, int y, int width, int height) { }

}

