/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public sealed class DotPool // TypeDefIndex: 2300
{
	// Fields
	private readonly Dictionary<string, Stack<GameObject>> _byTag; // 0x10
	private readonly Transform _root; // 0x18

	// Constructors
	public DotPool(Transform root); // 0x0000000180AF0A10-0x0000000180AF0BF0

	// Methods
	public bool TryGet(string tag, Vector2 worldPos, out GameObject go); // 0x0000000180AF0BF0-0x0000000180AF1080
	public void Release(GameObject go); // 0x0000000180AF1080-0x0000000180AF1510
	public void Clear(); // 0x0000000180AF1510-0x0000000180AF1800
	private static string ResolveTag(GameObject go); // 0x0000000180AF1800-0x0000000180AF1930
	private static void Sanitize(GameObject go); // 0x0000000180AF1930-0x0000000180AF20A0
}

