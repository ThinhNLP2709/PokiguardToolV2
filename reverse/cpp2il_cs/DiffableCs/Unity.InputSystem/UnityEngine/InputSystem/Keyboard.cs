namespace UnityEngine.InputSystem;

[DefaultMember("Item")]
[InputControlLayout(stateType = typeof(KeyboardState), isGenericTypeOfDevice = True)]
public class Keyboard : InputDevice, ITextInputReceiver, IEventPreProcessor
{
	public const int KeyCount = 110; //Field offset: 0x0
	internal const int ExtendedKeyCount = 126; //Field offset: 0x0
	[CompilerGenerated]
	private static Keyboard <current>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private AnyKeyControl <anyKey>k__BackingField; //Field offset: 0x190
	[CompilerGenerated]
	private ButtonControl <shiftKey>k__BackingField; //Field offset: 0x198
	[CompilerGenerated]
	private ButtonControl <ctrlKey>k__BackingField; //Field offset: 0x1A0
	[CompilerGenerated]
	private ButtonControl <altKey>k__BackingField; //Field offset: 0x1A8
	[CompilerGenerated]
	private ButtonControl <imeSelected>k__BackingField; //Field offset: 0x1B0
	private InlinedArray<Action`1<Char>> m_TextInputListeners; //Field offset: 0x1B8
	private string m_KeyboardLayoutName; //Field offset: 0x1D0
	private KeyControl[] m_Keys; //Field offset: 0x1D8
	private InlinedArray<Action`1<IMECompositionString>> m_ImeCompositionListeners; //Field offset: 0x1E0

	public event Action<IMECompositionString> onIMECompositionChange
	{
		 add { } //Length: 216
		 remove { } //Length: 76
	}

	public event Action<Char> onTextInput
	{
		 add { } //Length: 216
		 remove { } //Length: 76
	}

	public KeyControl aKey
	{
		 get { } //Length: 13
	}

	public ReadOnlyArray<KeyControl> allKeys
	{
		 get { } //Length: 86
	}

	public ButtonControl altKey
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public AnyKeyControl anyKey
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public KeyControl backquoteKey
	{
		 get { } //Length: 13
	}

	public KeyControl backslashKey
	{
		 get { } //Length: 13
	}

	public KeyControl backspaceKey
	{
		 get { } //Length: 13
	}

	public KeyControl bKey
	{
		 get { } //Length: 13
	}

	public KeyControl capsLockKey
	{
		 get { } //Length: 13
	}

	public KeyControl cKey
	{
		 get { } //Length: 13
	}

	public KeyControl commaKey
	{
		 get { } //Length: 13
	}

	public KeyControl contextMenuKey
	{
		 get { } //Length: 13
	}

	public ButtonControl ctrlKey
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public private static Keyboard current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public KeyControl deleteKey
	{
		 get { } //Length: 13
	}

	public KeyControl digit0Key
	{
		 get { } //Length: 13
	}

	public KeyControl digit1Key
	{
		 get { } //Length: 13
	}

	public KeyControl digit2Key
	{
		 get { } //Length: 13
	}

	public KeyControl digit3Key
	{
		 get { } //Length: 13
	}

	public KeyControl digit4Key
	{
		 get { } //Length: 13
	}

	public KeyControl digit5Key
	{
		 get { } //Length: 13
	}

	public KeyControl digit6Key
	{
		 get { } //Length: 13
	}

	public KeyControl digit7Key
	{
		 get { } //Length: 13
	}

	public KeyControl digit8Key
	{
		 get { } //Length: 13
	}

	public KeyControl digit9Key
	{
		 get { } //Length: 13
	}

	public KeyControl dKey
	{
		 get { } //Length: 13
	}

	public KeyControl downArrowKey
	{
		 get { } //Length: 13
	}

	public KeyControl eKey
	{
		 get { } //Length: 13
	}

	public KeyControl endKey
	{
		 get { } //Length: 13
	}

	public KeyControl enterKey
	{
		 get { } //Length: 13
	}

	public KeyControl equalsKey
	{
		 get { } //Length: 13
	}

	public KeyControl escapeKey
	{
		 get { } //Length: 13
	}

