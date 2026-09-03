/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class GeneralCameraShake : MonoBehaviour // TypeDefIndex: 251
{
	// Fields
	private GameObject avatarBig; // 0x20
	private float jumpIter; // 0x28
	private AudioClip boomAudioClip; // 0x30

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass4_0 // TypeDefIndex: 252
	{
		// Fields
		public GeneralCameraShake __4__this; // 0x10
		public float height; // 0x18
		public Action __9__1; // 0x20

		// Constructors
		public __c__DisplayClass4_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _bigGuyJump_b__0(); // 0x00000001806CA110-0x00000001806CA230
		internal void _bigGuyJump_b__1(); // 0x00000001806CA230-0x00000001806CA770
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass4_1 // TypeDefIndex: 253
	{
		// Fields
		public LTDescr shakeTween; // 0x10

		// Constructors
		public __c__DisplayClass4_1(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _bigGuyJump_b__2(float val); // 0x00000001806CAA70-0x00000001806CAAF0
	}

	// Constructors
	public GeneralCameraShake(); // 0x00000001806ADE50-0x00000001806ADE60

	// Methods
	private void Start(); // 0x00000001806AD900-0x00000001806ADE50
	private void bigGuyJump(); // 0x00000001806ADE60-0x00000001806ADFF0
}

