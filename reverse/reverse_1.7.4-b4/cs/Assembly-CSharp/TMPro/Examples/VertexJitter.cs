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
	public class VertexJitter : MonoBehaviour // TypeDefIndex: 2510
	{
		// Fields
		public float AngleMultiplier; // 0x20
		public float SpeedMultiplier; // 0x24
		public float CurveScale; // 0x28
		private TMP_Text m_TextComponent; // 0x30
		private bool hasTextChanged; // 0x38
	
		// Nested types
		private struct VertexAnim // TypeDefIndex: 2511
		{
			// Fields
			public float angleRange; // 0x00
			public float angle; // 0x04
			public float speed; // 0x08
		}
	
		[CompilerGenerated]
		private sealed class _AnimateVertexColors_d__11 : IEnumerator<object> // TypeDefIndex: 2512
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateVertexColors_d__11(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180930A50-0x0000000180930B60
			private bool MoveNext(); // 0x0000000180BA0DD0-0x0000000180BA1DC0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BA1DC0-0x0000000180BA1E00
		}
	
		// Constructors
		public VertexJitter(); // 0x0000000180BA0D70-0x0000000180BA0DD0
	
		// Methods
		private void Awake(); // 0x0000000180BA0870-0x0000000180BA0900
		private void OnEnable(); // 0x0000000180BA0900-0x0000000180BA09F0
		private void OnDisable(); // 0x0000000180BA09F0-0x0000000180BA0AE0
		private void Start(); // 0x0000000180BA0AE0-0x0000000180BA0B90
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x0000000180BA0B90-0x0000000180BA0CD0
		[IteratorStateMachine(typeof(_AnimateVertexColors_d__11))]
		private IEnumerator AnimateVertexColors(); // 0x0000000180BA0CD0-0x0000000180BA0D70
	}
}
