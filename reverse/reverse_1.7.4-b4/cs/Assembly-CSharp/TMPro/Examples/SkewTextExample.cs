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

namespace TMPro.Examples
{
	public class SkewTextExample : MonoBehaviour // TypeDefIndex: 2485
	{
		// Fields
		private TMP_Text m_TextComponent; // 0x20
		public AnimationCurve VertexCurve; // 0x28
		public float CurveScale; // 0x30
		public float ShearAmount; // 0x34
	
		// Nested types
		[CompilerGenerated]
		private sealed class _WarpText_d__7 : IEnumerator<object> // TypeDefIndex: 2486
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public SkewTextExample __4__this; // 0x20
			private float _old_CurveScale_5__2; // 0x28
			private float _old_ShearValue_5__3; // 0x2C
			private AnimationCurve _old_curve_5__4; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _WarpText_d__7(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
			private bool MoveNext(); // 0x0000000180B93A30-0x0000000180B948B0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180B948B0-0x0000000180B948F0
		}
	
		// Constructors
		public SkewTextExample(); // 0x0000000180B937B0-0x0000000180B93A30
	
		// Methods
		private void Awake(); // 0x0000000180B934A0-0x0000000180B93540
		private void Start(); // 0x0000000180B93540-0x0000000180B935F0
		private AnimationCurve CopyAnimationCurve(AnimationCurve curve); // 0x0000000180B935F0-0x0000000180B93710
		[IteratorStateMachine(typeof(_WarpText_d__7))]
		private IEnumerator WarpText(); // 0x0000000180B93710-0x0000000180B937B0
	}
}
