/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace TMPro.Examples
{
	public class ShaderPropAnimator : MonoBehaviour // TypeDefIndex: 2077
	{
		// Fields
		private Renderer m_Renderer; // 0x20
		private Material m_Material; // 0x28
		public AnimationCurve GlowCurve; // 0x30
		public float m_frame; // 0x38
	
		// Nested types
		[CompilerGenerated]
		private sealed class _AnimateProperties_d__6 : IEnumerator<object> // TypeDefIndex: 2078
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ShaderPropAnimator __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateProperties_d__6(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x0000000180731C60-0x0000000180731DE0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180731DE0-0x0000000180731E20
		}
	
		// Constructors
		public ShaderPropAnimator(); // 0x00000001802EBA70-0x00000001802EBAF0
	
		// Methods
		private void Awake(); // 0x0000000180729960-0x00000001807299D0
		private void Start(); // 0x00000001807299D0-0x0000000180729A50
		[IteratorStateMachine(typeof(_AnimateProperties_d__6))]
		private IEnumerator AnimateProperties(); // 0x00000001807298F0-0x0000000180729960
	}
}
