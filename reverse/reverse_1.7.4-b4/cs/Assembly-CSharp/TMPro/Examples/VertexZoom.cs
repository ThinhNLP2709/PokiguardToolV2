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
	public class VertexZoom : MonoBehaviour // TypeDefIndex: 2517
	{
		// Fields
		public float AngleMultiplier; // 0x20
		public float SpeedMultiplier; // 0x24
		public float CurveScale; // 0x28
		private TMP_Text m_TextComponent; // 0x30
		private bool hasTextChanged; // 0x38
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass10_0 // TypeDefIndex: 2518
		{
			// Fields
			public List<float> modifiedCharScale; // 0x10
			public Comparison<int> __9__0; // 0x18
	
			// Constructors
			public __c__DisplayClass10_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal int _AnimateVertexColors_b__0(int a, int b); // 0x0000000180BA5750-0x0000000180BA5830
		}
	
		[CompilerGenerated]
		private sealed class _AnimateVertexColors_d__10 : IEnumerator<object> // TypeDefIndex: 2519
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateVertexColors_d__10(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B99A0-0x00000001802B9B00
			private bool MoveNext(); // 0x0000000180BA5830-0x0000000180BA6AC0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BA6AC0-0x0000000180BA6B00
		}
	
		// Constructors
		public VertexZoom(); // 0x0000000180BA0D70-0x0000000180BA0DD0
	
		// Methods
		private void Awake(); // 0x0000000180BA5250-0x0000000180BA52E0
		private void OnEnable(); // 0x0000000180BA52E0-0x0000000180BA53D0
		private void OnDisable(); // 0x0000000180BA53D0-0x0000000180BA54C0
		private void Start(); // 0x0000000180BA54C0-0x0000000180BA5570
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x0000000180BA5570-0x0000000180BA56B0
		[IteratorStateMachine(typeof(_AnimateVertexColors_d__10))]
		private IEnumerator AnimateVertexColors(); // 0x0000000180BA56B0-0x0000000180BA5750
	}
}
