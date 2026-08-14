namespace UnityEngine.Rendering.RenderGraphModule;

internal class TexturePool : RenderGraphResourcePool<RTHandle>
{

	public TexturePool() { }

	protected virtual string GetResourceName(in RTHandle res) { }

	protected virtual long GetResourceSize(in RTHandle res) { }

	protected virtual string GetResourceTypeName() { }

	protected virtual int GetSortIndex(RTHandle res) { }

	protected virtual void ReleaseInternalResource(RTHandle res) { }

}

