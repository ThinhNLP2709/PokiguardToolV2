namespace UnityEngine.UIElements.UIR;

internal abstract class BaseElementBuilder
{

	protected BaseElementBuilder() { }

	public void Build(MeshGenerationContext mgc) { }

	protected abstract void DrawVisualElementBackground(MeshGenerationContext mgc) { }

	protected abstract void DrawVisualElementBorder(MeshGenerationContext mgc) { }

	protected abstract void DrawVisualElementStencilMask(MeshGenerationContext mgc) { }

	private static void InvokeGenerateVisualContent(MeshGenerationContext mgc) { }

	private static void PopVisualElementClipping(MeshGenerationContext mgc) { }

	private void PushVisualElementClipping(MeshGenerationContext mgc) { }

	public abstract bool RequiresStencilMask(VisualElement ve) { }

	public abstract void ScheduleMeshGenerationJobs(MeshGenerationContext mgc) { }

}

