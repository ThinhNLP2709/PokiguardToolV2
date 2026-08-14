namespace UnityEngine;

[NativeHeader("Runtime/Export/Graphics/Light.bindings.h")]
[NativeHeader("Runtime/Camera/Light.h")]
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Transform))]
public sealed class Light : Behaviour
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private LightShape <shape>k__BackingField; //Field offset: 0x18
	private int m_BakedIndex; //Field offset: 0x1C

	public Vector2 areaSize
	{
		 get { } //Length: 135
	}

	public LightBakingOutput bakingOutput
	{
		 get { } //Length: 147
	}

	public float bounceIntensity
	{
		 get { } //Length: 118
	}

	public Color color
	{
		 get { } //Length: 142
		 set { } //Length: 133
	}

	public float colorTemperature
	{
		 get { } //Length: 118
	}

	public Texture cookie
	{
		 get { } //Length: 144
	}

	public float cookieSize
	{
		 get { } //Length: 118
	}

	public float dilatedRange
	{
		 get { } //Length: 118
	}

	public bool enableSpotReflector
	{
		 get { } //Length: 118
	}

	public float innerSpotAngle
	{
		 get { } //Length: 118
	}

	public float intensity
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	public float luxAtDistance
	{
		 get { } //Length: 118
	}

	public float range
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	public int renderingLayerMask
	{
		 set { } //Length: 131
	}

	public float shadowBias
	{
		 get { } //Length: 118
	}

	public float shadowNearPlane
	{
		 get { } //Length: 118
	}

	public float shadowNormalBias
	{
		 get { } //Length: 118
	}

	public LightShadowResolution shadowResolution
	{
		 get { } //Length: 118
	}

	public LightShadows shadows
	{
		[NativeMethod("GetShadowType")]
		 get { } //Length: 118
	}

	public float shadowStrength
	{
		 get { } //Length: 118
		[FreeFunction("Light_Bindings::SetShadowStrength", HasExplicitThis = True)]
		 set { } //Length: 134
	}

	public float spotAngle
	{
		 get { } //Length: 118
	}

	[NativeProperty("LightType")]
	public LightType type
	{
		 get { } //Length: 118
	}

	public bool useColorTemperature
	{
		 get { } //Length: 118
	}

	public Vector2 get_areaSize() { }

	private static void get_areaSize_Injected(IntPtr _unity_self, out Vector2 ret) { }

	public LightBakingOutput get_bakingOutput() { }

	private static void get_bakingOutput_Injected(IntPtr _unity_self, out LightBakingOutput ret) { }

	public float get_bounceIntensity() { }

	private static float get_bounceIntensity_Injected(IntPtr _unity_self) { }

	public Color get_color() { }

	private static void get_color_Injected(IntPtr _unity_self, out Color ret) { }

	public float get_colorTemperature() { }

	private static float get_colorTemperature_Injected(IntPtr _unity_self) { }

	public Texture get_cookie() { }

	private static IntPtr get_cookie_Injected(IntPtr _unity_self) { }

	public float get_cookieSize() { }

	private static float get_cookieSize_Injected(IntPtr _unity_self) { }

	public float get_dilatedRange() { }

	private static float get_dilatedRange_Injected(IntPtr _unity_self) { }

	public bool get_enableSpotReflector() { }

	private static bool get_enableSpotReflector_Injected(IntPtr _unity_self) { }

	public float get_innerSpotAngle() { }

	private static float get_innerSpotAngle_Injected(IntPtr _unity_self) { }

	public float get_intensity() { }

	private static float get_intensity_Injected(IntPtr _unity_self) { }

	public float get_luxAtDistance() { }

	private static float get_luxAtDistance_Injected(IntPtr _unity_self) { }

	public float get_range() { }

	private static float get_range_Injected(IntPtr _unity_self) { }

	public float get_shadowBias() { }

	private static float get_shadowBias_Injected(IntPtr _unity_self) { }

	public float get_shadowNearPlane() { }

	private static float get_shadowNearPlane_Injected(IntPtr _unity_self) { }

	public float get_shadowNormalBias() { }

	private static float get_shadowNormalBias_Injected(IntPtr _unity_self) { }

	public LightShadowResolution get_shadowResolution() { }

	private static LightShadowResolution get_shadowResolution_Injected(IntPtr _unity_self) { }

	[NativeMethod("GetShadowType")]
	public LightShadows get_shadows() { }

	private static LightShadows get_shadows_Injected(IntPtr _unity_self) { }

	public float get_shadowStrength() { }

	private static float get_shadowStrength_Injected(IntPtr _unity_self) { }

	public float get_spotAngle() { }

	private static float get_spotAngle_Injected(IntPtr _unity_self) { }

	public LightType get_type() { }

	private static LightType get_type_Injected(IntPtr _unity_self) { }

	public bool get_useColorTemperature() { }

	private static bool get_useColorTemperature_Injected(IntPtr _unity_self) { }

	public void set_color(Color value) { }

	private static void set_color_Injected(IntPtr _unity_self, in Color value) { }

	public void set_intensity(float value) { }

	private static void set_intensity_Injected(IntPtr _unity_self, float value) { }

	public void set_range(float value) { }

	private static void set_range_Injected(IntPtr _unity_self, float value) { }

	public void set_renderingLayerMask(int value) { }

	private static void set_renderingLayerMask_Injected(IntPtr _unity_self, int value) { }

	[FreeFunction("Light_Bindings::SetShadowStrength", HasExplicitThis = True)]
	public void set_shadowStrength(float value) { }

	private static void set_shadowStrength_Injected(IntPtr _unity_self, float value) { }

}

