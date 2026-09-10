/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

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
	public static VoiceChatManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018042A1E0-0x000000018042A220 0x000000018042A480-0x000000018042A4E0
	public bool IsMicOn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018042A220-0x000000018042A230 0x000000018042A4E0-0x000000018042A4F0
	public bool IsSpeakerOn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018042A230-0x000000018042A240 0x000000018042A4F0-0x000000018042A500
	public bool IsVoiceActive { get; } // 0x00000001802EB840-0x00000001802EB850 

	// Events
	public event Action<bool> OnMicChanged {
		add; // 0x0000000180429FA0-0x000000018042A060
		remove; // 0x000000018042A240-0x000000018042A300
	}
	public event Action<bool> OnSpeakerChanged {
		add; // 0x000000018042A120-0x000000018042A1E0
		remove; // 0x000000018042A3C0-0x000000018042A480
	}
	public event Action<int, bool> OnRemotePlayerSpeaking {
		add; // 0x000000018042A060-0x000000018042A120
		remove; // 0x000000018042A300-0x000000018042A3C0
	}

	// Constructors
	public VoiceChatManager(); // 0x0000000180429F80-0x0000000180429FA0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoCreate(); // 0x0000000180429C20-0x0000000180429D00
	private void Awake(); // 0x0000000180429D00-0x0000000180429E40
	private void OnDestroy(); // 0x0000000180429E40-0x0000000180429F10
	public void SetMic(bool on); // 0x0000000180429F10-0x0000000180429F30
	public void SetSpeaker(bool on); // 0x0000000180429F30-0x0000000180429F50
	public void ToggleMic(); // 0x0000000180429F10-0x0000000180429F30
	public void ToggleSpeaker(); // 0x0000000180429F50-0x0000000180429F80
	public void EnsureVoiceReady(); // 0x00000001802EB6C0-0x00000001802EB6D0
	public void RefreshRemoteSpeakers(); // 0x00000001802EB6C0-0x00000001802EB6D0
	private void OnValidate(); // 0x00000001802EB6C0-0x00000001802EB6D0
}

