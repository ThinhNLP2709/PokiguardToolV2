namespace UnityEngine.Rendering;

public abstract class RenderPipelineAsset : RenderPipelineAsset
{

	public virtual Type pipelineType
	{
		 get { } //Length: 56
	}

	public virtual string renderPipelineShaderTag
	{
		 get { } //Length: 89
	}

	[Obsolete("This property is obsolete. Use pipelineType instead. #from(23.2)", False)]
	protected private virtual Type renderPipelineType
	{
		private get { } //Length: 56
	}

	protected RenderPipelineAsset`1() { }

	public virtual Type get_pipelineType() { }

	public virtual string get_renderPipelineShaderTag() { }

	protected private virtual Type get_renderPipelineType() { }

}

