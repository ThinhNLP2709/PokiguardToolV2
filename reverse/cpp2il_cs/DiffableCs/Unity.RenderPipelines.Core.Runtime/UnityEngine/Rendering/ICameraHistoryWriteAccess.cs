namespace UnityEngine.Rendering;

public interface ICameraHistoryWriteAccess
{

	public Type GetHistoryForWrite() { }

	public bool IsAccessRequested() { }

	public bool IsWritten() { }

}

