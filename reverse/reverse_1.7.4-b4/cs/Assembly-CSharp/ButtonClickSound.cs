/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ButtonClickSound : MonoBehaviour, IPointerClickHandler // TypeDefIndex: 2142
{
	// Fields
	public static AudioClip clickSound; // 0x00
	public static AudioSource audioSource; // 0x08
	public static float staticVolume; // 0x10
	[Range(0f, 1f)]
	public float volume; // 0x20
	private Button button; // 0x28
	private static bool _sharedSubscribed; // 0x14

	// Constructors
	public ButtonClickSound(); // 0x0000000180A1C7A0-0x0000000180A1C7F0
	static ButtonClickSound(); // 0x0000000180A1C7F0-0x0000000180A1C840

	// Methods
	public static void EnsureShared(); // 0x0000000180A1B8B0-0x0000000180A1BCB0
	private static void OnSharedVolumeChanged(float _); // 0x0000000180A1BCB0-0x0000000180A1BD00
	public static void UpdateSharedVolume(); // 0x0000000180A1BD00-0x0000000180A1BEA0
	public static void PlayStatic(); // 0x0000000180A1BEA0-0x0000000180A1C120
	private void Awake(); // 0x0000000180A1C120-0x0000000180A1C1F0
	private void OnEnable(); // 0x0000000180A1C1F0-0x0000000180A1C2A0
	private void OnDisable(); // 0x0000000180A1C2A0-0x0000000180A1C470
	private void OnVolumeChanged(float newValue); // 0x0000000180A1C470-0x0000000180A1C4C0
	private void UpdateAudioSourceVolume(); // 0x0000000180A1C470-0x0000000180A1C4C0
	public void OnPointerClick(PointerEventData eventData); // 0x0000000180A1C4C0-0x0000000180A1C7A0
}

