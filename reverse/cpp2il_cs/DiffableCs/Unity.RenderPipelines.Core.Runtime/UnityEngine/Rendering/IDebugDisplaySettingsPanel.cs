namespace UnityEngine.Rendering;

public interface IDebugDisplaySettingsPanel
{

	public Flags Flags
	{
		 get { } //Length: 0
	}

	public string PanelName
	{
		 get { } //Length: 0
	}

	public Widget[] Widgets
	{
		 get { } //Length: 0
	}

	public Flags get_Flags() { }

	public string get_PanelName() { }

	public Widget[] get_Widgets() { }

}

