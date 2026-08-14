namespace UnityEngine.Rendering.Universal;

[ExcludeFromPreset]
public abstract class ScriptableRendererFeature : ScriptableObject, IDisposable
{
	[HideInInspector]
	[SerializeField]
	private bool m_Active; //Field offset: 0x18

	public bool isActive
	{
		 get { } //Length: 5
	}

	protected ScriptableRendererFeature() { }

	public abstract void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData) { }

	public abstract void Create() { }

	public override void Dispose() { }

	protected override void Dispose(bool disposing) { }

	public bool get_isActive() { }

	public override void OnCameraPreCull(ScriptableRenderer renderer, in CameraData cameraData) { }

	private void OnEnable() { }

	private void OnValidate() { }

	internal override bool RequireRenderingLayers(bool isDeferred, bool needsGBufferAccurateNormals, out Event atEvent, out MaskSize maskSize) { }

	public void SetActive(bool active) { }

	public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData) { }

	internal override bool SupportsNativeRenderPass() { }

}

