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
	public class VertexJitter : MonoBehaviour // TypeDefIndex: 2105
	{
		// Fields
		public float AngleMultiplier; // 0x20
		public float SpeedMultiplier; // 0x24
		public float CurveScale; // 0x28
		private TMP_Text m_TextComponent; // 0x30
		private bool hasTextChanged; // 0x38
	
		// Nested types
		private struct VertexAnim // TypeDefIndex: 2106
		{
			// Fields
			public float angleRange; // 0x00
			public float angle; // 0x04
			public float speed; // 0x08
		}
	
		[CompilerGenerated]
		private sealed class _AnimateVertexColors_d__11 : IEnumerator<object> // TypeDefIndex: 2107
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public VertexJitter __4__this; // 0x20
			private TMP_TextInfo _textInfo_5__2; // 0x28
			private int _loopCount_5__3; // 0x30
			private VertexAnim[] _vertexAnim_5__4; // 0x38
			private TMP_MeshInfo[] _cachedMeshInfo_5__5; // 0x40
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateVertexColors_d__11(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001806073C0-0x0000000180607410
			private bool MoveNext(); // 0x00000001807356F0-0x00000001807364F0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807364F0-0x0000000180736530
		}
	
		// Constructors
		public VertexJitter(); // 0x0000000180739B50-0x0000000180739B70
	
		// Methods
		private void Awake(); // 0x0000000180739870-0x00000001807398C0
		private void OnEnable(); // 0x0000000180739A00-0x0000000180739AD0
		private void OnDisable(); // 0x0000000180739930-0x0000000180739A00
		private void Start(); // 0x0000000180739AD0-0x0000000180739B50
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x00000001807398C0-0x0000000180739930
		[IteratorStateMachine(typeof(_AnimateVertexColors_d__11))]
		private IEnumerator AnimateVertexColors(); // 0x0000000180739800-0x0000000180739870
	}
}
