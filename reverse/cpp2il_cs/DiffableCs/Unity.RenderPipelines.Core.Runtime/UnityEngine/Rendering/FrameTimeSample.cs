namespace UnityEngine.Rendering;

internal struct FrameTimeSample
{
	internal float FramesPerSecond; //Field offset: 0x0
	internal float FullFrameTime; //Field offset: 0x4
	internal float MainThreadCPUFrameTime; //Field offset: 0x8
	internal float MainThreadCPUPresentWaitTime; //Field offset: 0xC
	internal float RenderThreadCPUFrameTime; //Field offset: 0x10
	internal float GPUFrameTime; //Field offset: 0x14

	internal FrameTimeSample(float initValue) { }

}

