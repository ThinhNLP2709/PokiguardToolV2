/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

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
	public static VoiceChatManager Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180480E00-0x0000000180480E40 0x0000000180480E40-0x0000000180480EE0
	public bool IsMicOn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180480EE0-0x0000000180480EF0 0x0000000180480EF0-0x0000000180480F00
	public bool IsSpeakerOn { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180480F00-0x0000000180480F10 0x0000000180480F10-0x0000000180480F20
	public bool IsVoiceActive { get; } // 0x000000018028A030-0x000000018028A040 

	// Events
	public event Action<bool> OnMicChanged {
		add; // 0x0000000180480F20-0x0000000180481040
		remove; // 0x0000000180481040-0x0000000180481160
	}
	public event Action<bool> OnSpeakerChanged {
		add; // 0x0000000180481160-0x0000000180481280
		remove; // 0x0000000180481280-0x00000001804813A0
	}
	public event Action<int, bool> OnRemotePlayerSpeaking {
		add; // 0x00000001804813A0-0x00000001804814C0
		remove; // 0x00000001804814C0-0x00000001804815E0
	}

	// Constructors
	public VoiceChatManager(); // 0x0000000180481BA0-0x0000000180481BF0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoCreate(); // 0x00000001804815E0-0x0000000180481760
	private void Awake(); // 0x0000000180481760-0x00000001804819D0
	private void OnDestroy(); // 0x00000001804819D0-0x0000000180481B30
	public void SetMic(bool on); // 0x0000000180481B30-0x0000000180481B50
	public void SetSpeaker(bool on); // 0x0000000180481B50-0x0000000180481B70
	public void ToggleMic(); // 0x0000000180481B30-0x0000000180481B50
	public void ToggleSpeaker(); // 0x0000000180481B70-0x0000000180481BA0
	private void OnValidate(); // 0x000000018028A320-0x000000018028A330
}

