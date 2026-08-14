namespace UnityEngine.Rendering;

public interface IDebugDisplaySettingsQuery
{

	public bool AreAnySettingsActive
	{
		 get { } //Length: 0
	}

	public bool IsLightingActive
	{
		 get { } //Length: 3
	}

	public bool IsPostProcessingAllowed
	{
		 get { } //Length: 3
	}

	public bool get_AreAnySettingsActive() { }

	public bool get_IsLightingActive() { }

	public bool get_IsPostProcessingAllowed() { }

	public bool TryGetScreenClearColor(ref Color color) { }

}

