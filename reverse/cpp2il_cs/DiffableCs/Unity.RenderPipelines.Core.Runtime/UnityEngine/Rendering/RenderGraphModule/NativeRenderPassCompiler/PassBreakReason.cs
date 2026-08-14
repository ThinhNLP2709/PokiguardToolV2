namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

internal enum PassBreakReason
{
	NotOptimized = 0,
	TargetSizeMismatch = 1,
	NextPassReadsTexture = 2,
	NonRasterPass = 3,
	DifferentDepthTextures = 4,
	AttachmentLimitReached = 5,
	SubPassLimitReached = 6,
	EndOfGraph = 7,
	FRStateMismatch = 8,
	Merged = 9,
	Count = 10,
}

