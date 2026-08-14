namespace UnityEngine;

[NativeHeader("Runtime/GfxDevice/ScalableBufferManager.h")]
[StaticAccessor("ScalableBufferManager::GetInstance()", StaticAccessorType::Dot (0))]
public static class ScalableBufferManager
{

	public static float heightScaleFactor
	{
		 get { } //Length: 42
	}

	public static float widthScaleFactor
	{
		 get { } //Length: 42
	}

	public static float get_heightScaleFactor() { }

	public static float get_widthScaleFactor() { }

	public static void ResizeBuffers(float widthScale, float heightScale) { }

}

