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
public class HomeNotifyBadge : MonoBehaviour // TypeDefIndex: 615
{
	// Fields
	[Tooltip("Ch\u1EEF s\u1ED1 trong ch\u1EA5m \u0111\u1ECF. B\u1ECF tr\u1ED1ng = ch\u1EC9 hi\u1EC7n ch\u1EA5m, kh\u00F4ng hi\u1EC7n s\u1ED1.")]
	public UnityEngine.UI.Text countText; // 0x20
	[Tooltip("Tr\u00EAn ng\u01B0\u1EE1ng n\u00E0y th\u00EC hi\u1EC7n d\u1EA1ng 99+ cho kh\u1ECFi tr\u00E0n kh\u1ECFi ch\u1EA5m.")]
	public int maxDisplay; // 0x28
	private int _count; // 0x2C

	// Properties
	public int Count { get; } // 0x00000001803B5DE0-0x00000001803B5DF0 

	// Constructors
	public HomeNotifyBadge(); // 0x00000001803B5DC0-0x00000001803B5DE0

	// Methods
	private void OnDisable(); // 0x00000001803B5720-0x00000001803B57D0
	public void SetCount(int count); // 0x00000001803B5970-0x00000001803B5C90
	private void PopIn(); // 0x00000001803B57D0-0x00000001803B5970
	[CompilerGenerated]
	private void _PopIn_b__7_0(); // 0x00000001803B5C90-0x00000001803B5DC0
}

