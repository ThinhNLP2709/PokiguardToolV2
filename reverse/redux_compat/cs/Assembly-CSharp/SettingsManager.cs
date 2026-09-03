/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class SettingsManager : MonoBehaviour // TypeDefIndex: 484
{
	// Fields
	[Header("Panels")]
	public GameObject panelSettings; // 0x20
	[Header("Buttons")]
	public Button btnOpenSettings; // 0x28
	public Button btnCloseSettings; // 0x30
	public Button btnLogout; // 0x38
	public Button btnChangePassword; // 0x40
	[Header("Volume Sliders")]
	public Slider sliderMasterVolume; // 0x48
	public Slider sliderBGMVolume; // 0x50
	public Slider sliderSFXVolume; // 0x58
	[Header("Volume Texts (Optional)")]
	public UnityEngine.UI.Text txtMasterVolume; // 0x60
	public UnityEngine.UI.Text txtBGMVolume; // 0x68
	public UnityEngine.UI.Text txtSFXVolume; // 0x70
	[Header("Confirm Logout Panel (Optional)")]
	public GameObject panelConfirmLogout; // 0x78
	public Button btnConfirmLogout; // 0x80
	public Button btnCancelLogout; // 0x88
	private AudioSettingsManager audioSettingsManager; // 0x90

	// Constructors
	public SettingsManager(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Start(); // 0x000000018036C5E0-0x000000018036CAE0
	public void OpenSettings(); // 0x000000018036C310-0x000000018036C3A0
	private void CloseSettings(); // 0x000000018036B250-0x000000018036B300
	private void LoadCurrentVolumes(); // 0x000000018036B800-0x000000018036B9F0
	private void OnMasterVolumeChanged(float value); // 0x000000018036BF30-0x000000018036C0C0
	private void OnBGMVolumeChanged(float value); // 0x000000018036B9F0-0x000000018036BAE0
	private void OnSFXVolumeChanged(float value); // 0x000000018036C0C0-0x000000018036C250
	private void UpdateVolumeText(UnityEngine.UI.Text textComponent, float value); // 0x000000018036CAE0-0x000000018036CBB0
	public void OpenChangePassword(); // 0x000000018036C250-0x000000018036C310
	private void EnsureChangePasswordButton(); // 0x000000018036B3B0-0x000000018036B800
	private static void SetButtonLabel(GameObject buttonGo, string label); // 0x000000018036C3A0-0x000000018036C4B0
	private void ShowLogoutConfirmation(); // 0x000000018036C4B0-0x000000018036C5E0
	private void CancelLogout(); // 0x000000018036ACE0-0x000000018036AD60
	private void ConfirmLogout(); // 0x000000018036B300-0x000000018036B3B0
	private void ClearAllUserData(); // 0x000000018036AD60-0x000000018036B250
	private void OnDestroy(); // 0x000000018036BAE0-0x000000018036BF30
}

