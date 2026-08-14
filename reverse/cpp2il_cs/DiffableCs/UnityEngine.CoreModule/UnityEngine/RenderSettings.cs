namespace UnityEngine;

[NativeHeader("Runtime/Camera/RenderSettings.h")]
[NativeHeader("Runtime/Graphics/QualitySettingsTypes.h")]
[StaticAccessor("GetRenderSettings()", StaticAccessorType::Dot (0))]
public sealed class RenderSettings : object
{

	public static Color ambientEquatorColor
	{
		 get { } //Length: 60
	}

	public static Color ambientGroundColor
	{
		 get { } //Length: 60
		 set { } //Length: 51
	}

	public static SphericalHarmonicsL2 ambientProbe
	{
		[NativeMethod("GetFinalAmbientProbe")]
		 get { } //Length: 89
	}

	public static Color ambientSkyColor
	{
		 get { } //Length: 60
	}

	[NativeProperty("UseFog")]
	public static bool fog
	{
		 get { } //Length: 42
	}

	public static float reflectionIntensity
	{
		 get { } //Length: 42
	}

	[NativeProperty("SkyboxMaterial")]
	public static Material skybox
	{
		 get { } //Length: 84
	}

	public static Color subtractiveShadowColor
	{
		 get { } //Length: 60
	}

	public static Light sun
	{
		 get { } //Length: 84
	}

	public static Color get_ambientEquatorColor() { }

	private static void get_ambientEquatorColor_Injected(out Color ret) { }

	public static Color get_ambientGroundColor() { }

	private static void get_ambientGroundColor_Injected(out Color ret) { }

	[NativeMethod("GetFinalAmbientProbe")]
	public static SphericalHarmonicsL2 get_ambientProbe() { }

	private static void get_ambientProbe_Injected(out SphericalHarmonicsL2 ret) { }

	public static Color get_ambientSkyColor() { }

	private static void get_ambientSkyColor_Injected(out Color ret) { }

	public static bool get_fog() { }

	public static float get_reflectionIntensity() { }

	public static Material get_skybox() { }

	private static IntPtr get_skybox_Injected() { }

	public static Color get_subtractiveShadowColor() { }

	private static void get_subtractiveShadowColor_Injected(out Color ret) { }

	public static Light get_sun() { }

	private static IntPtr get_sun_Injected() { }

	public static void set_ambientGroundColor(Color value) { }

	private static void set_ambientGroundColor_Injected(in Color value) { }

}