	public KeyControl f10Key
	{
		 get { } //Length: 13
	}

	public KeyControl f11Key
	{
		 get { } //Length: 13
	}

	public KeyControl f12Key
	{
		 get { } //Length: 13
	}

	public KeyControl f13Key
	{
		 get { } //Length: 13
	}

	public KeyControl f14Key
	{
		 get { } //Length: 13
	}

	public KeyControl f15Key
	{
		 get { } //Length: 13
	}

	public KeyControl f16Key
	{
		 get { } //Length: 13
	}

	public KeyControl f17Key
	{
		 get { } //Length: 13
	}

	public KeyControl f18Key
	{
		 get { } //Length: 13
	}

	public KeyControl f19Key
	{
		 get { } //Length: 13
	}

	public KeyControl f1Key
	{
		 get { } //Length: 13
	}

	public KeyControl f20Key
	{
		 get { } //Length: 13
	}

	public KeyControl f21Key
	{
		 get { } //Length: 13
	}

	public KeyControl f22Key
	{
		 get { } //Length: 13
	}

	public KeyControl f23Key
	{
		 get { } //Length: 13
	}

	public KeyControl f24Key
	{
		 get { } //Length: 13
	}

	public KeyControl f2Key
	{
		 get { } //Length: 13
	}

	public KeyControl f3Key
	{
		 get { } //Length: 13
	}

	public KeyControl f4Key
	{
		 get { } //Length: 13
	}

	public KeyControl f5Key
	{
		 get { } //Length: 13
	}

	public KeyControl f6Key
	{
		 get { } //Length: 13
	}

	public KeyControl f7Key
	{
		 get { } //Length: 13
	}

	public KeyControl f8Key
	{
		 get { } //Length: 13
	}

	public KeyControl f9Key
	{
		 get { } //Length: 13
	}

	public KeyControl fKey
	{
		 get { } //Length: 13
	}

	public KeyControl gKey
	{
		 get { } //Length: 13
	}

	public KeyControl hKey
	{
		 get { } //Length: 13
	}

	public KeyControl homeKey
	{
		 get { } //Length: 13
	}

	public KeyControl iKey
	{
		 get { } //Length: 13
	}

	public ButtonControl imeSelected
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public KeyControl insertKey
	{
		 get { } //Length: 13
	}

	public KeyControl Item
	{
		 get { } //Length: 233
	}

	public KeyControl jKey
	{
		 get { } //Length: 13
	}

	public string keyboardLayout
	{
		 get { } //Length: 29
		 set { } //Length: 19
	}

	protected KeyControl[] keys
	{
		 get { } //Length: 8
		 set { } //Length: 19
	}

	public KeyControl kKey
	{
		 get { } //Length: 13
	}

	public KeyControl leftAltKey
	{
		 get { } //Length: 13
	}

	public KeyControl leftAppleKey
	{
		 get { } //Length: 13
	}

	public KeyControl leftArrowKey
	{
		 get { } //Length: 13
	}

	public KeyControl leftBracketKey
	{
		 get { } //Length: 13
	}

	public KeyControl leftCommandKey
	{
		 get { } //Length: 13
	}

	public KeyControl leftCtrlKey
	{
		 get { } //Length: 13
	}

	public KeyControl leftMetaKey
	{
		 get { } //Length: 13
	}

	public KeyControl leftShiftKey
	{
		 get { } //Length: 13
	}

	public KeyControl leftWindowsKey
	{
		 get { } //Length: 13
	}

	public KeyControl lKey
	{
		 get { } //Length: 13
	}

	public KeyControl mediaForward
	{
		 get { } //Length: 13
	}

	public KeyControl mediaPlayPause
	{
		 get { } //Length: 13
	}

	public KeyControl mediaRewind
	{
		 get { } //Length: 13
	}

	public KeyControl minusKey
	{
		 get { } //Length: 13
	}

	public KeyControl mKey
	{
		 get { } //Length: 13
	}

	public KeyControl nKey
	{
		 get { } //Length: 13
	}

	public KeyControl numLockKey
	{
		 get { } //Length: 13
	}

	public KeyControl numpad0Key
	{
		 get { } //Length: 13
	}

