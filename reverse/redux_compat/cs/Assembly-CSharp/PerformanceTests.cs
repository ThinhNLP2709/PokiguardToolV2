/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DentedPixel;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class PerformanceTests : MonoBehaviour // TypeDefIndex: 311
{
	// Fields
	public bool debug; // 0x20
	public GameObject bulletPrefab; // 0x28
	private LeanPool bulletPool; // 0x30
	private Dictionary<GameObject, int> animIds; // 0x38
	public float shipSpeed; // 0x40
	private float shipDirectionX; // 0x44

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass7_0 // TypeDefIndex: 312
	{
		// Fields
		public GameObject go; // 0x10
		public PerformanceTests __4__this; // 0x18

		// Constructors
		public __c__DisplayClass7_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Update_b__0(); // 0x00000001806FFC50-0x00000001806FFC80
	}

	// Constructors
	public PerformanceTests(); // 0x00000001806FBFD0-0x00000001806FC090

	// Methods
	private void Start(); // 0x00000001806FB9D0-0x00000001806FBAA0
	private void Update(); // 0x00000001806FBAA0-0x00000001806FBFD0
}

