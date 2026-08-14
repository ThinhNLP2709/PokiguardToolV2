namespace UnityEngine.Rendering.Universal;

public class UniversalRenderPipelineVolumeDebugSettings : VolumeDebugSettings<UniversalAdditionalCameraData>
{

	public virtual LayerMask selectedCameraLayerMask
	{
		 get { } //Length: 226
	}

	public virtual Vector3 selectedCameraPosition
	{
		 get { } //Length: 250
	}

	public virtual VolumeStack selectedCameraVolumeStack
	{
		 get { } //Length: 299
	}

	[Obsolete("This property is obsolete and kept only for not breaking user code. VolumeDebugSettings will use current pipeline when it needs to gather volume component types and paths. #from(23.2)", False)]
	public virtual Type targetRenderPipeline
	{
		 get { } //Length: 77
	}

	public UniversalRenderPipelineVolumeDebugSettings() { }

	public virtual LayerMask get_selectedCameraLayerMask() { }

	public virtual Vector3 get_selectedCameraPosition() { }

	public virtual VolumeStack get_selectedCameraVolumeStack() { }

	public virtual Type get_targetRenderPipeline() { }

}

