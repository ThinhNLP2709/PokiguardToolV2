/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace TMPro.Examples
{
	public class ShaderPropAnimator : MonoBehaviour // TypeDefIndex: 1798
	{
		// Fields
		private Renderer m_Renderer; // 0x20
		private Material m_Material; // 0x28
		public AnimationCurve GlowCurve; // 0x30
		public float m_frame; // 0x38
	
		// Nested types
		[CompilerGenerated]
		private sealed class _AnimateProperties_d__6 : IEnumerator<object> // TypeDefIndex: 1799
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ShaderPropAnimator __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateProperties_d__6(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x00000001805FBB00-0x00000001805FBC80
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001805FBC80-0x00000001805FBCC0
		}
	
		// Constructors
		public ShaderPropAnimator(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void Awake(); // 0x00000001805F6050-0x00000001805F60C0
		private void Start(); // 0x00000001805F60C0-0x00000001805F6140
		[IteratorStateMachine(typeof(_AnimateProperties_d__6))]
		private IEnumerator AnimateProperties(); // 0x00000001805F5FE0-0x00000001805F6050
	}
}
