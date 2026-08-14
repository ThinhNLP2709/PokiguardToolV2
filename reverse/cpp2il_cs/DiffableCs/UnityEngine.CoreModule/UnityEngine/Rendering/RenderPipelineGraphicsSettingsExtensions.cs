namespace UnityEngine.Rendering;

[Extension]
public static class RenderPipelineGraphicsSettingsExtensions
{

	[Extension]
	public static void SetValueAndNotify(IRenderPipelineGraphicsSettings settings, ref T currentPropertyValue, T newValue, string propertyName = null) { }

}

