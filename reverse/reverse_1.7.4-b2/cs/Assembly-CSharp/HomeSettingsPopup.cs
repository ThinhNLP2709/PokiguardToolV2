/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class HomeSettingsPopup : MonoBehaviour // TypeDefIndex: 822
{
	// Fields
	private const string KEY_MASTER = "MasterVolume"; // Metadata: 0x0068BCAF
	private const string KEY_BGM = "BGMVolume"; // Metadata: 0x0068BCBC
	private const string KEY_SFX = "SFXVolume"; // Metadata: 0x0068BCC6
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
	public HomeSettingsPopup(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x0000000180499060-0x0000000180499490
	private void OnDestroy(); // 0x00000001804996A0-0x0000000180499920
	public void Open(); // 0x0000000180499AF0-0x0000000180499BB0
	public void Close(); // 0x0000000180499490-0x0000000180499550
	public void ForceHide(); // 0x0000000180499550-0x0000000180499610
	private void OnBgmChanged(float v); // 0x0000000180499610-0x00000001804996A0
	private void OnSfxChanged(float v); // 0x0000000180499A00-0x0000000180499AF0
	private void OnLogout(); // 0x0000000180499920-0x0000000180499A00
	[CompilerGenerated]
	private void _Close_b__16_0(); // 0x0000000180499BB0-0x0000000180499C30
}

