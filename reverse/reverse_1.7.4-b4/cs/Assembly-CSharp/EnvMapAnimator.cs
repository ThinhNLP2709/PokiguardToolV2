/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class EnvMapAnimator : MonoBehaviour // TypeDefIndex: 2459
{
	// Fields
	public Vector3 RotationSpeeds; // 0x20
	private TMP_Text m_textMeshPro; // 0x30
	private Material m_material; // 0x38

	// Nested types
	[CompilerGenerated]
	private sealed class _Start_d__4 : IEnumerator<object> // TypeDefIndex: 2460
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnvMapAnimator __4__this; // 0x20
		private Matrix4x4 _matrix_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Start_d__4(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B8B220-0x0000000180B8B680
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B8B680-0x0000000180B8B6C0
	}

	// Constructors
	public EnvMapAnimator(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180B8B060-0x0000000180B8B180
	[IteratorStateMachine(typeof(_Start_d__4))]
	private IEnumerator Start(); // 0x0000000180B8B180-0x0000000180B8B220
}