	public KeyControl numpad1Key
	{
		 get { } //Length: 13
	}

	public KeyControl numpad2Key
	{
		 get { } //Length: 13
	}

	public KeyControl numpad3Key
	{
		 get { } //Length: 13
	}

	public KeyControl numpad4Key
	{
		 get { } //Length: 13
	}

	public KeyControl numpad5Key
	{
		 get { } //Length: 13
	}

	public KeyControl numpad6Key
	{
		 get { } //Length: 13
	}

	public KeyControl numpad7Key
	{
		 get { } //Length: 13
	}

	public KeyControl numpad8Key
	{
		 get { } //Length: 13
	}

	public KeyControl numpad9Key
	{
		 get { } //Length: 13
	}

	public KeyControl numpadDivideKey
	{
		 get { } //Length: 13
	}

	public KeyControl numpadEnterKey
	{
		 get { } //Length: 13
	}

	public KeyControl numpadEqualsKey
	{
		 get { } //Length: 13
	}

	public KeyControl numpadMinusKey
	{
		 get { } //Length: 13
	}

	public KeyControl numpadMultiplyKey
	{
		 get { } //Length: 13
	}

	public KeyControl numpadPeriodKey
	{
		 get { } //Length: 13
	}

	public KeyControl numpadPlusKey
	{
		 get { } //Length: 13
	}

	public KeyControl oem1Key
	{
		 get { } //Length: 13
	}

	public KeyControl oem2Key
	{
		 get { } //Length: 13
	}

	public KeyControl oem3Key
	{
		 get { } //Length: 13
	}

	public KeyControl oem4Key
	{
		 get { } //Length: 13
	}

	public KeyControl oem5Key
	{
		 get { } //Length: 13
	}

	public KeyControl oKey
	{
		 get { } //Length: 13
	}

	public KeyControl pageDownKey
	{
		 get { } //Length: 13
	}

	public KeyControl pageUpKey
	{
		 get { } //Length: 13
	}

	public KeyControl pauseKey
	{
		 get { } //Length: 13
	}

	public KeyControl periodKey
	{
		 get { } //Length: 13
	}

	public KeyControl pKey
	{
		 get { } //Length: 13
	}

	public KeyControl printScreenKey
	{
		 get { } //Length: 13
	}

	public KeyControl qKey
	{
		 get { } //Length: 13
	}

	public KeyControl quoteKey
	{
		 get { } //Length: 13
	}

	public KeyControl rightAltKey
	{
		 get { } //Length: 13
	}

	public KeyControl rightAppleKey
	{
		 get { } //Length: 13
	}

	public KeyControl rightArrowKey
	{
		 get { } //Length: 13
	}

	public KeyControl rightBracketKey
	{
		 get { } //Length: 13
	}

	public KeyControl rightCommandKey
	{
		 get { } //Length: 13
	}

	public KeyControl rightCtrlKey
	{
		 get { } //Length: 13
	}

	public KeyControl rightMetaKey
	{
		 get { } //Length: 13
	}

	public KeyControl rightShiftKey
	{
		 get { } //Length: 13
	}

	public KeyControl rightWindowsKey
	{
		 get { } //Length: 13
	}

	public KeyControl rKey
	{
		 get { } //Length: 13
	}

	public KeyControl scrollLockKey
	{
		 get { } //Length: 13
	}

	public KeyControl semicolonKey
	{
		 get { } //Length: 13
	}

	public ButtonControl shiftKey
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public KeyControl sKey
	{
		 get { } //Length: 13
	}

	public KeyControl slashKey
	{
		 get { } //Length: 13
	}

	public KeyControl spaceKey
	{
		 get { } //Length: 13
	}

	public KeyControl tabKey
	{
		 get { } //Length: 13
	}

	public KeyControl tKey
	{
		 get { } //Length: 13
	}

	public KeyControl uKey
	{
		 get { } //Length: 13
	}

	public KeyControl upArrowKey
	{
		 get { } //Length: 13
	}

	public KeyControl vKey
	{
		 get { } //Length: 13
	}

	public KeyControl wKey
	{
		 get { } //Length: 13
	}

