namespace UnityEngine.Rendering;

public class DebugDisplayGPUResidentDrawer : IDebugDisplaySettingsData, IDebugDisplaySettingsQuery
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass29_0
	{
		public int viewIndex; //Field offset: 0x10

		public <>c__DisplayClass29_0() { }

		internal bool <AddInstanceCullerViewDataRow>b__0() { }

		internal object <AddInstanceCullerViewDataRow>b__1() { }

		internal object <AddInstanceCullerViewDataRow>b__2() { }

		internal object <AddInstanceCullerViewDataRow>b__3() { }

		internal object <AddInstanceCullerViewDataRow>b__4() { }

		internal object <AddInstanceCullerViewDataRow>b__5() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass34_0
	{
		public int eventIndex; //Field offset: 0x10

		public <>c__DisplayClass34_0() { }

		internal bool <AddInstanceOcclusionPassDataRow>b__0() { }

		internal object <AddInstanceOcclusionPassDataRow>b__1() { }

		internal object <AddInstanceOcclusionPassDataRow>b__2() { }

		internal object <AddInstanceOcclusionPassDataRow>b__3() { }

		internal object <AddInstanceOcclusionPassDataRow>b__4() { }

		internal object <AddInstanceOcclusionPassDataRow>b__5() { }

		internal object <AddInstanceOcclusionPassDataRow>b__6() { }

		internal object <AddInstanceOcclusionPassDataRow>b__7() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_0
	{
		public int index; //Field offset: 0x10

		public <>c__DisplayClass35_0() { }

		internal bool <AddOcclusionContextDataRow>b__0() { }

		internal object <AddOcclusionContextDataRow>b__1() { }

		internal object <AddOcclusionContextDataRow>b__2() { }

		internal object <AddOcclusionContextDataRow>b__3() { }

	}

	[DisplayInfo(name = "GPU Resident Drawer", order = 5)]
	private class SettingsPanel : DebugDisplaySettingsPanel
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Func<String> <>9__4_0; //Field offset: 0x8
			public static Func<Boolean> <>9__4_1; //Field offset: 0x10
			public static Func<Boolean> <>9__4_2; //Field offset: 0x18
			public static Func<Int32> <>9__4_16; //Field offset: 0x20
			public static Func<Int32> <>9__4_17; //Field offset: 0x28
			public static Func<Boolean> <>9__4_24; //Field offset: 0x30
			public static Func<Object> <>9__5_1; //Field offset: 0x38
			public static Func<Object> <>9__6_1; //Field offset: 0x40

			private static <>c() { }

			public <>c() { }

			internal string <.ctor>b__4_0() { }

			internal bool <.ctor>b__4_1() { }

			internal int <.ctor>b__4_16() { }

			internal int <.ctor>b__4_17() { }

			internal bool <.ctor>b__4_2() { }

			internal bool <.ctor>b__4_24() { }

			internal object <AddInstanceCullingStatsWidget>b__5_1() { }

			internal object <AddOcclusionContextStatsWidget>b__6_1() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass4_0
		{
			public DebugDisplayGPUResidentDrawer data; //Field offset: 0x10

			public <>c__DisplayClass4_0() { }

			internal void <.ctor>b__10(bool value) { }

			internal bool <.ctor>b__11() { }

			internal void <.ctor>b__12(bool value) { }

			internal int <.ctor>b__13() { }

			internal void <.ctor>b__14(int value) { }

			internal bool <.ctor>b__15() { }

			internal float <.ctor>b__18() { }

			internal void <.ctor>b__19(float value) { }

			internal bool <.ctor>b__20() { }

			internal float <.ctor>b__21() { }

			internal void <.ctor>b__22(float value) { }

			internal bool <.ctor>b__23() { }

			internal bool <.ctor>b__25() { }

			internal void <.ctor>b__26(bool value) { }

			internal bool <.ctor>b__3() { }

			internal void <.ctor>b__4(bool value) { }

			internal bool <.ctor>b__5() { }

			internal void <.ctor>b__6(bool value) { }

			internal bool <.ctor>b__7() { }

			internal void <.ctor>b__8(bool value) { }

			internal bool <.ctor>b__9() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass5_0
		{
			public DebugDisplayGPUResidentDrawer data; //Field offset: 0x10

			public <>c__DisplayClass5_0() { }

			internal bool <AddInstanceCullingStatsWidget>b__0() { }

			internal bool <AddInstanceCullingStatsWidget>b__2() { }

			internal bool <AddInstanceCullingStatsWidget>b__3() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass6_0
		{
			public DebugDisplayGPUResidentDrawer data; //Field offset: 0x10

			public <>c__DisplayClass6_0() { }

			internal bool <AddOcclusionContextStatsWidget>b__0() { }

		}


		public virtual Flags Flags
		{
			 get { } //Length: 6
		}

		public virtual string PanelName
		{
			 get { } //Length: 44
		}

		public SettingsPanel(DebugDisplayGPUResidentDrawer data) { }

		private void AddInstanceCullingStatsWidget(DebugDisplayGPUResidentDrawer data) { }

		private void AddOcclusionContextStatsWidget(DebugDisplayGPUResidentDrawer data) { }

		public virtual Flags get_Flags() { }

		public virtual string get_PanelName() { }

	}

	private static class Strings
	{
		public const string drawerSettingsContainerName = "GPU Resident Drawer Settings"; //Field offset: 0x0
		public static readonly NameAndTooltip displayBatcherStats; //Field offset: 0x0
		public const string occlusionCullingTitle = "Occlusion Culling"; //Field offset: 0x0
		public static readonly NameAndTooltip occlusionTestOverlayEnable; //Field offset: 0x10
		public static readonly NameAndTooltip occlusionTestOverlayCountVisible; //Field offset: 0x20
		public static readonly NameAndTooltip overrideOcclusionTestToAlwaysPass; //Field offset: 0x30
		public static readonly NameAndTooltip occluderContextStats; //Field offset: 0x40
		public static readonly NameAndTooltip occluderDebugViewEnable; //Field offset: 0x50
		public static readonly NameAndTooltip occluderDebugViewIndex; //Field offset: 0x60
		public static readonly NameAndTooltip occluderDebugViewRangeMin; //Field offset: 0x70
		public static readonly NameAndTooltip occluderDebugViewRangeMax; //Field offset: 0x80

		private static Strings() { }

	}

	private const string k_FormatString = "{0}"; //Field offset: 0x0
	private const float k_RefreshRate = 0.2; //Field offset: 0x0
	private const int k_MaxViewCount = 32; //Field offset: 0x0
	private const int k_MaxOcclusionPassCount = 32; //Field offset: 0x0
	private const int k_MaxContextCount = 16; //Field offset: 0x0
	public bool occluderDebugViewEnable; //Field offset: 0x10
	internal bool occluderContextStats; //Field offset: 0x11
	internal Vector2 occluderDebugViewRange; //Field offset: 0x14
	internal int occluderDebugViewIndex; //Field offset: 0x1C

	public override bool AreAnySettingsActive
	{
		 get { } //Length: 96
	}

	private bool displayBatcherStats
	{
		private get { } //Length: 96
		private set { } //Length: 94
	}

	public override bool IsLightingActive
	{
		 get { } //Length: 3
	}

	public override bool IsPostProcessingAllowed
	{
		 get { } //Length: 3
	}

	private bool occlusionTestOverlayCountVisible
	{
		private get { } //Length: 96
		private set { } //Length: 94
	}

	internal bool occlusionTestOverlayEnable
	{
		internal get { } //Length: 96
		internal set { } //Length: 94
	}

	private bool overrideOcclusionTestToAlwaysPass
	{
		private get { } //Length: 96
		private set { } //Length: 94
	}

	public DebugDisplayGPUResidentDrawer() { }

	private static Row AddInstanceCullerViewDataRow(int viewIndex) { }

	private static Row AddInstanceOcclusionPassDataRow(int eventIndex) { }

	private static Row AddOcclusionContextDataRow(int index) { }

	private static object CulledInstancesString(in InstanceOcclusionEventStats stats) { }

	public override bool get_AreAnySettingsActive() { }

	private bool get_displayBatcherStats() { }

	public override bool get_IsLightingActive() { }

	public override bool get_IsPostProcessingAllowed() { }

	private bool get_occlusionTestOverlayCountVisible() { }

	internal bool get_occlusionTestOverlayEnable() { }

	private bool get_overrideOcclusionTestToAlwaysPass() { }

	private static int GetInstanceCullerViewCount() { }

	private static InstanceCullerViewStats GetInstanceCullerViewStats(int viewIndex) { }

	private static int GetInstanceOcclusionEventCount() { }

	private static InstanceOcclusionEventStats GetInstanceOcclusionEventStats(int passIndex) { }

	private static DebugOccluderStats GetOccluderStats(int occluderIndex) { }

	internal bool GetOccluderViewInstanceID(out int viewInstanceID) { }

	private static int GetOcclusionContextsCounts() { }

	private static object OccluderVersionString(in InstanceOcclusionEventStats stats) { }

	private static object OcclusionTestString(in InstanceOcclusionEventStats stats) { }

	private void set_displayBatcherStats(bool value) { }

	private void set_occlusionTestOverlayCountVisible(bool value) { }

	internal void set_occlusionTestOverlayEnable(bool value) { }

	private void set_overrideOcclusionTestToAlwaysPass(bool value) { }

	public override bool TryGetScreenClearColor(ref Color color) { }

	private override IDebugDisplaySettingsPanelDisposable UnityEngine.Rendering.IDebugDisplaySettingsData.CreatePanel() { }

	private static object VisibleInstancesString(in InstanceOcclusionEventStats stats) { }

}

