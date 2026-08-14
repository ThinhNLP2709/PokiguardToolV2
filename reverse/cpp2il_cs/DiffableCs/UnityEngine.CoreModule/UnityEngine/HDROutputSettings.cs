namespace UnityEngine;

[NativeHeader("Runtime/GfxDevice/HDROutputSettings.h")]
[UsedByNativeCode]
public class HDROutputSettings
{
	public static HDROutputSettings[] displays; //Field offset: 0x0
	private static HDROutputSettings _mainDisplay; //Field offset: 0x8
	private int m_DisplayIndex; //Field offset: 0x10

	public bool active
	{
		 get { } //Length: 102
	}

	public bool automaticHDRTonemapping
	{
		 get { } //Length: 102
		 set { } //Length: 118
	}

	public bool available
	{
		 get { } //Length: 102
	}

	public ColorGamut displayColorGamut
	{
		 get { } //Length: 102
	}

	public GraphicsFormat graphicsFormat
	{
		 get { } //Length: 102
	}

	public bool HDRModeChangeRequested
	{
		 get { } //Length: 102
	}

	public static HDROutputSettings main
	{
		 get { } //Length: 79
	}

	public int maxFullFrameToneMapLuminance
	{
		 get { } //Length: 102
	}

	public int maxToneMapLuminance
	{
		 get { } //Length: 102
	}

	public int minToneMapLuminance
	{
		 get { } //Length: 102
	}

	public float paperWhiteNits
	{
		 get { } //Length: 102
	}

	private static HDROutputSettings() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.XRModule"})]
	internal HDROutputSettings() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.XRModule"})]
	internal HDROutputSettings(int displayIndex) { }

	public bool get_active() { }

	public bool get_automaticHDRTonemapping() { }

	public bool get_available() { }

	public ColorGamut get_displayColorGamut() { }

	public GraphicsFormat get_graphicsFormat() { }

	public bool get_HDRModeChangeRequested() { }

	public static HDROutputSettings get_main() { }

	public int get_maxFullFrameToneMapLuminance() { }

	public int get_maxToneMapLuminance() { }

	public int get_minToneMapLuminance() { }

	public float get_paperWhiteNits() { }

	[FreeFunction("HDROutputSettingsBindings::GetActive", HasExplicitThis = False, ThrowsException = True)]
	private static bool GetActive(int displayIndex) { }

	[FreeFunction("HDROutputSettingsBindings::GetAutomaticHDRTonemapping", HasExplicitThis = False, ThrowsException = True)]
	private static bool GetAutomaticHDRTonemapping(int displayIndex) { }

	[FreeFunction("HDROutputSettingsBindings::GetAvailable", HasExplicitThis = False, ThrowsException = True)]
	private static bool GetAvailable(int displayIndex) { }

	[FreeFunction("HDROutputSettingsBindings::GetDisplayColorGamut", HasExplicitThis = False, ThrowsException = True)]
	private static ColorGamut GetDisplayColorGamut(int displayIndex) { }

	[FreeFunction("HDROutputSettingsBindings::GetGraphicsFormat", HasExplicitThis = False, ThrowsException = True)]
	private static GraphicsFormat GetGraphicsFormat(int displayIndex) { }

	[FreeFunction("HDROutputSettingsBindings::GetHDRModeChangeRequested", HasExplicitThis = False, ThrowsException = True)]
	private static bool GetHDRModeChangeRequested(int displayIndex) { }

	[FreeFunction("HDROutputSettingsBindings::GetMaxFullFrameToneMapLuminance", HasExplicitThis = False, ThrowsException = True)]
	private static int GetMaxFullFrameToneMapLuminance(int displayIndex) { }

	[FreeFunction("HDROutputSettingsBindings::GetMaxToneMapLuminance", HasExplicitThis = False, ThrowsException = True)]
	private static int GetMaxToneMapLuminance(int displayIndex) { }

	[FreeFunction("HDROutputSettingsBindings::GetMinToneMapLuminance", HasExplicitThis = False, ThrowsException = True)]
	private static int GetMinToneMapLuminance(int displayIndex) { }

	[FreeFunction("HDROutputSettingsBindings::GetPaperWhiteNits", HasExplicitThis = False, ThrowsException = True)]
	private static float GetPaperWhiteNits(int displayIndex) { }

	public void RequestHDRModeChange(bool enabled) { }

	[FreeFunction("HDROutputSettingsBindings::RequestHDRModeChange", HasExplicitThis = False, ThrowsException = True)]
	private static void RequestHDRModeChangeInternal(int displayIndex, bool enabled) { }

	public void set_automaticHDRTonemapping(bool value) { }

	[FreeFunction("HDROutputSettingsBindings::SetAutomaticHDRTonemapping", HasExplicitThis = False, ThrowsException = True)]
	private static void SetAutomaticHDRTonemapping(int displayIndex, bool scripted) { }

}

