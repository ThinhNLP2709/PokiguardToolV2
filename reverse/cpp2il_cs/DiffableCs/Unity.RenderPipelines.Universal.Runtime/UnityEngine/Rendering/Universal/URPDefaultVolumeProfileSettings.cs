namespace UnityEngine.Rendering.Universal;

[CategoryInfo(Name = "Volume", Order = 0)]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
public class URPDefaultVolumeProfileSettings : IDefaultVolumeProfileSettings, IRenderPipelineGraphicsSettings
{
	public enum Version
	{
		Initial = 0,
	}

	[HideInInspector]
	[SerializeField]
	private Version m_Version; //Field offset: 0x10
	[SerializeField]
	private VolumeProfile m_VolumeProfile; //Field offset: 0x18

	public override int version
	{
		 get { } //Length: 4
	}

	public override VolumeProfile volumeProfile
	{
		 get { } //Length: 5
		 set { } //Length: 101
	}

	public URPDefaultVolumeProfileSettings() { }

	public override int get_version() { }

	public override VolumeProfile get_volumeProfile() { }

	public override void set_volumeProfile(VolumeProfile value) { }

}

