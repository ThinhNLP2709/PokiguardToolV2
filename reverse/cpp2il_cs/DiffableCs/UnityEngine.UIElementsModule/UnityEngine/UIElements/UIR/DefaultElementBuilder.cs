namespace UnityEngine.UIElements.UIR;

internal class DefaultElementBuilder : BaseElementBuilder
{
	private RenderChain m_RenderChain; //Field offset: 0x10

	public DefaultElementBuilder(RenderChain renderChain) { }

	protected virtual void DrawVisualElementBackground(MeshGenerationContext mgc) { }

	protected virtual void DrawVisualElementBorder(MeshGenerationContext mgc) { }

	protected virtual void DrawVisualElementStencilMask(MeshGenerationContext mgc) { }

	private static void GenerateStencilClipEntryForRoundedRectBackground(MeshGenerationContext mgc) { }

	public virtual bool RequiresStencilMask(VisualElement ve) { }

	public virtual void ScheduleMeshGenerationJobs(MeshGenerationContext mgc) { }

}

