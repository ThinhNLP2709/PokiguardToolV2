/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class ServerStateDebugOverlay : MonoBehaviour // TypeDefIndex: 1032
{
	// Fields
	[CompilerGenerated]
	private static ServerStateDebugOverlay _Instance_k__BackingField; // 0x00
	private UnityEngine.UI.Text _text; // 0x20
	private bool _visible; // 0x28

	// Properties
	public static ServerStateDebugOverlay Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018050AD10-0x000000018050AD50 0x000000018050AD50-0x000000018050ADB0

	// Constructors
	public ServerStateDebugOverlay(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void AutoInit(); // 0x00000001802EB6C0-0x00000001802EB6D0
	private void Awake(); // 0x0000000180509E90-0x000000018050A000
	private void Update(); // 0x000000018050AC30-0x000000018050AD10
	private void Refresh(); // 0x000000018050A510-0x000000018050AC30
	private void BuildUI(); // 0x000000018050A000-0x000000018050A510
}

