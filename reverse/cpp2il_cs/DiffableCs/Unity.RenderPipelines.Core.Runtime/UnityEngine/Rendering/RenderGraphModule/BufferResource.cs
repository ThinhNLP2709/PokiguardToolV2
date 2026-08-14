namespace UnityEngine.Rendering.RenderGraphModule;

[DebuggerDisplay("BufferResource ({desc.name})")]
internal class BufferResource : RenderGraphResource<BufferDesc, GraphicsBuffer>
{

	public BufferResource() { }

	public virtual void CreateGraphicsResource() { }

	public virtual int GetDescHashCode() { }

	public virtual string GetName() { }

	public virtual void LogCreation(RenderGraphLogger logger) { }

	public virtual void LogRelease(RenderGraphLogger logger) { }

	public virtual void ReleaseGraphicsResource() { }

	public virtual void UpdateGraphicsResource() { }

}