	public KeyControl xKey
	{
		 get { } //Length: 13
	}

	public KeyControl yKey
	{
		 get { } //Length: 13
	}

	public KeyControl zKey
	{
		 get { } //Length: 13
	}

	public Keyboard() { }

	public void add_onIMECompositionChange(Action<IMECompositionString> value) { }

	public void add_onTextInput(Action<Char> value) { }

	public KeyControl FindKeyOnCurrentKeyboardLayout(string displayName) { }

	protected virtual void FinishSetup() { }

	public KeyControl get_aKey() { }

	public ReadOnlyArray<KeyControl> get_allKeys() { }

	[CompilerGenerated]
	public ButtonControl get_altKey() { }

	[CompilerGenerated]
	public AnyKeyControl get_anyKey() { }

	public KeyControl get_backquoteKey() { }

	public KeyControl get_backslashKey() { }

	public KeyControl get_backspaceKey() { }

	public KeyControl get_bKey() { }

	public KeyControl get_capsLockKey() { }

	public KeyControl get_cKey() { }

	public KeyControl get_commaKey() { }

	public KeyControl get_contextMenuKey() { }

	[CompilerGenerated]
	public ButtonControl get_ctrlKey() { }

	[CompilerGenerated]
	public static Keyboard get_current() { }

	public KeyControl get_deleteKey() { }

	public KeyControl get_digit0Key() { }

	public KeyControl get_digit1Key() { }

	public KeyControl get_digit2Key() { }

	public KeyControl get_digit3Key() { }

	public KeyControl get_digit4Key() { }

	public KeyControl get_digit5Key() { }

	public KeyControl get_digit6Key() { }

	public KeyControl get_digit7Key() { }

	public KeyControl get_digit8Key() { }

	public KeyControl get_digit9Key() { }

	public KeyControl get_dKey() { }

	public KeyControl get_downArrowKey() { }

	public KeyControl get_eKey() { }

	public KeyControl get_endKey() { }

	public KeyControl get_enterKey() { }

	public KeyControl get_equalsKey() { }

	public KeyControl get_escapeKey() { }

	public KeyControl get_f10Key() { }

	public KeyControl get_f11Key() { }

	public KeyControl get_f12Key() { }

	public KeyControl get_f13Key() { }

	public KeyControl get_f14Key() { }

	public KeyControl get_f15Key() { }

	public KeyControl get_f16Key() { }

	public KeyControl get_f17Key() { }

	public KeyControl get_f18Key() { }

	public KeyControl get_f19Key() { }

	public KeyControl get_f1Key() { }

	public KeyControl get_f20Key() { }

	public KeyControl get_f21Key() { }

	public KeyControl get_f22Key() { }

	public KeyControl get_f23Key() { }

	public KeyControl get_f24Key() { }

	public KeyControl get_f2Key() { }

	public KeyControl get_f3Key() { }

	public KeyControl get_f4Key() { }

	public KeyControl get_f5Key() { }

	public KeyControl get_f6Key() { }

	public KeyControl get_f7Key() { }

	public KeyControl get_f8Key() { }

	public KeyControl get_f9Key() { }

	public KeyControl get_fKey() { }

	public KeyControl get_gKey() { }

	public KeyControl get_hKey() { }

	public KeyControl get_homeKey() { }

	public KeyControl get_iKey() { }

	[CompilerGenerated]
	public ButtonControl get_imeSelected() { }

	public KeyControl get_insertKey() { }

	public KeyControl get_Item(Key key) { }

	public KeyControl get_jKey() { }

	public string get_keyboardLayout() { }

	protected KeyControl[] get_keys() { }

	public KeyControl get_kKey() { }

	public KeyControl get_leftAltKey() { }

	public KeyControl get_leftAppleKey() { }

	public KeyControl get_leftArrowKey() { }

	public KeyControl get_leftBracketKey() { }

	public KeyControl get_leftCommandKey() { }

	public KeyControl get_leftCtrlKey() { }

	public KeyControl get_leftMetaKey() { }

	public KeyControl get_leftShiftKey() { }

	public KeyControl get_leftWindowsKey() { }

	public KeyControl get_lKey() { }

	public KeyControl get_mediaForward() { }

