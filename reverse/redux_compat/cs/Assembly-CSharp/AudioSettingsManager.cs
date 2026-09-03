/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class AudioSettingsManager : MonoBehaviour // TypeDefIndex: 457
{
	// Fields
	[Header("Volume Settings")]
	[Range(0f, 1f)]
	public float masterVolume; // 0x20
	[Range(0f, 1f)]
	public float bgmVolume; // 0x24
	[Range(0f, 1f)]
	public float sfxVolume; // 0x28
	private const string MASTER_VOLUME_KEY = "MasterVolume"; // Metadata: 0x0064C495
	private const string BGM_VOLUME_KEY = "BGMVolume"; // Metadata: 0x0064C4A2
	private const string SFX_VOLUME_KEY = "SFXVolume"; // Metadata: 0x0064C4AC

	// Constructors
	public AudioSettingsManager(); // 0x000000018035D100-0x000000018035D120

	// Methods
	private void Start(); // 0x000000018035D060-0x000000018035D100
	public void LoadSettings(); // 0x000000018035CDD0-0x000000018035CE70
	public void SaveSettings(); // 0x000000018035CE70-0x000000018035CF00
	public void ApplySettingsToCurrentScene(); // 0x000000018035CBC0-0x000000018035CD00
	public void SetMasterVolume(float volume); // 0x000000018035CF40-0x000000018035CFD0
	public void SetBGMVolume(float volume); // 0x000000018035CF00-0x000000018035CF40
	public void SetSFXVolume(float volume); // 0x000000018035CFD0-0x000000018035D060
	public static AudioSettings GetSavedSettings(); // 0x000000018035CD00-0x000000018035CDD0
}

