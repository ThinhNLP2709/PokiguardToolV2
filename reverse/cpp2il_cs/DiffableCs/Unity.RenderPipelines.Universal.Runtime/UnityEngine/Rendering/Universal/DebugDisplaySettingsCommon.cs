namespace UnityEngine.Rendering.Universal;

internal class DebugDisplaySettingsCommon : IDebugDisplaySettingsData, IDebugDisplaySettingsQuery
{
	[DisplayInfo(name = "Frequently Used", order = -1)]
	private class SettingsPanel : DebugDisplaySettingsPanel
	{
		[CompilerGenerated]
		private sealed class <>c__DisplayClass3_0
		{
			public Foldout foldout; //Field offset: 0x10

			public <>c__DisplayClass3_0() { }

			internal void <.ctor>b__0() { }

		}

		private const string k_GoToSectionString = "Go to Section..."; //Field offset: 0x0

		public virtual Flags Flags
		{
			 get { } //Length: 6
		}

		public SettingsPanel() { }

		public virtual Flags get_Flags() { }

	}


	public override bool AreAnySettingsActive
	{
		 get { } //Length: 3
	}

	public DebugDisplaySettingsCommon() { }

	public override IDebugDisplaySettingsPanelDisposable CreatePanel() { }

	public override bool get_AreAnySettingsActive() { }

}

