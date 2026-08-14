namespace UnityEngine.Rendering.Universal;

internal sealed class StpHistory : CameraHistoryItem
{
	private HistoryContext[] m_historyContexts; //Field offset: 0x20

	public StpHistory() { }

	internal HistoryContext GetHistoryContext(int eyeIndex) { }

	public virtual void OnCreate(BufferedRTHandleSystem owner, uint typeId) { }

	public virtual void Reset() { }

	internal bool Update(UniversalCameraData cameraData) { }

}

