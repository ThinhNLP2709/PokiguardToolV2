/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public sealed class DotPool // TypeDefIndex: 2293
{
	// Fields
	private readonly Dictionary<string, Stack<GameObject>> _byTag; // 0x10
	private readonly Transform _root; // 0x18

	// Constructors
	public DotPool(Transform root); // 0x0000000180AE37A0-0x0000000180AE3980

	// Methods
	public bool TryGet(string tag, Vector2 worldPos, out GameObject go); // 0x0000000180AE3980-0x0000000180AE3E10
	public void Release(GameObject go); // 0x0000000180AE3E10-0x0000000180AE42A0
	public void Clear(); // 0x0000000180AE42A0-0x0000000180AE4590
	private static string ResolveTag(GameObject go); // 0x0000000180AE4590-0x0000000180AE46C0
	private static void Sanitize(GameObject go); // 0x0000000180AE46C0-0x0000000180AE4E30
}

