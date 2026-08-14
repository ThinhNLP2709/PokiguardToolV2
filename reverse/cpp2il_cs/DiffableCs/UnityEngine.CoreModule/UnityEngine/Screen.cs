namespace UnityEngine;

[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
[NativeHeader("Runtime/Graphics/WindowLayout.h")]
[NativeHeader("Runtime/Graphics/ScreenManager.h")]
[StaticAccessor("GetScreenManager()", StaticAccessorType::Dot (0))]
public sealed class Screen
{

	public static Resolution currentResolution
	{
		 get { } //Length: 60
	}

	public static float dpi
	{
		[NativeName("GetDPI")]
		 get { } //Length: 42
	}

	public static bool fullScreen
	{
		[NativeName("IsFullscreen")]
		 get { } //Length: 42
	}

	public static int height
	{
		[NativeMethod(Name = "GetHeight", IsThreadSafe = True)]
		 get { } //Length: 42
	}

	public static int msaaSamples
	{
		 get { } //Length: 42
	}

	public static ScreenOrientation orientation
	{
		 get { } //Length: 42
	}

	public static int width
	{
		[NativeMethod(Name = "GetWidth", IsThreadSafe = True)]
		 get { } //Length: 42
	}

	public static Resolution get_currentResolution() { }

	private static void get_currentResolution_Injected(out Resolution ret) { }

	[NativeName("GetDPI")]
	public static float get_dpi() { }

	[NativeName("IsFullscreen")]
	public static bool get_fullScreen() { }

	[NativeMethod(Name = "GetHeight", IsThreadSafe = True)]
	public static int get_height() { }

	public static int get_msaaSamples() { }

	public static ScreenOrientation get_orientation() { }

	[NativeMethod(Name = "GetWidth", IsThreadSafe = True)]
	public static int get_width() { }

	private static int GetMSAASamples() { }

	private static ScreenOrientation GetScreenOrientation() { }

	public static void SetMSAASamples(int numSamples) { }

}

