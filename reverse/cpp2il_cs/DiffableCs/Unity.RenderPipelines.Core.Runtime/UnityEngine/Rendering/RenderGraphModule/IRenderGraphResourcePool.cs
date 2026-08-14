namespace UnityEngine.Rendering.RenderGraphModule;

internal abstract class IRenderGraphResourcePool
{

	protected IRenderGraphResourcePool() { }

	public abstract void CheckFrameAllocation(bool onException, int frameIndex) { }

	public abstract void Cleanup() { }

	public abstract void LogResources(RenderGraphLogger logger) { }

	public abstract void PurgeUnusedResources(int currentFrameIndex) { }

}

