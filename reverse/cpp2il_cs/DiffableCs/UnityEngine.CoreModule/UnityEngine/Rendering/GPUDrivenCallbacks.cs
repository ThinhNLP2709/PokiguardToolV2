namespace UnityEngine.Rendering;

[RequiredByNativeCode]
internal static class GPUDrivenCallbacks
{

	[RequiredByNativeCode(GenerateProxy = True)]
	public static void InvokeGPUDrivenLODGroupDataNativeCallback(GPUDrivenLODGroupDataNativeCallback callback, in GPUDrivenLODGroupDataNative lodGroupDataNative, GPUDrivenLODGroupDataCallback target) { }

	[RequiredByNativeCode(GenerateProxy = True)]
	public static void InvokeGPUDrivenRendererDataNativeCallback(GPUDrivenRendererDataNativeCallback callback, in GPUDrivenRendererGroupDataNative rendererDataNative, List<Mesh> meshes, List<Material> materials, GPUDrivenRendererDataCallback target) { }

}

