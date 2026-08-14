namespace UnityEngine.Rendering;

public class DebugDisplaySettingsVolume : IDebugDisplaySettingsData, IDebugDisplaySettingsQuery
{
	[DisplayInfo(name = "Volume", order = 2147483647)]
	public class SettingsPanel : DebugDisplaySettingsPanel<DebugDisplaySettingsVolume>
	{
		private Table m_VolumeTable; //Field offset: 0x28

		public SettingsPanel(DebugDisplaySettingsVolume data) { }

		[CompilerGenerated]
		private void <.ctor>b__0_0(Field<Object> _, object __) { }

		[CompilerGenerated]
		private void <.ctor>b__0_1(Field<Int32> _, int __) { }

		private void Refresh() { }

	}

	private static class Strings
	{
		public static readonly string none; //Field offset: 0x0
		public static readonly string camera; //Field offset: 0x8
		public static readonly string parameter; //Field offset: 0x10
		public static readonly string component; //Field offset: 0x18
		public static readonly string debugViewNotSupported; //Field offset: 0x20
		public static readonly string volumeInfo; //Field offset: 0x28
		public static readonly string resultValue; //Field offset: 0x30
		public static readonly string resultValueTooltip; //Field offset: 0x38
		public static readonly string globalDefaultValue; //Field offset: 0x40
		public static readonly string globalDefaultValueTooltip; //Field offset: 0x48
		public static readonly string qualityLevelValue; //Field offset: 0x50
		public static readonly string qualityLevelValueTooltip; //Field offset: 0x58
		public static readonly string global; //Field offset: 0x60
		public static readonly string local; //Field offset: 0x68

		private static Strings() { }

	}

	private static class Styles
	{
		public static readonly GUIContent none; //Field offset: 0x0
		public static readonly GUIContent editorCamera; //Field offset: 0x8

		private static Styles() { }

	}

	public static class WidgetFactory
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Func<Object> <>9__2_0; //Field offset: 0x8
			public static Func<Object> <>9__2_6; //Field offset: 0x10
			public static Func<Object> <>9__4_4; //Field offset: 0x18
			public static Func<Object> <>9__4_8; //Field offset: 0x20
			public static Func<Object> <>9__4_10; //Field offset: 0x28
			public static Func<Object> <>9__4_12; //Field offset: 0x30
			public static Func<FieldInfo, Int32> <>9__4_15; //Field offset: 0x38
			public static Func<Row, String> <>9__4_17; //Field offset: 0x40

			private static <>c() { }

			public <>c() { }

			internal object <.cctor>b__5_0() { }

			internal object <CreateVolumeParameterWidget>b__2_0() { }

			internal object <CreateVolumeParameterWidget>b__2_6() { }

			internal object <CreateVolumeTable>b__4_10() { }

			internal object <CreateVolumeTable>b__4_12() { }

			internal int <CreateVolumeTable>b__4_15(FieldInfo t) { }

			internal string <CreateVolumeTable>b__4_17(Row t) { }

			internal object <CreateVolumeTable>b__4_4() { }

			internal object <CreateVolumeTable>b__4_8() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass0_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass0_0() { }

			internal int <CreateComponentSelector>b__0() { }

			internal void <CreateComponentSelector>b__1(int value) { }

			internal int <CreateComponentSelector>b__2() { }

			internal void <CreateComponentSelector>b__3(int value) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass1_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass1_0() { }

			internal object <CreateCameraSelector>b__0() { }

			internal void <CreateCameraSelector>b__1(object value) { }

