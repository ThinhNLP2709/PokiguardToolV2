namespace UnityEngine.Rendering;

public interface IDebugDisplaySettings
{

	public IDebugDisplaySettingsData Add(IDebugDisplaySettingsData newData) { }

	public void ForEach(Action<IDebugDisplaySettingsData> onExecute) { }

	public void Reset() { }

}

