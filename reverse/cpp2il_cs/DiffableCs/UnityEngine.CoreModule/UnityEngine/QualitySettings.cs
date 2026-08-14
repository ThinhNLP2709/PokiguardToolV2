namespace UnityEngine;

[NativeHeader("Runtime/Graphics/QualitySettings.h")]
[NativeHeader("Runtime/Misc/PlayerSettings.h")]
[StaticAccessor("GetQualitySettings()", StaticAccessorType::Dot (0))]
public sealed class QualitySettings : object
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action<Int32, Int32> activeQualityLevelChanged; //Field offset: 0x0

	public static ColorSpace activeColorSpace
	{
		[NativeName("GetColorSpace")]
		[StaticAccessor("GetPlayerSettings()", StaticAccessorType::Dot (0))]
		 get { } //Length: 42
	}

	public static int antiAliasing
	{
		 get { } //Length: 42
		 set { } //Length: 49
	}

	public static bool billboardsFaceCameraPosition
	{
		 get { } //Length: 42
	}

	public static bool enableLODCrossFade
	{
		 set { } //Length: 51
	}

	[NativeProperty("LODBias")]
	public static float lodBias
	{
		 get { } //Length: 42
		 set { } //Length: 58
	}

	public static int maximumLODLevel
	{
		 get { } //Length: 42
	}

	[NativeProperty("ShadowmaskMode")]
	public static ShadowmaskMode shadowmaskMode
	{
		 get { } //Length: 42
	}

	public static int vSyncCount
	{
		 get { } //Length: 42
		 set { } //Length: 49
	}

	[NativeName("GetColorSpace")]
	[StaticAccessor("GetPlayerSettings()", StaticAccessorType::Dot (0))]
	public static ColorSpace get_activeColorSpace() { }

	public static int get_antiAliasing() { }

	public static bool get_billboardsFaceCameraPosition() { }

	public static float get_lodBias() { }

	public static int get_maximumLODLevel() { }

	public static ShadowmaskMode get_shadowmaskMode() { }

	public static int get_vSyncCount() { }

	[RequiredByNativeCode]
	internal static void OnActiveQualityLevelChanged(int previousQualityLevel, int currentQualityLevel) { }

	public static void set_antiAliasing(int value) { }

	public static void set_enableLODCrossFade(bool value) { }

	public static void set_lodBias(float value) { }

	public static void set_vSyncCount(int value) { }

}

