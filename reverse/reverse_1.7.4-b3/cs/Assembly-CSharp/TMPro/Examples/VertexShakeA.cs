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
	public class VertexShakeA : MonoBehaviour // TypeDefIndex: 2506
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
		private sealed class _AnimateVertexColors_d__11 : IEnumerator<object> // TypeDefIndex: 2507
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public VertexShakeA __4__this; // 0x20
			private TMP_TextInfo _textInfo_5__2; // 0x28
			private Vector3[][] _copyOfVertices_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateVertexColors_d__11(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001805EEA90-0x00000001805EEB50
			private bool MoveNext(); // 0x0000000180B95050-0x0000000180B960A0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180B960A0-0x0000000180B960E0
		}
	
		// Constructors
		public VertexShakeA(); // 0x0000000180B94FE0-0x0000000180B95050
	
		// Methods
		private void Awake(); // 0x0000000180B94BB0-0x0000000180B94C40
		private void OnEnable(); // 0x0000000180B94C40-0x0000000180B94D30
		private void OnDisable(); // 0x0000000180B94D30-0x0000000180B94E20
		private void Start(); // 0x0000000180B94E20-0x0000000180B94ED0
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x0000000180B94ED0-0x0000000180B94F40
		[IteratorStateMachine(typeof(_AnimateVertexColors_d__11))]
		private IEnumerator AnimateVertexColors(); // 0x0000000180B94F40-0x0000000180B94FE0
	}
}
