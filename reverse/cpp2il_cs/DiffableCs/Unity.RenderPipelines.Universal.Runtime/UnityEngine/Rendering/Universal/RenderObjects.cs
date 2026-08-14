namespace UnityEngine.Rendering.Universal;

[ExcludeFromPreset]
[MovedFrom(True, "UnityEngine.Experimental.Rendering.Universal", null, null)]
[Tooltip("Render Objects simplifies the injection of additional render passes by exposing a selection of commonly used settings.")]
public class RenderObjects : ScriptableRendererFeature
{
	internal class CustomCameraSettings
	{
		public bool overrideCamera; //Field offset: 0x10
		public bool restoreCamera; //Field offset: 0x11
		public Vector4 offset; //Field offset: 0x14
		public float cameraFieldOfView; //Field offset: 0x24

		public CustomCameraSettings() { }

	}

	internal class FilterSettings
	{
		public RenderQueueType RenderQueueType; //Field offset: 0x10
		public LayerMask LayerMask; //Field offset: 0x14
		public String[] PassNames; //Field offset: 0x18

		public FilterSettings() { }

	}

	internal class RenderObjectsSettings
	{
		internal enum OverrideMaterialMode
		{
			None = 0,
			Material = 1,
			Shader = 2,
		}

		public string passTag; //Field offset: 0x10
		public RenderPassEvent Event; //Field offset: 0x18
		public FilterSettings filterSettings; //Field offset: 0x20
		public Material overrideMaterial; //Field offset: 0x28
		public int overrideMaterialPassIndex; //Field offset: 0x30
		public Shader overrideShader; //Field offset: 0x38
		public int overrideShaderPassIndex; //Field offset: 0x40
		public OverrideMaterialMode overrideMode; //Field offset: 0x44
		public bool overrideDepthState; //Field offset: 0x48
		public CompareFunction depthCompareFunction; //Field offset: 0x4C
		public bool enableWrite; //Field offset: 0x50
		public StencilStateData stencilSettings; //Field offset: 0x58
		public CustomCameraSettings cameraSettings; //Field offset: 0x60

		public RenderObjectsSettings() { }

	}

	public RenderObjectsSettings settings; //Field offset: 0x20
	private RenderObjectsPass renderObjectsPass; //Field offset: 0x28

	public RenderObjects() { }

	public virtual void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData) { }

	public virtual void Create() { }

	internal virtual bool SupportsNativeRenderPass() { }

}

