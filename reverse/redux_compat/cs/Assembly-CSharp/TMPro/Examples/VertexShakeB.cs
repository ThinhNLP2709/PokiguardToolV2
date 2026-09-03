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
	public class VertexShakeB : MonoBehaviour // TypeDefIndex: 1831
	{
		// Fields
		public float AngleMultiplier; // 0x20
		public float SpeedMultiplier; // 0x24
		public float CurveScale; // 0x28
		private TMP_Text m_TextComponent; // 0x30
		private bool hasTextChanged; // 0x38
	
		// Nested types
		[CompilerGenerated]
		private sealed class _AnimateVertexColors_d__10 : IEnumerator<object> // TypeDefIndex: 1832
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public VertexShakeB __4__this; // 0x20
			private TMP_TextInfo _textInfo_5__2; // 0x28
			private Vector3[][] _copyOfVertices_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateVertexColors_d__10(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001803BE650-0x00000001803BE690
			private bool MoveNext(); // 0x000000018060C7F0-0x000000018060DFD0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018060DFD0-0x000000018060E010
		}
	
		// Constructors
		public VertexShakeB(); // 0x0000000180613BF0-0x0000000180613C10
	
		// Methods
		private void Awake(); // 0x0000000180613FF0-0x0000000180614040
		private void OnEnable(); // 0x0000000180614170-0x0000000180614240
		private void OnDisable(); // 0x00000001806140A0-0x0000000180614170
		private void Start(); // 0x0000000180614240-0x00000001806142C0
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x0000000180614040-0x00000001806140A0
		[IteratorStateMachine(typeof(_AnimateVertexColors_d__10))]
		private IEnumerator AnimateVertexColors(); // 0x0000000180613F80-0x0000000180613FF0
	}
}
