namespace UnityEngine;

[NativeHeader("Runtime/Input/TimeManager.h")]
[StaticAccessor("GetTimeManager()", StaticAccessorType::Dot (0))]
public class Time
{

	public static float deltaTime
	{
		 get { } //Length: 42
	}

	public static float fixedDeltaTime
	{
		 get { } //Length: 42
		 set { } //Length: 58
	}

	public static float fixedUnscaledTime
	{
		 get { } //Length: 42
	}

	public static int frameCount
	{
		 get { } //Length: 42
	}

	[NativeProperty("Realtime")]
	public static float realtimeSinceStartup
	{
		 get { } //Length: 42
	}

	[NativeProperty("Realtime")]
	public static double realtimeSinceStartupAsDouble
	{
		 get { } //Length: 42
	}

	[NativeProperty("RenderFrameCount")]
	public static int renderedFrameCount
	{
		 get { } //Length: 42
	}

	public static float smoothDeltaTime
	{
		 get { } //Length: 42
	}

	[NativeProperty("CurTime")]
	public static float time
	{
		 get { } //Length: 42
	}

	[NativeProperty("CurTime")]
	public static double timeAsDouble
	{
		 get { } //Length: 42
	}

	[NativeProperty("CurTimeRational")]
	public static RationalTime timeAsRational
	{
		 get { } //Length: 60
	}

	public static float timeScale
	{
		 get { } //Length: 42
		 set { } //Length: 58
	}

	public static float unscaledDeltaTime
	{
		 get { } //Length: 42
	}

	public static float unscaledTime
	{
		 get { } //Length: 42
	}

	public static float get_deltaTime() { }

	public static float get_fixedDeltaTime() { }

	public static float get_fixedUnscaledTime() { }

	public static int get_frameCount() { }

	public static float get_realtimeSinceStartup() { }

	public static double get_realtimeSinceStartupAsDouble() { }

	public static int get_renderedFrameCount() { }

	public static float get_smoothDeltaTime() { }

	public static float get_time() { }

	public static double get_timeAsDouble() { }

	public static RationalTime get_timeAsRational() { }

	private static void get_timeAsRational_Injected(out RationalTime ret) { }

	public static float get_timeScale() { }

	public static float get_unscaledDeltaTime() { }

	public static float get_unscaledTime() { }

	public static void set_fixedDeltaTime(float value) { }

	public static void set_timeScale(float value) { }

}

