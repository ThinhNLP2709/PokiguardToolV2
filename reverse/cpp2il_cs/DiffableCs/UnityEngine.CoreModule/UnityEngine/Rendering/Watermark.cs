namespace UnityEngine.Rendering;

[NativeHeader("Runtime/Graphics/DrawSplashScreenAndWatermarks.h")]
public class Watermark
{

	[FreeFunction("IsAnyWatermarkVisible")]
	public static bool IsVisible() { }

}

