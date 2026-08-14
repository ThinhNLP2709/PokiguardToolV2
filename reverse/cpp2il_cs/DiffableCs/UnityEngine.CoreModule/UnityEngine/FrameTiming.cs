namespace UnityEngine;

[NativeHeader("Runtime/GfxDevice/FrameTiming.h")]
public struct FrameTiming
{
	[NativeName("totalFrameTime")]
	public double cpuFrameTime; //Field offset: 0x0
	[NativeName("mainThreadActiveTime")]
	public double cpuMainThreadFrameTime; //Field offset: 0x8
	[NativeName("mainThreadPresentWaitTime")]
	public double cpuMainThreadPresentWaitTime; //Field offset: 0x10
	[NativeName("renderThreadActiveTime")]
	public double cpuRenderThreadFrameTime; //Field offset: 0x18
	[NativeName("gpuFrameTime")]
	public double gpuFrameTime; //Field offset: 0x20
	[NativeName("frameStartTimestamp")]
	public ulong frameStartTimestamp; //Field offset: 0x28
	[NativeName("firstSubmitTimestamp")]
	public ulong firstSubmitTimestamp; //Field offset: 0x30
	[NativeName("presentFrameTimestamp")]
	public ulong cpuTimePresentCalled; //Field offset: 0x38
	[NativeName("frameCompleteTimestamp")]
	public ulong cpuTimeFrameComplete; //Field offset: 0x40
	[NativeName("heightScale")]
	public float heightScale; //Field offset: 0x48
	[NativeName("widthScale")]
	public float widthScale; //Field offset: 0x4C
	[NativeName("syncInterval")]
	public uint syncInterval; //Field offset: 0x50

}

