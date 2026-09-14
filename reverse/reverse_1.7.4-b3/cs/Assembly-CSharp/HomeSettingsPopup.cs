/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class HomeSettingsPopup : MonoBehaviour // TypeDefIndex: 989
{
	// Fields
	private const string KEY_MASTER = "MasterVolume"; // Metadata: 0x005EF1D5
	private const string KEY_BGM = "BGMVolume"; // Metadata: 0x005EF1E2
	private const string KEY_SFX = "SFXVolume"; // Metadata: 0x005EF1EC
	[Tooltip("Node popup (node CON, kh\u00F4ng ph\u1EA3i object mang component n\u00E0y).")]
	public GameObject panel; // 0x20
	public GameObject dim; // 0x28
	public CanvasGroup canvasGroup; // 0x30
	public Button dimButton; // 0x38
	public Button closeButton; // 0x40
	public Button logoutButton; // 0x48
	public Slider bgmSlider; // 0x50
	public Slider sfxSlider; // 0x58
	[Tooltip("Ngu\u1ED3n nh\u1EA1c n\u1EC1n Home \u2014 ch\u1EC9nh slider l\u00E0 nghe th\u1EA5y ngay, kh\u00F4ng ph\u1EA3i ch\u1EDD v\u00E0o l\u1EA1i scene.")]
	public HomeAudio homeAudio; // 0x60
	private bool _open; // 0x68

	// Constructors
	public HomeSettingsPopup(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x00000001805EF310-0x00000001805EF920
	private void OnDestroy(); // 0x00000001805EF920-0x00000001805EFF00
	public void Open(); // 0x00000001805EFF00-0x00000001805F0090
	public void Close(); // 0x00000001805F0090-0x00000001805F0170
	public void ForceHide(); // 0x00000001805F0170-0x00000001805F04B0
	private void OnBgmChanged(float v); // 0x00000001805F04B0-0x00000001805F05D0
	private void OnSfxChanged(float v); // 0x00000001805F05D0-0x00000001805F07C0
	private void OnLogout(); // 0x00000001805F07C0-0x00000001805F0900
	[CompilerGenerated]
	private void _Close_b__16_0(); // 0x00000001805F0900-0x00000001805F0A40
}

