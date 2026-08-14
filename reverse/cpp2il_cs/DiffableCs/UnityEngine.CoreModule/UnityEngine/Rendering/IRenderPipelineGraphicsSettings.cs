namespace UnityEngine.Rendering;

public interface IRenderPipelineGraphicsSettings
{

	public bool isAvailableInPlayerBuild
	{
		 get { } //Length: 3
	}

	public int version
	{
		 get { } //Length: 0
	}

	public bool get_isAvailableInPlayerBuild() { }

	public int get_version() { }

}

