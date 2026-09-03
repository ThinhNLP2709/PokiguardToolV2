/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ButtonClickSound : MonoBehaviour, IPointerClickHandler // TypeDefIndex: 1514
{
	// Fields
	public static AudioClip clickSound; // 0x00
	public static AudioSource audioSource; // 0x08
	[Range(0f, 1f)]
	public float volume; // 0x20
	private Button button; // 0x28

	// Constructors
	public ButtonClickSound(); // 0x000000018056B590-0x000000018056B5A0

	// Methods
	private void Awake(); // 0x000000018056B0B0-0x000000018056B260
	private void OnEnable(); // 0x000000018056B300-0x000000018056B3A0
	private void OnDisable(); // 0x000000018056B260-0x000000018056B300
	private void OnVolumeChanged(float newValue); // 0x000000018056B4D0-0x000000018056B4E0
	private void UpdateAudioSourceVolume(); // 0x000000018056B4E0-0x000000018056B590
	public void OnPointerClick(PointerEventData eventData); // 0x000000018056B3A0-0x000000018056B4D0
}

