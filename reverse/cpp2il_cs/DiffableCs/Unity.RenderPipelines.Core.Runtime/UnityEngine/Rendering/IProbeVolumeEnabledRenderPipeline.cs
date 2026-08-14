namespace UnityEngine.Rendering;

public interface IProbeVolumeEnabledRenderPipeline
{

	public ProbeVolumeSHBands maxSHBands
	{
		 get { } //Length: 0
	}

	[Obsolete("This field is no longer necessary")]
	public ProbeVolumeSceneData probeVolumeSceneData
	{
		 get { } //Length: 0
	}

	public bool supportProbeVolume
	{
		 get { } //Length: 0
	}

	public ProbeVolumeSHBands get_maxSHBands() { }

	public ProbeVolumeSceneData get_probeVolumeSceneData() { }

	public bool get_supportProbeVolume() { }

}

