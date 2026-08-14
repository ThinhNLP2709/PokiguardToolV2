namespace UnityEngine.Networking;

public struct DownloadedTextureParams
{
	public DownloadedTextureFlags flags; //Field offset: 0x0
	public int mipmapCount; //Field offset: 0x4

	public static DownloadedTextureParams Default
	{
		 get { } //Length: 22
	}

	public bool readable
	{
		 set { } //Length: 23
	}

	public static DownloadedTextureParams get_Default() { }

	public void set_readable(bool value) { }

	private void SetFlags(DownloadedTextureFlags flgs, bool add) { }

}

