/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class VoiceChatManager : MonoBehaviour // TypeDefIndex: 91
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
	public static VoiceChatManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018047FB90-0x000000018047FBD0 0x000000018047FBD0-0x000000018047FC70
	public bool IsMicOn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018047FC70-0x000000018047FC80 0x000000018047FC80-0x000000018047FC90
	public bool IsSpeakerOn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018047FC90-0x000000018047FCA0 0x000000018047FCA0-0x000000018047FCB0
	public bool IsVoiceActive { get; } // 0x000000018028A030-0x000000018028A040 

	// Events
	public event Action<bool> OnMicChanged {
		add; // 0x000000018047FCB0-0x000000018047FDD0
		remove; // 0x000000018047FDD0-0x000000018047FEF0
	}
	public event Action<bool> OnSpeakerChanged {
		add; // 0x000000018047FEF0-0x0000000180480010
		remove; // 0x0000000180480010-0x0000000180480130
	}
	public event Action<int, bool> OnRemotePlayerSpeaking {
		add; // 0x0000000180480130-0x0000000180480250
		remove; // 0x0000000180480250-0x0000000180480370
	}

	// Constructors
	public VoiceChatManager(); // 0x0000000180480930-0x0000000180480980

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoCreate(); // 0x0000000180480370-0x00000001804804F0
	private void Awake(); // 0x00000001804804F0-0x0000000180480760
	private void OnDestroy(); // 0x0000000180480760-0x00000001804808C0
	public void SetMic(bool on); // 0x00000001804808C0-0x00000001804808E0
	public void SetSpeaker(bool on); // 0x00000001804808E0-0x0000000180480900
	public void ToggleMic(); // 0x00000001804808C0-0x00000001804808E0
	public void ToggleSpeaker(); // 0x0000000180480900-0x0000000180480930
	private void OnValidate(); // 0x000000018028A320-0x000000018028A330
}

