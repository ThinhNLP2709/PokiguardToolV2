namespace UnityEngine.Rendering.Universal;

public class DebugDisplaySettingsMaterial : IDebugDisplaySettingsData, IDebugDisplaySettingsQuery
{
	internal enum AlbedoDebugValidationPreset
	{
		DefaultLuminance = 0,
		BlackAcrylicPaint = 1,
		DarkSoil = 2,
		WornAsphalt = 3,
		DryClaySoil = 4,
		GreenGrass = 5,
		OldConcrete = 6,
		RedClayTile = 7,
		DrySand = 8,
		NewConcrete = 9,
		WhiteAcrylicPaint = 10,
		FreshSnow = 11,
		BlueSky = 12,
		Foliage = 13,
		Custom = 14,
	}

	private struct AlbedoDebugValidationPresetData
	{
		public string name; //Field offset: 0x0
		public Color color; //Field offset: 0x8
		public float minLuminance; //Field offset: 0x18
		public float maxLuminance; //Field offset: 0x1C

	}

	[DisplayInfo(name = "Material", order = 2)]
	public class SettingsPanel : DebugDisplaySettingsPanel<DebugDisplaySettingsMaterial>
	{
		[CompilerGenerated]
		private sealed class <>c__DisplayClass0_0
		{
			public SettingsPanel <>4__this; //Field offset: 0x10
			public DebugDisplaySettingsMaterial data; //Field offset: 0x18

			public <>c__DisplayClass0_0() { }

			internal bool <.ctor>b__2() { }

			internal bool <.ctor>b__3() { }

			internal bool <.ctor>b__4() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass0_1
		{
			public int index; //Field offset: 0x10
			public <>c__DisplayClass0_0 CS$<>8__locals1; //Field offset: 0x18

			public <>c__DisplayClass0_1() { }

			internal Color <.ctor>b__0() { }

			internal void <.ctor>b__1(Color value) { }

		}


		public SettingsPanel(DebugDisplaySettingsMaterial data) { }

	}

	private static class Strings
	{
		public const string AlbedoSettingsContainerName = "Albedo Settings"; //Field offset: 0x0
		public const string MetallicSettingsContainerName = "Metallic Settings"; //Field offset: 0x0
		public const string RenderingLayerMasksSettingsContainerName = "Rendering Layer Masks Settings"; //Field offset: 0x0
		public static readonly NameAndTooltip MaterialOverride; //Field offset: 0x0
		public static readonly NameAndTooltip VertexAttribute; //Field offset: 0x10
		public static readonly NameAndTooltip MaterialValidationMode; //Field offset: 0x20
		public static readonly NameAndTooltip RenderingLayersSelectedLight; //Field offset: 0x30
		public static readonly NameAndTooltip SelectedLightShadowLayerMask; //Field offset: 0x40
		public static readonly NameAndTooltip RenderingLayerColors; //Field offset: 0x50
		public static readonly NameAndTooltip FilterRenderingLayerMask; //Field offset: 0x60
		public static readonly NameAndTooltip ValidationPreset; //Field offset: 0x70
		public static readonly NameAndTooltip AlbedoCustomColor; //Field offset: 0x80
		public static readonly NameAndTooltip AlbedoMinLuminance; //Field offset: 0x90
		public static readonly NameAndTooltip AlbedoMaxLuminance; //Field offset: 0xA0
		public static readonly NameAndTooltip AlbedoHueTolerance; //Field offset: 0xB0
		public static readonly NameAndTooltip AlbedoSaturationTolerance; //Field offset: 0xC0
		public static readonly NameAndTooltip MetallicMinValue; //Field offset: 0xD0
		public static readonly NameAndTooltip MetallicMaxValue; //Field offset: 0xE0

		private static Strings() { }

	}

	public static class WidgetFactory
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Action<Field`1<Int32>, Int32> <>9__2_4; //Field offset: 0x8
			public static Action<Field`1<Int32>, Int32> <>9__6_4; //Field offset: 0x10

			private static <>c() { }

			public <>c() { }

			internal void <CreateAlbedoPreset>b__6_4(Field<Int32> _, int _) { }

			internal void <CreateMaterialValidationMode>b__2_4(Field<Int32> _, int _) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass0_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass0_0() { }

			internal int <CreateMaterialOverride>b__0() { }

			internal void <CreateMaterialOverride>b__1(int value) { }

			internal int <CreateMaterialOverride>b__2() { }

			internal void <CreateMaterialOverride>b__3(int value) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass1_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass1_0() { }

			internal int <CreateVertexAttribute>b__0() { }

			internal void <CreateVertexAttribute>b__1(int value) { }

			internal int <CreateVertexAttribute>b__2() { }

			internal void <CreateVertexAttribute>b__3(int value) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass10_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass10_0() { }

