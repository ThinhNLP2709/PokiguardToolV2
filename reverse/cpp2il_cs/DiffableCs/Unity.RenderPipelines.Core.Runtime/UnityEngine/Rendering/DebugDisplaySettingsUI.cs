namespace UnityEngine.Rendering;

public class DebugDisplaySettingsUI : IDebugData
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public DebugManager debugManager; //Field offset: 0x10
		public List<IDebugDisplaySettingsPanelDisposable> panels; //Field offset: 0x18

		public <>c__DisplayClass3_0() { }

		internal void <RegisterDebug>b__0(IDebugDisplaySettingsData data) { }

	}

	private IEnumerable<IDebugDisplaySettingsPanelDisposable> m_DisposablePanels; //Field offset: 0x10
	private IDebugDisplaySettings m_Settings; //Field offset: 0x18

	public DebugDisplaySettingsUI() { }

	public override Action GetReset() { }

	public void RegisterDebug(IDebugDisplaySettings settings) { }

	private void Reset() { }

	public void UnregisterDebug() { }

}

