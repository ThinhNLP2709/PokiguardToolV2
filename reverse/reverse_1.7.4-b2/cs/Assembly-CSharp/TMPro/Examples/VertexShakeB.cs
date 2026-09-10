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
	public class VertexShakeB : MonoBehaviour // TypeDefIndex: 2110
	{
		// Fields
		public float AngleMultiplier; // 0x20
		public float SpeedMultiplier; // 0x24
		public float CurveScale; // 0x28
		private TMP_Text m_TextComponent; // 0x30
		private bool hasTextChanged; // 0x38
	
		// Nested types
		[CompilerGenerated]
		private sealed class _AnimateVertexColors_d__10 : IEnumerator<object> // TypeDefIndex: 2111
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public VertexShakeB __4__this; // 0x20
			private TMP_TextInfo _textInfo_5__2; // 0x28
			private Vector3[][] _copyOfVertices_5__3; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _AnimateVertexColors_d__10(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001804AC800-0x00000001804AC840
			private bool MoveNext(); // 0x0000000180732F10-0x00000001807346F0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807346F0-0x0000000180734730
		}
	
		// Constructors
		public VertexShakeB(); // 0x0000000180739B50-0x0000000180739B70
	
		// Methods
		private void Awake(); // 0x0000000180739F50-0x0000000180739FA0
		private void OnEnable(); // 0x000000018073A0D0-0x000000018073A1A0
		private void OnDisable(); // 0x000000018073A000-0x000000018073A0D0
		private void Start(); // 0x000000018073A1A0-0x000000018073A220
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x0000000180739FA0-0x000000018073A000
		[IteratorStateMachine(typeof(_AnimateVertexColors_d__10))]
		private IEnumerator AnimateVertexColors(); // 0x0000000180739EE0-0x0000000180739F50
	}
}
