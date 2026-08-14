namespace UnityEngine.Rendering;

[Obsolete("VolumeComponentMenuForRenderPipelineAttribute is deprecated. Use VolumeComponentMenu with SupportedOnCurrentPipeline instead. #from(2023.1)", False)]
public class VolumeComponentMenuForRenderPipeline : VolumeComponentMenu
{
	[CompilerGenerated]
	private readonly Type[] <pipelineTypes>k__BackingField; //Field offset: 0x18

	public Type[] pipelineTypes
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public VolumeComponentMenuForRenderPipeline(string menu, Type[] pipelineTypes) { }

	[CompilerGenerated]
	public Type[] get_pipelineTypes() { }

}

