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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace TMPro.Examples
{
	public class VertexShakeB : MonoBehaviour // TypeDefIndex: 2508
	{
		// Fields
		public float AngleMultiplier; // 0x20
		public float SpeedMultiplier; // 0x24
		public float CurveScale; // 0x28
		private TMP_Text m_TextComponent; // 0x30
		private bool hasTextChanged; // 0x38
	
		// Nested types
		[CompilerGenerated]
		private sealed class _AnimateVertexColors_d__10 : IEnumerator<object> // TypeDefIndex: 2509
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public VertexShakeB __4__this; // 0x20
			private TMP_TextInfo _textInfo_5__2; // 0x28
			private Vector3[][] _copyOfVertices_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateVertexColors_d__10(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001805EEA90-0x00000001805EEB50
			private bool MoveNext(); // 0x0000000180B96510-0x0000000180B97DF0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180B97DF0-0x0000000180B97E30
		}
	
		// Constructors
		public VertexShakeB(); // 0x0000000180B93B20-0x0000000180B93B80
	
		// Methods
		private void Awake(); // 0x0000000180B960E0-0x0000000180B96170
		private void OnEnable(); // 0x0000000180B96170-0x0000000180B96260
		private void OnDisable(); // 0x0000000180B96260-0x0000000180B96350
		private void Start(); // 0x0000000180B96350-0x0000000180B96400
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x0000000180B96400-0x0000000180B96470
		[IteratorStateMachine(typeof(_AnimateVertexColors_d__10))]
		private IEnumerator AnimateVertexColors(); // 0x0000000180B96470-0x0000000180B96510
	}
}
