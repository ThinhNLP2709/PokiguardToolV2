namespace UnityEngine.Rendering;

public class DebugDisplaySettingsStats : IDebugDisplaySettingsData, IDebugDisplaySettingsQuery
{
	[DisplayInfo(name = "Display Stats", order = -2147483648)]
	private class StatsPanel : DebugDisplaySettingsPanel
	{
		private readonly DebugDisplaySettingsStats<TProfileId> m_Data; //Field offset: 0x0

		public virtual Flags Flags
		{
			 get { } //Length: 6
		}

		public StatsPanel(DebugDisplaySettingsStats<TProfileId> displaySettingsStats) { }

		public virtual void Dispose() { }

		public virtual Flags get_Flags() { }

	}

	[CompilerGenerated]
	private readonly DebugDisplayStats<TProfileId> <debugDisplayStats>k__BackingField; //Field offset: 0x0

	public override bool AreAnySettingsActive
	{
		 get { } //Length: 3
	}

	public DebugDisplayStats<TProfileId> debugDisplayStats
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public DebugDisplaySettingsStats`1(DebugDisplayStats<TProfileId> debugDisplayStats) { }

	public override IDebugDisplaySettingsPanelDisposable CreatePanel() { }

	public override bool get_AreAnySettingsActive() { }

	[CompilerGenerated]
	public DebugDisplayStats<TProfileId> get_debugDisplayStats() { }

}

