namespace UnityEngine.Rendering;

public static class ColorUtils
{
	public static float s_LightMeterCalibrationConstant; //Field offset: 0x0
	public static float s_LensAttenuation; //Field offset: 0x4

	public static float lensImperfectionExposureScale
	{
		 get { } //Length: 100
	}

	private static ColorUtils() { }

	public static Vector3 CIExyToLMS(float x, float y) { }

	public static Vector3 ColorBalanceToLMSCoeffs(float temperature, float tint) { }

	public static float ComputeEV100(float aperture, float shutterSpeed, float ISO) { }

	public static float ComputeEV100FromAvgLuminance(float avgLuminance) { }

	public static float ComputeISO(float aperture, float shutterSpeed, float targetEV100) { }

	public static float ConvertEV100ToExposure(float EV100) { }

	public static float ConvertExposureToEV100(float exposure) { }

	public static float get_lensImperfectionExposureScale() { }

	public static float Luminance(in Color color) { }

	public static ValueTuple<Vector4, Vector4, Vector4> PrepareLiftGammaGain(in Vector4 inLift, in Vector4 inGamma, in Vector4 inGain) { }

	public static ValueTuple<Vector4, Vector4, Vector4> PrepareShadowsMidtonesHighlights(in Vector4 inShadows, in Vector4 inMidtones, in Vector4 inHighlights) { }

	public static ValueTuple<Vector4, Vector4> PrepareSplitToning(in Vector4 inShadows, in Vector4 inHighlights, float balance) { }

	public static float StandardIlluminantY(float x) { }

	public static uint ToHex(Color c) { }

	public static Color ToRGBA(uint hex) { }

}

