namespace UnityEngine.Rendering.RenderGraphModule;

internal class RenderGraphLogger
{
	private Dictionary<String, StringBuilder> m_LogMap; //Field offset: 0x10
	private StringBuilder m_CurrentBuilder; //Field offset: 0x18
	private int m_CurrentIndentation; //Field offset: 0x20

	public RenderGraphLogger() { }

	public void DecrementIndentation(int value) { }

	public string GetAllLogs() { }

	public string GetLog(string logName) { }

	public void IncrementIndentation(int value) { }

	public void Initialize(string logName) { }

	public void LogLine(string format, Object[] args) { }

}

