namespace UnityEngine.Rendering.Universal;

public class DebugDisplaySettingsLighting : IDebugDisplaySettingsData, IDebugDisplaySettingsQuery
{
	[DisplayInfo(name = "Lighting", order = 3)]
	public class SettingsPanel : DebugDisplaySettingsPanel<DebugDisplaySettingsLighting>
	{

		public SettingsPanel(DebugDisplaySettingsLighting data) { }

	}

	public static class Strings
	{
		public static readonly NameAndTooltip LightingDebugMode; //Field offset: 0x0
		public static readonly NameAndTooltip LightingFeatures; //Field offset: 0x10
		public static readonly NameAndTooltip HDRDebugMode; //Field offset: 0x20

		private static Strings() { }

	}

	public static class WidgetFactory
	{
		[CompilerGenerated]
		private sealed class <>c__DisplayClass0_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass0_0() { }

			internal int <CreateLightingDebugMode>b__0() { }

			internal void <CreateLightingDebugMode>b__1(int value) { }

			internal int <CreateLightingDebugMode>b__2() { }

			internal void <CreateLightingDebugMode>b__3(int value) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass1_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass1_0() { }

			internal Enum <CreateLightingFeatures>b__0() { }

			internal void <CreateLightingFeatures>b__1(Enum value) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass2_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass2_0() { }

			internal int <CreateHDRDebugMode>b__0() { }

			internal void <CreateHDRDebugMode>b__1(int value) { }

			internal int <CreateHDRDebugMode>b__2() { }

			internal void <CreateHDRDebugMode>b__3(int value) { }

		}


		internal static Widget CreateHDRDebugMode(SettingsPanel panel) { }

		internal static Widget CreateLightingDebugMode(SettingsPanel panel) { }

		internal static Widget CreateLightingFeatures(SettingsPanel panel) { }

	}

	[CompilerGenerated]
	private DebugLightingMode <lightingDebugMode>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private DebugLightingFeatureFlags <lightingFeatureFlags>k__BackingField; //Field offset: 0x14
	[CompilerGenerated]
	private HDRDebugMode <hdrDebugMode>k__BackingField; //Field offset: 0x18

	public override bool AreAnySettingsActive
	{
		 get { } //Length: 23
	}

	public HDRDebugMode hdrDebugMode
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public override bool IsLightingActive
	{
		 get { } //Length: 3
	}

	public override bool IsPostProcessingAllowed
	{
		 get { } //Length: 17
	}

	public DebugLightingMode lightingDebugMode
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public DebugLightingFeatureFlags lightingFeatureFlags
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public DebugDisplaySettingsLighting() { }

	public override bool get_AreAnySettingsActive() { }

	[CompilerGenerated]
	public HDRDebugMode get_hdrDebugMode() { }

	public override bool get_IsLightingActive() { }

	public override bool get_IsPostProcessingAllowed() { }

	[CompilerGenerated]
	public DebugLightingMode get_lightingDebugMode() { }

	[CompilerGenerated]
	public DebugLightingFeatureFlags get_lightingFeatureFlags() { }

	[CompilerGenerated]
	public void set_hdrDebugMode(HDRDebugMode value) { }

	[CompilerGenerated]
	public void set_lightingDebugMode(DebugLightingMode value) { }

	[CompilerGenerated]
	public void set_lightingFeatureFlags(DebugLightingFeatureFlags value) { }

	private override IDebugDisplaySettingsPanelDisposable UnityEngine.Rendering.IDebugDisplaySettingsData.CreatePanel() { }

}

