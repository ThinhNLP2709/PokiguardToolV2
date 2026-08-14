namespace UnityEngine.Rendering;

internal struct BinningConfig
{
	public int viewCount; //Field offset: 0x0
	public bool supportsCrossFade; //Field offset: 0x4
	public bool supportsMotionCheck; //Field offset: 0x5

	public int visibilityConfigCount
	{
		 get { } //Length: 33
	}

	public int get_visibilityConfigCount() { }

}

