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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class EnvMapAnimator : MonoBehaviour // TypeDefIndex: 1773
{
	// Fields
	public Vector3 RotationSpeeds; // 0x20
	private TMP_Text m_textMeshPro; // 0x30
	private Material m_material; // 0x38

	// Nested types
	[CompilerGenerated]
	private sealed class _Start_d__4 : IEnumerator<object> // TypeDefIndex: 1774
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public EnvMapAnimator __4__this; // 0x20
		private Matrix4x4 _matrix_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Start_d__4(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805FDD70-0x00000001805FDFB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805FDFB0-0x00000001805FDFF0
	}

	// Constructors
	public EnvMapAnimator(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x00000001805ECF90-0x00000001805ED010
	[IteratorStateMachine(typeof(_Start_d__4))]
	private IEnumerator Start(); // 0x00000001805ED010-0x00000001805ED080
}

