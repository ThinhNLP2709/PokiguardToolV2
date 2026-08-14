namespace UnityEngine.Rendering;

public class XRSRPSettings
{

	public static bool enabled
	{
		 get { } //Length: 7
	}

	public static RenderTextureDescriptor eyeTextureDesc
	{
		 get { } //Length: 113
	}

	public static int eyeTextureHeight
	{
		 get { } //Length: 33
	}

	public static int eyeTextureWidth
	{
		 get { } //Length: 33
	}

	public static bool isDeviceActive
	{
		 get { } //Length: 31
	}

	public static string loadedDeviceName
	{
		 get { } //Length: 66
	}

	public static int mirrorViewMode
	{
		 get { } //Length: 82
		 set { } //Length: 88
	}

	public static float occlusionMeshScale
	{
		 get { } //Length: 145
		 set { } //Length: 9634
	}

	public static String[] supportedDevices
	{
		 get { } //Length: 75
	}

	public XRSRPSettings() { }

	public static bool get_enabled() { }

	public static RenderTextureDescriptor get_eyeTextureDesc() { }

	public static int get_eyeTextureHeight() { }

	public static int get_eyeTextureWidth() { }

	public static bool get_isDeviceActive() { }

	public static string get_loadedDeviceName() { }

	public static int get_mirrorViewMode() { }

	public static float get_occlusionMeshScale() { }

	public static String[] get_supportedDevices() { }

	public static void set_mirrorViewMode(int value) { }

	public static void set_occlusionMeshScale(float value) { }

}

