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
	public class VertexZoom : MonoBehaviour // TypeDefIndex: 2112
	{
		// Fields
		public float AngleMultiplier; // 0x20
		public float SpeedMultiplier; // 0x24
		public float CurveScale; // 0x28
		private TMP_Text m_TextComponent; // 0x30
		private bool hasTextChanged; // 0x38
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass10_0 // TypeDefIndex: 2113
		{
			// Fields
			public List<float> modifiedCharScale; // 0x10
			public Comparison<int> __9__0; // 0x18
	
			// Constructors
			public __c__DisplayClass10_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal int _AnimateVertexColors_b__0(int a, int b); // 0x0000000180737B70-0x0000000180737BE0
		}
	
		[CompilerGenerated]
		private sealed class _AnimateVertexColors_d__10 : IEnumerator<object> // TypeDefIndex: 2114
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateVertexColors_d__10(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001803151D0-0x0000000180315230
			private bool MoveNext(); // 0x0000000180731E20-0x0000000180732F10
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180734730-0x0000000180734770
		}
	
		// Constructors
		public VertexZoom(); // 0x0000000180739B50-0x0000000180739B70
	
		// Methods
		private void Awake(); // 0x000000018073A290-0x000000018073A2E0
		private void OnEnable(); // 0x000000018073A420-0x000000018073A4F0
		private void OnDisable(); // 0x000000018073A350-0x000000018073A420
		private void Start(); // 0x000000018073A4F0-0x000000018073A570
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x000000018073A2E0-0x000000018073A350
		[IteratorStateMachine(typeof(_AnimateVertexColors_d__10))]
		private IEnumerator AnimateVertexColors(); // 0x000000018073A220-0x000000018073A290
	}
}
