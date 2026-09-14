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
	public class VertexJitter : MonoBehaviour // TypeDefIndex: 2503
	{
		// Fields
		public float AngleMultiplier; // 0x20
		public float SpeedMultiplier; // 0x24
		public float CurveScale; // 0x28
		private TMP_Text m_TextComponent; // 0x30
		private bool hasTextChanged; // 0x38
	
		// Nested types
		private struct VertexAnim // TypeDefIndex: 2504
		{
			// Fields
			public float angleRange; // 0x00
			public float angle; // 0x04
			public float speed; // 0x08
		}
	
		[CompilerGenerated]
		private sealed class _AnimateVertexColors_d__11 : IEnumerator<object> // TypeDefIndex: 2505
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
			void IDisposable.Dispose(); // 0x000000018092D510-0x000000018092D620
			private bool MoveNext(); // 0x0000000180B93B80-0x0000000180B94B70
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180B94B70-0x0000000180B94BB0
		}
	
		// Constructors
		public VertexJitter(); // 0x0000000180B93B20-0x0000000180B93B80
	
		// Methods
		private void Awake(); // 0x0000000180B93620-0x0000000180B936B0
		private void OnEnable(); // 0x0000000180B936B0-0x0000000180B937A0
		private void OnDisable(); // 0x0000000180B937A0-0x0000000180B93890
		private void Start(); // 0x0000000180B93890-0x0000000180B93940
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x0000000180B93940-0x0000000180B93A80
		[IteratorStateMachine(typeof(_AnimateVertexColors_d__11))]
		private IEnumerator AnimateVertexColors(); // 0x0000000180B93A80-0x0000000180B93B20
	}
}
