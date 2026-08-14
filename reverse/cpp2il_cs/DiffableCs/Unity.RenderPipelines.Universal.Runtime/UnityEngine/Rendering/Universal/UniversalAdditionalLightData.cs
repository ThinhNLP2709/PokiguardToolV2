namespace UnityEngine.Rendering.Universal;

[DisallowMultipleComponent]
[RequireComponent(typeof(Light))]
public class UniversalAdditionalLightData : MonoBehaviour, ISerializationCallbackReceiver, IAdditionalData
{
	public static readonly int AdditionalLightsShadowResolutionTierCustom; //Field offset: 0x0
	public static readonly int AdditionalLightsShadowResolutionTierLow; //Field offset: 0x4
	public static readonly int AdditionalLightsShadowResolutionTierMedium; //Field offset: 0x8
	public static readonly int AdditionalLightsShadowResolutionTierHigh; //Field offset: 0xC
	public static readonly int AdditionalLightsShadowDefaultResolutionTier; //Field offset: 0x10
	public static readonly int AdditionalLightsShadowDefaultCustomResolution; //Field offset: 0x14
	public static readonly int AdditionalLightsShadowMinimumResolution; //Field offset: 0x18
	[SerializeField]
	private int m_Version; //Field offset: 0x20
	[SerializeField]
	[Tooltip("Controls if light Shadow Bias parameters use pipeline settings.")]
	private bool m_UsePipelineSettings; //Field offset: 0x24
	private Light m_Light; //Field offset: 0x28
	[SerializeField]
	[Tooltip("Controls if light shadow resolution uses pipeline settings.")]
	private int m_AdditionalLightsShadowResolutionTier; //Field offset: 0x30
	[Obsolete("This is obsolete, please use m_RenderingLayerMask instead.", False)]
	[SerializeField]
	private LightLayerEnum m_LightLayerMask; //Field offset: 0x34
	[SerializeField]
	private uint m_RenderingLayers; //Field offset: 0x38
	[SerializeField]
	private bool m_CustomShadowLayers; //Field offset: 0x3C
	[SerializeField]
	private LightLayerEnum m_ShadowLayerMask; //Field offset: 0x40
	[SerializeField]
	private uint m_ShadowRenderingLayers; //Field offset: 0x44
	[SerializeField]
	private Vector2 m_LightCookieSize; //Field offset: 0x48
	[SerializeField]
	private Vector2 m_LightCookieOffset; //Field offset: 0x50
	[SerializeField]
	private SoftShadowQuality m_SoftShadowQuality; //Field offset: 0x58

	public int additionalLightsShadowResolutionTier
	{
		 get { } //Length: 4
	}

	public bool customShadowLayers
	{
		 get { } //Length: 5
		 set { } //Length: 16
	}

	internal Light light
	{
		internal get { } //Length: 126
	}

	[Tooltip("Controls the offset of the cookie mask currently assigned to the light.")]
	public Vector2 lightCookieOffset
	{
		 get { } //Length: 19
		 set { } //Length: 5
	}

	[Tooltip("Controls the size of the cookie mask currently assigned to the light.")]
	public Vector2 lightCookieSize
	{
		 get { } //Length: 19
		 set { } //Length: 5
	}

	[Obsolete("This is obsolete, please use renderingLayerMask instead.", True)]
	public LightLayerEnum lightLayerMask
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public uint renderingLayers
	{
		 get { } //Length: 4
		 set { } //Length: 16
	}

	[Obsolete("This is obsolete, please use shadowRenderingLayerMask instead.", True)]
	public LightLayerEnum shadowLayerMask
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public uint shadowRenderingLayers
	{
		 get { } //Length: 4
		 set { } //Length: 16
	}

	[Tooltip("Controls the filtering quality of soft shadows. Higher quality has lower performance.")]
	public SoftShadowQuality softShadowQuality
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public bool usePipelineSettings
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	internal int version
	{
		internal get { } //Length: 4
	}

	private static UniversalAdditionalLightData() { }

	public UniversalAdditionalLightData() { }

	public int get_additionalLightsShadowResolutionTier() { }

	public bool get_customShadowLayers() { }

	internal Light get_light() { }

	public Vector2 get_lightCookieOffset() { }

	public Vector2 get_lightCookieSize() { }

	public LightLayerEnum get_lightLayerMask() { }

	public uint get_renderingLayers() { }

	public LightLayerEnum get_shadowLayerMask() { }

	public uint get_shadowRenderingLayers() { }

	public SoftShadowQuality get_softShadowQuality() { }

	public bool get_usePipelineSettings() { }

	internal int get_version() { }

	public override void OnAfterDeserialize() { }

	public override void OnBeforeSerialize() { }

	public void set_customShadowLayers(bool value) { }

	public void set_lightCookieOffset(Vector2 value) { }

	public void set_lightCookieSize(Vector2 value) { }

	public void set_lightLayerMask(LightLayerEnum value) { }

	public void set_renderingLayers(uint value) { }

	public void set_shadowLayerMask(LightLayerEnum value) { }

	public void set_shadowRenderingLayers(uint value) { }

	public void set_softShadowQuality(SoftShadowQuality value) { }

	public void set_usePipelineSettings(bool value) { }

	private void SyncLightAndShadowLayers() { }

}

