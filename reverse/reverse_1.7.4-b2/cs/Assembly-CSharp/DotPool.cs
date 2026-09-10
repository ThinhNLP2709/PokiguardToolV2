/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public sealed class DotPool // TypeDefIndex: 1927
{
	// Fields
	public const int CapPerTag = 96; // Metadata: 0x0068DC51
	private readonly Dictionary<string, Stack<GameObject>> _byTag; // 0x10
	private readonly Transform _root; // 0x18

	// Properties
	public int Count { get; } // 0x00000001806EA670-0x00000001806EA780 

	// Constructors
	public DotPool(Transform root); // 0x00000001806EA550-0x00000001806EA670

	// Methods
	public int CountOf(string tag); // 0x00000001806E9D00-0x00000001806E9D90
	public bool TryGet(string tag, Vector2 worldPos, out GameObject go); // 0x00000001806EA320-0x00000001806EA550
	public void Release(GameObject go); // 0x00000001806E9D90-0x00000001806E9FE0
	public void Clear(); // 0x00000001806E9B50-0x00000001806E9D00
	private static string ResolveTag(GameObject go); // 0x00000001806E9FE0-0x00000001806EA0A0
	private static void Sanitize(GameObject go); // 0x00000001806EA0A0-0x00000001806EA320
}