			internal IEnumerable<Object> <CreateCameraSelector>b__2() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass2_0
		{
			public Type parameterType; //Field offset: 0x10
			public VolumeParameter param; //Field offset: 0x18
			public PropertyInfo property; //Field offset: 0x20

			public <>c__DisplayClass2_0() { }

			internal Object[] <CreateVolumeParameterWidget>b__5() { }

			internal object <CreateVolumeParameterWidget>b__8() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass2_1
		{
			public ColorParameter p; //Field offset: 0x10

			public <>c__DisplayClass2_1() { }

			internal Color <CreateVolumeParameterWidget>b__1() { }

			internal void <CreateVolumeParameterWidget>b__2(Color value) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass2_2
		{
			public BoolParameter p; //Field offset: 0x10

			public <>c__DisplayClass2_2() { }

			internal bool <CreateVolumeParameterWidget>b__3() { }

			internal void <CreateVolumeParameterWidget>b__4(bool value) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass2_3
		{
			public PropertyInfo nameProp; //Field offset: 0x10
			public <>c__DisplayClass2_0 CS$<>8__locals1; //Field offset: 0x18

			public <>c__DisplayClass2_3() { }

			internal object <CreateVolumeParameterWidget>b__7() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass4_0
		{
			public DebugDisplaySettingsVolume data; //Field offset: 0x10
			public VolumeManager volumeManager; //Field offset: 0x18
			public Type selectedType; //Field offset: 0x20
			public List<Row> rows; //Field offset: 0x28
			public VolumeComponent stackComponent; //Field offset: 0x30
			public Volume[] volumes; //Field offset: 0x38
			public List<ValueTuple`2<VolumeProfile, VolumeComponent>> customDefaultComponents; //Field offset: 0x40
			public VolumeComponent qualityDefaultComponent; //Field offset: 0x48
			public VolumeComponent globalDefaultComponent; //Field offset: 0x50
			public float timer; //Field offset: 0x58
			public float refreshRate; //Field offset: 0x5C
			public Table table; //Field offset: 0x60

			public <>c__DisplayClass4_0() { }

			internal object <CreateVolumeTable>b__11() { }

			internal object <CreateVolumeTable>b__13() { }

			internal bool <CreateVolumeTable>b__2() { }

			internal bool <CreateVolumeTable>b__3() { }

			internal int <CreateVolumeTable>g__AddParameterRows|1(Type type, string baseName = null, int skip = 0) { }

			internal void <CreateVolumeTable>g__AddRow|14(FieldInfo f, string prefix, int skip) { }

			internal VolumeComponent <CreateVolumeTable>g__GetSelectedVolumeComponent|0(VolumeProfile profile) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass4_1
		{
			public Volume volume; //Field offset: 0x10
			public <>c__DisplayClass4_0 CS$<>8__locals1; //Field offset: 0x18

			public <>c__DisplayClass4_1() { }

			internal object <CreateVolumeTable>b__5() { }

			internal object <CreateVolumeTable>b__6() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass4_2
		{
			public VolumeProfile profile; //Field offset: 0x10

			public <>c__DisplayClass4_2() { }

			internal object <CreateVolumeTable>b__7() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass4_3
		{
			public VolumeProfile customProfile; //Field offset: 0x10

			public <>c__DisplayClass4_3() { }

			internal object <CreateVolumeTable>b__9() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass4_4
		{
			public int currentParam; //Field offset: 0x10

			public <>c__DisplayClass4_4() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass4_5
		{
			public VolumeComponent component; //Field offset: 0x10
			public <>c__DisplayClass4_4 CS$<>8__locals2; //Field offset: 0x18

			public <>c__DisplayClass4_5() { }

			internal bool <CreateVolumeTable>b__16() { }

		}

		private static Value s_EmptyDebugUIValue; //Field offset: 0x0

		private static WidgetFactory() { }

		public static ObjectPopupField CreateCameraSelector(SettingsPanel panel, Action<Field`1<Object>, Object> refresh) { }

		public static EnumField CreateComponentSelector(SettingsPanel panel, Action<Field`1<Int32>, Int32> refresh) { }

		private static Widget CreateVolumeParameterWidget(string name, VolumeParameter param, Func<Boolean> isHiddenCallback = null) { }

		public static Table CreateVolumeTable(DebugDisplaySettingsVolume data) { }

	}

	private const string k_PanelTitle = "Volume"; //Field offset: 0x0
	[CompilerGenerated]
	private readonly IVolumeDebugSettings <volumeDebugSettings>k__BackingField; //Field offset: 0x10
	internal int volumeComponentEnumIndex; //Field offset: 0x18
	internal Dictionary<String, VolumeComponent> debugState; //Field offset: 0x20

	public override bool AreAnySettingsActive
	{
		 get { } //Length: 3
	}

	public IVolumeDebugSettings volumeDebugSettings
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public DebugDisplaySettingsVolume(IVolumeDebugSettings volumeDebugSettings) { }

	public override IDebugDisplaySettingsPanelDisposable CreatePanel() { }

	public override bool get_AreAnySettingsActive() { }

	[CompilerGenerated]
	public IVolumeDebugSettings get_volumeDebugSettings() { }

}

