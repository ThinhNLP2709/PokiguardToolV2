namespace UnityEngine.Rendering.RenderGraphModule;

internal class IRenderGraphResource
{
	public bool imported; //Field offset: 0x10
	public bool shared; //Field offset: 0x11
	public bool sharedExplicitRelease; //Field offset: 0x12
	public bool requestFallBack; //Field offset: 0x13
	public bool forceRelease; //Field offset: 0x14
	public uint writeCount; //Field offset: 0x18
	public int cachedHash; //Field offset: 0x1C
	public int transientPassIndex; //Field offset: 0x20
	public int sharedResourceLastFrameUsed; //Field offset: 0x24
	public int version; //Field offset: 0x28

	public IRenderGraphResource() { }

	public override void CreateGraphicsResource() { }

	public override void CreatePooledGraphicsResource() { }

	public override int GetDescHashCode() { }

	public override string GetName() { }

	public override int GetSortIndex() { }

	public override void IncrementWriteCount() { }

	public override bool IsCreated() { }

	public override void LogCreation(RenderGraphLogger logger) { }

	public override void LogRelease(RenderGraphLogger logger) { }

	public override bool NeedsFallBack() { }

	public override int NewVersion() { }

	public override void ReleaseGraphicsResource() { }

	public override void ReleasePooledGraphicsResource(int frameIndex) { }

	public override void Reset(IRenderGraphResourcePool _ = null) { }

	public override void UpdateGraphicsResource() { }

}

