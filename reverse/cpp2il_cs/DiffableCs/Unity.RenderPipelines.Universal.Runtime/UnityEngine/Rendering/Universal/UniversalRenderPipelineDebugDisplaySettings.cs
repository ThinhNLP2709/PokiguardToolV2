namespace UnityEngine.Rendering.Universal;

public class UniversalRenderPipelineDebugDisplaySettings : DebugDisplaySettings<UniversalRenderPipelineDebugDisplaySettings>
{
	[CompilerGenerated]
	private DebugDisplaySettingsCommon <commonSettings>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private DebugDisplaySettingsMaterial <materialSettings>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private DebugDisplaySettingsRendering <renderingSettings>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private DebugDisplaySettingsLighting <lightingSettings>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private DebugDisplaySettingsVolume <volumeSettings>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private DebugDisplaySettingsStats<URPProfileId> <displayStats>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private DebugDisplayGPUResidentDrawer <gpuResidentDrawerSettings>k__BackingField; //Field offset: 0x48

	private DebugDisplaySettingsCommon commonSettings
	{
		[CompilerGenerated]
		private get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	internal DebugDisplaySettingsStats<URPProfileId> displayStats
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	internal DebugDisplayGPUResidentDrawer gpuResidentDrawerSettings
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public virtual bool IsPostProcessingAllowed
	{
		 get { } //Length: 640
	}

	public private DebugDisplaySettingsLighting lightingSettings
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private DebugDisplaySettingsMaterial materialSettings
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private DebugDisplaySettingsRendering renderingSettings
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private DebugDisplaySettingsVolume volumeSettings
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public UniversalRenderPipelineDebugDisplaySettings() { }

	[CompilerGenerated]
	private DebugDisplaySettingsCommon get_commonSettings() { }

	[CompilerGenerated]
	internal DebugDisplaySettingsStats<URPProfileId> get_displayStats() { }

	[CompilerGenerated]
	internal DebugDisplayGPUResidentDrawer get_gpuResidentDrawerSettings() { }

	public virtual bool get_IsPostProcessingAllowed() { }

	[CompilerGenerated]
	public DebugDisplaySettingsLighting get_lightingSettings() { }

	[CompilerGenerated]
	public DebugDisplaySettingsMaterial get_materialSettings() { }

	[CompilerGenerated]
	public DebugDisplaySettingsRendering get_renderingSettings() { }

	[CompilerGenerated]
	public DebugDisplaySettingsVolume get_volumeSettings() { }

	public virtual void Reset() { }

	[CompilerGenerated]
	private void set_commonSettings(DebugDisplaySettingsCommon value) { }

	[CompilerGenerated]
	private void set_displayStats(DebugDisplaySettingsStats<URPProfileId> value) { }

	[CompilerGenerated]
	private void set_gpuResidentDrawerSettings(DebugDisplayGPUResidentDrawer value) { }

	[CompilerGenerated]
	private void set_lightingSettings(DebugDisplaySettingsLighting value) { }

	[CompilerGenerated]
	private void set_materialSettings(DebugDisplaySettingsMaterial value) { }

	[CompilerGenerated]
	private void set_renderingSettings(DebugDisplaySettingsRendering value) { }

	[CompilerGenerated]
	private void set_volumeSettings(DebugDisplaySettingsVolume value) { }

	internal void UpdateDisplayStats() { }

	internal void UpdateMaterials() { }

}

