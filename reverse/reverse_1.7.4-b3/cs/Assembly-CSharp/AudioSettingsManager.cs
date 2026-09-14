/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class AudioSettingsManager : MonoBehaviour // TypeDefIndex: 598
{
	// Fields
	[Header("Volume Settings")]
	[Range(0f, 1f)]
	public float masterVolume; // 0x20
	[Range(0f, 1f)]
	public float bgmVolume; // 0x24
	[Range(0f, 1f)]
	public float sfxVolume; // 0x28
	private const string MASTER_VOLUME_KEY = "MasterVolume"; // Metadata: 0x005EE416
	private const string BGM_VOLUME_KEY = "BGMVolume"; // Metadata: 0x005EE423
	private const string SFX_VOLUME_KEY = "SFXVolume"; // Metadata: 0x005EE42D

	// Constructors
	public AudioSettingsManager(); // 0x000000018042C780-0x000000018042C7E0

	// Methods
	private void Start(); // 0x000000018042C0D0-0x000000018042C0F0
	public void LoadSettings(); // 0x000000018042C0F0-0x000000018042C1A0
	public void SaveSettings(); // 0x000000018042C1A0-0x000000018042C280
	public void ApplySettingsToCurrentScene(); // 0x000000018042C280-0x000000018042C520
	public void SetMasterVolume(float volume); // 0x000000018042C520-0x000000018042C5C0
	public void SetBGMVolume(float volume); // 0x000000018042C5C0-0x000000018042C600
	public void SetSFXVolume(float volume); // 0x000000018042C600-0x000000018042C6A0
	public static AudioSettings GetSavedSettings(); // 0x000000018042C6A0-0x000000018042C780
}

