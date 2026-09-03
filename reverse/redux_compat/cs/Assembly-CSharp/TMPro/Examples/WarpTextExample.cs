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
	public class WarpTextExample : MonoBehaviour // TypeDefIndex: 1836
	{
		// Fields
		private TMP_Text m_TextComponent; // 0x20
		public AnimationCurve VertexCurve; // 0x28
		public float AngleMultiplier; // 0x30
		public float SpeedMultiplier; // 0x34
		public float CurveScale; // 0x38
	
		// Nested types
		[CompilerGenerated]
		private sealed class _WarpText_d__8 : IEnumerator<object> // TypeDefIndex: 1837
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public WarpTextExample __4__this; // 0x20
			private float _old_CurveScale_5__2; // 0x28
			private AnimationCurve _old_curve_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _WarpText_d__8(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
			private bool MoveNext(); // 0x0000000180612A90-0x0000000180613720
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180613720-0x0000000180613760
		}
	
		// Constructors
		public WarpTextExample(); // 0x00000001806147E0-0x0000000180614AC0
	
		// Methods
		private void Awake(); // 0x0000000180614610-0x0000000180614670
		private void Start(); // 0x00000001806146F0-0x0000000180614770
		private AnimationCurve CopyAnimationCurve(AnimationCurve curve); // 0x0000000180614670-0x00000001806146F0
		[IteratorStateMachine(typeof(_WarpText_d__8))]
		private IEnumerator WarpText(); // 0x0000000180614770-0x00000001806147E0
	}
}
