namespace UnityEngine.Rendering;

internal class DebugRendererBatcherStats : IDisposable
{
	public bool enabled; //Field offset: 0x10
	public NativeList<InstanceCullerViewStats> instanceCullerStats; //Field offset: 0x18
	public NativeList<InstanceOcclusionEventStats> instanceOcclusionEventStats; //Field offset: 0x20
	public NativeList<DebugOccluderStats> occluderStats; //Field offset: 0x28
	public bool occlusionOverlayEnabled; //Field offset: 0x30
	public bool occlusionOverlayCountVisible; //Field offset: 0x31
	public bool overrideOcclusionTestToAlwaysPass; //Field offset: 0x32

	public DebugRendererBatcherStats() { }

	public override void Dispose() { }

}

