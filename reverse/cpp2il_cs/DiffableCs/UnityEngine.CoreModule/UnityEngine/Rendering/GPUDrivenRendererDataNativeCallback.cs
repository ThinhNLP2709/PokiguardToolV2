namespace UnityEngine.Rendering;

internal sealed class GPUDrivenRendererDataNativeCallback : MulticastDelegate
{

	public GPUDrivenRendererDataNativeCallback(object object, IntPtr method) { }

	public override void Invoke(in GPUDrivenRendererGroupDataNative rendererDataNative, List<Mesh> meshes, List<Material> materials, GPUDrivenRendererDataCallback callback) { }

}

