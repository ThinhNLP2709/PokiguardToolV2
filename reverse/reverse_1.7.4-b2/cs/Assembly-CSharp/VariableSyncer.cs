/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class VariableSyncer : MonoBehaviour // TypeDefIndex: 262
{
	// Fields
	[Header("Ngu\u1ED3n & \u0110\u00EDch")]
	public MonoBehaviour sourceScript; // 0x20
	public MonoBehaviour targetScript; // 0x28
	[Header("Tu\u1EF3 ch\u1ECDn")]
	[Tooltip("Ch\u1EC9 sync c\u00E1c field \u0111\u01B0\u1EE3c \u0111\u00E1nh d\u1EA5u [SyncVariable]")]
	public bool useAttributeFilter; // 0x30
	[Tooltip("B\u1ECF qua n\u1EBFu ki\u1EC3u d\u1EEF li\u1EC7u kh\u00E1c nhau")]
	public bool strictTypeMatch; // 0x31

	// Constructors
	public VariableSyncer(); // 0x0000000180857270-0x0000000180857280

	// Methods
	[ContextMenu("\uD83D\uDD04 Sync Variables \u2192 Target")]
	public void SyncToTarget(); // 0x0000000180857140-0x0000000180857180
	[ContextMenu("\uD83D\uDD04 Sync Variables \u2190 Source (\u0111\u1EA3o ng\u01B0\u1EE3c)")]
	public void SyncToSource(); // 0x0000000180857100-0x0000000180857140
	private int SyncFields(MonoBehaviour from, MonoBehaviour to); // 0x0000000180856AC0-0x0000000180857100
	private bool Validate(); // 0x0000000180857180-0x0000000180857270
}

