namespace UnityEngine.Rendering;

[CategoryInfo(Name = "Adaptive Probe Volumes", Order = 20)]
[SupportedOnRenderPipeline(new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
internal class ProbeVolumeGlobalSettings : IRenderPipelineGraphicsSettings
{
	[HideInInspector]
	[SerializeField]
	private int m_Version; //Field offset: 0x10
	[SerializeField]
	[Tooltip("Enabling this will make APV baked data assets compatible with Addressables and Asset Bundles. This will also make Disk Streaming unavailable. After changing this setting, a clean rebuild may be required for data assets to be included in Adressables and Asset Bundles.")]
	private bool m_ProbeVolumeDisableStreamingAssets; //Field offset: 0x14

	public bool probeVolumeDisableStreamingAssets
	{
		 get { } //Length: 5
		 set { } //Length: 102
	}

	public override int version
	{
		 get { } //Length: 4
	}

	public ProbeVolumeGlobalSettings() { }

	public bool get_probeVolumeDisableStreamingAssets() { }

	public override int get_version() { }

	public void set_probeVolumeDisableStreamingAssets(bool value) { }

}