	public KeyControl get_mediaPlayPause() { }

	public KeyControl get_mediaRewind() { }

	public KeyControl get_minusKey() { }

	public KeyControl get_mKey() { }

	public KeyControl get_nKey() { }

	public KeyControl get_numLockKey() { }

	public KeyControl get_numpad0Key() { }

	public KeyControl get_numpad1Key() { }

	public KeyControl get_numpad2Key() { }

	public KeyControl get_numpad3Key() { }

	public KeyControl get_numpad4Key() { }

	public KeyControl get_numpad5Key() { }

	public KeyControl get_numpad6Key() { }

	public KeyControl get_numpad7Key() { }

	public KeyControl get_numpad8Key() { }

	public KeyControl get_numpad9Key() { }

	public KeyControl get_numpadDivideKey() { }

	public KeyControl get_numpadEnterKey() { }

	public KeyControl get_numpadEqualsKey() { }

	public KeyControl get_numpadMinusKey() { }

	public KeyControl get_numpadMultiplyKey() { }

	public KeyControl get_numpadPeriodKey() { }

	public KeyControl get_numpadPlusKey() { }

	public KeyControl get_oem1Key() { }

	public KeyControl get_oem2Key() { }

	public KeyControl get_oem3Key() { }

	public KeyControl get_oem4Key() { }

	public KeyControl get_oem5Key() { }

	public KeyControl get_oKey() { }

	public KeyControl get_pageDownKey() { }

	public KeyControl get_pageUpKey() { }

	public KeyControl get_pauseKey() { }

	public KeyControl get_periodKey() { }

	public KeyControl get_pKey() { }

	public KeyControl get_printScreenKey() { }

	public KeyControl get_qKey() { }

	public KeyControl get_quoteKey() { }

	public KeyControl get_rightAltKey() { }

	public KeyControl get_rightAppleKey() { }

	public KeyControl get_rightArrowKey() { }

	public KeyControl get_rightBracketKey() { }

	public KeyControl get_rightCommandKey() { }

	public KeyControl get_rightCtrlKey() { }

	public KeyControl get_rightMetaKey() { }

	public KeyControl get_rightShiftKey() { }

	public KeyControl get_rightWindowsKey() { }

	public KeyControl get_rKey() { }

	public KeyControl get_scrollLockKey() { }

	public KeyControl get_semicolonKey() { }

	[CompilerGenerated]
	public ButtonControl get_shiftKey() { }

	public KeyControl get_sKey() { }

	public KeyControl get_slashKey() { }

	public KeyControl get_spaceKey() { }

	public KeyControl get_tabKey() { }

	public KeyControl get_tKey() { }

	public KeyControl get_uKey() { }

	public KeyControl get_upArrowKey() { }

	public KeyControl get_vKey() { }

	public KeyControl get_wKey() { }

	public KeyControl get_xKey() { }

	public KeyControl get_yKey() { }

	public KeyControl get_zKey() { }

	public virtual void MakeCurrent() { }

	public override void OnIMECompositionChanged(IMECompositionString compositionString) { }

	protected virtual void OnRemoved() { }

	public override void OnTextInput(char character) { }

	protected virtual void RefreshConfiguration() { }

	public void remove_onIMECompositionChange(Action<IMECompositionString> value) { }

	public void remove_onTextInput(Action<Char> value) { }

	[CompilerGenerated]
	protected void set_altKey(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_anyKey(AnyKeyControl value) { }

	[CompilerGenerated]
	protected void set_ctrlKey(ButtonControl value) { }

	[CompilerGenerated]
	private static void set_current(Keyboard value) { }

	[CompilerGenerated]
	protected void set_imeSelected(ButtonControl value) { }

	protected void set_keyboardLayout(string value) { }

	protected void set_keys(KeyControl[] value) { }

	[CompilerGenerated]
	protected void set_shiftKey(ButtonControl value) { }

	public void SetIMECursorPosition(Vector2 position) { }

	public void SetIMEEnabled(bool enabled) { }

	private override bool UnityEngine.InputSystem.LowLevel.IEventPreProcessor.PreProcessEvent(InputEventPtr currentEventPtr) { }

}

