namespace UnityEngine.ResourceManagement.AsyncOperations;

public struct DownloadStatus
{
	public long TotalBytes; //Field offset: 0x0
	public long DownloadedBytes; //Field offset: 0x8
	public bool IsDone; //Field offset: 0x10

	public float Percent
	{
		 get { } //Length: 47
	}

	public float get_Percent() { }

}

