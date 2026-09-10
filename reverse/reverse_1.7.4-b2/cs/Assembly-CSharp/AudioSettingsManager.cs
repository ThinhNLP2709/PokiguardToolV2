/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class AudioSettingsManager : MonoBehaviour // TypeDefIndex: 545
{
	// Fields
	[Header("Volume Settings")]
	[Range(0f, 1f)]
	public float masterVolume; // 0x20
	[Range(0f, 1f)]
	public float bgmVolume; // 0x24
	[Range(0f, 1f)]
	public float sfxVolume; // 0x28
	private const string MASTER_VOLUME_KEY = "MasterVolume"; // Metadata: 0x0068B64A
	private const string BGM_VOLUME_KEY = "BGMVolume"; // Metadata: 0x0068B657
	private const string SFX_VOLUME_KEY = "SFXVolume"; // Metadata: 0x0068B661

	// Constructors
	public AudioSettingsManager(); // 0x00000001803C4160-0x00000001803C4180

	// Methods
	private void Start(); // 0x00000001803C40C0-0x00000001803C4160
	public void LoadSettings(); // 0x00000001803C3E30-0x00000001803C3ED0
	public void SaveSettings(); // 0x00000001803C3ED0-0x00000001803C3F60
	public void ApplySettingsToCurrentScene(); // 0x00000001803C3C20-0x00000001803C3D60
	public void SetMasterVolume(float volume); // 0x00000001803C3FA0-0x00000001803C4030
	public void SetBGMVolume(float volume); // 0x00000001803C3F60-0x00000001803C3FA0
	public void SetSFXVolume(float volume); // 0x00000001803C4030-0x00000001803C40C0
	public static AudioSettings GetSavedSettings(); // 0x00000001803C3D60-0x00000001803C3E30
}

