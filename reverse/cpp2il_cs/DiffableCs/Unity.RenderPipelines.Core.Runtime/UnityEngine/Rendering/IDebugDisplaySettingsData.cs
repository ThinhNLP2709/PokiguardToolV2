namespace UnityEngine.Rendering;

public interface IDebugDisplaySettingsData : IDebugDisplaySettingsQuery
{

	public IDebugDisplaySettingsPanelDisposable CreatePanel() { }

}

