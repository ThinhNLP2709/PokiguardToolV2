namespace UnityEngine.Rendering.RenderGraphModule;

internal class BufferPool : RenderGraphResourcePool<GraphicsBuffer>
{

	public BufferPool() { }

	protected virtual string GetResourceName(in GraphicsBuffer res) { }

	protected virtual long GetResourceSize(in GraphicsBuffer res) { }

	protected virtual string GetResourceTypeName() { }

	protected virtual int GetSortIndex(GraphicsBuffer res) { }

	protected virtual void ReleaseInternalResource(GraphicsBuffer res) { }

}

