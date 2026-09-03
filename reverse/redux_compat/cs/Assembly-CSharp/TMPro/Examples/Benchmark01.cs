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
	public class Benchmark01 : MonoBehaviour // TypeDefIndex: 1786
	{
		// Fields
		public int BenchmarkType; // 0x20
		public TMP_FontAsset TMProFont; // 0x28
		public Font TextMeshFont; // 0x30
		private TextMeshPro m_textMeshPro; // 0x38
		private TextContainer m_textContainer; // 0x40
		private TextMesh m_textMesh; // 0x48
		private const string label01 = "The <#0050FF>count is: </color>{0}"; // Metadata: 0x0064DA46
		private const string label02 = "The <color=#0050FF>count is: </color>"; // Metadata: 0x0064DA69
		private Material m_material01; // 0x50
		private Material m_material02; // 0x58
	
		// Nested types
		[CompilerGenerated]
		private sealed class _Start_d__10 : IEnumerator<object> // TypeDefIndex: 1787
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public Benchmark01 __4__this; // 0x20
			private int _i_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _Start_d__10(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x00000001805FD280-0x00000001805FD830
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001805FDCF0-0x00000001805FDD30
		}
	
		// Constructors
		public Benchmark01(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		[IteratorStateMachine(typeof(_Start_d__10))]
		private IEnumerator Start(); // 0x00000001805EA140-0x00000001805EA1B0
	}
}
