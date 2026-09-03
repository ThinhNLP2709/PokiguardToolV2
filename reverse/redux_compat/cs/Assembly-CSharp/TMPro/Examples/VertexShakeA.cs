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
	public class VertexShakeA : MonoBehaviour // TypeDefIndex: 1829
	{
		// Fields
		public float AngleMultiplier; // 0x20
		public float SpeedMultiplier; // 0x24
		public float ScaleMultiplier; // 0x28
		public float RotationMultiplier; // 0x2C
		private TMP_Text m_TextComponent; // 0x30
		private bool hasTextChanged; // 0x38
	
		// Nested types
		[CompilerGenerated]
		private sealed class _AnimateVertexColors_d__11 : IEnumerator<object> // TypeDefIndex: 1830
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public VertexShakeA __4__this; // 0x20
			private TMP_TextInfo _textInfo_5__2; // 0x28
			private Vector3[][] _copyOfVertices_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateVertexColors_d__11(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001803BE650-0x00000001803BE690
			private bool MoveNext(); // 0x000000018060E050-0x000000018060EFD0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018060FE10-0x000000018060FE50
		}
	
		// Constructors
		public VertexShakeA(); // 0x0000000180613F50-0x0000000180613F80
	
		// Methods
		private void Awake(); // 0x0000000180613C80-0x0000000180613CD0
		private void OnEnable(); // 0x0000000180613E00-0x0000000180613ED0
		private void OnDisable(); // 0x0000000180613D30-0x0000000180613E00
		private void Start(); // 0x0000000180613ED0-0x0000000180613F50
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x0000000180613CD0-0x0000000180613D30
		[IteratorStateMachine(typeof(_AnimateVertexColors_d__11))]
		private IEnumerator AnimateVertexColors(); // 0x0000000180613C10-0x0000000180613C80
	}
}
