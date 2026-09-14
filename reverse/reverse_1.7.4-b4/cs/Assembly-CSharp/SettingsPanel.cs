/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome.InfoPlayer;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class SettingsPanel : MonoBehaviour // TypeDefIndex: 1226
{
	// Fields
	public const string N_ROOT = "[SettingsPanel]"; // Metadata: 0x005F0960
	private const string KEY_MASTER = "MasterVolume"; // Metadata: 0x005F0970
	private const string KEY_BGM = "BGMVolume"; // Metadata: 0x005F097D
	private const string KEY_SFX = "SFXVolume"; // Metadata: 0x005F0987
	private const string KEY_BGM_LAST = "BGMVolume_last"; // Metadata: 0x005F0991
	private const string KEY_SFX_LAST = "SFXVolume_last"; // Metadata: 0x005F09A0
	private const float DEFAULT_BGM = 0.5f; // Metadata: 0x005F09AF
	private const float DEFAULT_SFX = 0.8f; // Metadata: 0x005F09B3
	private const float OFF_THRESHOLD = 0.01f; // Metadata: 0x005F09B7
	private const int SORT_ORDER = 400; // Metadata: 0x005F09BB
	private const float CARD_W = 800f; // Metadata: 0x005F09BD
	private const float CARD_H = 720f; // Metadata: 0x005F09C1
	private const float CARD_Y = 118f; // Metadata: 0x005F09C5
	private const float CARD_L_X = 64f; // Metadata: 0x005F09C9
	private const float CARD_R_X = 910f; // Metadata: 0x005F09CD
	private const float PAD = 36f; // Metadata: 0x005F09D1
	private const float INNER_W = 728f; // Metadata: 0x005F09D5
	private const float APPLY_INTERVAL = 0.05f; // Metadata: 0x005F09D9
	private static SettingsPanel _instance; // 0x00
	private Canvas _canvas; // 0x20
	private GraphicRaycaster _raycaster; // 0x28
	private CanvasGroup _group; // 0x30
	private RectTransform _content; // 0x38
	private InfoPlayerBackdrop _backdrop; // 0x40
	private Slider _sldBgm; // 0x48
	private Slider _sldSfx; // 0x50
	private UnityEngine.UI.Text _txtBgmValue; // 0x58
	private UnityEngine.UI.Text _txtSfxValue; // 0x60
	private Button _btnBgmMute; // 0x68
	private Button _btnSfxMute; // 0x70
	private AudioSettingsManager _audioMgr; // 0x78
	private float _lastApplyAt; // 0x80
	private bool _prefsDirty; // 0x84
	private GameObject _rowBusy; // 0x88
	private Image _busyBg; // 0x90
	private RectTransform _busyKnob; // 0x98
	private GameObject _rowName; // 0xA0
	private GameObject _rowPassword; // 0xA8
	private GameObject _rowUserId; // 0xB0
	private GameObject _rowProtect; // 0xB8
	private UnityEngine.UI.Text _txtName; // 0xC0
	private UnityEngine.UI.Text _txtUserId; // 0xC8
	private UnityEngine.UI.Text _txtRenameCost; // 0xD0
	private UnityEngine.UI.Text _txtProtect; // 0xD8
	private Button _btnRename; // 0xE0
	private GameObject _btnTermsGo; // 0xE8
	private GameObject _btnSupportGo; // 0xF0
	private GameObject _txtVersionGo; // 0xF8
	private SettingsRenamePopup _rename; // 0x100
	private SettingsLogoutConfirm _logout; // 0x108
	private long _builtConfigVersion; // 0x110
	private int _userId; // 0x118
	private int _gold; // 0x11C
	private const string InfoPlayerLayoutRoot = "InfoRoot"; // Metadata: 0x005F09DD

	// Properties
	public static bool IsOpen { get; } // 0x00000001806E0FA0-0x00000001806E11D0 
	private static Color DividerColor { get; } // 0x00000001806E3F50-0x00000001806E3FD0 

	// Nested types
	[Serializable]
	private class EmailStatusDTO // TypeDefIndex: 1227
	{
		// Fields
		public bool success; // 0x10
		public bool linked; // 0x11
		public string emailMask; // 0x18

		// Constructors
		public EmailStatusDTO(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1228
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__74_1; // 0x08

		// Constructors
		static __c(); // 0x00000001806E9A10-0x00000001806E9AB0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RefreshEmailStatus_b__74_1(string _); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass68_0 // TypeDefIndex: 1229
	{
		// Fields
		public Slider capturedSlider; // 0x10
		public SettingsPanel __4__this; // 0x18

		// Constructors
		public __c__DisplayClass68_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildVolumeRow_b__0(); // 0x00000001806E9AB0-0x00000001806E9B20
		internal void _BuildVolumeRow_b__1(); // 0x00000001806E9B20-0x00000001806E9C10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass74_0 // TypeDefIndex: 1230
	{
		// Fields
		public SettingsPanel __4__this; // 0x10
		public SettingsConfig.StringsCfg s; // 0x18

		// Constructors
		public __c__DisplayClass74_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RefreshEmailStatus_b__0(EmailStatusDTO res); // 0x00000001806E9C10-0x00000001806E9E50
	}

	// Constructors
	public SettingsPanel(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static void Open(); // 0x00000001806E11D0-0x00000001806E1710
	public static void CloseIfOpen(); // 0x00000001806E1710-0x00000001806E1830
	public void Close(); // 0x00000001806E1830-0x00000001806E1DB0
	private void SetShown(bool on); // 0x00000001806E1DB0-0x00000001806E21C0
	private void OnDestroy(); // 0x00000001806E21C0-0x00000001806E23F0
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x00000001806E23F0-0x00000001806E2400
	private static SettingsPanel Build(long configVersion); // 0x00000001806E2400-0x00000001806E2B30
	private void BuildBody(RectTransform root); // 0x00000001806E2B30-0x00000001806E34F0
	private void BuildLeftColumn(RectTransform card, SettingsConfig.StringsCfg s); // 0x00000001806E34F0-0x00000001806E3F50
	private UnityEngine.UI.Text Section(RectTransform card, string name, float y, string label); // 0x00000001806E3FD0-0x00000001806E4110
	private Slider BuildVolumeRow(RectTransform card, float y, string rowName, string suffix, string label, string iconSprite, string key, float def, out UnityEngine.UI.Text value, out Button mute); // 0x00000001806E4110-0x00000001806E4930
	private void BuildBusyRow(RectTransform card, SettingsConfig.StringsCfg s); // 0x00000001806E4930-0x00000001806E4E10
	private void BuildRightColumn(RectTransform card, SettingsConfig.StringsCfg s); // 0x00000001806E4E10-0x00000001806E5B30
	private GameObject BuildValueRow(RectTransform card, float y, string rowName, string suffix, string label, string value, string button, Color valueColor, UnityAction onTap, out UnityEngine.UI.Text valueText); // 0x00000001806E5B30-0x00000001806E5FD0
	private void BuildDialogs(); // 0x00000001806E5FD0-0x00000001806E64C0
	private void Refresh(); // 0x00000001806E64C0-0x00000001806E74F0
	private void RefreshEmailStatus(SettingsConfig.StringsCfg s); // 0x00000001806E74F0-0x00000001806E7A60
	private static int ReadCost(); // 0x00000001806E7A60-0x00000001806E7BC0
	private static string Percent(float v); // 0x00000001806E7BC0-0x00000001806E7C90
	private void SetVolumeVisual(UnityEngine.UI.Text value, Button mute, float v, bool animate); // 0x00000001806E7C90-0x00000001806E8040
	private void OnBgmChanged(float v); // 0x00000001806E8040-0x00000001806E80B0
	private void OnSfxChanged(float v); // 0x00000001806E80B0-0x00000001806E8120
	private void OnVolumeChanged(string key, float v, UnityEngine.UI.Text value, Button mute); // 0x00000001806E8120-0x00000001806E81A0
	private void ApplyAudio(bool force); // 0x00000001806E81A0-0x00000001806E8420
	private void FlushPrefs(); // 0x00000001806E8420-0x00000001806E8480
	private void ToggleMute(string key, string lastKey, float def, Slider sld, UnityEngine.UI.Text value, Button mute); // 0x00000001806E8480-0x00000001806E86B0
	private void OnBusyTap(); // 0x00000001806E86B0-0x00000001806E88B0
	private void SetBusyVisual(bool on, bool animate); // 0x00000001806E88B0-0x00000001806E8B80
	private void OnTerms(); // 0x00000001806E8B80-0x00000001806E8BA0
	private void OnSupport(); // 0x00000001806E8BA0-0x00000001806E8E00
	private void OnPassword(); // 0x00000001806E8E00-0x00000001806E8EC0
	private void OnProtect(); // 0x00000001806E8EC0-0x00000001806E8F80
	private void OnCopyId(); // 0x00000001806E8F80-0x00000001806E9170
	private void OnRename(); // 0x00000001806E9170-0x00000001806E93E0
	private void OnRenamed(string newName); // 0x00000001806E93E0-0x00000001806E9570
	private void OnLogout(); // 0x00000001806E9570-0x00000001806E9680
	private void LateWire(); // 0x00000001806E9680-0x00000001806E98F0
	[CompilerGenerated]
	private void _LateWire_b__95_0(); // 0x00000001806E98F0-0x00000001806E9980
	[CompilerGenerated]
	private void _LateWire_b__95_1(); // 0x00000001806E9980-0x00000001806E9A10
}

