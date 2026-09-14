/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DentedPixel;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class PerformanceTests : MonoBehaviour // TypeDefIndex: 334
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
	private sealed class __c__DisplayClass7_0 // TypeDefIndex: 335
	{
		// Fields
		public GameObject go; // 0x10
		public PerformanceTests __4__this; // 0x18

		// Constructors
		public __c__DisplayClass7_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Update_b__0(); // 0x00000001802FE260-0x00000001802FE340
	}

	// Constructors
	public PerformanceTests(); // 0x00000001802FE0C0-0x00000001802FE260

	// Methods
	private void Start(); // 0x00000001802FD500-0x00000001802FD5E0
	private void Update(); // 0x00000001802FD5E0-0x00000001802FE0C0
}

