/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class HomeSettingsPopup : MonoBehaviour // TypeDefIndex: 991
{
	// Fields
	private const string KEY_MASTER = "MasterVolume"; // Metadata: 0x005F05A2
	private const string KEY_BGM = "BGMVolume"; // Metadata: 0x005F05AF
	private const string KEY_SFX = "SFXVolume"; // Metadata: 0x005F05B9
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
	private void Awake(); // 0x00000001805F0D00-0x00000001805F1310
	private void OnDestroy(); // 0x00000001805F1310-0x00000001805F18F0
	public void Open(); // 0x00000001805F18F0-0x00000001805F1A80
	public void Close(); // 0x00000001805F1A80-0x00000001805F1B60
	public void ForceHide(); // 0x00000001805F1B60-0x00000001805F1EA0
	private void OnBgmChanged(float v); // 0x00000001805F1EA0-0x00000001805F1FC0
	private void OnSfxChanged(float v); // 0x00000001805F1FC0-0x00000001805F21B0
	private void OnLogout(); // 0x00000001805F21B0-0x00000001805F22F0
	[CompilerGenerated]
	private void _Close_b__16_0(); // 0x00000001805F22F0-0x00000001805F2430
}

