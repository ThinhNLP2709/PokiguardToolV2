/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ButtonClickSound : MonoBehaviour, IPointerClickHandler // TypeDefIndex: 2140
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
	public ButtonClickSound(); // 0x0000000180A18BB0-0x0000000180A18C00
	static ButtonClickSound(); // 0x0000000180A18C00-0x0000000180A18C50

	// Methods
	public static void EnsureShared(); // 0x0000000180A17CC0-0x0000000180A180C0
	private static void OnSharedVolumeChanged(float _); // 0x0000000180A180C0-0x0000000180A18110
	public static void UpdateSharedVolume(); // 0x0000000180A18110-0x0000000180A182B0
	public static void PlayStatic(); // 0x0000000180A182B0-0x0000000180A18530
	private void Awake(); // 0x0000000180A18530-0x0000000180A18600
	private void OnEnable(); // 0x0000000180A18600-0x0000000180A186B0
	private void OnDisable(); // 0x0000000180A186B0-0x0000000180A18880
	private void OnVolumeChanged(float newValue); // 0x0000000180A18880-0x0000000180A188D0
	private void UpdateAudioSourceVolume(); // 0x0000000180A18880-0x0000000180A188D0
	public void OnPointerClick(PointerEventData eventData); // 0x0000000180A188D0-0x0000000180A18BB0
}

