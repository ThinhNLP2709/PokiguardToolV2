namespace UnityEngine.Rendering;

internal sealed class GPUDrivenRendererDataCallback : MulticastDelegate
{

	public GPUDrivenRendererDataCallback(object object, IntPtr method) { }

	public override void Invoke(in GPUDrivenRendererGroupData rendererData, IList<Mesh> meshes, IList<Material> materials) { }

}

