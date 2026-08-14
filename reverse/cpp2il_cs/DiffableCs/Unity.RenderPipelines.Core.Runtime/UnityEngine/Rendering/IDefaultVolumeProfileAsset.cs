namespace UnityEngine.Rendering;

public interface IDefaultVolumeProfileAsset : IRenderPipelineGraphicsSettings
{

	public VolumeProfile defaultVolumeProfile
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public VolumeProfile get_defaultVolumeProfile() { }

	public void set_defaultVolumeProfile(VolumeProfile value) { }

}