			internal float <CreateAlbedoHueTolerance>b__0() { }

			internal void <CreateAlbedoHueTolerance>b__1(float value) { }

			internal bool <CreateAlbedoHueTolerance>b__2() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass11_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass11_0() { }

			internal float <CreateAlbedoSaturationTolerance>b__0() { }

			internal void <CreateAlbedoSaturationTolerance>b__1(float value) { }

			internal bool <CreateAlbedoSaturationTolerance>b__2() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass12_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass12_0() { }

			internal float <CreateMetallicMinValue>b__0() { }

			internal void <CreateMetallicMinValue>b__1(float value) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass13_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass13_0() { }

			internal float <CreateMetallicMaxValue>b__0() { }

			internal void <CreateMetallicMaxValue>b__1(float value) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass2_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass2_0() { }

			internal int <CreateMaterialValidationMode>b__0() { }

			internal void <CreateMaterialValidationMode>b__1(int value) { }

			internal int <CreateMaterialValidationMode>b__2() { }

			internal void <CreateMaterialValidationMode>b__3(int value) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass3_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass3_0() { }

			internal bool <CreateRenderingLayersSelectedLight>b__0() { }

			internal void <CreateRenderingLayersSelectedLight>b__1(bool value) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass4_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass4_0() { }

			internal bool <CreateSelectedLightShadowLayerMask>b__0() { }

			internal void <CreateSelectedLightShadowLayerMask>b__1(bool value) { }

			internal bool <CreateSelectedLightShadowLayerMask>b__2() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass5_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass5_0() { }

			internal uint <CreateFilterRenderingLayerMasks>b__0() { }

			internal void <CreateFilterRenderingLayerMasks>b__1(uint value) { }

			internal bool <CreateFilterRenderingLayerMasks>b__2() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass6_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass6_0() { }

			internal int <CreateAlbedoPreset>b__0() { }

			internal void <CreateAlbedoPreset>b__1(int value) { }

			internal int <CreateAlbedoPreset>b__2() { }

			internal void <CreateAlbedoPreset>b__3(int value) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass7_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass7_0() { }

			internal Color <CreateAlbedoCustomColor>b__0() { }

			internal void <CreateAlbedoCustomColor>b__1(Color value) { }

			internal bool <CreateAlbedoCustomColor>b__2() { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass8_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass8_0() { }

			internal float <CreateAlbedoMinLuminance>b__0() { }

			internal void <CreateAlbedoMinLuminance>b__1(float value) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass9_0
		{
			public SettingsPanel panel; //Field offset: 0x10

			public <>c__DisplayClass9_0() { }

			internal float <CreateAlbedoMaxLuminance>b__0() { }

			internal void <CreateAlbedoMaxLuminance>b__1(float value) { }

		}


		internal static Widget CreateAlbedoCustomColor(SettingsPanel panel) { }

		internal static Widget CreateAlbedoHueTolerance(SettingsPanel panel) { }

		internal static Widget CreateAlbedoMaxLuminance(SettingsPanel panel) { }

		internal static Widget CreateAlbedoMinLuminance(SettingsPanel panel) { }

		internal static Widget CreateAlbedoPreset(SettingsPanel panel) { }

		internal static Widget CreateAlbedoSaturationTolerance(SettingsPanel panel) { }

		internal static Widget CreateFilterRenderingLayerMasks(SettingsPanel panel) { }

		internal static Widget CreateMaterialOverride(SettingsPanel panel) { }

		internal static Widget CreateMaterialValidationMode(SettingsPanel panel) { }

		internal static Widget CreateMetallicMaxValue(SettingsPanel panel) { }

		internal static Widget CreateMetallicMinValue(SettingsPanel panel) { }

		internal static Widget CreateRenderingLayersSelectedLight(SettingsPanel panel) { }

		internal static Widget CreateSelectedLightShadowLayerMask(SettingsPanel panel) { }

		internal static Widget CreateVertexAttribute(SettingsPanel panel) { }

	}

