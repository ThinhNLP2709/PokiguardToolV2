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
	public class VertexZoom : MonoBehaviour // TypeDefIndex: 1833
	{
		// Fields
		public float AngleMultiplier; // 0x20
		public float SpeedMultiplier; // 0x24
		public float CurveScale; // 0x28
		private TMP_Text m_TextComponent; // 0x30
		private bool hasTextChanged; // 0x38
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass10_0 // TypeDefIndex: 1834
		{
			// Fields
			public List<float> modifiedCharScale; // 0x10
			public Comparison<int> __9__0; // 0x18
	
			// Constructors
			public __c__DisplayClass10_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _AnimateVertexColors_b__0(int a, int b); // 0x00000001806127F0-0x0000000180612860
		}
	
		[CompilerGenerated]
		private sealed class _AnimateVertexColors_d__10 : IEnumerator<object> // TypeDefIndex: 1835
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public VertexZoom __4__this; // 0x20
			private __c__DisplayClass10_0 __8__1; // 0x28
			private TMP_TextInfo _textInfo_5__2; // 0x30
			private TMP_MeshInfo[] _cachedMeshInfoVertexData_5__3; // 0x38
			private List<int> _scaleSortingOrder_5__4; // 0x40
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateVertexColors_d__10(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9810-0x00000001802F9870
			private bool MoveNext(); // 0x000000018060B700-0x000000018060C7F0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018060E010-0x000000018060E050
		}
	
		// Constructors
		public VertexZoom(); // 0x0000000180613BF0-0x0000000180613C10
	
		// Methods
		private void Awake(); // 0x0000000180614330-0x0000000180614380
		private void OnEnable(); // 0x00000001806144C0-0x0000000180614590
		private void OnDisable(); // 0x00000001806143F0-0x00000001806144C0
		private void Start(); // 0x0000000180614590-0x0000000180614610
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x0000000180614380-0x00000001806143F0
		[IteratorStateMachine(typeof(_AnimateVertexColors_d__10))]
		private IEnumerator AnimateVertexColors(); // 0x00000001806142C0-0x0000000180614330
	}
}
