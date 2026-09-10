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

namespace TMPro.Examples
{
	public class SkewTextExample : MonoBehaviour // TypeDefIndex: 2080
	{
		// Fields
		private TMP_Text m_TextComponent; // 0x20
		public AnimationCurve VertexCurve; // 0x28
		public float CurveScale; // 0x30
		public float ShearAmount; // 0x34
	
		// Nested types
		[CompilerGenerated]
		private sealed class _WarpText_d__7 : IEnumerator<object> // TypeDefIndex: 2081
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public SkewTextExample __4__this; // 0x20
			private float _old_CurveScale_5__2; // 0x28
			private float _old_ShearValue_5__3; // 0x2C
			private AnimationCurve _old_curve_5__4; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _WarpText_d__7(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
			private bool MoveNext(); // 0x0000000180737BE0-0x00000001807389B0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807389B0-0x00000001807389F0
		}
	
		// Constructors
		public SkewTextExample(); // 0x0000000180729D70-0x0000000180729FD0
	
		// Methods
		private void Awake(); // 0x0000000180729BA0-0x0000000180729C00
		private void Start(); // 0x0000000180729C80-0x0000000180729D00
		private AnimationCurve CopyAnimationCurve(AnimationCurve curve); // 0x0000000180729C00-0x0000000180729C80
		[IteratorStateMachine(typeof(_WarpText_d__7))]
		private IEnumerator WarpText(); // 0x0000000180729D00-0x0000000180729D70
	}
}
