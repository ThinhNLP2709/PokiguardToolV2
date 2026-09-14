/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class ServerStateDebugOverlay : MonoBehaviour // TypeDefIndex: 1410
{
	// Fields
	[CompilerGenerated]
	private static ServerStateDebugOverlay _Instance_k__BackingField; // 0x00
	private UnityEngine.UI.Text _text; // 0x20
	private bool _visible; // 0x28

	// Properties
	public static ServerStateDebugOverlay Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180796250-0x0000000180796290 0x0000000180796290-0x0000000180796330

	// Constructors
	public ServerStateDebugOverlay(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void AutoInit(); // 0x000000018028A320-0x000000018028A330
	private void Awake(); // 0x0000000180796330-0x0000000180796690
	private void Update(); // 0x0000000180796690-0x0000000180796850
	private void Refresh(); // 0x0000000180796850-0x0000000180797230
	private void BuildUI(); // 0x0000000180797230-0x0000000180797AD0
}

