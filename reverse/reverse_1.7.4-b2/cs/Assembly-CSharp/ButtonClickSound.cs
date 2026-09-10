/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ButtonClickSound : MonoBehaviour, IPointerClickHandler // TypeDefIndex: 1777
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
	public ButtonClickSound(); // 0x0000000180691960-0x0000000180691970
	static ButtonClickSound(); // 0x0000000180691920-0x0000000180691960

	// Methods
	public static void EnsureShared(); // 0x0000000180691220-0x0000000180691450
	private static void OnSharedVolumeChanged(float _); // 0x00000001806916D0-0x0000000180691710
	public static void UpdateSharedVolume(); // 0x0000000180691850-0x0000000180691920
	public static void PlayStatic(); // 0x0000000180691750-0x0000000180691850
	private void Awake(); // 0x00000001806911A0-0x0000000180691220
	private void OnEnable(); // 0x00000001806914F0-0x0000000180691590
	private void OnDisable(); // 0x0000000180691450-0x00000001806914F0
	private void OnVolumeChanged(float newValue); // 0x0000000180691710-0x0000000180691750
	private void UpdateAudioSourceVolume(); // 0x0000000180691710-0x0000000180691750
	public void OnPointerClick(PointerEventData eventData); // 0x0000000180691590-0x00000001806916D0
}

