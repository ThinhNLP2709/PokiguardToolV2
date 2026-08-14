namespace UnityEngine.Rendering.Universal;

[Extension]
public static class CameraExtensions
{

	[Extension]
	public static void DestroyVolumeStack(Camera camera) { }

	[Extension]
	public static void DestroyVolumeStack(Camera camera, UniversalAdditionalCameraData cameraData) { }

	[Extension]
	public static UniversalAdditionalCameraData GetUniversalAdditionalCameraData(Camera camera) { }

	[Extension]
	public static VolumeFrameworkUpdateMode GetVolumeFrameworkUpdateMode(Camera camera) { }

	[Extension]
	internal static void GetVolumeLayerMaskAndTrigger(Camera camera, UniversalAdditionalCameraData cameraData, out LayerMask layerMask, out Transform trigger) { }

	[Extension]
	public static void SetVolumeFrameworkUpdateMode(Camera camera, VolumeFrameworkUpdateMode mode) { }

	[Extension]
	public static void UpdateVolumeStack(Camera camera) { }

	[Extension]
	public static void UpdateVolumeStack(Camera camera, UniversalAdditionalCameraData cameraData) { }

}

