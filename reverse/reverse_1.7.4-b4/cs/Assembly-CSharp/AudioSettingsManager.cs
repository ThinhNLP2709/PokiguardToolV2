/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class AudioSettingsManager : MonoBehaviour // TypeDefIndex: 599
{
	// Fields
	[Header("Volume Settings")]
	[Range(0f, 1f)]
	public float masterVolume; // 0x20
	[Range(0f, 1f)]
	public float bgmVolume; // 0x24
	[Range(0f, 1f)]
	public float sfxVolume; // 0x28
	private const string MASTER_VOLUME_KEY = "MasterVolume"; // Metadata: 0x005EF7E7
	private const string BGM_VOLUME_KEY = "BGMVolume"; // Metadata: 0x005EF7F4
	private const string SFX_VOLUME_KEY = "SFXVolume"; // Metadata: 0x005EF7FE

	// Constructors
	public AudioSettingsManager(); // 0x000000018042D810-0x000000018042D870

	// Methods
	private void Start(); // 0x000000018042D160-0x000000018042D180
	public void LoadSettings(); // 0x000000018042D180-0x000000018042D230
	public void SaveSettings(); // 0x000000018042D230-0x000000018042D310
	public void ApplySettingsToCurrentScene(); // 0x000000018042D310-0x000000018042D5B0
	public void SetMasterVolume(float volume); // 0x000000018042D5B0-0x000000018042D650
	public void SetBGMVolume(float volume); // 0x000000018042D650-0x000000018042D690
	public void SetSFXVolume(float volume); // 0x000000018042D690-0x000000018042D730
	public static AudioSettings GetSavedSettings(); // 0x000000018042D730-0x000000018042D810
}

