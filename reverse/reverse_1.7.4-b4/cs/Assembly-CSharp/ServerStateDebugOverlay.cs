/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class ServerStateDebugOverlay : MonoBehaviour // TypeDefIndex: 1412
{
	// Fields
	[CompilerGenerated]
	private static ServerStateDebugOverlay _Instance_k__BackingField; // 0x00
	private UnityEngine.UI.Text _text; // 0x20
	private bool _visible; // 0x28

	// Properties
	public static ServerStateDebugOverlay Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807982C0-0x0000000180798300 0x0000000180798300-0x00000001807983A0

	// Constructors
	public ServerStateDebugOverlay(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void AutoInit(); // 0x000000018028A320-0x000000018028A330
	private void Awake(); // 0x00000001807983A0-0x0000000180798700
	private void Update(); // 0x0000000180798700-0x00000001807988C0
	private void Refresh(); // 0x00000001807988C0-0x00000001807992A0
	private void BuildUI(); // 0x00000001807992A0-0x0000000180799B40
}

