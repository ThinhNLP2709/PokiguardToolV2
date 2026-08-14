namespace UnityEngine.AdaptivePerformance;

public class AdaptivePerformanceScalerSettings
{
	private const string obsoleteMsg = "AdaptiveShadowCascades has been renamed. Please use AdaptiveShadowCascade. (UnityUpgradable) -> AdaptiveShadowCascade"; //Field offset: 0x0
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer to adjust the application update rate using Application.TargetFramerate")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptiveFramerate; //Field offset: 0x10
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer to adjust the resolution of all render targets that allow dynamic resolution.")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptiveResolution; //Field offset: 0x18
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer to control if dynamic batching is enabled.")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptiveBatching; //Field offset: 0x20
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer for adjusting at what distance LODs are switched.")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptiveLOD; //Field offset: 0x28
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer to adjust the size of the palette used for color grading in URP.")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptiveLut; //Field offset: 0x30
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer to adjust the level of antialiasing.")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptiveMSAA; //Field offset: 0x38
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer to adjust the number of shadow cascades to be used.")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptiveShadowCascade; //Field offset: 0x40
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer to change the distance at which shadows are rendered.")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptiveShadowDistance; //Field offset: 0x48
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer to adjust the resolution of shadow maps.")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptiveShadowmapResolution; //Field offset: 0x50
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer to adjust the quality of shadows.")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptiveShadowQuality; //Field offset: 0x58
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer to change if objects in the scene are sorted by depth before rendering to reduce overdraw.")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptiveSorting; //Field offset: 0x60
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer to disable transparent objects rendering")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptiveTransparency; //Field offset: 0x68
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer to change the view distance")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptiveViewDistance; //Field offset: 0x70
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer to change physics properties")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptivePhysics; //Field offset: 0x78
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer to change decal properties")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptiveDecals; //Field offset: 0x80
	[SerializeField]
	[Tooltip("Settings for a scaler used by the Indexer to change the layer culling distance")]
	private AdaptivePerformanceScalerSettingsBase m_AdaptiveLayerCulling; //Field offset: 0x88

	public AdaptivePerformanceScalerSettingsBase AdaptiveBatching
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public AdaptivePerformanceScalerSettingsBase AdaptiveDecals
	{
		 get { } //Length: 8
		 set { } //Length: 16
	}

	public AdaptivePerformanceScalerSettingsBase AdaptiveFramerate
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public AdaptivePerformanceScalerSettingsBase AdaptiveLayerCulling
	{
		 get { } //Length: 8
		 set { } //Length: 19
	}

	public AdaptivePerformanceScalerSettingsBase AdaptiveLOD
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public AdaptivePerformanceScalerSettingsBase AdaptiveLut
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public AdaptivePerformanceScalerSettingsBase AdaptiveMSAA
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public AdaptivePerformanceScalerSettingsBase AdaptivePhysics
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public AdaptivePerformanceScalerSettingsBase AdaptiveResolution
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public AdaptivePerformanceScalerSettingsBase AdaptiveShadowCascade
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	[Obsolete("AdaptiveShadowCascades has been renamed. Please use AdaptiveShadowCascade. (UnityUpgradable) -> AdaptiveShadowCascade", False)]
	public AdaptivePerformanceScalerSettingsBase AdaptiveShadowCascades
	{
		 get { } //Length: 5
	}

	public AdaptivePerformanceScalerSettingsBase AdaptiveShadowDistance
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public AdaptivePerformanceScalerSettingsBase AdaptiveShadowmapResolution
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public AdaptivePerformanceScalerSettingsBase AdaptiveShadowQuality
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public AdaptivePerformanceScalerSettingsBase AdaptiveSorting
	{
		 get { } //Length: 694
		 set { } //Length: 13
	}

	public AdaptivePerformanceScalerSettingsBase AdaptiveTransparency
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public AdaptivePerformanceScalerSettingsBase AdaptiveViewDistance
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public AdaptivePerformanceScalerSettings() { }

	public void ApplySettings(AdaptivePerformanceScalerSettings settings) { }

	private void ApplySettingsBase(AdaptivePerformanceScalerSettingsBase destination, AdaptivePerformanceScalerSettingsBase sources) { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveBatching() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveDecals() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveFramerate() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveLayerCulling() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveLOD() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveLut() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveMSAA() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptivePhysics() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveResolution() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveShadowCascade() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveShadowCascades() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveShadowDistance() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveShadowmapResolution() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveShadowQuality() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveSorting() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveTransparency() { }

	public AdaptivePerformanceScalerSettingsBase get_AdaptiveViewDistance() { }

	public void set_AdaptiveBatching(AdaptivePerformanceScalerSettingsBase value) { }

	public void set_AdaptiveDecals(AdaptivePerformanceScalerSettingsBase value) { }

	public void set_AdaptiveFramerate(AdaptivePerformanceScalerSettingsBase value) { }

	public void set_AdaptiveLayerCulling(AdaptivePerformanceScalerSettingsBase value) { }

	public void set_AdaptiveLOD(AdaptivePerformanceScalerSettingsBase value) { }

	public void set_AdaptiveLut(AdaptivePerformanceScalerSettingsBase value) { }

	public void set_AdaptiveMSAA(AdaptivePerformanceScalerSettingsBase value) { }

	public void set_AdaptivePhysics(AdaptivePerformanceScalerSettingsBase value) { }

	public void set_AdaptiveResolution(AdaptivePerformanceScalerSettingsBase value) { }

	public void set_AdaptiveShadowCascade(AdaptivePerformanceScalerSettingsBase value) { }

	public void set_AdaptiveShadowDistance(AdaptivePerformanceScalerSettingsBase value) { }

	public void set_AdaptiveShadowmapResolution(AdaptivePerformanceScalerSettingsBase value) { }

	public void set_AdaptiveShadowQuality(AdaptivePerformanceScalerSettingsBase value) { }

	public void set_AdaptiveSorting(AdaptivePerformanceScalerSettingsBase value) { }

	public void set_AdaptiveTransparency(AdaptivePerformanceScalerSettingsBase value) { }

	public void set_AdaptiveViewDistance(AdaptivePerformanceScalerSettingsBase value) { }

}

