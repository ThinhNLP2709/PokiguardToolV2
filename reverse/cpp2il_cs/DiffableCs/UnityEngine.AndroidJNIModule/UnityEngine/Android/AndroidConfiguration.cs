namespace UnityEngine.Android;

[NativeAsStruct]
[NativeType(Header = "Modules/AndroidJNI/Public/AndroidConfiguration.bindings.h")]
[RequiredByNativeCode]
public sealed class AndroidConfiguration
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <colorMode>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <densityDpi>k__BackingField; //Field offset: 0x14
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private float <fontScale>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <fontWeightAdjustment>k__BackingField; //Field offset: 0x1C
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private AndroidKeyboard <keyboard>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private AndroidHardwareKeyboardHidden <hardKeyboardHidden>k__BackingField; //Field offset: 0x24
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private AndroidKeyboardHidden <keyboardHidden>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <mobileCountryCode>k__BackingField; //Field offset: 0x2C
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <mobileNetworkCode>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private AndroidNavigation <navigation>k__BackingField; //Field offset: 0x34
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private AndroidNavigationHidden <navigationHidden>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private AndroidOrientation <orientation>k__BackingField; //Field offset: 0x3C
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <screenHeightDp>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <screenWidthDp>k__BackingField; //Field offset: 0x44
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <smallestScreenWidthDp>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <screenLayout>k__BackingField; //Field offset: 0x4C
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private AndroidTouchScreen <touchScreen>k__BackingField; //Field offset: 0x50
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <uiMode>k__BackingField; //Field offset: 0x54
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <primaryLocaleCountry>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <primaryLocaleLanguage>k__BackingField; //Field offset: 0x60

	private int colorMode
	{
		[CompilerGenerated]
		private get { } //Length: 4
	}

	public AndroidColorModeHdr colorModeHdr
	{
		 get { } //Length: 7
	}

	public AndroidColorModeWideColorGamut colorModeWideColorGamut
	{
		 get { } //Length: 7
	}

	public int densityDpi
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public float fontScale
	{
		[CompilerGenerated]
		 get { } //Length: 6
	}

	public int fontWeightAdjustment
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public AndroidHardwareKeyboardHidden hardKeyboardHidden
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public AndroidKeyboard keyboard
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public AndroidKeyboardHidden keyboardHidden
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public AndroidLocale[] locales
	{
		 get { } //Length: 290
	}

	public int mobileCountryCode
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public int mobileNetworkCode
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public AndroidNavigation navigation
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public AndroidNavigationHidden navigationHidden
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public AndroidOrientation orientation
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	private string primaryLocaleCountry
	{
		[CompilerGenerated]
		private get { } //Length: 5
	}

	private string primaryLocaleLanguage
	{
		[CompilerGenerated]
		private get { } //Length: 694
	}

	public int screenHeightDp
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	private int screenLayout
	{
		[CompilerGenerated]
		private get { } //Length: 4
	}

	public AndroidScreenLayoutDirection screenLayoutDirection
	{
		 get { } //Length: 9
	}

	public AndroidScreenLayoutLong screenLayoutLong
	{
		 get { } //Length: 7
	}

	public AndroidScreenLayoutRound screenLayoutRound
	{
		 get { } //Length: 9
	}

	public AndroidScreenLayoutSize screenLayoutSize
	{
		 get { } //Length: 7
	}

	public int screenWidthDp
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public int smallestScreenWidthDp
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public AndroidTouchScreen touchScreen
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	private int uiMode
	{
		[CompilerGenerated]
		private get { } //Length: 4
	}

	public AndroidUIModeNight uiModeNight
	{
		 get { } //Length: 7
	}

	public AndroidUIModeType uiModeType
	{
		 get { } //Length: 7
	}

	[CompilerGenerated]
	private int get_colorMode() { }

	public AndroidColorModeHdr get_colorModeHdr() { }

	public AndroidColorModeWideColorGamut get_colorModeWideColorGamut() { }

	[CompilerGenerated]
	public int get_densityDpi() { }

	[CompilerGenerated]
	public float get_fontScale() { }

	[CompilerGenerated]
	public int get_fontWeightAdjustment() { }

	[CompilerGenerated]
	public AndroidHardwareKeyboardHidden get_hardKeyboardHidden() { }

	[CompilerGenerated]
	public AndroidKeyboard get_keyboard() { }

	[CompilerGenerated]
	public AndroidKeyboardHidden get_keyboardHidden() { }

	public AndroidLocale[] get_locales() { }

	[CompilerGenerated]
	public int get_mobileCountryCode() { }

	[CompilerGenerated]
	public int get_mobileNetworkCode() { }

	[CompilerGenerated]
	public AndroidNavigation get_navigation() { }

	[CompilerGenerated]
	public AndroidNavigationHidden get_navigationHidden() { }

	[CompilerGenerated]
	public AndroidOrientation get_orientation() { }

	[CompilerGenerated]
	private string get_primaryLocaleCountry() { }

	[CompilerGenerated]
	private string get_primaryLocaleLanguage() { }

	[CompilerGenerated]
	public int get_screenHeightDp() { }

	[CompilerGenerated]
	private int get_screenLayout() { }

	public AndroidScreenLayoutDirection get_screenLayoutDirection() { }

	public AndroidScreenLayoutLong get_screenLayoutLong() { }

	public AndroidScreenLayoutRound get_screenLayoutRound() { }

	public AndroidScreenLayoutSize get_screenLayoutSize() { }

	[CompilerGenerated]
	public int get_screenWidthDp() { }

	[CompilerGenerated]
	public int get_smallestScreenWidthDp() { }

	[CompilerGenerated]
	public AndroidTouchScreen get_touchScreen() { }

	[CompilerGenerated]
	private int get_uiMode() { }

	public AndroidUIModeNight get_uiModeNight() { }

	public AndroidUIModeType get_uiModeType() { }

	[Preserve]
	public virtual string ToString() { }

}