	private AlbedoDebugValidationPresetData[] m_AlbedoDebugValidationPresetData; //Field offset: 0x10
	private AlbedoDebugValidationPreset m_AlbedoValidationPreset; //Field offset: 0x18
	[CompilerGenerated]
	private float <albedoMinLuminance>k__BackingField; //Field offset: 0x1C
	[CompilerGenerated]
	private float <albedoMaxLuminance>k__BackingField; //Field offset: 0x20
	private float m_AlbedoHueTolerance; //Field offset: 0x24
	private float m_AlbedoSaturationTolerance; //Field offset: 0x28
	[CompilerGenerated]
	private Color <albedoCompareColor>k__BackingField; //Field offset: 0x2C
	[CompilerGenerated]
	private float <metallicMinValue>k__BackingField; //Field offset: 0x3C
	[CompilerGenerated]
	private float <metallicMaxValue>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private bool <renderingLayersSelectedLight>k__BackingField; //Field offset: 0x44
	[CompilerGenerated]
	private bool <selectedLightShadowLayerMask>k__BackingField; //Field offset: 0x45
	[CompilerGenerated]
	private uint <renderingLayerMask>k__BackingField; //Field offset: 0x48
	public Vector4[] debugRenderingLayersColors; //Field offset: 0x50
	[CompilerGenerated]
	private DebugMaterialValidationMode <materialValidationMode>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private DebugMaterialMode <materialDebugMode>k__BackingField; //Field offset: 0x5C
	[CompilerGenerated]
	private DebugVertexAttributeMode <vertexAttributeDebugMode>k__BackingField; //Field offset: 0x60

	public Color albedoCompareColor
	{
		[CompilerGenerated]
		 get { } //Length: 11
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public float albedoHueTolerance
	{
		 get { } //Length: 21
		 set { } //Length: 6
	}

	public float albedoMaxLuminance
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		 set { } //Length: 6
	}

	public float albedoMinLuminance
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		 set { } //Length: 6
	}

	public float albedoSaturationTolerance
	{
		 get { } //Length: 21
		 set { } //Length: 6
	}

	public AlbedoDebugValidationPreset albedoValidationPreset
	{
		 get { } //Length: 4
		 set { } //Length: 99
	}

	public override bool AreAnySettingsActive
	{
		 get { } //Length: 23
	}

	public override bool IsLightingActive
	{
		 get { } //Length: 24
	}

	public override bool IsPostProcessingAllowed
	{
		 get { } //Length: 24
	}

	public DebugMaterialMode materialDebugMode
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public DebugMaterialValidationMode materialValidationMode
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public float metallicMaxValue
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		 set { } //Length: 6
	}

	public float metallicMinValue
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		 set { } //Length: 6
	}

	public uint renderingLayerMask
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool renderingLayersSelectedLight
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool selectedLightShadowLayerMask
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public DebugVertexAttributeMode vertexAttributeDebugMode
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public DebugDisplaySettingsMaterial() { }

	[CompilerGenerated]
	public Color get_albedoCompareColor() { }

	public float get_albedoHueTolerance() { }

	[CompilerGenerated]
	public float get_albedoMaxLuminance() { }

	[CompilerGenerated]
	public float get_albedoMinLuminance() { }

	public float get_albedoSaturationTolerance() { }

	public AlbedoDebugValidationPreset get_albedoValidationPreset() { }

	public override bool get_AreAnySettingsActive() { }

	public override bool get_IsLightingActive() { }

	public override bool get_IsPostProcessingAllowed() { }

	[CompilerGenerated]
	public DebugMaterialMode get_materialDebugMode() { }

	[CompilerGenerated]
	public DebugMaterialValidationMode get_materialValidationMode() { }

	[CompilerGenerated]
	public float get_metallicMaxValue() { }

	[CompilerGenerated]
	public float get_metallicMinValue() { }

	[CompilerGenerated]
	public uint get_renderingLayerMask() { }

	[CompilerGenerated]
	public bool get_renderingLayersSelectedLight() { }

	[CompilerGenerated]
	public bool get_selectedLightShadowLayerMask() { }

	[CompilerGenerated]
	public DebugVertexAttributeMode get_vertexAttributeDebugMode() { }

	public uint GetDebugLightLayersMask() { }

	[CompilerGenerated]
	public void set_albedoCompareColor(Color value) { }

	public void set_albedoHueTolerance(float value) { }

	[CompilerGenerated]
	public void set_albedoMaxLuminance(float value) { }

	[CompilerGenerated]
	public void set_albedoMinLuminance(float value) { }

	public void set_albedoSaturationTolerance(float value) { }

	public void set_albedoValidationPreset(AlbedoDebugValidationPreset value) { }

	[CompilerGenerated]
	public void set_materialDebugMode(DebugMaterialMode value) { }

	[CompilerGenerated]
	public void set_materialValidationMode(DebugMaterialValidationMode value) { }

	[CompilerGenerated]
	public void set_metallicMaxValue(float value) { }

	[CompilerGenerated]
	public void set_metallicMinValue(float value) { }

	[CompilerGenerated]
	public void set_renderingLayerMask(uint value) { }

	[CompilerGenerated]
	public void set_renderingLayersSelectedLight(bool value) { }

	[CompilerGenerated]
	public void set_selectedLightShadowLayerMask(bool value) { }

	[CompilerGenerated]
	public void set_vertexAttributeDebugMode(DebugVertexAttributeMode value) { }

	private override IDebugDisplaySettingsPanelDisposable UnityEngine.Rendering.IDebugDisplaySettingsData.CreatePanel() { }

}

