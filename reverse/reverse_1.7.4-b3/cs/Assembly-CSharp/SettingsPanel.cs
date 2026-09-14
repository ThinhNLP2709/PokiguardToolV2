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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class SettingsPanel : MonoBehaviour // TypeDefIndex: 1224
{
	// Fields
	public const string N_ROOT = "[SettingsPanel]"; // Metadata: 0x005EF593
	private const string KEY_MASTER = "MasterVolume"; // Metadata: 0x005EF5A3
	private const string KEY_BGM = "BGMVolume"; // Metadata: 0x005EF5B0
	private const string KEY_SFX = "SFXVolume"; // Metadata: 0x005EF5BA
	private const string KEY_BGM_LAST = "BGMVolume_last"; // Metadata: 0x005EF5C4
	private const string KEY_SFX_LAST = "SFXVolume_last"; // Metadata: 0x005EF5D3
	private const float DEFAULT_BGM = 0.5f; // Metadata: 0x005EF5E2
	private const float DEFAULT_SFX = 0.8f; // Metadata: 0x005EF5E6
	private const float OFF_THRESHOLD = 0.01f; // Metadata: 0x005EF5EA
	private const int SORT_ORDER = 400; // Metadata: 0x005EF5EE
	private const float CARD_W = 800f; // Metadata: 0x005EF5F0
	private const float CARD_H = 720f; // Metadata: 0x005EF5F4
	private const float CARD_Y = 118f; // Metadata: 0x005EF5F8
	private const float CARD_L_X = 64f; // Metadata: 0x005EF5FC
	private const float CARD_R_X = 910f; // Metadata: 0x005EF600
	private const float PAD = 36f; // Metadata: 0x005EF604
	private const float INNER_W = 728f; // Metadata: 0x005EF608
	private const float APPLY_INTERVAL = 0.05f; // Metadata: 0x005EF60C
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
	private const string InfoPlayerLayoutRoot = "InfoRoot"; // Metadata: 0x005EF610

	// Properties
	public static bool IsOpen { get; } // 0x00000001806DF330-0x00000001806DF560 
	private static Color DividerColor { get; } // 0x00000001806E22E0-0x00000001806E2360 

	// Nested types
	[Serializable]
	private class EmailStatusDTO // TypeDefIndex: 1225
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
	private sealed class __c // TypeDefIndex: 1226
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__74_1; // 0x08

		// Constructors
		static __c(); // 0x00000001806E7D80-0x00000001806E7E20
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RefreshEmailStatus_b__74_1(string _); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass68_0 // TypeDefIndex: 1227
	{
		// Fields
		public Slider capturedSlider; // 0x10
		public SettingsPanel __4__this; // 0x18

		// Constructors
		public __c__DisplayClass68_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildVolumeRow_b__0(); // 0x00000001806E7E20-0x00000001806E7E90
		internal void _BuildVolumeRow_b__1(); // 0x00000001806E7E90-0x00000001806E7F80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass74_0 // TypeDefIndex: 1228
	{
		// Fields
		public SettingsPanel __4__this; // 0x10
		public SettingsConfig.StringsCfg s; // 0x18

		// Constructors
		public __c__DisplayClass74_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RefreshEmailStatus_b__0(EmailStatusDTO res); // 0x00000001806E7F80-0x00000001806E81C0
	}

	// Constructors
	public SettingsPanel(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static void Open(); // 0x00000001806DF560-0x00000001806DFAA0
	public static void CloseIfOpen(); // 0x00000001806DFAA0-0x00000001806DFBC0
	public void Close(); // 0x00000001806DFBC0-0x00000001806E0140
	private void SetShown(bool on); // 0x00000001806E0140-0x00000001806E0550
	private void OnDestroy(); // 0x00000001806E0550-0x00000001806E0780
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x00000001806E0780-0x00000001806E0790
	private static SettingsPanel Build(long configVersion); // 0x00000001806E0790-0x00000001806E0EC0
	private void BuildBody(RectTransform root); // 0x00000001806E0EC0-0x00000001806E1880
	private void BuildLeftColumn(RectTransform card, SettingsConfig.StringsCfg s); // 0x00000001806E1880-0x00000001806E22E0
	private UnityEngine.UI.Text Section(RectTransform card, string name, float y, string label); // 0x00000001806E2360-0x00000001806E24A0
	private Slider BuildVolumeRow(RectTransform card, float y, string rowName, string suffix, string label, string iconSprite, string key, float def, out UnityEngine.UI.Text value, out Button mute); // 0x00000001806E24A0-0x00000001806E2CC0
	private void BuildBusyRow(RectTransform card, SettingsConfig.StringsCfg s); // 0x00000001806E2CC0-0x00000001806E31A0
	private void BuildRightColumn(RectTransform card, SettingsConfig.StringsCfg s); // 0x00000001806E31A0-0x00000001806E3EC0
	private GameObject BuildValueRow(RectTransform card, float y, string rowName, string suffix, string label, string value, string button, Color valueColor, UnityAction onTap, out UnityEngine.UI.Text valueText); // 0x00000001806E3EC0-0x00000001806E4360
	private void BuildDialogs(); // 0x00000001806E4360-0x00000001806E4850
	private void Refresh(); // 0x00000001806E4850-0x00000001806E5880
	private void RefreshEmailStatus(SettingsConfig.StringsCfg s); // 0x00000001806E5880-0x00000001806E5DD0
	private static int ReadCost(); // 0x00000001806E5DD0-0x00000001806E5F30
	private static string Percent(float v); // 0x00000001806E5F30-0x00000001806E6000
	private void SetVolumeVisual(UnityEngine.UI.Text value, Button mute, float v, bool animate); // 0x00000001806E6000-0x00000001806E63B0
	private void OnBgmChanged(float v); // 0x00000001806E63B0-0x00000001806E6420
	private void OnSfxChanged(float v); // 0x00000001806E6420-0x00000001806E6490
	private void OnVolumeChanged(string key, float v, UnityEngine.UI.Text value, Button mute); // 0x00000001806E6490-0x00000001806E6510
	private void ApplyAudio(bool force); // 0x00000001806E6510-0x00000001806E6790
	private void FlushPrefs(); // 0x00000001806E6790-0x00000001806E67F0
	private void ToggleMute(string key, string lastKey, float def, Slider sld, UnityEngine.UI.Text value, Button mute); // 0x00000001806E67F0-0x00000001806E6A20
	private void OnBusyTap(); // 0x00000001806E6A20-0x00000001806E6C20
	private void SetBusyVisual(bool on, bool animate); // 0x00000001806E6C20-0x00000001806E6EF0
	private void OnTerms(); // 0x00000001806E6EF0-0x00000001806E6F10
	private void OnSupport(); // 0x00000001806E6F10-0x00000001806E7170
	private void OnPassword(); // 0x00000001806E7170-0x00000001806E7230
	private void OnProtect(); // 0x00000001806E7230-0x00000001806E72F0
	private void OnCopyId(); // 0x00000001806E72F0-0x00000001806E74E0
	private void OnRename(); // 0x00000001806E74E0-0x00000001806E7750
	private void OnRenamed(string newName); // 0x00000001806E7750-0x00000001806E78E0
	private void OnLogout(); // 0x00000001806E78E0-0x00000001806E79F0
	private void LateWire(); // 0x00000001806E79F0-0x00000001806E7C60
	[CompilerGenerated]
	private void _LateWire_b__95_0(); // 0x00000001806E7C60-0x00000001806E7CF0
	[CompilerGenerated]
	private void _LateWire_b__95_1(); // 0x00000001806E7CF0-0x00000001806E7D80
}

