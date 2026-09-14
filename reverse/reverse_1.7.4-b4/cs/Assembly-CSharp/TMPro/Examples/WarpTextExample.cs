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
	public class WarpTextExample : MonoBehaviour // TypeDefIndex: 2520
	{
		// Fields
		private TMP_Text m_TextComponent; // 0x20
		public AnimationCurve VertexCurve; // 0x28
		public float AngleMultiplier; // 0x30
		public float SpeedMultiplier; // 0x34
		public float CurveScale; // 0x38
	
		// Nested types
		[CompilerGenerated]
		private sealed class _WarpText_d__8 : IEnumerator<object> // TypeDefIndex: 2521
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public WarpTextExample __4__this; // 0x20
			private float _old_CurveScale_5__2; // 0x28
			private AnimationCurve _old_curve_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _WarpText_d__8(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
			private bool MoveNext(); // 0x0000000180BA7090-0x0000000180BA7DB0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BA7DB0-0x0000000180BA7DF0
		}
	
		// Constructors
		public WarpTextExample(); // 0x0000000180BA6E10-0x0000000180BA7090
	
		// Methods
		private void Awake(); // 0x0000000180BA6B00-0x0000000180BA6BA0
		private void Start(); // 0x0000000180BA6BA0-0x0000000180BA6C50
		private AnimationCurve CopyAnimationCurve(AnimationCurve curve); // 0x0000000180BA6C50-0x0000000180BA6D70
		[IteratorStateMachine(typeof(_WarpText_d__8))]
		private IEnumerator WarpText(); // 0x0000000180BA6D70-0x0000000180BA6E10
	}
}
