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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class EnvMapAnimator : MonoBehaviour // TypeDefIndex: 2054
{
	// Fields
	public Vector3 RotationSpeeds; // 0x20
	private TMP_Text m_textMeshPro; // 0x30
	private Material m_material; // 0x38

	// Nested types
	[CompilerGenerated]
	private sealed class _Start_d__4 : IEnumerator<object> // TypeDefIndex: 2055
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnvMapAnimator __4__this; // 0x20
		private Matrix4x4 _matrix_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Start_d__4(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001807265A0-0x00000001807267E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807267E0-0x0000000180726820
	}

	// Constructors
	public EnvMapAnimator(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x0000000180714520-0x00000001807145A0
	[IteratorStateMachine(typeof(_Start_d__4))]
	private IEnumerator Start(); // 0x00000001807145A0-0x0000000180714610
}

