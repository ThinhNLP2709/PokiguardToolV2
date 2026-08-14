namespace UnityEngine.Rendering;

public static class LightUnitUtils
{
	public const float SphereSolidAngle = 12.566371; //Field offset: 0x0

	private static float k_EvToLuminanceFactor
	{
		private get { } //Length: 23
	}

	private static float k_LuminanceToEvFactor
	{
		private get { } //Length: 169
	}

	public static float CandelaToEv100(float candela) { }

	public static float CandelaToLumen(float candela, float solidAngle) { }

	public static float CandelaToLux(float candela, float distance) { }

	public static float ConvertIntensity(Light light, float intensity, LightUnit fromUnit, LightUnit toUnit) { }

	internal static float ConvertIntensityInternal(float intensity, LightUnit fromUnit, LightUnit toUnit, LightType lightType, float area, float luxAtDistance, float solidAngle) { }

	public static float Ev100ToCandela(float ev100) { }

	public static float Ev100ToNits(float ev100) { }

	private static float get_k_EvToLuminanceFactor() { }

	private static float get_k_LuminanceToEvFactor() { }

	public static float GetAreaFromDiscLight(float discRadius) { }

	public static float GetAreaFromRectangleLight(Vector2 rectSize) { }

	public static float GetAreaFromRectangleLight(float rectSizeX, float rectSizeY) { }

	public static float GetAreaFromTubeLight(float tubeLength) { }

	public static LightUnit GetNativeLightUnit(LightType lightType) { }

	internal static float GetSolidAngle(LightType lightType, bool spotReflector, float spotAngle, float aspectRatio) { }

	public static float GetSolidAngleFromPointLight() { }

	public static float GetSolidAngleFromPyramidLight(float spotAngle, float aspectRatio) { }

	public static float GetSolidAngleFromSpotLight(float spotAngle) { }

	public static bool IsLightUnitSupported(LightType lightType, LightUnit lightUnit) { }

	public static float LumenToCandela(float lumen, float solidAngle) { }

	public static float LumenToNits(float lumen, float area) { }

	public static float LuxToCandela(float lux, float distance) { }

	public static float NitsToEv100(float nits) { }

	public static float NitsToLumen(float nits, float area) { }

}

