/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class VoiceChatManager : MonoBehaviour // TypeDefIndex: 80
{
	// Fields
	[CompilerGenerated]
	private static VoiceChatManager _Instance_k__BackingField; // 0x00
	[HideInInspector]
	public bool debugEchoMode; // 0x20
	[HideInInspector]
	public bool debugLogMicLevel; // 0x21
	[HideInInspector]
	[Range(0f, 1f)]
	public float debugMicLevelThreshold; // 0x24
	[HideInInspector]
	public bool debugLogRemoteSpeaking; // 0x28
	[CompilerGenerated]
	private bool _IsMicOn_k__BackingField; // 0x29
	[CompilerGenerated]
	private bool _IsSpeakerOn_k__BackingField; // 0x2A
	[CompilerGenerated]
	private Action<bool> OnMicChanged; // 0x30
	[CompilerGenerated]
	private Action<bool> OnSpeakerChanged; // 0x38
	[CompilerGenerated]
	private Action<int, bool> OnRemotePlayerSpeaking; // 0x40

	// Properties
	public static VoiceChatManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018052D4C0-0x000000018052D500 0x000000018052D760-0x000000018052D7C0
	public bool IsMicOn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018052D500-0x000000018052D510 0x000000018052D7C0-0x000000018052D7D0
	public bool IsSpeakerOn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018052D510-0x000000018052D520 0x000000018052D7D0-0x000000018052D910
	public bool IsVoiceActive { get; } // 0x00000001802E7840-0x00000001802E7850 

	// Events
	public event Action<bool> OnMicChanged {
		add; // 0x000000018052D280-0x000000018052D340
		remove; // 0x000000018052D520-0x000000018052D5E0
	}
	public event Action<bool> OnSpeakerChanged {
		add; // 0x000000018052D400-0x000000018052D4C0
		remove; // 0x000000018052D6A0-0x000000018052D760
	}
	public event Action<int, bool> OnRemotePlayerSpeaking {
		add; // 0x000000018052D340-0x000000018052D400
		remove; // 0x000000018052D5E0-0x000000018052D6A0
	}

	// Constructors
	public VoiceChatManager(); // 0x000000018052D260-0x000000018052D280

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoCreate(); // 0x000000018052CF00-0x000000018052CFE0
	private void Awake(); // 0x000000018052CFE0-0x000000018052D120
	private void OnDestroy(); // 0x000000018052D120-0x000000018052D1F0
	public void SetMic(bool on); // 0x000000018052D1F0-0x000000018052D210
	public void SetSpeaker(bool on); // 0x000000018052D210-0x000000018052D230
	public void ToggleMic(); // 0x000000018052D1F0-0x000000018052D210
	public void ToggleSpeaker(); // 0x000000018052D230-0x000000018052D260
	public void EnsureVoiceReady(); // 0x00000001802E76C0-0x00000001802E76D0
	public void RefreshRemoteSpeakers(); // 0x00000001802E76C0-0x00000001802E76D0
	private void OnValidate(); // 0x00000001802E76C0-0x00000001802E76D0
}

