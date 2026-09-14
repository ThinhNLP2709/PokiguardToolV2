/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace TMPro.Examples
{
	public class ShaderPropAnimator : MonoBehaviour // TypeDefIndex: 2475
	{
		// Fields
		private Renderer m_Renderer; // 0x20
		private Material m_Material; // 0x28
		public AnimationCurve GlowCurve; // 0x30
		public float m_frame; // 0x38
	
		// Nested types
		[CompilerGenerated]
		private sealed class _AnimateProperties_d__6 : IEnumerator<object> // TypeDefIndex: 2476
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ShaderPropAnimator __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateProperties_d__6(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180B85AA0-0x0000000180B85D60
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180B85D60-0x0000000180B85DA0
		}
	
		// Constructors
		public ShaderPropAnimator(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void Awake(); // 0x0000000180B85840-0x0000000180B85950
		private void Start(); // 0x0000000180B85950-0x0000000180B85A00
		[IteratorStateMachine(typeof(_AnimateProperties_d__6))]
		private IEnumerator AnimateProperties(); // 0x0000000180B85A00-0x0000000180B85AA0
	}
}
