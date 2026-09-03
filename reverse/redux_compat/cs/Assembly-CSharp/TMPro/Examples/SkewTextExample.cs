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

namespace TMPro.Examples
{
	public class SkewTextExample : MonoBehaviour // TypeDefIndex: 1801
	{
		// Fields
		private TMP_Text m_TextComponent; // 0x20
		public AnimationCurve VertexCurve; // 0x28
		public float CurveScale; // 0x30
		public float ShearAmount; // 0x34
	
		// Nested types
		[CompilerGenerated]
		private sealed class _WarpText_d__7 : IEnumerator<object> // TypeDefIndex: 1802
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public SkewTextExample __4__this; // 0x20
			private float _old_CurveScale_5__2; // 0x28
			private float _old_ShearValue_5__3; // 0x2C
			private AnimationCurve _old_curve_5__4; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _WarpText_d__7(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
			private bool MoveNext(); // 0x00000001805FE9F0-0x00000001805FF7C0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001805FF7C0-0x00000001805FF800
		}
	
		// Constructors
		public SkewTextExample(); // 0x00000001805F6460-0x00000001805F66C0
	
		// Methods
		private void Awake(); // 0x00000001805F6290-0x00000001805F62F0
		private void Start(); // 0x00000001805F6370-0x00000001805F63F0
		private AnimationCurve CopyAnimationCurve(AnimationCurve curve); // 0x00000001805F62F0-0x00000001805F6370
		[IteratorStateMachine(typeof(_WarpText_d__7))]
		private IEnumerator WarpText(); // 0x00000001805F63F0-0x00000001805F6460
	}
}
