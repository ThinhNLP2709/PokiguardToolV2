/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class ServerStateDebugOverlay : MonoBehaviour // TypeDefIndex: 836
{
	// Fields
	[CompilerGenerated]
	private static ServerStateDebugOverlay _Instance_k__BackingField; // 0x00
	private UnityEngine.UI.Text _text; // 0x20
	private bool _visible; // 0x28

	// Properties
	public static ServerStateDebugOverlay Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018042FF50-0x000000018042FF90 0x000000018042FF90-0x000000018042FFF0

	// Constructors
	public ServerStateDebugOverlay(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void AutoInit(); // 0x00000001802E76C0-0x00000001802E76D0
	private void Awake(); // 0x000000018042F0D0-0x000000018042F240
	private void Update(); // 0x000000018042FE70-0x000000018042FF50
	private void Refresh(); // 0x000000018042F750-0x000000018042FE70
	private void BuildUI(); // 0x000000018042F240-0x000000018042F750
}

