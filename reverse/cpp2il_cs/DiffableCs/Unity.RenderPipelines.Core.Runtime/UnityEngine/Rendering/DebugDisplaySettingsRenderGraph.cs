namespace UnityEngine.Rendering;

internal class DebugDisplaySettingsRenderGraph : IDebugDisplaySettingsData, IDebugDisplaySettingsQuery
{
	[DisplayInfo(name = "Render Graph", order = 10)]
	private class SettingsPanel : DebugDisplaySettingsPanel
	{

		public virtual string PanelName
		{
			 get { } //Length: 44
		}

		public SettingsPanel(DebugDisplaySettingsRenderGraph _) { }

		public virtual string get_PanelName() { }

	}


	public override bool AreAnySettingsActive
	{
		 get { } //Length: 374
	}

	public DebugDisplaySettingsRenderGraph() { }

	public override bool get_AreAnySettingsActive() { }

	private override IDebugDisplaySettingsPanelDisposable UnityEngine.Rendering.IDebugDisplaySettingsData.CreatePanel() { }

}

