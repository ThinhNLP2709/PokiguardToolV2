/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GeneralCameraShake : MonoBehaviour // TypeDefIndex: 277
{
	// Fields
	private GameObject avatarBig; // 0x20
	private float jumpIter; // 0x28
	private AudioClip boomAudioClip; // 0x30

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass4_0 // TypeDefIndex: 278
	{
		// Fields
		public GeneralCameraShake __4__this; // 0x10
		public float height; // 0x18
		public Action __9__1; // 0x20

		// Constructors
		public __c__DisplayClass4_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _bigGuyJump_b__0(); // 0x0000000180D74870-0x0000000180D749C0
		internal void _bigGuyJump_b__1(); // 0x0000000180D749C0-0x0000000180D75340
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass4_1 // TypeDefIndex: 279
	{
		// Fields
		public LTDescr shakeTween; // 0x10

		// Constructors
		public __c__DisplayClass4_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _bigGuyJump_b__2(float val); // 0x0000000180D75340-0x0000000180D753C0
	}

	// Constructors
	public GeneralCameraShake(); // 0x0000000180D74820-0x0000000180D74870

	// Methods
	private void Start(); // 0x0000000180D74160-0x0000000180D74630
	private void bigGuyJump(); // 0x0000000180D74630-0x0000000180D74820
}

